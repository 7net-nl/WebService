using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Models.Product
{
    public class GetProductViewModel
    {
        public GetProductViewModel()
        {
            Images = new List<GetImageViewModel>();
        }
        public string Customer { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public List<string> Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Services { get; set; }
        public List<string> Tags { get; set; }
        public List<GetImageViewModel> Images { get; set; }
        public string Description { get; set; }
       
    }
}
