using System.Collections.Generic;

namespace WebService.UI.WebUI.Models.Product
{
    public interface IGetProductApi
    {
        string Create(GetProductViewModel model);
        string Delete(DeleteProductViewModel model);
        string Edit(UpdateProductViewModel model);
        GetAllProductViewModel GetAll(GetAllProductViewModel model);
        GetProductViewModel Get(FindProductViewModel model, string Customer = "");
        short TotalPage(TotalPageProductViewModel model);
    }
}