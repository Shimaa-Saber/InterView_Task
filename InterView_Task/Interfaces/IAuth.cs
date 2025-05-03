using InterView_Task.DTOs.Auth;
using InterView_Task.GeneralResponse;
using Microsoft.AspNetCore.Identity;

namespace InterView_Task.Interfaces
{
    public interface IAuth
    {
        Task<IdentityResult> RegisterUserAsync(RegisterDto userFromConsumer);
        Task<LoginResponse> LoginUserAsync(LoginDto userFromConsumer);
    }
}
