using Domain.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum Role
{
	/// <summary>
	/// برنامه نویس
	/// </summary>
	[Display(Description = nameof(DataDictionary.Developer))]
	Developer = 0,


	/// <summary>
	/// مدیر
	/// </summary>
	[Display(Description = nameof(DataDictionary.Manager))]
	Manager = 1,


	/// <summary>
	/// کارمند
	/// </summary>
	[Display(Description = nameof(DataDictionary.Employee))]
	Employee = 2,
}