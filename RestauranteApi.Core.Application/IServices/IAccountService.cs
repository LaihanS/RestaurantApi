using RestauranteApi.Core.Application.Dtos.Account;
using RestauranteApi.Core.Application.ViewModels.UserVMS;

namespace RestauranteApi.Core.Application.IServices
{
    public interface IAccountService
    {
        Task ActivateOrInactivateUser(string id);
        Task<AuthenticationResponse> AuthAsync(AuthenticationRequest request);
        Task<string> ConfirmUserAsync(string userid, string token);
        Task EditUser(UserViewModel edituser);
        Task<ForgotPassworResponse> ForgotPasswordAsync(ForgotPassworRequest request, string origin);
        Task<List<UserViewModel>> GetUsers(List<string> userids);
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest request, string origin, bool IsAdmin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest reset);
        Task SingOutAsync();
    }
}