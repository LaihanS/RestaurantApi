using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using RestauranteApi.Core.Application.Dtos.Account;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Enums;
using RestauranteApi.Core.Application.IServices;
using RestauranteApi.Core.Application.ViewModels.UserVMS;
using RestauranteApi.Infrastructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper imapper;
        private readonly IUserRepository userRepository;
        //private readonly IProductRepository productRepository;
        IHttpContextAccessor httpContextAccessor;
        AuthenticationResponse User = new();

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor,IMapper imapper, IAccountService accountService)
        {
            this.httpContextAccessor = httpContextAccessor;
            //User = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            this.userRepository = userRepository;
            _accountService = accountService;
        }


        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            List<UserViewModel> userlist = imapper.Map<List<UserViewModel>>(await userRepository.GetAsync());
            return userlist;

        }

        public async Task<List<UserViewModel>> ActiveClients()
        {
            List<UserViewModel> userlist = imapper.Map<List<UserViewModel>>(await userRepository.GetAsync());
            List<string> userids = new();

            if (userlist != null)
            {
                foreach (UserViewModel viewmodel in userlist)
                {
                    userids.Add(viewmodel.Id);
                }
            }

            List<UserViewModel> userlistas = await _accountService.GetUsers(userids);

            List<UserViewModel> clients = new();

            clients = userlistas.Where(u => u.EmailConfirmed == true && u.Roles.Any(r => r.Equals(EnumRoles.Mesero.ToString()))).ToList();


            return clients;

        }


        public async Task<List<UserViewModel>> UnactiveClients()
        {
            List<UserViewModel> userlist = imapper.Map<List<UserViewModel>>(await userRepository.GetAsync());
            List<string> userids = new();

            if (userlist != null)
            {
                foreach (UserViewModel viewmodel in userlist)
                {
                    userids.Add(viewmodel.Id);
                }
            }

            List<UserViewModel> userlistas = await _accountService.GetUsers(userids);

            List<UserViewModel> clients = new();

            clients = userlistas.Where(u => u.EmailConfirmed == false && u.Roles.Any(r => r.Equals(EnumRoles.Mesero.ToString()))).ToList();

            return clients;

        }


        public async Task<List<UserViewModel>> GetAllUsersAsyncJoined()
        {
            List<UserViewModel> userlist = imapper.Map<List<UserViewModel>>(await userRepository.GetAsync());
            List<string> userids = new();

            foreach (UserViewModel viewmodel in userlist)
            {
                userids.Add(viewmodel.Id);
            }

            List<UserViewModel> userlistas = await _accountService.GetUsers(userids);
            List<UserViewModel> users = userlistas.Where(users => users.Id != User.id).ToList();
            return users;

        }


        public async Task ActivateOrInactivate(string id)
        {
            await _accountService.ActivateOrInactivateUser(id);
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel loginvm)
        {

            AuthenticationRequest loginrequest = imapper.Map<AuthenticationRequest>(loginvm);

            AuthenticationResponse authenticationResponse = await _accountService.AuthAsync(loginrequest);

            return authenticationResponse;

        }

        public async Task SignOutAsync()
        {
            await _accountService.SingOutAsync();
        }

        public async Task DeleteUserAsync(UserViewModel user)
        {
          
            await userRepository.DeleteAsync(imapper.Map<UserDTO>(user), user.Id);


        }


        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel saveuservm, string origin)
        {
     
            RegisterRequest registerRequest = imapper.Map<RegisterRequest>(saveuservm);

            RegisterResponse response = await _accountService.RegisterBasicUserAsync(registerRequest, origin, saveuservm.IsAdmin);

            return response;
        }

        public async Task EditUser(SaveUserViewModel uservmsave)
        {
            await userRepository.EditAsync(imapper.Map<UserDTO>(uservmsave), uservmsave.Id);

            await _accountService.EditUser(imapper.Map<UserViewModel>(uservmsave));
        }

        public async Task<SaveUserViewModel> GetEditAsync(string id)
        {
            UserViewModel user = imapper.Map<UserViewModel>(await userRepository.GetByidAsync(id));

            return imapper.Map<SaveUserViewModel>(user);
        }


        public async Task<string> ConfirmAsync(string userid, string token)
        {
            return await _accountService.ConfirmUserAsync(userid, token);
        }

        public async Task<ForgotPassworResponse> ForgotPasswordAsync(ForgotPasswordViewModel forgotPasswordvm, string origin)
        {
            ForgotPassworRequest forgotPassworRequest = imapper.Map<ForgotPassworRequest>(forgotPasswordvm);

            return await _accountService.ForgotPasswordAsync(forgotPassworRequest, origin);
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel resetPasswordvm, string origin)
        {
            ResetPasswordRequest resetPassworRequest = imapper.Map<ResetPasswordRequest>(resetPasswordvm);

            return await _accountService.ResetPasswordAsync(resetPassworRequest);
        }
    }
}

