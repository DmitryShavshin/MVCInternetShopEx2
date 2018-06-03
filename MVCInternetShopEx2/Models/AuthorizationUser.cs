using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCInternetShopEx2
{
    public class AuthorizationUser
    {
        [Required(ErrorMessage = "Please, enter your login")]
        //[Range(5, 15, ErrorMessage = "Login must have 5 - 15 symbols")]
        public string Login { get; set; }
        //[Range(6, 30, ErrorMessage = "Password must have 6 - 30 symbols")]
        [Required(ErrorMessage = "Plese, enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public AuthorizationUser() {}

        public AuthorizationUser( string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

    }
}