using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using DataAccess.Entities;
using CinemaManagement_API.Models;
using AutoMapper;
namespace CinemaManagement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private CinemaManagementDbContext cinemaManagementDbContext;
        private readonly IMapper _mapper;
        FilmsController(CinemaManagementDbContext cinemaManagementDbContext, IMapper mapper)
        {
            this.cinemaManagementDbContext = cinemaManagementDbContext;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(AddFilmModel film)
        {

            cinemaManagementDbContext.Films.Add(_mapper.Map<Film>(film));

            cinemaManagementDbContext.SaveChanges();

            return Created();

        }

        [HttpGet("Read")]
        public IActionResult Read()
        {

            return Ok(cinemaManagementDbContext.Films.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if(cinemaManagementDbContext.Films.Find(id) == null)
            {
                return NotFound();
            }

            return Ok(cinemaManagementDbContext.Films.Find(id));
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            if (cinemaManagementDbContext.Films.Find(id) == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string id) 
        {
            if (cinemaManagementDbContext.Films.Find(id) == null)
            {
                return NotFound();
            }

            cinemaManagementDbContext.Remove(id);

            cinemaManagementDbContext.SaveChanges();

            return NoContent();
        }

    }
}
