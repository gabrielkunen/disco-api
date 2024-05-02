using Api.Data;
using Api.Models;
using Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscoController : ControllerBase
    {
        private readonly DiscoContext _context;

        public DiscoController(DiscoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Discos);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _context.Discos.Remove(_context.Discos.First(d => d.Id == id));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, CriarDiscoRequest request)
        {
            var disco = _context.Discos.First(d => d.Id == id);
            disco.NumeroCatalogo = request.NumeroCatalogo;
            disco.Titulo = request.Titulo;
            _context.Discos.Update(disco);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CriarDiscoRequest request)
        {
            var disco = new Disco { NumeroCatalogo = request.NumeroCatalogo, Titulo = request.Titulo, IdLabel = request.IdLabel };
            _context.Discos.Add(disco);
            _context.SaveChanges();
            return Ok();
        }
    }
}