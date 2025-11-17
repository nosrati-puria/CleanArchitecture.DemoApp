using Domain.Shared;
using Domain.Entities;
using Domain.Shared.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class RoleConfiguration() : BaseConfiguration<Role>
{
	public override void Configure(EntityTypeBuilder<Role> builder)
	{
		base.Configure(builder);

		//**************************************************

		#region Name

		builder
			.Property(current => current.Name)
			.IsUnicode(unicode: false)
			.IsRequired(required: true)
			.IsFixedLength(fixedLength: false)
			.HasColumnName(name: nameof(DataDictionary.RoleName))
			.HasMaxLength(maxLength: Utility.Const.RoleNameMaxLength)
			;

		builder
			.HasIndex(current => current.Name)
			.IsUnique(unique: true)
			;

		#endregion /Name

		//**************************************************

		#region Employees

		builder
			.HasMany(current => current.Employees)
			.WithOne(current => current.Role)
			.HasForeignKey(current => current.RoleId)
			;

		#endregion /Employees
	}
}