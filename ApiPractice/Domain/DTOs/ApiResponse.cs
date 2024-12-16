namespace ApiPractice.Domain.DTOs;
public class ApiResponse<T>
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ApiResponse(bool status, string message, T data)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public static ApiResponse<T> Success(string message, T data)
    {
        return new ApiResponse<T>(true, message, data);
    }

    public static ApiResponse<T> Error(string message)
    {
        return new ApiResponse<T>(false, message, default);
    }
}