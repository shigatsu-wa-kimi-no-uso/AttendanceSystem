using AttendanceSystemUI.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AttendanceSystemUI.Clients
{
    public class HttpClient
    {
        private readonly long httpTimeout = long.Parse(ConfigurationManager.AppSettings["HttpTimeout"]);

		/// <summary>
		/// http请求接口
		/// </summary>
		/// <param name="url">地址</param>
		/// <param name="data">数据，json格式化后的数据</param>
		/// <param name="method">方法 POST，或者get</param>
		/// <returns></returns>
		public ResultStatus doHttpRequest<T>(string apiPath, Method method,out T response,string data = null, string file = null)
        {
            try
            {
                var client = new RestClient(apiPath);
				var request = new RestRequest {
					RequestFormat = DataFormat.Json,
					Method = method
				};
				request.AddHeader("Content-Type", "application/json");
                request.Timeout = TimeSpan.FromMilliseconds(httpTimeout);
                if (data != null)
                    request.AddParameter("application/json; charset=utf-8", data, ParameterType.RequestBody);
                RestResponse restResponse = client.Execute(request);
                if(restResponse != null && restResponse.Content!=null) {
					response = restResponse.Content.jsonToObject<T>();
					return ResultStatus.SUCCESS;
				} else {
                    response = default;
                    return ResultStatus.NO_CONTENT;
                }
            }
            catch (Exception e)
            {
				response = default;
				return ResultStatus.UNDEFINED_ERROR;
            }
        }



	}
}
