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

		builder.ToTable(name: nameof(Role), schema: "HR");

		//*************************

		#region Number

		builder
			.Property(current => current.Number)
			.IsRequired(required: true)
			.HasColumnName(name: nameof(DataDictionary.RoleNumber))
			;

		builder
			.HasIndex(current => current.Number)
			.IsClustered(clustered: false)
			;

		#endregion /Number

		//*************************

		#region Name

		builder
			.Property(current => current.Number)
			.IsUnicode(unicode: false)
			.IsFixedLength(fixedLength: false)
			.HasColumnName(name: nameof(DataDictionary.RoleName))
			.HasMaxLength(maxLength: Utility.Const.RoleNameMaxLength)
			;

		#endregion /Name

		//*************************

		#region Employees

		builder
			.HasMany(current => current.Employees)
			.WithOne(current => current.Role)
			.HasForeignKey(current => current.RoleId)
			;

		#endregion /Employees

		//*************************
	}
}