using ApiModel;
using BusinessLogic.BLL;
using BusinessLogic.TransactionBLL;
using Entities;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class StaffController : ApiController
    {
        private readonly StaffCheckBalanceATMBLL _bllStaffCheckBalance;
        private readonly PaymentTransactionBLL _bllPaymentTransaction;
        private readonly CustomerBLL _bllCustomer;

        public StaffController()
        {
            _bllStaffCheckBalance = new StaffCheckBalanceATMBLL();
            _bllPaymentTransaction = new PaymentTransactionBLL();
            _bllCustomer = new CustomerBLL();
        }
        [Route("StaffCheckBalance")]
        [SwaggerResponse(200, "Returns detail payment", typeof(ApiStaffCheckBalanceATMModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult StaffCheckBalance(int atmId)
        {
            var repose = _bllStaffCheckBalance.CheckAvailableBalance(atmId);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
        [Route("StaffPaymentTransaction")]
        [SwaggerResponse(200, "Returns detail staff payment", typeof(ApiPaymentTransactionModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult PaymentTransaction(string accountNumber, double payment, int atmId)
        {
            var repose = _bllPaymentTransaction.PaymentTransaction(accountNumber, payment, atmId);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }
        [Route("StaffTransactionStatistics")]
        [SwaggerResponse(200, "Returns detail staff statistics transaction", typeof(ApiStaffTransactionStatisticsModel))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpGet]
        public IHttpActionResult StaffTransactionStatistics(string accountNumber)
        {
            var repose = _bllCustomer.StaffTransactionStatistics(accountNumber);
            return new HttpApiActionResult(HttpStatusCode.OK, repose);
        }

        [Route("StaffAddCustomer")]
        [SwaggerResponse(200, "Returns detail staff add customer", typeof(ApiResult))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpPost]
        public IHttpActionResult StaffAddCustomer(Customer customer,double money, AccountCard.AccountTypes types,int bankId)
        {
            _bllCustomer.AddCustomer(customer,money,types,bankId);
            var result = new ApiJsonResult() {};
            return new HttpApiActionResult(HttpStatusCode.OK, result);
        }

        [Route("ResetPasswordCustomer")]
        [SwaggerResponse(200, "Returns detail staff reset password for customer", typeof(ApiResult))]
        [SwaggerResponse(500, "Internal Server Error")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(401, "Not Authorizated")]
        [HttpPost]
        public IHttpActionResult ResetPasswordCustomer(string account)
        {
            _bllCustomer.ResetPassword(account);
            var result = new ApiJsonResult() { };
            return new HttpApiActionResult(HttpStatusCode.OK, result);
        }
    }
}
