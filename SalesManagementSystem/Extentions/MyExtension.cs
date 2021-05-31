using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Extentions
{
    public static class MyExtension
    {
        public static void UseMyExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var currentException = context.Features.Get<IExceptionHandlerFeature>().Error as MyException;
                    ErrorModel errorModel = new ErrorModel();
                    if (currentException != null)
                    {
                        errorModel = currentException.ErrorModel;
                        errorModel.ErrorCode = StatusCodes.Status400BadRequest;
                    }
                    else
                    {
                        errorModel.ErrorCode = StatusCodes.Status500InternalServerError;
                        errorModel.Message = $"Internal Server Error";
                    }
                    context.Response.StatusCode = errorModel.ErrorCode;
                    var response = JsonConvert.SerializeObject(errorModel);
                    await context.Response.WriteAsync(response);
                });
            });
        }
    }
}