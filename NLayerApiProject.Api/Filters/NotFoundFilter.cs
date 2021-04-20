using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerApiProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerApiProject.API.DTOs;
namespace NLayerApiProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        // Bu filtre constructor(DI nesnesi) aldığından dolayı startup'ta tanımlanması gerekiyor

        // private readonly IService<Product> _productService;
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Value sayıyı yakalar(1,5,8 ...), Key ise ismi("Id" ismini getirir)
            // Action metoduna giren id'nin değerini getir
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                // eğer id null değilse action'a devam et
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;

                errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}