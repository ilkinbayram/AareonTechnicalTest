using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Models.Dto
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
