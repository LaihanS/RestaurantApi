namespace RestauranteApi.Core.Application.Services
{
    public interface IGenericAppService<Dto, SaveViewModel, Entity>
        where Dto : class
        where SaveViewModel : class
           where Entity :class
    {
        Task<SaveViewModel> AddAsync(SaveViewModel vm);
        Task Delete(SaveViewModel vm, int id);
        Task EditAsync(SaveViewModel vm, int id);
        Task<List<Dto>> GetAsync();
        Task<SaveViewModel> GetEditAsync(int id);
    }
}