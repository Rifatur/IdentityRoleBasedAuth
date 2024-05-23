using RoleBaseAuth.Models.DTOs;

namespace RoleBaseAuth.Repositories.Services
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(Registration model);
        Task LogoutAsync();
    }
}
