namespace Sayara.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; } = default!;
        public required string Message { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Operation successful", int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ApiResponse<T> ErrorResponse(string message, int statusCode = 400, T data = default)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
    public class ApiResponse
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse SuccessResponse(string message = "Operation successful", int statusCode = 200)
        {
            return new ApiResponse
            {
                Success = true,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ApiResponse ErrorResponse(string message, int statusCode = 400)
        {
            return new ApiResponse
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
