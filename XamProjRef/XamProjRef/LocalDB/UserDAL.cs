using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;

namespace XamProjRef1.LocalDB
{
    public class UserDAL : BaseDal, IRepository<User>
    {
        public string Save(User entities)
        {
            // the below code is just for testing purpose. 
            var lastUser = GetAll().LastOrDefault();
            if (lastUser != null) { entities.Id = lastUser.Id + 1; }
            else { entities.Id = 1;}
             Database.Insert(entities);
            return entities.Id.ToString();
        }

        public bool Update(User entity)
        {
            var returnVal = Database.Update(entity);
            return (returnVal > 0 ? true : false);// not sure of this code
        }

        public bool Delete(User entity)
        {
            var returnVal = Database.Delete(entity);
            return (returnVal > 0 ? true : false);// not sure of this code
        }

        public User GetById(string id)
        {
            return Database.Get<User>(id);
        }

        public bool SaveAll(IEnumerable<User> entities)
        {
            var returnVal = Database.InsertAll(entities);
            return (returnVal > 0 ? true : false);// not sure of this code
        }

        public bool UpdateAll(IEnumerable<User> entities)
        {
            var returnVal = Database.UpdateAll(entities);
            return (returnVal > 0 ? true : false);// not sure of this code
        }

        public bool DeleteAll()
        {
            var returnVal = Database.DeleteAll<User>();
            return (returnVal > 0 ? true : false);// not sure of this code
        }

        public IEnumerable<User> GetAll()
        {
            return Database.Table<User>().ToList();
        }

        public bool IfExists(User entity)
        {
            return GetById(entity.Id.ToString()) != null;
        }
    }
}
