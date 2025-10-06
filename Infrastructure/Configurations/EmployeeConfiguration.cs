using Domain.Shared;
using Domain.Entities;
using Domain.Shared.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class EmployeeConfiguration() : BaseConfiguration<Employee>
{
	public override void Configure(EntityTypeBuilder<Employee> builder)
	{
		base.Configure(builder);

		//*************************

		#region FullName
		builder
			.Property(current => current.FullName)
			.IsUnicode(unicode: true)
			.IsRequired(required: true)
			.IsFixedLength(fixedLength: false)
			.HasColumnName(name: nameof(DataDictionary.FullName))
			.HasMaxLength(maxLength: Utility.Const.FullNameMaxLength)
			;

		builder
			.HasIndex(current => current.FullName)
			.IsUnique(unique: true)
			;
		#endregion /FullName

		//*************************

		#region Email
		builder
			.Property(current => current.Email)
			.IsRequired(required: true)
			.HasMaxLength(Utility.Const.EmailMaxLength)
			.HasColumnName(name: nameof(DataDictionary.EmailAddress))
			;

		builder
			.HasIndex(current => current.Email)
			.IsUnique(unique: true)
			;

		builder
			.HasMany(current => current.LeaveRequests)
			.WithOne(other => other.Employee)
			.HasForeignKey(current => current.EmployeeId)
			;

		#endregion /Email

		//*************************
	}
}