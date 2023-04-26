using RestauranteApi.Core.Application.Dtos.Account;
using RestauranteApi.Core.Application.ViewModels.UserVMS;

namespace RestauranteApi.Core.Application.IServices
{
    public interface IUserService
    {
        Task ActivateOrInactivate(string id);
        Task<List<UserViewModel>> ActiveClients();
        Task<string> ConfirmAsync(string userid, string token);
        Task DeleteUserAsync(UserViewModel user);
        Task EditUser(SaveUserViewModel uservmsave);
        Task<ForgotPassworResponse> ForgotPasswordAsync(ForgotPasswordViewModel forgotPasswordvm, string origin);
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<List<UserViewModel>> GetAllUsersAsyncJoined();
        Task<SaveUserViewModel> GetEditAsync(string id);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel loginvm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel saveuservm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel resetPasswordvm, string origin);
        Task SignOutAsync();
        Task<List<UserViewModel>> UnactiveClients();
    }
}