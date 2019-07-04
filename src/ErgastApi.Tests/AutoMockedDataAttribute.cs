using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using Xunit;
using Xunit.Sdk;

namespace ErgastApi.Tests
{
    public class AutoMockedDataAttribute : CompositeDataAttribute
    {
        public AutoMockedDataAttribute()
            : this(new AutoNSubstituteDataAttribute())
        { }

        public AutoMockedDataAttribute(params object[] values)
            : this(new AutoNSubstituteDataAttribute(), values)
        { }

        public AutoMockedDataAttribute(DataAttribute autoDataAttributeAttribute, params object[] values)
            : base(new InlineDataAttribute(values), autoDataAttributeAttribute)
        { }

        public class AutoNSubstituteDataAttribute : AutoDataAttribute
        {
            public AutoNSubstituteDataAttribute()
                : base(() => new Fixture().Customize(new AutoNSubstituteCustomization { ConfigureMembers = true }))
            { }
        }
    }
}
