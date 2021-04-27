using WebService.UI.WebUI.Areas.Admin.Models;
using WebService.UI.WebUI.Models.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Areas.Admin.Views.Product.Edit
{
    public class EditComponentBase : ComponentBase
    {
        [Parameter]
        public GetAllProductForAdminViewModel Models { get; set; }
        public UpdateProductViewModel GetProduct { get; set; } = new UpdateProductViewModel { Product = new GetProductViewModel() };

        [Inject]
        public IGetProductApi api { get; set; }
        public string Id { get; set; } = "";
        public string Result { get; set; } = "";
        public string Show { get; set; } = "";
        public string Style { get; set; } = "none;";
        public bool ShowBackdrop { get; set; } = false;
        public string Servicejoin { get; set; } = "";
        public string Tagjoin { get; set; } = "";
        public string Categoryjoin { get; set; } = "";
        public GetImageViewModel GetImage { get; set; } = new GetImageViewModel();
        public string File { get; set; } = "";
        public string AddOrEdit { get; set; } = "";
        public void Open(UpdateProductViewModel model,bool Method=false)
        {
            Result = "";

            if (Method == true)
            {
                AddOrEdit = "Edit";
                GetProduct = model;
                Servicejoin = string.Join(",", model.Product.Services);
                Categoryjoin = string.Join(",", model.Product.Category);
                Tagjoin = string.Join(",", model.Product.Tags);
            }
            else
            {
                AddOrEdit = "Add";
                GetProduct = new UpdateProductViewModel { Product = new GetProductViewModel() };

            }

            Style = "block;";
            Show = "show";
            ShowBackdrop = true;

            StateHasChanged();
        }

        public void Close()
        {
            GetProduct.Product.Category = Categoryjoin.Split(",").ToList();
            GetProduct.Product.Services = Servicejoin.Split(",").ToList();
            GetProduct.Product.Tags = Tagjoin.Split(",").ToList();
            Show = "";
            Style = "none;";
            ShowBackdrop = false;
            StateHasChanged();
        }

        public void AddImage()
        {
            GetProduct.Product.Images.Add(GetImage);
            StateHasChanged();
        }
        
        public void DeleteImage(GetImageViewModel model)
        {
            GetProduct.Product.Images.Remove(model);
            StateHasChanged();
        }


        public void Edit(UpdateProductViewModel model)
        {
            GetProduct.Product.Category = Categoryjoin.Split(",").ToList();
            GetProduct.Product.Services = Servicejoin.Split(",").ToList();
            GetProduct.Product.Tags = Tagjoin.Split(",").ToList();

            Result = api.Edit(model);

                if (Result == "Modified")
                {
                    model.ProductBefore = new FindProductViewModel
                    {
                        Customer = model.Product.Customer,
                        SiteName = model.Product.SiteName,
                        SiteUrl = model.Product.SiteUrl
                    };

                }

                StateHasChanged();
            
            
        }

        public void Delete(UpdateProductViewModel model)
        {
            GetProduct.Product.Category = Categoryjoin.Split(",").ToList();
            GetProduct.Product.Services = Servicejoin.Split(",").ToList();
            GetProduct.Product.Tags = Tagjoin.Split(",").ToList();

            Result = api.Delete(new DeleteProductViewModel
            {
                ProductRequest = model.ProductBefore
            });

            if(Result == "Deleted")
            {
                Models.Products.Remove(model);
            }

            StateHasChanged();
        }

        public void Create()
        {
            GetProduct.Product.Category = Categoryjoin.Split(",").ToList();
            GetProduct.Product.Services = Servicejoin.Split(",").ToList();
            GetProduct.Product.Tags = Tagjoin.Split(",").ToList();

            var model = new UpdateProductViewModel
            {
                 Product = new GetProductViewModel
                 {
                     Category = GetProduct.Product.Category,
                     Customer = GetProduct.Product.Customer,
                     Description = GetProduct.Product.Description,
                     EndDate = GetProduct.Product.EndDate,
                     Images = GetProduct.Product.Images,
                     Services = GetProduct.Product.Services,
                     SiteName = GetProduct.Product.SiteName,
                     SiteUrl = GetProduct.Product.SiteUrl,
                     StartDate = GetProduct.Product.StartDate,
                     Tags = GetProduct.Product.Tags
                 },
                 ProductBefore = new FindProductViewModel()
            };

          Result =  api.Create(model.Product);

            if (Result == "Added")
            { 
                model.ProductBefore = new FindProductViewModel
                {
                    Customer = GetProduct.Product.Customer,
                    SiteName = GetProduct.Product.SiteName,
                    SiteUrl = GetProduct.Product.SiteUrl
                };

                Models.Products.Add(model);
            }

            StateHasChanged();
        }

    }
}
