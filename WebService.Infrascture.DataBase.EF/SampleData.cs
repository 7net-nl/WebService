using CnetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CnetCore.Infrascture

namespace CnetCore.Infrascture.DataBase.EF
{
    public static class SampleData
    {
        public static List<Product> Products()
        {
           return new List<Product>
           {
                new Product
                {
                     ID = Guid.Empty.Fake(1),
                      Category = new List<Category>{ new Category { ID = Guid.Empty.Fake(1) , Name = CategoryEnum.Designe, Product_ID = Guid.Empty.Fake(1) },new Category { ID = Guid.Empty.Fake(2), Name = CategoryEnum.Develope, Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(3), Name = CategoryEnum.Host, Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(4), Name = CategoryEnum.Support, Product_ID = Guid.Empty.Fake(1) } },
                       Customer = "Dorika",
                        SiteName = "Dorika Ceramic",
                        SiteUrl = new Uri("https://DorikaCeramics.com"),
                         StartDate = DateTime.Parse("02-2019"),
                         EndDate = DateTime.Parse("09-2019"),
                          Description = "The DorikaCeramic site, a site for introducing Dorica products, has an agent page, custom designs and a management page. Website design, programming, hosting is ours. This site has long-time support. It was previously hosted on a Linux server and had problems with WordPress, is currently running a Windows server and was built with netcore. ",
                           Images = new List<Image>{ new Image { ID = Guid.Empty.Fake(1), Name="01.jpg" , Path = "/images/gallery/DorikaCeramic/" , Product_ID = Guid.Empty.Fake(1) },
                           new Image { ID = Guid.Empty.Fake(2), Name="02.jpg" , Path = "/images/gallery/DorikaCeramic/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(3), Name="03.jpg" , Path = "/images/gallery/DorikaCeramic/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(4), Name="04.jpg" , Path = "/images/gallery/DorikaCeramic/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(5), Name="05.jpg" , Path = "/images/gallery/DorikaCeramic/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(6), Name="06.jpg" , Path = "/images/gallery/DorikaCeramic/" , Product_ID = Guid.Empty.Fake(1) }},
                            Services = new List<Service>{ new Service { ID = Guid.Empty.Fake(1), Name = "Product Management" , Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(2), Name = "Product Information", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(3), Name = "Admin panel", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(4), Name = "Expandable in the online store", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(5), Name = "Support Long Time WebSite", Product_ID = Guid.Empty.Fake(1) } },
                             Tags = new List<Tag>{ new Tag { ID = Guid.Empty.Fake(1), Name = ".NetCore", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(2), Name = "C#", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(3), Name = "Designer", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(4), Name = "Developer", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(5), Name = "Ecommerce", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(6), Name = "WebShop", Product_ID = Guid.Empty.Fake(1) } }
                }
           };
        }
    }
}
