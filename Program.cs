using System;
using Dapper.Contrib.Extensions;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using BlogBalta.Models;
using BlogBalta.Repositories;

namespace BlogBalta
{
    //dotnet add package .Microsoft.Data.DataClient
    // dotnet add package Dapper
    //dotnet add package Dapper.Contrib

    public class Program
    {
        private const string connectionString = @"Server=192.168.99.100\sqlserver,1433;Database=Blog;User ID=sa; Password=1q2w3e4r@#$;";
        const string conectStringJob = @"Server=IM-BRS-NT1071\MSSQLSERVER01; Integrated Security=SSPI; Database=Blog;";
        static void Main(string[] args)
        {
            var con = new SqlConnection(conectStringJob);
            con.Open();
            // ReadUsersNew(con);
            //System.Console.Clear();
           /*  System.Console.WriteLine("GET"); */
           /*  ReadUsersWithGenericClass(con); */
           /*  System.Console.WriteLine("*************************"); */
           /*  ReadRolesWithGenericClass(con); */
           /*  System.Console.WriteLine("*************************"); */
           /*  ReadTagsWithGenericClass(con); */
           /*  System.Console.WriteLine("GET ONE"); */
           /*      Read_User(con); */
           /*  System.Console.WriteLine("*************************"); */
           /*      Read_Role(con); */
           /*   System.Console.WriteLine("*************************"); */
           /*      Read_Tag(con); */
             /*  Console.WriteLine("CRE ATE"); */
             /*  Create_User(con);   */
             /*  Create_Role(con); */
             /*  Create_Tag(con); */
              System.Console.WriteLine("ALTER");
              Alter_User(con);
              Alter_Role(con);
              Alter_Tag(con);

            con.Close();
            #region old
            //Console.Clear();
            //  System.Console.WriteLine("Hello Word");
            // ReadUsers();
            // ReadUser();
            //  CreateUser();
            // UpdateUser();
            // DeleteUser();
            #endregion
        }

        public static void ReadUsersWithGenericClass(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAlll();
            foreach (var user in users)
                System.Console.WriteLine($"{user.Name}- {user.Email}");
        }
        public static void ReadRolesWithGenericClass(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAlll();
            foreach (var role in roles)
                System.Console.WriteLine($"{role.Name}- {role.Slug}");
        }
        public static void ReadTagsWithGenericClass(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAlll();
            foreach (var tag in tags)
                System.Console.WriteLine($"{tag.Name}- {tag.Slug}");
        }
     
        public static void Read_User(SqlConnection connection){
            var repository = new Repository<User>(connection);
            var user = repository.Get(1);
            System.Console.WriteLine($"USER:  {user.Name}- {user.Email}");
        }
        public static void Read_Role(SqlConnection conection){
               var repository = new Repository<Role>(conection);
               var role = repository.Get(1);
               System.Console.WriteLine($"ROLE: {role.Name}");
            }
        public static void Read_Tag(SqlConnection conection){
       var repository = new Repository<Tag>(conection);
       var tag = repository.Get(1);
       System.Console.WriteLine($"TAG: {tag.Name}");
    }
        
        public static void Create_User(SqlConnection connection){
        var repository = new Repository<User>(connection);
        var user = new User()
        {
           Bio = "Equipe monitor.io",
           Email = "Gello@monitor.io",
          Image = "https://...",
          Name = "eeuipe monitor.io",
          PasswordHash = "Hash",
          Slug = "equipe-montior"
            };
            repository.Create(user);
            System.Console.WriteLine("User realizado com sucesso!");
        }
        public static void Create_Role(SqlConnection con){
            var repository = new Repository<Role>(con);
            var role = new Role(){
                Name = "user-local",
                Slug = "localUser"
            };
            repository.Create(role);
            System.Console.WriteLine("Role criada com sucessso");
        }
        public static void Create_Tag(SqlConnection con){
            var repository = new Repository<Tag>(con);
            var tag = new Tag(){
            Name = "Tag exemplo",
            Slug = "slug tag"
             };
            repository.Create(tag);
            System.Console.WriteLine("tag criada com sucesso.");
        }
     
        public static void Alter_User(SqlConnection con){
            var respository = new Repository<User>(con);
            var user = new User()
            {
                Id =3,
                Bio = "Equipe || Monitor.io",
                Email = "monitor@monitor.io",
                Image = "https://...",
                Name = "equipe de suporte monitor.io",
                PasswordHash = "Hash",
                Slug = "equipe-monitor"
            };
            respository.Update(user);
            System.Console.WriteLine("User changed");
        }
        public static void Alter_Role(SqlConnection con){
            var repo = new Repository<Role>(con);
            var role = new Role(){
                 Id = 3,
                  Name = "Administrador",
                  Slug = "ADM..."  
            };
            repo.Update(role);
            System.Console.WriteLine("Role changed");
        }
        public static void Alter_Tag(SqlConnection con){
            var repo = new Repository<Tag>(con);
            var tag = new Tag(){
                Id=2,
                Name = "tag 2",
                Slug = "Tag 2"
            };
            repo.Update(tag);
            System.Console.WriteLine("tag changed");
        }
     
        public  static void Delete_User(SqlConnection con){
            var repository = new Repository<User>(con);
            var user  = repository.Get(2);
            repository.Delete(user);
            System.Console.WriteLine( $"User {user.Name} foi limado!");
        }

        public static void Delete_Role(SqlConnection con){
            var repo = new Repository<Role>(con);
            var role = repo.Get(4);
            repo.Delete(role);
            System.Console.WriteLine($"role {role.Name}");
        }

        public static void Delete_tag(SqlConnection con){
            var repo = new Repository<Tag>(con);
            var tag = repo.Get(2);
            repo.Delete(tag);
            System.Console.WriteLine($"Tag {tag.Name}");
        }
     
        public static void ReadUsersNew(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetAlll();
            foreach (var user in users)
                System.Console.WriteLine($"{user.Name}- {user.Email}");
        }
        public static void ReadUserNew(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var user = repository.Get(1);
            System.Console.WriteLine($"{user.Name}- {user.Email}");
        }
       
        #region old
        public static void ReadUser()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var user = con.Get<User>(1);

                System.Console.WriteLine($"{user.Name}- {user.Email}");
            }
        }
        public static void ReadUsers()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var users = con.GetAll<User>();

                foreach (var user in users)
                    System.Console.WriteLine($"{user.Name}- {user.Email}");
            }
        }
        public void UpdateUser()
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
