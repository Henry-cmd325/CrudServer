using ApiRestJavascript.Data;
using ApiRestJavascript.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestJavascript.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [EnableCors("permitir")]
    public class CervezaController : ControllerBase
    {
        private readonly ICervezaRepository repo;

        public CervezaController(ICervezaRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cerveza>> GetAll()
        {
            return Ok(repo.GetAllCervezas());
        }

        [HttpGet("{id}", Name = "GetCervezaById")]
        public ActionResult<Cerveza> GetCervezaById(int id)
        {
            var cervezaDb = repo.GetCervezaById(id);

            if (cervezaDb == null)
            {
                return NotFound();
            }

            return Ok(cervezaDb);
        }

        [HttpPost]
        public ActionResult<Cerveza> PostCerveza(CervezaRequest cerveza)
        {
            var cervezaDb = repo.CreateCerveza(cerveza);

            return CreatedAtRoute(nameof(GetCervezaById), new { Id = cervezaDb.Id}, cervezaDb);
        }

        [HttpPut("{id}")]
        public ActionResult<Cerveza> UpdateCerveza(int id, CervezaRequest cerveza)
        {
            var cervezaDb = repo.GetCervezaById(id);

            if (cervezaDb == null)
            {
                NotFound();
            }

            repo.UpdateCerveza(id, cerveza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Cerveza> DeleteCerveza(int id)
        {
            var cervezaDb = repo.GetCervezaById(id);

            if (cervezaDb == null)
            {
                return NotFound();
            }

            repo.DeleteCerveza(id);
            return NoContent();
        }
    }
}
