using ApiModel;
using BusinessLogic;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private UserLoginBLL _userLoginBLL = new UserLoginBLL();
        [Route("Login")]
        [SwaggerResponse(200, "Returns detail login", typeof(ApiUserLoginModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult Login(string user,string pass,string atmId)
        {
            var a = new ApiUserLoginModel() {  AccountNumber="123456", PersonName="Trương Đăng Quang", Role= ApiUserLoginModel.AccountRole.Customer };
            return new HttpApiActionResult(HttpStatusCode.OK, a);
        }
    }
}
