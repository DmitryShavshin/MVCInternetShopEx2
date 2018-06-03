using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace MVCInternetShopEx2
{
    public class DAOImplements : DAO
    {
        string server = "localhost";
        string dataBase = "internetShop";
        string userName = "root";
        //string password = "klan301270";
        string password = "ROOT0920x";
        string connectionString;
        string query;

        MySqlConnection connect;
        MySqlCommand cmd;
        MySqlDataReader reader;

        List<AllGoods> AllGoods = new List<AllGoods>();
        List<RegistrUser> users = new List<RegistrUser>();

        private void OpenDB()
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + dataBase + ";" +
                                    "USERNAME=" + userName + ";" + "PASSWORD=" + password + ";";
            connect = new MySqlConnection(connectionString);
            connect.Open();
            cmd = new MySqlCommand(query, connect);
            
        }

        private void CloseDB()
        {
            connect.Close();
            reader.Close();
        }

        public List<AllGoods> LoadAllGoods()
        {
            query = "SELECT * FROM allgoods";         
            OpenDB();
            reader = cmd.ExecuteReader();
            AllGoods.Clear();
            while (reader.Read())
            {
                AllGoods.Add(new AllGoods (int.Parse(reader["id"] + ""), reader["name"] + "", double.Parse(reader["price"] + ""), int.Parse(reader["count"] + ""),
                                        reader["img1"] + "", reader["img2"] + "", reader["img3"] + "", reader["img4"] + "", reader["img5"] + "", reader["img6"] + "", reader["groupGoods"] + ""));
            }
            CloseDB();
            return AllGoods;
        }

        public List<RegistrUser> GetAllUser()
        {
            query = "SELECT * FROM users";
            OpenDB();
            reader = cmd.ExecuteReader();
            users.Clear();
            while (reader.Read())
            {
                users.Add(new RegistrUser(int.Parse(reader["id"] + ""), reader["login"] + "", reader["password"] + "", reader["email"] + "", reader["gender"] + "",
                            int.Parse(reader["year"] + ""), int.Parse(reader["day"] + ""), reader["month"] + "", reader["name"] + "", reader["surename"] + "", reader["role"] + ""));
            }
            CloseDB();
            return users;
        }

        public void SaveUser(string login, string pass, string email, string gender, int year, int day, string month, string name, string surename)
        {
            query = "INSERT INTO users(login, password, email, gender, year, day, month, name, surename, role) " +
                        "VALUES(@login, @password, @email, @gender, @year, @day, @month, @name, @surename, @role) ";

            OpenDB();
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@day", day);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surename", surename);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@role", "user");          
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}