using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Core.Application.ViewModels.UserVMS;
using RestauranteApi.Core.Domain.Entities;
using RestauranteApi.Infrastructure.Shared.Services;

namespace RestauranteApi.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Administrador")]
    public class IngredientController : BaseApiController
    {
        private readonly IIngredienteService ingredienteService;
        private readonly IMapper imapper;

        public IngredientController(IMapper imapper, IIngredienteService ingredienteService)
        {
            this.imapper = imapper;
            this.ingredienteService = ingredienteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IngredienteViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ingredients = await ingredienteService.GetAsync();

                if (ingredients == null || ingredients.Count == 0)
                {
                    return NotFound();
                }

                return Ok(ingredients);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getingredientbyid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveIngredientDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ingredientDto = await ingredienteService.GetEditAsync(id);

                if (ingredientDto == null)
                {
                    return NotFound();
                }

                return Ok(ingredientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(SaveIngredientDto vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                SaveIngredientDto data = imapper.Map<SaveIngredientDto>(await ingredienteService.AddAsync(imapper.Map<SaveIngredienteViewModel>(vm)));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("updateingredientvalues/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveIngredientDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, SaveIngredientDto vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await ingredienteService.EditAsync(imapper.Map<SaveIngredienteViewModel>(vm), id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("deleteingredient/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                SaveIngredienteViewModel ing = await ingredienteService.GetEditAsync(id);
                await ingredienteService.Delete(ing, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
