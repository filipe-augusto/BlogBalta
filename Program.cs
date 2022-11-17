using System;
using Dapper.Contrib.Extensions;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace BlogBalta
{
    //dotnet add package .Microsoft.Data.DataClient
    // dotnet add package Dapper
    //dotnet add package Dapper.Contrib

    public class Program
    {
        const string connectionString = @"Server=192.168.99.100\sqlserver,1433;Database=Blog;User ID=sa; Password=1q2w3e4r@#$;";
        const string conectStringJob = @"Server=IM-BRS-NT1071\MSSQLSERVER01; Integrated Security=SSPI; Database=balta; TrustServerCeritificate=True";
        static void Main(string[] args)
        {
            //Console.Clear();
            System.Console.WriteLine("Hello Word");
            // ReadUsers();
            // ReadUser();
            //  CreateUser();
            // UpdateUser();
            // DeleteUser();
        }
        #region old
        public static void ReadUsers()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var users = con.GetAll<User>();

                foreach (var user in users)
                    System.Console.WriteLine($"{user.Name}- {user.Email}");
            }
        }
        public static void ReadUser()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var user = con.Get<User>(1);

                System.Console.WriteLine($"{user.Name}- {user.Email}");
            }
        }
        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "equipe de suporte balta.io",
                PasswordHash = "Hash",
                Slug = "equipe-suporte"
            };
            using (var con = new SqlConnection(connectionString))
            {
                var affectsRows = con.Update<User>(user);
                System.Console.WriteLine(affectsRows + "Atualização realizado com sucesso!");
            }
        }
        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe balta.io",
                Email = "Gello@balta.io",
                Image = "https://...",
                Name = "eeuipe balta.io",
                PasswordHash = "Hash",
                Slug = "equipe-bata"
            };
            using (var con = new SqlConnection(connectionString))
            {
                var affectsRows = con.Insert<User>(user);
                System.Console.WriteLine("Cadastro realizado com sucesso!");
            }
        }
        public static void DeleteUser()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var user = con.Get<User>(2);
                var status = con.Delete<User>(user);
                System.Console.WriteLine($"{status}");
            }
        }
        #endregion
    }
}
