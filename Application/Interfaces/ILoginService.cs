using SharedKernel;
using SharedKernel.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ILoginService
{
	Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto request);
}