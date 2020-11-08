using DnD_Board.API.DTOs;
using DnD_Board.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DnD_Board.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode;
            switch (context.Exception)
            {
                case BadRequestException _:
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case DataNotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    break;

                case InternalServerErrorException _:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var result = new ObjectResult(new BaseResponse<bool>(statusCode, context.Exception.Message)) { StatusCode = (int)statusCode };
            context.Result = result;
        }
    }
}