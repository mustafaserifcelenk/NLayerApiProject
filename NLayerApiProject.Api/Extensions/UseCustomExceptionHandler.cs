using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;

namespace NLayerApiProject.Api.Extensions
{ 
    // Extension metot . dab sonra çıkan metotlardır. Daima static olurlar.
    public static class UseCustomExceptionHandler
    {
        // Neye extense edeceği this keyword'ünden belirlenir
        public static void UseCustomException(this IApplicationBuilder app)
        {
            #region Global Exception Handling
            // Uygulamanın herhangi bir yerinde erhangi bir hata fırlatıldığı zaman
            app.UseExceptionHandler(config =>
            {
                // Hata gelince config option üzerinden run metodu çalışacak
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    // Hata yakalama
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        // Yakalanan errorler
                        var ex = error.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        // Cevabın oluşturulması (Bu OK metodu gibi otomatik Json Convert yapmaz biz manuel yapıyoruz)
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
            #endregion

        }
    }
}
