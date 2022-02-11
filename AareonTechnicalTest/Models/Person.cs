using AareonTechnicalTest.Models.Resources.Enum;
using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class Person
    {
        [Key]
        public int Id { get; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }
    }
}
