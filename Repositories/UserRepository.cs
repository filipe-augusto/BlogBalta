using System.Data.SqlClient;
using BlogBalta.Models;
using Dapper.Contrib.Extensions;

namespace BlogBalta.Repositories
{

    public class UserRepository
    {
        private readonly SqlConnection _conection;

        public UserRepository(SqlConnection connection)
          => _conection = connection;

        public IEnumerable<User> GetAlll()
        => _conection.GetAll<User>();

        public User Get(int id)
        => _conection.Get<User>(id);

        public void Create(User user)
        {
            user.Id = 0;
            _conection.Insert<User>(user);
        }


        public void Update(User user)
        {
            if (user.Id != 0)
            {
                _conection.Insert<User>(user);
            }
        }

        public void Delete(User user)
        {
            if (user.Id != 0)
            {
                _conection.Delete<User>(user);
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;
            var user = _conection.Get<User>(id);
            _conection.Delete<User>(user);
        }



    }
}