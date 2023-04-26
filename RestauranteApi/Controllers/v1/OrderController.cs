using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Core.Application.Dtos.DtosExtra;
using RestauranteApi.Core.Application.Enums;
using RestauranteApi.Core.Application.Services;
using RestauranteApi.Core.Application.ViewModels.Ingrediente;
using RestauranteApi.Core.Application.ViewModels.Mesa;
using RestauranteApi.Core.Application.ViewModels.Orden;
using RestauranteApi.Infrastructure.Shared.Services;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestauranteApi.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Mesero")]
    public class OrderController : BaseApiController
    {
        private readonly IOrdenService ordenService;
        private readonly IMapper imapper;

        public OrderController(IMapper imapper, IOrdenService ordenService)
        {
            this.imapper = imapper;
            this.ordenService = ordenService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrdenViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                List<OrdenViewModel> orders = await ordenService.GetAllJoin();

                if (orders == null || orders.Count == 0)
                {
                    return NotFound();
                }

                //var configs = new JsonSerializerOptions
                //{
                //    ReferenceHandler = ReferenceHandler.Preserve,
                //};

                //var serialized = JsonSerializer.Serialize(orders, configs);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getorderbyid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrdenViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdOrder(int id)
        {
            try
            {
                var orden = await ordenService.GetOrderJoin(id);

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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostOr(SaveOrderDto vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                vm.Estado = EnumOrderStates.Proceso.ToString();
                await ordenService.AddAsync(imapper.Map<SaveOrderViewModel>(vm)); ;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveOrderDto))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveOrderDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutOrder(string addorquit, int platoid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await ordenService.EditPlat(addorquit, platoid);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("deleteorder/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                SaveOrderViewModel ing = await ordenService.GetEditAsync(id);
                await ordenService.Delete(ing, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
