using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;



namespace WebService.UI.WebUI.Models.Product
{
    public class GetProductApi : IGetProductApi
    {
        public readonly WebClient client;
        public readonly IOptions<UrlApi> options;
        public string GetJsonResult { get; set; } = new string("");
        public GetProductApi(WebClient client, IOptions<UrlApi> options)
        {
            this.client = client;
            this.options = options;
        }

        public GetAllProductViewModel GetAll(GetAllProductViewModel model)
        {
            GetJsonResult = client.DownloadString(options.Value.Url + $"product/{model.CurrentPage}/{model.CountOnPage}");
            model = JsonConvert.DeserializeObject<GetAllProductViewModel>(GetJsonResult);
            return model;
        }

        public string Edit(UpdateProductViewModel model)
        {
            client.Headers.Add("Content-Type", "application/json");
            GetJsonResult = JsonConvert.SerializeObject(model);
            GetJsonResult = client.UploadString(options.Value.Url + $"product", "PUT", GetJsonResult);
            return GetJsonResult;
        }



        public string Create(GetProductViewModel model)
        {

            GetJsonResult = JsonConvert.SerializeObject(model);
            client.Headers.Add("Content-Type", "application/json");
            GetJsonResult = client.UploadString(options.Value.Url + $"product", "POST", GetJsonResult);

            return GetJsonResult;
        }

        public string Delete(DeleteProductViewModel model)
        {

            GetJsonResult = JsonConvert.SerializeObject(model);
            client.Headers.Add("Content-Type", "application/json");
            GetJsonResult = client.UploadString(options.Value.Url + $"product", "Delete", GetJsonResult);

            return GetJsonResult;
        }

        public short TotalPage(TotalPageProductViewModel model)
        {
            client.Headers.Add("Content-Type", "application/json");
            GetJsonResult = client.DownloadString(options.Value.Url + $"product/totalpage/{model.CountOnPage}");

            return short.Parse(GetJsonResult);

        }

        public GetProductViewModel Get(FindProductViewModel model, string Customer="")
        {
            GetJsonResult = JsonConvert.SerializeObject(model);
            client.Headers.Add("Content-Type", "application/json");
            GetJsonResult = client.UploadString(options.Value.Url + $"product/{Customer}", "POST", GetJsonResult);

            return JsonConvert.DeserializeObject<GetProductViewModel>(GetJsonResult);
        }
    }
}
