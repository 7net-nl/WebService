using WebService.UI.WebUI.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Areas.Admin.Models
{
    public class GetAllProductForAdminViewModel
    {
        public GetAllProductForAdminViewModel()
        {
            CurrentPage = 1;
            CountOnPage = 1;
        }
        public short CurrentPage { get; set; }
        public short CountOnPage { get; set; }
        public short TotalPage { get; set; }

        public List<UpdateProductViewModel> Products { get; set; }
        
    }
}
