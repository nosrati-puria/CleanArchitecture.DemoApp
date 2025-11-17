using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
	#region Constructor

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
		Database.EnsureDeleted();
		Database.EnsureCreated();
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
	}

	#endregion /Methods
}