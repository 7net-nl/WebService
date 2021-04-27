using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Models.Product
{
    public class GetAllProductViewModel
    {
        public GetAllProductViewModel()
        {
            CurrentPage = 1;
            CountOnPage = 1;
        }
        public short CurrentPage { get; set; }
        public short CountOnPage { get; set; }

        public List<GetProductViewModel> Products { get; set; }
    }
}
