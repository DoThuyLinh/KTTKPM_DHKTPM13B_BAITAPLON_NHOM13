using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PersonDAL:DataContextBLO
    {
        public PersonDAL()
        {
        }
        public Person GetPerson(int personID)
        {
            var person = new Person();
            if (_dbContext.Staffs.FirstOrDefault(x => x.PersonID == personID) is Staff)
                person = _dbContext.Staffs.FirstOrDefault(x => x.PersonID == personID);
            else if (_dbContext.Customers.FirstOrDefault(x => x.PersonID == personID) is Customer)
                person = _dbContext.Customers.FirstOrDefault(x => x.PersonID == personID);
            return person;
        }
    }
}
