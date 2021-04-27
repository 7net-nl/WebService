using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Customer { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public List<Category> Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Service> Services { get;  set; }
        public List<Tag> Tags { get; set; }
        public List<Image> Images { get; set; }
        public string Description { get; set; }


    }
}
