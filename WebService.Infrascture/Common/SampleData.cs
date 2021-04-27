using WebService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.Common
{
    public static class SampleData
    {

        public static List<Product> Products { get; set; } = new List<Product> {new Product
        {
            ID = Guid.Empty.Fake(1),
            Customer = "Shrine vast",
            SiteName = "The to a one virtues",
            SiteUrl = "https://Tests.com",
            StartDate = DateTime.Parse("02-2019"),
            EndDate = DateTime.Parse("09-2019"),
            Description = "Relief oft feels to his tales earth would love paphian might of light rake sore none me his flatterers might" } };
        public static Product ProductComplete { get; set; } = new Product
        {
            ID = Guid.Empty.Fake(1),
            Category = new List<Category> { new Category { ID = Guid.Empty.Fake(1), Name = "Designe", Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(2), Name = "Develope", Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(3), Name = "Host", Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(4), Name = "Support", Product_ID = Guid.Empty.Fake(1) } },
            Customer = "Vile soul was",
            SiteName = "Es mein herz wie aus",
            SiteUrl = "https://Tests.com",
            StartDate = DateTime.Parse("02-2019"),
            EndDate = DateTime.Parse("09-2019"),
            Description = "Geneigt neu mein irren zu die in kommt halbverklungnen vom labyrinthisch euch tränen tage froher einst tönen meinem zerstreuet besitze sonst dunst widerklang mich euch die die ihr schmerz gleich",
            Images = new List<Image>{ new Image { ID = Guid.Empty.Fake(1), Name="01.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },
                           new Image { ID = Guid.Empty.Fake(2), Name="02.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(3), Name="03.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(4), Name="04.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(5), Name="05.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(6), Name="06.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) }},
            Services = new List<Service> { new Service { ID = Guid.Empty.Fake(1), Name = "Product Management", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(2), Name = "Product Information", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(3), Name = "Admin panel", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(4), Name = "Expandable in the online store", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(5), Name = "Support Long Time WebSite", Product_ID = Guid.Empty.Fake(1) } },
            Tags = new List<Tag> { new Tag { ID = Guid.Empty.Fake(1), Name = ".NetCore", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(2), Name = "C#", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(3), Name = "Designer", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(4), Name = "Developer", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(5), Name = "Ecommerce", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(6), Name = "WebShop", Product_ID = Guid.Empty.Fake(1) } }
        };

        public static List<Category> CategoryOnly { get; set; } = new List<Category>
        {
            new Category { ID = Guid.Empty.Fake(1), Name = "Designe", Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(2), Name = "Develope", Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(3), Name = "Host", Product_ID = Guid.Empty.Fake(1) }, new Category { ID = Guid.Empty.Fake(4), Name = "Support", Product_ID = Guid.Empty.Fake(1) }
        };

        public static List<Image> ImageOnly { get; set; } = new List<Image>
        {
             new Image { ID = Guid.Empty.Fake(1), Name="01.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },
                           new Image { ID = Guid.Empty.Fake(2), Name="02.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(3), Name="03.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(4), Name="04.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(5), Name="05.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) },new Image { ID = Guid.Empty.Fake(6), Name="06.jpg" , Path = "/images/gallery/Test/" , Product_ID = Guid.Empty.Fake(1) }
        };

        public static List<Service> ServiceOnly { get; set; } = new List<Service>
        {
            new Service { ID = Guid.Empty.Fake(1), Name = "Product Management", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(2), Name = "Product Information", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(3), Name = "Admin panel", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(4), Name = "Expandable in the online store", Product_ID = Guid.Empty.Fake(1) }, new Service { ID = Guid.Empty.Fake(5), Name = "Support Long Time WebSite", Product_ID = Guid.Empty.Fake(1) } };

        public static List<Tag> TagOnly { get; set; } = new List<Tag>
        {
            new Tag { ID = Guid.Empty.Fake(1), Name = ".NetCore", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(2), Name = "C#", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(3), Name = "Designer", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(4), Name = "Developer", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(5), Name = "Ecommerce", Product_ID = Guid.Empty.Fake(1) }, new Tag { ID = Guid.Empty.Fake(6), Name = "WebShop", Product_ID = Guid.Empty.Fake(1) } 
        };
}

    }

