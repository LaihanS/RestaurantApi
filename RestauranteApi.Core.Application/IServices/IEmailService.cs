using RestauranteApi.Core.Application.Dtos.Email;

namespace RestauranteApi.Core.Application.IServices
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest email);
    }
}