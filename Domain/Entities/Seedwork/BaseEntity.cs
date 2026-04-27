using System;
using Domain.Shared.Resources;
using Domain.Shared.Resources.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Seedwork;

public abstract class BaseEntity
{
	#region Constructor

	/// <summary>
	/// Constructor
	/// </summary>
	protected BaseEntity()
	{
		Id = Guid.NewGuid();
		InsertDateTime = DateTime.Now;
	}

	#endregion /Constructor

	//*************************

	#region Id

	/// <summary>
	/// شناسه
	/// </summary>
	[Key]
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	[Display(Name = nameof(DataDictionary.Id), ResourceType = typeof(DataDictionary))]
	public Guid Id { get; private set; }

	#endregion /Id

	//*************************

	#region InsertDateTime

	/// <summary>
	/// زمان درج
	/// </summary>
	[Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Validations),
		ErrorMessageResourceName = nameof(Validations.Required))]
	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	[Display(Name = nameof(DataDictionary.InsertDateTime), ResourceType = typeof(DataDictionary))]
	public DateTimeOffset InsertDateTime { get; private set; }

	#endregion /InsertDateTime

	//*************************
}