using System;
using Domain.Enums;
using Domain.Shared;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class LeaveRequest() : Seedwork.BaseEntity
{
	#region EmployeeId

	/// <summary>
	/// شناسه کارمندی
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public Guid EmployeeId { get; set; }
	public virtual Employee? Employee { get; set; } = null!;

	#endregion EmployeeId

	//**************************************************

	#region FromDate

	/// <summary>
	/// از تاریخِ
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	public DateTime FromDate { get; set; }

	#endregion /FromDate

	//**************************************************

	#region ToDate

	/// <summary>
	/// تا تاریخِ
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	public DateTime ToDate { get; set; }

	#endregion /ToDate

	//**************************************************

	#region Reason

	/// <summary>
	/// علت مرخصی
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[StringLength
		(maximumLength: Utility.Const.ReasonMaxLength,
		MinimumLength = Utility.Const.ReasonMinLength,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.StringLength))]
	public string Reason { get; set; } = null!;

	#endregion /Reason

	//**************************************************

	#region Status

	/// <summary>
	/// وضعیت
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

	#endregion /Status

	//**************************************************

	#region SubstituteEmployeeId

	/// <summary>
	/// کارمند جایگزین
	/// </summary>
	public Guid? SubstituteEmployeeId { get; set; }

	#endregion /SubstituteEmployeeId

	//**************************************************
}