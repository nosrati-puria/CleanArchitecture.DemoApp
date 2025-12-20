using Domain.Shared;
using System.Reflection;
using Domain.Shared.Resources;
using System.Collections.Generic;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Role() : Seedwork.BaseEntity
{
	#region Number

	/// <summary>
	/// شماره نقش
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.RoleNumber))]
	public Enums.Role Number { get; set; }

	#endregion /Number

	//**************************************************

	#region Name
	/// <summary>
	/// نام نقش
	/// </summary>

	[NotMapped]
	[Display(Name = nameof(DataDictionary.RoleName))]
	public string? Name
	{
		get
		{
			var name =
				Number.GetType().GetField(Number.ToString())?
					.GetCustomAttribute<DisplayAttribute>()?.Description;

			return name;
		}
	}

	#endregion /Name

	//**************************************************

	#region Description

	/// <summary>
	/// توضیحات نقش
	/// </summary>
	[StringLength
		(maximumLength: Utility.Const.DescriptionMaxLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	[Display(Name = nameof(DataDictionary.Description))]
	public string Description { get; set; } = null!;

	#endregion /Description

	//**************************************************

	#region Employees

	/// <summary>
	///	لیست کارمندان
	/// </summary>
	public virtual IList<Employee> Employees { get; set; } = [];

	#endregion /Employees

	//**************************************************

}