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

		//**************************************************

		#region Username

		builder
			.Property(current => current.Username)
			.IsUnicode(unicode: false)
			.IsRequired(required: true)
			.IsFixedLength(fixedLength: false)
			.HasColumnName(name: nameof(DataDictionary.Username))
			.HasMaxLength(maxLength: Utility.Const.UsernameMaxLength)
			;

		builder
			.HasIndex(current => current.Username)
			.IsUnique(unique: true)
			;

		#endregion /Username

		//**************************************************

		#region Password

		builder
			.Property(current => current.Password)
			.IsUnicode(unicode: false)
			.IsRequired(required: true)
			.IsFixedLength(fixedLength: false)
			.HasColumnName(name: nameof(DataDictionary.Password))
			.HasMaxLength(maxLength: Utility.Const.PasswordMaxLength)
			;

		#endregion /Password

		//**************************************************

		#region FullName

		builder
			.Property(current => current.FullName)
			.IsUnicode(unicode: true)
			.IsRequired(required: false)
			.IsFixedLength(fixedLength: false)
			.HasColumnName(name: nameof(DataDictionary.FullName))
			.HasMaxLength(maxLength: Utility.Const.FullNameMaxLength)
			;

		builder
			.HasIndex(current => current.FullName)
			.IsUnique(unique: false)
			;

		#endregion /FullName

		//**************************************************

		#region Email

		builder
			.Property(current => current.Email)
			.IsRequired(required: false)
			.HasMaxLength(Utility.Const.EmailMaxLength)
			.HasColumnName(name: nameof(DataDictionary.EmailAddress))
			;

		builder
			.HasIndex(current => current.Email)
			.IsUnique(unique: true)
			;

		#endregion /Email

		//**************************************************

		#region CellPhoneNumber

		builder
			.Property(current => current.CellPhoneNumber)
			.IsRequired(required: false)
			.HasColumnName(name: nameof(DataDictionary.CellPhoneNumber))
			;

		builder
			.HasIndex(current => current.CellPhoneNumber)
			.IsUnique(unique: true)
			;

		#endregion /CellPhoneNumber

		//**************************************************

		#region LeaveRequests

		builder
			.HasMany(current => current.LeaveRequests)
			.WithOne(other => other.Employee)
			.HasForeignKey(current => current.EmployeeId)
			;

		#endregion /LeaveRequests
	}
}