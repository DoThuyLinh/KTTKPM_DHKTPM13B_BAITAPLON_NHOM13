using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModel
{
    public class ApiUserLoginModel : ApiJsonResult
    {
        public enum AccountRole
        {
            Customer, Staff
        }
        public string AccountNumber { get; set; }
        public string PersonName { get; set; }
        public AccountRole? Role { get; set; }
    }
}
