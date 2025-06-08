using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        ///Generice Methods For CURD Operations =>Signuture of the methods only 
        ///T=> is Category Model or any other Model
        //Gte All Data form Database
        IEnumerable<T> GetAll();
        // Get Data By Id
        T GetById(int id);
        T  Get(Expression<Func<T,bool>> filter);
        //Add Data to Database
        void Add(T entity);
        //Update Data in Database
       // void Update(T entity);
        //Delete Data from Database
        void Delete(T entity);
        void DeleteRangeg(IEnumerable<T> entities);

    }
}
