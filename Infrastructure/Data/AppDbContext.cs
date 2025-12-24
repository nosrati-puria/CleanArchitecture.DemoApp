using Domain.Shared;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
	#region Constructor

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
		Database.Migrate();
	}

	#endregion /Constructor


	#region Properties

	public DbSet<Employee> Employees { get; set; } = null!;
	public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;
	public DbSet<Role> Roles { get; set; } = null!;

	#endregion /Properties


	#region Methods

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder
			.ApplyConfigurationsFromAssembly
				(assembly: typeof(AppDbContext).Assembly);

		modelBuilder
			.Entity<Employee>(entity =>
			{
				entity.HasKey(employee => employee.Id);

				entity
				  .HasOne(employee => employee.Role)
				  .WithMany(role => role.Employees)
				  .HasForeignKey(employee => employee.RoleId);
			});

		modelBuilder
			.Entity<LeaveRequest>(entity =>
			{
				entity.HasKey(leaveRequest => leaveRequest.Id);

				entity
				  .HasOne(leaveRequest => leaveRequest.Employee)
				  .WithMany(employee => employee.LeaveRequests)
				  .HasForeignKey(leaveRequest => leaveRequest.EmployeeId);
			});

		var role = new Role
		{
			Number = Domain.Enums.Role.Manager,
			Description = "Seed data for manager",
		};

		modelBuilder
			.Entity<Role>()
			.HasData(role);

		modelBuilder
			.Entity<Employee>()
			.HasData(new Employee
			{
				Username = "puria.nosrati",
				Password = Utility.Hasher.GetHash(input: "12345678"),
				FullName = "Puria Nosrati",
				Email = "nosrati.puria@gmail.com",
				CellPhoneNumber = "09356685894",
				RoleId = role.Id,
			});
	}

	#endregion /Methods
}