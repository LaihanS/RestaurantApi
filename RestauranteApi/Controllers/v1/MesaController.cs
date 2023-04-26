using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Enums;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Mesa;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Infrastructure.Shared.Services;
using System.Data;

namespace RestauranteApi.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    
    public class MesaController : BaseApiController
    {
        private readonly IMesaService mesaService;
        private readonly IMapper imapper;

        public MesaController(IMapper imapper, IMesaService mesaService)
        {
            this.imapper = imapper;
            this.mesaService = mesaService;
        }

        [Authorize(Roles = "Administrador, Mesero")]
        [HttpGet("mesa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MesaViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMesaByID(int id)
        {
            try
            {
                var orden = await mesaService.GetEditAsync(id);

                if (orden == null)
                {
                    return NotFound();
                }

                return Ok(orden);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddMesa(SaveMesaDto vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                vm.Estado = EnumOrderStates.Proceso.ToString();
                await mesaService.AddAsync(imapper.Map<SaveMesaViewModel>(vm)); ;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [Authorize(Roles = "Administrador")]
        [HttpPut("mesaupdate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveMesaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutM(int id, string description, int cantidad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                SaveMesaViewModel mesa = await mesaService.GetEditAsync(id);
                mesa.Descipcion = description;
                mesa.Cantidad = cantidad;
                await mesaService.EditAsync(mesa, mesa.id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("deletemesa/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                SaveMesaViewModel ing = await mesaService.GetEditAsync(id);
                await mesaService.Delete(ing, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("mesaorders/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders(int id)
        {
            try
            {
                List<OrdenViewModel> ing = await mesaService.GetOrdersAsync(id);

                return Ok(ing.Where(o => o.Estado == "En Proceso" || o.Estado == "Proceso"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("changestatus/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeMesaStatus(int id, string newstatus)
        {
            try
            {
                await mesaService.ChangeStatus(id, newstatus);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrador, Mesero")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MesaViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await mesaService.GetAsync();

                if (orders == null || orders.Count == 0)
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
