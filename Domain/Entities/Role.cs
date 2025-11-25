using Domain.Shared;
using Domain.Shared.Resources;
using System.Collections.Generic;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Role() : Seedwork.BaseEntity
{
	#region Name

	/// <summary>
	/// نام نقش
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[Display(Name = nameof(DataDictionary.RoleName))]
	public Enums.RolesName Name { get; set; }

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

	#region Description

	/// <summary>
	///	لیست کارمندان
	/// </summary>
	public virtual IList<Employee> Employees { get; set; } = [];

	#endregion /Description

	//**************************************************

}