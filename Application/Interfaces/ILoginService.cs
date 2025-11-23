using SharedKernel.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ILoginService
{
	Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
}