using Domain.Entities;
using Domain.Shared.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class LeaveRequestConfiguration() : BaseConfiguration<LeaveRequest>
{
	public override void Configure(EntityTypeBuilder<LeaveRequest> builder)
	{
		base.Configure(builder);

		//***********************************************

		#region EmployeeId
		builder
			.Property(current => current.EmployeeId)
			.IsRequired(required: true)
			;
		#endregion /EmployeeId

		//***********************************************

		#region FromDate
		builder
			.Property(current => current.FromDate)
			.IsRequired(required: true)
			;
		#endregion /FromDate

		//***********************************************

		#region ToDate
		builder
			.Property(current => current.ToDate)
			.IsRequired(required: true)
			;
		#endregion /ToDate

		//***********************************************

		#region Reason
		builder
			.Property(current => current.Reason)
			.IsRequired(required: true)
			.IsUnicode(unicode: true)
			.IsFixedLength(fixedLength: false)
			.HasMaxLength(maxLength: Domain.Shared.Utility.Const.ReasonMaxLength)
			;
		#endregion /Reason

		//***********************************************

		#region Status
		builder
			.Property(current => current.Status)
			.HasColumnName(name: nameof(DataDictionary.Status))
			;
		#endregion /Status

		//***********************************************
	}
}