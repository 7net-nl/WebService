using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebService.UI.WebUI.Areas.Admin.Models;
using WebService.UI.WebUI.Models;
using WebService.UI.WebUI.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.UI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IGetProductApi api;
        
        public ProductController(IGetProductApi api)
        {
            this.api = api;
        }

        
        public IActionResult Index(GetAllProductViewModel model)
        {
            var TotalPage = api.TotalPage(new TotalPageProductViewModel { CountOnPage = 50 });
            model.CountOnPage = 50;
            var GetAllProduct = api.GetAll(model);
            var ListProductUpdate = GetAllProduct.Products.Select(c => new UpdateProductViewModel
            {
                     Product = new GetProductViewModel
                    {
                        Category = c.Category,
                        Customer = c.Customer,
                         Description = c.Description,
                          EndDate = c.EndDate ,
                           Images = c.Images,
                            Services = c.Services,
                             SiteName = c.SiteName,
                              SiteUrl = c.SiteUrl,
                               StartDate = c.StartDate,
                                Tags = c.Tags
                    },
                     ProductBefore = new FindProductViewModel
                     {
                          Customer = c.Customer,
                           SiteName = c.SiteName,
                            SiteUrl = c.SiteUrl
                     }
                
            }).ToList();

            var NewModel = new GetAllProductForAdminViewModel
            {
                Products = ListProductUpdate,
                CountOnPage = 50,
                CurrentPage = model.CurrentPage,
                 TotalPage = TotalPage
            };
            
            return View(NewModel);
        }

    }
}
