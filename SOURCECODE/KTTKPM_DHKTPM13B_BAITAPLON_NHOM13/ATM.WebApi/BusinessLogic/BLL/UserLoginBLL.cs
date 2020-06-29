using ApiModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserLoginBLL : ApiUserLoginModel,UserLoginDAL
    {
        public ApiUserLoginModel Login(string acount, string pass, int atmId)
        {
            
        }
    }
}
