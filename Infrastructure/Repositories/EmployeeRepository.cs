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
		var entity =
			_appDbContext.SaveChangesAsync();

		await entity;
	}

	public async Task AddAsync(Employee employee)
	{
		var entity =
			_appDbContext.Employees.AddAsync(entity: employee);

		await entity;
	}

	public async Task<List<Employee>> GetAllAsync()
	{
		var emplyeesList = await
			_appDbContext.Employees
				.Include(current => current.LeaveRequests)
				.ToListAsync();

		return emplyeesList;
	}

	public async Task<Employee?> GetByIdAsync(Guid id)
	{
		var emplyee = await
			_appDbContext.Employees
				.Include(current => current.LeaveRequests)
				.FirstOrDefaultAsync(current => current.Id == id);

		return emplyee;
	}

	public async Task<Employee?> GetByUsername(string username)
	{
		var emplyee = await
			_appDbContext.Employees
				.Include(current => current.Role)
				.FirstOrDefaultAsync(current => current.Username == username);

		return emplyee;
	}

	public async Task CreateAsync(Employee employee)
	{
		var alreadyExist = await
			_appDbContext.Employees
				.AnyAsync(current => current.Username == employee.Username);

		if (alreadyExist)
		{
			throw new Exception(Domain.Shared.Resources.Messages.Errors.AlreadyExists);
		}

		await AddAsync(employee);
		await SaveChangesAsync();
	}

	public async Task UpdateAsync(Employee employee)
	{
		var oldEmployee = await
			_appDbContext.Employees
				.FindAsync(employee.Id);

		if (oldEmployee is null)
		{
			throw new Exception(Domain.Shared.Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);
		}

		oldEmployee.Username = employee.Username;
		oldEmployee.Password = employee.Password;
		oldEmployee.FullName = employee.FullName;
		oldEmployee.Email = employee.Email;
		oldEmployee.CellPhoneNumber = employee.CellPhoneNumber;

		await SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		var employee = await
			_appDbContext.Employees
				.FindAsync(id);

		if (employee is null)
		{
			throw new Exception(Domain.Shared.Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);
		}

		_appDbContext.Employees.Remove(entity: employee);
	}

	#endregion /Methods
}