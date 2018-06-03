using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCInternetShopEx2
{
    public class RegistrUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, enter your login")]
        //[Range(5, 15, ErrorMessage ="Login must have 5 - 15 symbols")]
        public string Login { get; set; }
        //[Range(6, 30, ErrorMessage = "Password must have 6 - 30 symbols")]
        [Required(ErrorMessage = "Plese, enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Plese, enter confirm password")]
        [Compare("Password", ErrorMessage = "Password no match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Please, enter email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Your entered incorrect email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public int Day { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Months { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Surename { get; set; }  
        public string Role { get; set; }

        public RegistrUser() { }

        public RegistrUser RegUser { get; set; }

        public RegistrUser(int id, string login, string password, string email, string gender, int year, int day, string months, string name, string surename, string role)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Gender = gender;
            this.Year = year;
            this.Day = day;
            this.Months = months;
            this.Name = name;
            this.Surename = surename;
            this.Role = role;
        }
    }
}