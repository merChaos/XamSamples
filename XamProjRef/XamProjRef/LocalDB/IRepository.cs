using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;

namespace XamProjRef1.LocalDB
{
    interface IRepository<T> where T : BaseModel
    {
        string Save(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        T GetById(string id);

        bool SaveAll(IEnumerable<T> entities);

        bool UpdateAll(IEnumerable<T> entities);

        bool DeleteAll();

        IEnumerable<T> GetAll();

        bool IfExists(T entity);
    }
}
