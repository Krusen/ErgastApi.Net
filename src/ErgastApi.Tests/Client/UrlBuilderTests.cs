using System;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using ErgastApi.Client;
using ErgastApi.Client.Attributes;
using ErgastApi.Requests;
using ErgastApi.Responses;
using FluentAssertions;
using Xunit;

namespace ErgastApi.Tests.Client
{
    public class UrlBuilderTests
    {
        private UrlBuilder UrlBuilder { get; }

        public UrlBuilderTests()
        {
            UrlBuilder = new UrlBuilder();
        }

        [Fact]
        public void AddsJsonExtension()
        {
            var request = new MockRequest();
            var url = UrlBuilder.Build(request);
            url.Split('?')[0].Should().EndWith(".json");
        }

        [Fact]
        public void Limit_PrefixedWithQuestionMark()
        {
            var request = new MockRequest { Limit = 10 };
            var url = UrlBuilder.Build(request);
            url.Should().Contain("?limit=");
        }

        [Fact]
        public void Limit_IsAddedIfNotNull()
        {
            var request = new MockRequest { Limit = 10 };
            var url = UrlBuilder.Build(request);
            url.Should().Contain("limit=10");
        }

        [Fact]
        public void Limit_IsNotAddedIfNull()
        {
            var request = new MockRequest { Limit = null };
            var url = UrlBuilder.Build(request);
            url.Should().NotContain("limit");
        }

        [Fact]
        public void Offset_IsAddedIfNotNull()
        {
            var request = new MockRequest { Offset = 10 };
            var url = UrlBuilder.Build(request);
            url.Should().Contain("offset=10");
        }

        [Fact]
        public void Offset_IsNotAddedIfNull()
        {
            var request = new MockRequest { Offset = null };
            var url = UrlBuilder.Build(request);
            url.Should().NotContain("offset");
        }

        [Fact]
        public void Offset_PrefixedWithAmpersandIfLimitIsNull()
        {
            var request = new MockRequest { Offset = 10, Limit = null };
            var url = UrlBuilder.Build(request);
            url.Should().Contain("?offset=");
        }

        [Fact]
        public void Offset_PrefixedWithQuestionMarkIfLimitIsNull()
        {
            var request = new MockRequest { Offset = 10, Limit = 10 };
            var url = UrlBuilder.Build(request);
            url.Should().Contain("&offset=");
        }

        [Fact]
        public void AddsBothLimitAndOffsetIfSet()
        {
            var request = new MockRequest { Limit = 10, Offset = 20 };
            var url = UrlBuilder.Build(request);
            url.Should().Contain("?limit=10&offset=20");
        }

        [Fact]
        public void UrlTerminator_SegmentIsLast()
        {
            var request = new MockRequest { First = 1, Alpha = 2, Last = 3};
            var url = UrlBuilder.Build(request);
            url.Should().Be("/first/1/alpha/2/last/3.json");
        }

        [Fact]
        public void UrlTerminator_IsAddedEvenWithNullValue()
        {
            var request = new MockRequest { First = 1, Alpha = 2, Last = null };
            var url = UrlBuilder.Build(request);
            url.Should().Be("/first/1/alpha/2/last.json");
        }

        [Fact]
        public void UrlTerminator_MoreThanOneThrowsException()
        {
            var request = new MockMultipleTerminatorsRequest();
            Action act = () => UrlBuilder.Build(request);
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Segments_AreOrderedByOrderThenAlphabetically()
        {
            var request = new MockRequest { First = 1, Second = 2, Alpha = 3, Beta = 4, Last = 5 };
            var url = UrlBuilder.Build(request);
            url.Should().Be("/first/1/second/2/alpha/3/beta/4/last/5.json");
        }

        [Fact]
        public void Segments_AddsNameThenValue()
        {
            var request = new MockRequest { First = 1 };
            var url = UrlBuilder.Build(request);
            url.Should().Be("/first/1/last.json");
        }

        [Fact]
        public void Segments_AddsValueEvenIfNameIsNull()
        {
            var request = new MockRequest { WithoutName = 2};
            var url = UrlBuilder.Build(request);
            url.Should().Be("/2/last.json");
        }

        [Fact]
        public void Segments_DoesNotAddIfValueIsNull()
        {
            var request = new MockRequest { First = null };
            var url = UrlBuilder.Build(request);
            url.Should().Be("/last.json");
        }

        [Fact]
        public void Values_OutputWithToString()
        {
            var request = new MockRequest { String = "str", Integer = 42, Object = new MockObject() };
            var url = UrlBuilder.Build(request);
            url.Should().Be($"/int/42/object/{request.Object}/string/str/last.json");
        }

        [Fact]
        public void Values_EnumsOutputAsInteger()
        {
            var request = new MockRequest { Enum = MockEnum.Two };
            var url = UrlBuilder.Build(request);
            url.Should().Be("/enum/2/last.json");
        }

        [Fact]
        public async Task TestFromSprints()
        {
            var client = new ErgastClient();
            var request = new SprintResultsRequest
            {
                Season = "2022"
            };
            SprintResultsResponse response = await client.GetResponseAsync(request);
            response.Races.First().SprintResults.First().Points.Should().Be(8);
        }

        private class MockRequest : ErgastRequest<ErgastResponse>
        {
            [UrlSegment("first", Order = 1)]
            public int? First { get; set; }

            [UrlSegment("second", Order = 2)]
            public int? Second { get; set; }

            [UrlSegment]
            public int? WithoutName { get; set; }

            [UrlSegment("alpha")]
            public int? Alpha { get; set; }

            [UrlSegment("beta")]
            public int? Beta { get; set; }

            [UrlSegment("string")]
            public string String { get; set; }

            [UrlSegment("int")]
            public int? Integer { get; set; }

            [UrlSegment("object")]
            public MockObject Object { get; set; }

            [UrlSegment("enum")]
            public MockEnum? Enum { get; set; }

            [UrlTerminator, UrlSegment("last")]
            public int? Last { get; set; }
        }

        private class MockMultipleTerminatorsRequest : ErgastRequest<ErgastResponse>
        {
            [UrlTerminator, UrlSegment]
            public int? Last { get; set; }

            [UrlTerminator, UrlSegment]
            public int? AlsoLast { get; set; }
        }

        private class MockObject
        {
            public override string ToString()
            {
                return "obj";
            }
        }

        private enum MockEnum
        {
            Zero,
            One,
            Two
        }
    }
}
