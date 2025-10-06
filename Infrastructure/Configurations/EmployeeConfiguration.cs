using Domain.Entities;
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
			.HasColumnName(name: nameof(Domain.Shared.Resources.DataDictionary.FullName))
			.IsRequired(required: true)
			.IsUnicode(unicode: true)
			.IsFixedLength(fixedLength: false)
			.HasMaxLength(maxLength: Domain.Shared.Utility.Const.FullNameMaxLength)
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
		;
		#endregion /Email

		//*************************
	}
}