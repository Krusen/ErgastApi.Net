using System;

namespace ErgastApi.Responses.Models
{
    public interface IDriver
    {
        string Code { get; }
        DateTime DateOfBirth { get; }
        string DriverId { get; }
        string FirstName { get; }
        string LastName { get; }
        string Nationality { get; }
        int? PermanentNumber { get; }
        string WikiUrl { get; }
    }
}