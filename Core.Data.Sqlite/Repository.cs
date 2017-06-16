using Core.Data.Entity;
using Core.Data.Entity.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Sqlite
{
    public class SqliteRepository<T> where T : IEntity, new()
    {
        SqliteDatabase<T> db = null;
        public SqliteRepository(SQLiteConnection conn)
        {
            db = new SqliteDatabase<T>(conn);
        }

        public T Get(int id)
        {
            return db.GetItem(id);
        }

        public IEnumerable<T> Get()
        {
            return db.GetItems();
        }

        public IEnumerable<T> GetByFilters(Expression<Func<T, bool>> aFilters)
        {
            return db.GetItems(aFilters);
        }

        public long Save(T item)
        {
            return db.SaveItem(item);
        }

        public long Delete(long id)
        {
            return db.DeleteItem(id);
        }

        public long DeleteAll()
        {
            return db.DeleteAll();
        }
    }
}
