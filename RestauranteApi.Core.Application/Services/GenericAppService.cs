
using AutoMapper;
using RestauranteApi.Core.Application.IServices;
using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApi.Core.Application.Services
{
    public class GenericAppService<ViewModel, SaveViewModel, Entity> :  IGenericAppService<ViewModel, SaveViewModel, Entity> where Entity : class
        where ViewModel : class
         where SaveViewModel : class
    {
        private readonly IGenericAppRepository<Entity> repository;
        private readonly IMapper automapper;

        public GenericAppService(IMapper automapper, IGenericAppRepository<Entity> repository)
        {

            this.repository = repository;
            this.automapper = automapper;
        }


        public virtual async Task<SaveViewModel> AddAsync(SaveViewModel vm)
        {
            Entity usuario = automapper.Map<Entity>(vm);

            usuario = await repository.AddAsync(usuario);

            SaveViewModel saveUser = automapper.Map<SaveViewModel>(usuario);

            return saveUser;
        }


        public virtual async Task<List<ViewModel>> GetAsync()
        {
            var usuarioslist = await repository.GetAsync();

            List<ViewModel> listvm = automapper.Map<List<ViewModel>>(usuarioslist);

            return listvm;

        }

        public virtual async Task<SaveViewModel> GetEditAsync(int id)
        {

            var usuario = await repository.GetByidAsync(id);

            SaveViewModel saveUser = automapper.Map<SaveViewModel>(usuario);

            return saveUser;

        }

        public virtual async Task Delete(SaveViewModel vm, int id)
        {
            Entity usuario = await repository.GetByidAsync(id);
            await repository.DeleteAsync(usuario);
        }

        public virtual async Task EditAsync(SaveViewModel vm, int id)
        {
            Entity usuario = await repository.GetByidAsync(id);
            //string encryptedPassword = PasswordEncrypter.PassHasher(vm.Contraseña);

            usuario = automapper.Map<Entity>(vm);

            await repository.EditAsync(usuario, id);
        }
    }
}
