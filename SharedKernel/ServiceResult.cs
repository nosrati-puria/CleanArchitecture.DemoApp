namespace SharedKernel;

public class ServiceResult<T>
{
	private ServiceResult() { }

	public bool IsSuccess { get; private set; }

	public T? Data { get; private set; }

	public string? Message { get; private set; }

	public int StatusCode { get; private set; }


	public static ServiceResult<T> Succeeded(T data)
		=> new() { IsSuccess = true, Data = data };

	public static ServiceResult<T> Failed(string message, int statusCode)
		=> new() { IsSuccess = false, Message = message, StatusCode = statusCode };
}
