using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCInternetShopEx2
{
    interface DAO
    {
        List<RegistrUser> GetAllUser();
        void SaveUser(string login, string password, string email, string gender, int year, int day, string month, string name, string surename);
    }
}
