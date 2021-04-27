using AutoMapper;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.EF.Repositories;
using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Command.Create;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace WebService.Tests.Service
{
    public class MapperCheck
    {
        private readonly ITestOutputHelper helper;

        public MapperCheck(ITestOutputHelper helper)
        {
            this.helper = helper;
        }

        [Fact]
        public void test()
        {

            var repo = new Mock<IProductRepository>();
            var mapper = new Mock<IMapper>();
            repo.Setup(c => c.Add(It.IsAny<Product>())).Returns("Added");
            mapper.Setup(c => c.Map<CreateProductRequest, Product>(It.IsAny<CreateProductRequest>())).Returns(new Product());
            var handler = new CreateProductRequestHandler(repo.Object,mapper.Object);
           var result = handler.Handle(new CreateProductRequest(), new CancellationToken()).Result;

            helper.WriteLine(result);




        }

       
    }
}
