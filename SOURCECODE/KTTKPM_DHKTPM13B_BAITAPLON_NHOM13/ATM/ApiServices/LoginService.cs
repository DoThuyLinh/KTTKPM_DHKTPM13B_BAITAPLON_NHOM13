using ApiModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ATM.ApiServices
{
    public class LoginService
    {
        private string _pathAPI;
        static HttpClient _client;
        public LoginService()
        {
            _client = new HttpClient();
            _pathAPI = ConfigurationManager.AppSettings["WebApi"];
        }
        public async void GetLoginAsync(string acount,string pass, int atmId)
        {
            try
            {
                
                var loginStr = "";
                string apilink = _pathAPI + string.Format("Login?account={0}&pass={1}&atmId={2}",acount,pass,atmId);
                HttpResponseMessage response = await _client.GetAsync(apilink);
                if (response.IsSuccessStatusCode)
                {
                    loginStr = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var repose = serializer.Deserialize<List<ApiUserLoginModel>>(loginStr);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
