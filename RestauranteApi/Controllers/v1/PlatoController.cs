using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Enums;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Core.Application.ViewModels.Plato;
using RestauranteApi.Infrastructure.Shared.Services;
using System.Data;

namespace RestauranteApi.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Administrador")]
    public class PlatoController : BaseApiController
    {
        private readonly IPlatoService platoService;
        private readonly IMapper imapper;

        public PlatoController(IPlatoService platoService, IMapper imapper)
        {
            this.imapper = imapper;
            this.platoService = platoService;
        }


        [HttpPut("updateplato/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SavePlatoDto))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SavePlatoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutOrder(SavePlatoDto savePlato, string addorquit, int id, int ingredienteid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await platoService.EditPlat(imapper.Map<SavePlatoViewModel>(savePlato), addorquit, id, ingredienteid);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlatoViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPlatos()
        {
            try
            {
                var platos = await platoService.JoinPlatos();

                if (platos == null || platos.Count == 0)
                {
                    return NotFound();
                }

                return Ok(platos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getplatobyid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlatoViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdPlato(int id)
        {
            try
            {
                var plato = await platoService.GetByidJoin(id);

                if (plato == null)
                {
                    return NotFound();
                }

                return Ok(plato);
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
        public async Task<IActionResult> PostPlato(SavePlatoDto vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await platoService.AddAsync(imapper.Map<SavePlatoViewModel>(vm));
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("deleteplato/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePlato(int id)
        {
            try
            {
                SavePlatoViewModel ing = await platoService.GetEditAsync(id);
                await platoService.Delete(ing, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
