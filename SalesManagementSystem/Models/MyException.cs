using System;
using Microsoft.AspNetCore.Http;

namespace SalesManagementSystem.Models
{
    public class MyException : Exception
    {
        public Exception Exception { get; set; }
        public ErrorModel ErrorModel { get; set; }
        public MyException(ErrorModel errorModel, Exception exception)
        {
            ErrorModel = errorModel;
            Exception = exception;
        }
    }

    public class ErrorModel
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}