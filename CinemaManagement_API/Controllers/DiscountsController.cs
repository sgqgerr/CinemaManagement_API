using AutoMapper;
using CinemaManagement_API.Models;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private CinemaManagementDbContext cinemaManagementDbContext;
        private readonly IMapper _mapper;
        DiscountsController(CinemaManagementDbContext cinemaManagementDbContext, IMapper mapper)
        {
            this.cinemaManagementDbContext = cinemaManagementDbContext;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(AddDiscountModel discount)
        {

            cinemaManagementDbContext.Discounts.Add(_mapper.Map<Discount>(discount));

            cinemaManagementDbContext.SaveChanges();

            return Created();

        }

        [HttpGet("Read")]
        public IActionResult Read()
        {

            return Ok(cinemaManagementDbContext.Discounts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (cinemaManagementDbContext.Discounts.Find(id) == null)
            {
                return NotFound();
            }

            return Ok(cinemaManagementDbContext.Discounts.Find(id));
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            if (cinemaManagementDbContext.Discounts.Find(id) == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (cinemaManagementDbContext.Discounts.Find(id) == null)
            {
                return NotFound();
            }

            cinemaManagementDbContext.Remove(id);

            cinemaManagementDbContext.SaveChanges();

            return NoContent();
        }
    }
}
