using System.Data.SqlClient;
using BlogBalta.Models;
using Dapper.Contrib.Extensions;

namespace BlogBalta.Repositories
{

    public class RoleRepository
    {
        private readonly SqlConnection _conection;

        public RoleRepository(SqlConnection connection)
          => _conection = connection;

        public IEnumerable<Role> GetAlll()
        => _conection.GetAll<Role>();

        public Role Get(int id)
        => _conection.Get<Role>(id);

 /*        public void Create(Role role)
        => _conection.Insert<Role>(role); */

        public void Create(Role Role)
        {
            Role.Id = 0;
            _conection.Insert<Role>(Role);
        }

        public void Update(Role Role)
        {
            if (Role.Id != 0)
            {
                _conection.Insert<Role>(Role);
            }
        }

        public void Delete(Role role)
        {
            if (role.Id != 0)
            {
                _conection.Delete<Role>(role);
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;
            var role = _conection.Get<Role>(id);
            _conection.Delete<Role>(role);
        }

    }
}