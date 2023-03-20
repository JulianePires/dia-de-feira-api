using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Domain.Validations;
using DiaDeFeira.API.Services.Interfaces;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DiaDeFeira.API.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;
        private readonly CategoriaRequestValidator _validator;

        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
            _validator = new CategoriaRequestValidator();
        }

        [HttpGet]
        public async Task<List<Categoria>> BuscaCategorias() =>
            await _categoriasService.BuscaTodasCategorias();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Categoria>> BuscaCategoria(string id)
        {
            var categoria = await _categoriasService.BuscaCategoria(id);

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpGet("{nomeCategoria}")]
        public async Task<ActionResult<Categoria>> BuscaCategoriaPorNome(string nomeCategoria)
        {
            var categoria = await _categoriasService.BuscaCategoriaPorNome(nomeCategoria);

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ErrorOr<IActionResult>> CriaCategoria(CategoriaRequestDto categoriaCriacao)
        {
            var validator = await _validator.ValidateAsync(categoriaCriacao);

            if (!validator.IsValid)
            {
                return Error.Failure(validator.Errors[0].ErrorCode, validator.Errors[0].ErrorMessage);
            }

            var novaCategoria = new Categoria()
            {
                NomeCategoria = categoriaCriacao.NomeCategoria
            };


            await _categoriasService.CriaCategoria(novaCategoria);

            return CreatedAtAction(nameof(BuscaCategoriaPorNome),
                new { nomeCategoria = categoriaCriacao.NomeCategoria },
                novaCategoria);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> AtualizaCategoria(string id, Categoria categoriaAtualizada)
        {
            var categoria = await _categoriasService.BuscaCategoria(id);

            if (categoria is null)
            {
                return NotFound();
            }

            categoriaAtualizada.Id = categoria.Id;

            await _categoriasService.AtualizaCategoria(id, categoriaAtualizada);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveCategoria(string id)
        {
            var categoria = await _categoriasService.BuscaCategoria(id);

            if (categoria is null)
            {
                return NotFound();
            }

            await _categoriasService.RemoveCategoria(id);

            return NoContent();
        }
    }
}
