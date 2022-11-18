using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace BlogBalta.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private readonly SqlConnection _conection;
        public Repository(SqlConnection connection)
          => _conection = connection;
        public IEnumerable<TModel> GetAlll()
        => _conection.GetAll<TModel>();
        public TModel Get(int id)
            => _conection.Get<TModel>(id);

        public void Create(TModel model)
            => _conection.Insert<TModel>(model);

        public void Update(TModel model)
           =>  _conection.Update<TModel>(model);
        public void Delete(TModel model)
          =>  _conection.Delete<TModel>(model);
        public void Delete(int id)
        {
            if (id != 0)
                return;
            var model = _conection.Get<TModel>(id);
            _conection.Delete<TModel>(model);
        }
    }
}
