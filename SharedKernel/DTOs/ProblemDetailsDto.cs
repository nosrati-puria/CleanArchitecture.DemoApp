namespace SharedKernel.DTOs;

public class ProblemDetailsDto()
{
	/// <summary>
	/// نوع
	/// </summary>
	public string? Type { get; set; }


	/// <summary>
	/// عنوان
	/// </summary>
	public string? Title { get; set; }


	/// <summary>
	/// جزییات
	/// </summary>
	public string? Detail { get; set; }


	/// <summary>
	/// وضعیت
	/// </summary>
	public int? Status { get; set; }
}