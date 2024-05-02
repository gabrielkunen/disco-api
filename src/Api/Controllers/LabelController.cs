using Api.Data;
using Api.Models;
using Api.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelController : ControllerBase
    {
        private readonly DiscoContext _context;

        public LabelController(DiscoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Labels);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _context.Labels.Remove(_context.Labels.First(d => d.Id == id));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, CriarLabelRequest request)
        {
            var label = _context.Labels.First(d => d.Id == id);
            label.Nome = request.Nome;
            label.Regiao = request.Regiao;
            label.Descricao = request.Descricao;
            _context.Labels.Update(label);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CriarLabelRequest request)
        {
            var label = new Label { Nome = request.Nome, Regiao = request.Regiao, Descricao = request.Descricao };
            _context.Labels.Add(label);
            _context.SaveChanges();
            return Ok();
        }
    }
}