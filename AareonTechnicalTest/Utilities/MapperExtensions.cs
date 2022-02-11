using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Dto;
using System.Web.Helpers;

namespace AareonTechnicalTest.Utilities
{
    public static class MapperExtensions
    {
        public static Person MapToPerson(this RegisterDto registerDto)
        {
            var result = new Person
            {
                Username = registerDto.Username,
                Surname = registerDto.Surname,
                Forename = registerDto.Forename,
                IsAdmin = registerDto.IsAdmin,
                PasswordHash = Crypto.HashPassword(registerDto.Password)
            };

            return result;
        }
    }
}
