using System;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository(AppDbContext appDbContext) : IEmployeeRepository
{
	#region Properties

	private readonly AppDbContext _appDbContext = appDbContext;

	#endregion /Properties

	#region Methods

	public async Task SaveChangesAsync()
	{
		await _appDbContext.SaveChangesAsync();
	}

	public async Task AddAsync(Employee employee)
	{
		await _appDbContext.Employees.AddAsync(entity: employee);
	}

	public async Task<List<Employee>> GetAllAsync()
	{
		return await
			_appDbContext.Employees
				.Include(current => current.LeaveRequests)
				.ToListAsync();
	}

	public async Task<Employee?> GetByIdAsync(Guid id)
	{
		return await
			_appDbContext.Employees
				.Include(current => current.LeaveRequests)
				.FirstOrDefaultAsync(current => current.Id == id);
	}

	#endregion /Methods
}