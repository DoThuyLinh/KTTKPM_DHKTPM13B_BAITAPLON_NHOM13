using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityDAL
{
     public interface IDataAccess<T>:INewDataAccessBase<T>
    {
        T GetById(object id);
    }
}
