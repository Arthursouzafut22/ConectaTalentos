namespace ConectaTalentos.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> Ok(T? data, string message) =>
            new() { Success = true, Data = data, Message = message, StatusCode = 200 };

        public static ApiResponse<T> NotFound(string message) =>
            new() { Success = false, Message = message, StatusCode = 404 };

        public static ApiResponse<T> Unauthorized(string message) =>
            new() { Success = false, Message = message, StatusCode = 401 };

        public static ApiResponse<T> Conflict(string message) =>
            new() { Success = false, Message = message, StatusCode = 409 };

    }
}
