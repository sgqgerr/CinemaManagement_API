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
    public class SalesController : ControllerBase
    {
        private CinemaManagementDbContext cinemaManagementDbContext;
        private readonly IMapper _mapper;
        SalesController(CinemaManagementDbContext cinemaManagementDbContext, IMapper mapper)
        {
            this.cinemaManagementDbContext = cinemaManagementDbContext;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(AddSalesModel sales)
        {

            cinemaManagementDbContext.Sales.Add(_mapper.Map<Sales>(sales));

            cinemaManagementDbContext.SaveChanges();

            return Created();

        }

        [HttpGet("Read")]
        public IActionResult Read()
        {

            return Ok(cinemaManagementDbContext.Sales.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (cinemaManagementDbContext.Sales.Find(id) == null)
            {
                return NotFound();
            }

            return Ok(cinemaManagementDbContext.Sales.Find(id));
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            if (cinemaManagementDbContext.Sales.Find(id) == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (cinemaManagementDbContext.Sales.Find(id) == null)
            {
                return NotFound();
            }

            cinemaManagementDbContext.Remove(id);

            cinemaManagementDbContext.SaveChanges();

            return NoContent();
        }
    }
}
