using System.Net;

namespace DnD_Board.API.DTOs
{
    public class BaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }

        public int? Total { get; set; }

        public BaseResponse(HttpStatusCode statusCode, T data = default, int? total = null)
        {
            StatusCode = statusCode;
            Data = data;
            Total = total;
        }

        public BaseResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }
    }

    public class SuccessResponse<T> : BaseResponse<T>
    {
        public SuccessResponse(T data = default) : base(HttpStatusCode.OK, data)
        {
        }

        public SuccessResponse(T data = default, int? total = null) : base(HttpStatusCode.OK, data, total)
        {
        }
    }
}
