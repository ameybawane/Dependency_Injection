using DI.Data;
using DI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IRepo _repo;

        public SuperHeroController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAllSuperHero<SuperHero>());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetSuperHeroById<SuperHero>(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post (SuperHero s)
        {
            var result = _repo.AddSuperHero(s);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SuperHero s)
        {
            if (id != s.Id || id <= 0) return BadRequest();
            var result = _repo.UpdateSuperHero<SuperHero>(s);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _repo.GetSuperHeroById<SuperHero>(id);
            if (result == null) return NotFound();
            _repo.DeleteSuperHeroById<SuperHero>(id);
            return Ok(result);
        }
    }
}
