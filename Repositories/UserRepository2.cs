using System.Data.SqlClient;
using BlogBalta.Models;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BlogBalta.Repositories
{
    public class UserRepository2 : Repository<User>
    {
        private readonly SqlConnection _conection;

        public UserRepository2(SqlConnection connection)
        : base(connection)
          => _conection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"SELECT [User].*, [Role].* FROM  " +
            "[User] LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]" +
            "LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";
            var users = new List<User>();
            var items = _conection.Query<User, Role, User>(
                query,
                 (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id"
            );


            return users;
        }
    }
}