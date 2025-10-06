using Domain.Shared.Resources;
using Domain.Entities.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class BaseConfiguration<T> : IEntityTypeConfiguration<T>
	where T : class
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		#region Id
		builder
			.HasKey(nameof(BaseEntity.Id))
			.IsClustered(clustered: false)
		;
		#endregion /Id

		//*************************

		#region InsertDateTime
		builder
			.Property(nameof(BaseEntity.InsertDateTime))
			.HasColumnName(name: nameof(DataDictionary.InsertDateTime))
		;
		#endregion /InsertDateTime
	}
}