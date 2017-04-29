using System;
using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("constructorStandings")]
    public interface IConstructorStandings : IPageableQuery
    {
        IPageableQuery ConstructorStandings();
        IConstructorStandingsQuery ConstructorStandings(int position);
    }
}