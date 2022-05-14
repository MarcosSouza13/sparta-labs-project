using AutoRepairShop.Api.Validators.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace AutoRepairShop.Api.Services.Base
{
    public class ResponseHttp<T> : IActionResult where T : class
    {
        public ResponseHttp(int statusCode, T entity = null, string errorMessage = null, IEnumerable<VisualizationError> errorsModel = null)
        {
            StatusCode = statusCode;
            Entity = entity;
            ErrorMessage = errorMessage;
            ErrorsModel = errorsModel;
        }

        public int StatusCode { get; set; }
        public T Entity { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<VisualizationError> ErrorsModel { get; set; }

        private JsonSerializerSettings GetConfigJson
            => new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Include };

        public Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCode;

            if (StatusCode != 404 && StatusCode != 204)
            {
                string content;
                if (Entity != null)
                    content = JsonConvert.SerializeObject(Entity, GetConfigJson);
                else if (ErrorsModel != null)
                    content = JsonConvert.SerializeObject(ErrorsModel, GetConfigJson);
                else
                    content = JsonConvert.SerializeObject(new { error = ErrorMessage });

                byte[] data = Encoding.UTF8.GetBytes(content);

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.Body.Write(data, 0, data.Length);
            }

            return Task.CompletedTask;

        }
    }
}
