using WebService.Domain.Entities;
using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Images.Command.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Command.Create
{
    public class CreateProductRequest : IRequest<string>
    {
        public string Customer { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
        public List<string> Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string> Services { get; set; }
        public List<string> Tags { get; set; }
        public List<CreateImageRequest> Images { get; set; }
        public string Description { get; set; }
    }
}
