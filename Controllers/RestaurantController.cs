using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Entities;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly Services.IRestaurantService _IrestaurantService;
        public RestaurantController(Services.IRestaurantService service)
        {
            _IrestaurantService = service;
        }

        [HttpPut("{id}")]
        public ActionResult Modify([FromRoute] int id, [FromBody] UpdateRestaurantDTO dto)
        {
            _IrestaurantService.Modify(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _IrestaurantService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDTO dto)
        {
            var id = _IrestaurantService.Create(dto);
            return Created($"/api/restaurants/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDTO>> GetAll()
        {
            var restaurantsDTO = _IrestaurantService.GetAll();
            return StatusCode(200, restaurantsDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDTO> Get([FromRoute] int id)
        {
            var restaurant = _IrestaurantService.GetById(id);
            if(restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
    }
}
