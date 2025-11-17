using System;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
	Task SaveChangesAsync();

	Task AddAsync(Employee employee);

	Task<List<Employee>> GetAllAsync();

	Task<Employee?> GetByIdAsync(Guid id);

	Task<Employee?> GetByUsername(string username);

	Task CreateAsync(string username, string password, Role role);

	Task UpdateAsync(Employee employee);

	Task DeleteAsync(Guid id);
}
