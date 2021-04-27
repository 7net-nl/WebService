using WebService.Infrascture.Common;
using WebService.UI.WebUI.Controllers;
using WebService.UI.WebUI.Models;
using WebService.UI.WebUI.Models.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace WebService.Tests.UI.WebUI
{
    public class Product_Controller
    {
        private readonly ITestOutputHelper helper;

        public Product_Controller(ITestOutputHelper helper)
        {
            this.helper = helper;
        }

        [Fact]
        public void Gallery_Product_PassDataViewWithApiMock()
        {
            var webhost = new Mock<IWebHostEnvironment>();
            var product = new GetProductViewModel { Customer= "Test" };
            var GetAllProductvm = new GetAllProductViewModel { CountOnPage = 1, CurrentPage = 1, Products = new List<GetProductViewModel> { product } };
            var api = new Mock<IGetProductApi>();
            api.Setup(c => c.GetAll(It.IsAny<GetAllProductViewModel>())).Returns(new GetAllProductViewModel { Products = new List<GetProductViewModel> { product } });
            var mycontroller = new HomeController(api.Object,webhost.Object);

          var result =  mycontroller.Gallery(new GetAllProductViewModel { Products= new List<GetProductViewModel> { product } });
            
          var ViewResult =  Assert.IsType<ViewResult>(result);
            var myobjectresult = Assert.IsType<GetAllProductViewModel>(ViewResult.Model);
            Assert.True(myobjectresult.Products.Count > 0);
        }

        [Fact]
        public void Gallery_Product_ApiGetAll()
        {
            var urlapi = new UrlApi() { Url = "https://localhost:44397/api/v1/" };
            var client = new WebClient();
            var option = new Mock<IOptions<UrlApi>>();
            option.Setup(c => c.Value).Returns(urlapi);
            var getapi = new GetProductApi(client,option.Object);
            //var result = getapi.GetAll(new GetAllProductViewModel { CountOnPage = 1, CurrentPage = 1 });
            //var resultapi = client.DownloadString(option.Object.Value.Url + $"product/1/1");

            var result = getapi.GetAll(new GetAllProductViewModel { CurrentPage = 1 , CountOnPage = 1});

            Assert.True(result.Products.Count > 0);


        }

        [Fact]
        public void Gallery_Product_ApiEdit()
        {
            var urlapi = new UrlApi() { Url = "https://localhost:44397/api/v1/" };
            var client = new WebClient();
            var option = new Mock<IOptions<UrlApi>>();
            option.Setup(c => c.Value).Returns(urlapi);
            var getapi = new GetProductApi(client, option.Object);
            var result = client.DownloadString(option.Object.Value.Url + "product/1/1");
            var getAllProduct = JsonConvert.DeserializeObject<GetAllProductViewModel>(result);
            var product = getAllProduct.Products.LastOrDefault();
            var find = new FindProductViewModel { Customer = product.Customer, SiteName = product.SiteName, SiteUrl = product.SiteUrl };
            product.Customer = "Dorika";
            var model = new UpdateProductViewModel { ProductBefore = find, Product = product };
            result = getapi.Edit(model);

            Assert.Equal("Modified", result);

        }

        [Fact]
        public void Gallery_Product_Create()
        {
            
            var urlapi = new UrlApi() { Url = "https://localhost:44397/api/v1/" };
            var client = new WebClient();
            var option = new Mock<IOptions<UrlApi>>();
            option.Setup(c => c.Value).Returns(urlapi);
            var getapi = new GetProductApi(client, option.Object);
            var model = new GetProductViewModel
            {
                Category = new List<string> { Faker.Developers.Designe,Faker.Developers.Developer,Faker.Developers.Host },
                Customer = Faker.Lorem.Word(3),
                Description = Faker.Lorem.Word(50),
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Images = new List<GetImageViewModel> { new GetImageViewModel { Name = "06.jpg", Path = "/images/gallery/Test/" } },
                Services = new List<string> { Faker.Lorem.Word(4),Faker.Lorem.Word(3),Faker.Lorem.Word(5) },
                 SiteName = Faker.Lorem.Word(3),
                  SiteUrl = Faker.Persons.Email,
                   Tags = new List<string> {Faker.Developers.Ecommerce,Faker.Developers.Domain,Faker.Developers.netCore }
            };

           //var GetJsonResult = JsonConvert.SerializeObject(model);
            var result =  getapi.Create(model);
            Assert.Equal("Added", result);
        }

        [Fact]
        public void Gallery_Product_Delete()
        {
            var urlapi = new UrlApi() { Url = "https://localhost:44397/api/v1/" };
            var client = new WebClient();
            var option = new Mock<IOptions<UrlApi>>();
            option.Setup(c => c.Value).Returns(urlapi);
            var getapi = new GetProductApi(client, option.Object);
             var result = client.DownloadString(option.Object.Value.Url + "product/1/1");
            var getAllProduct = JsonConvert.DeserializeObject<GetAllProductViewModel>(result);
            var product = getAllProduct.Products.LastOrDefault();
            var model = new DeleteProductViewModel { ProductRequest = new FindProductViewModel { Customer = product.Customer, SiteName = product.SiteName, SiteUrl = product.SiteUrl } };
            result = getapi.Delete(model);
            Assert.Equal("Deleted", result);

        }

        [Fact]
        public void Gallery_Product_TotalPage()
        {
            var urlapi = new UrlApi() { Url = "https://localhost:44397/api/v1/" };
            var client = new WebClient();
            var option = new Mock<IOptions<UrlApi>>();
            option.Setup(c => c.Value).Returns(urlapi);
            var getapi = new GetProductApi(client, option.Object);
            var Result = getapi.TotalPage(new TotalPageProductViewModel { CountOnPage = 1 });
            Assert.True(Result > 0);

        }

        [Fact]
        public void Gallery_Product_Get()
        {
            var urlapi = new UrlApi() { Url = "https://localhost:44397/api/v1/" };
            var client = new WebClient();
            var option = new Mock<IOptions<UrlApi>>();
            option.Setup(c => c.Value).Returns(urlapi);
            var getapi = new GetProductApi(client, option.Object);
            var result = client.DownloadString(option.Object.Value.Url + "product/1/1");
            var getAllProduct = JsonConvert.DeserializeObject<GetAllProductViewModel>(result);
            var product = getAllProduct.Products.LastOrDefault();
            var model = new FindProductViewModel { Customer = product.Customer, SiteName = product.SiteName, SiteUrl = product.SiteUrl };
            //var GetJsonResult = JsonConvert.SerializeObject(model);
            var GetProduct = getapi.Get(model,model.Customer);
            helper.WriteLine(GetProduct.SiteUrl);

        }

    }
}
