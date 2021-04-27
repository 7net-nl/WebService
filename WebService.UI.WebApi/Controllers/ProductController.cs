using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.EF.Repositories;
using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Common.Exceptions;
using WebService.Service.ApplicationService.Products.Command.Create;
using WebService.Service.ApplicationService.Products.Command.Delete;
using WebService.Service.ApplicationService.Products.Command.Update;
using WebService.Service.ApplicationService.Products.Queries.Get;
using WebService.Service.ApplicationService.Products.Queries.GetAll;
using WebService.Service.ApplicationService.Products.Queries.TotalPage;
using WebService.UI.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace WebService.UI.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : Controller
    {
  
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
           
            this.mediator = mediator;
        }



        [HttpGet("{currentpage}/{countonpage}")]
        public Task<IActionResult> Get(GetAllProductRequest request)
        {
            
           return ExceptionRespons(() => mediator.Send(request));
        }

        [HttpPost("{Customer}")]
        public Task<IActionResult> Get([FromBody]GetProductRequest request, string Customer="")
        {
            if (Customer.ToLower() != request.Customer.ToLower()) BadRequest(request);
            return ExceptionRespons(()=>mediator.Send(request));   
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody]UpdateProductRequest request)
        {
            return ExceptionRespons(()=>mediator.Send(request));
        }

        [HttpDelete]
        public Task<IActionResult> Delete([FromBody]DeleteProductRequest request)
        {
            return ExceptionRespons(() => mediator.Send(request));
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody]CreateProductRequest request)
        {
            
            return ExceptionRespons(() => mediator.Send(request));
         
        }
       
        [HttpGet("totalpage/{CountOnPage}")]
        public Task<IActionResult> TotalPage(GetProductTotalPageRequest request)
        {
            return ExceptionRespons(() => mediator.Send(request));
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return BadRequest("System Erorr Try again");
        }

        private async Task<IActionResult> ExceptionRespons<TRespons>(Func<Task<TRespons>> func)
        {
           
            try
            {

                return Ok(await func());
            }

            catch (BaseException ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
    }
}
