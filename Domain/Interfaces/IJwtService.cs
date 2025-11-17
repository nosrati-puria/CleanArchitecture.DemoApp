using Domain.Entities;

namespace Domain.Interfaces;

public interface IJwtService
{
	string GenerateToken(Employee employee);
}