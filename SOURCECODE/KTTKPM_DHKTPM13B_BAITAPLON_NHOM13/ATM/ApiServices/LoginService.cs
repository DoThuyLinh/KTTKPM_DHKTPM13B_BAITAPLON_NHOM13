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
        static HttpClient client = new HttpClient();
        public async void GetLoginAsync(string path)
        {
            try
            {
                path = ConfigurationManager.AppSettings["WebApi"];
                var productStr = "";
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    productStr = await response.Content.ReadAsStringAsync();

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    var strings = serializer.Deserialize<List<string>>(productStr);
                }
            }
            catch (Exception ex)
            {

            }

            //return product;
        }
    }
}
