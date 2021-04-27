using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Models.Product
{
    public class UpdateProductViewModel
    {
        public FindProductViewModel ProductBefore { get; set; }
        public GetProductViewModel Product { get; set; }
    }
}
