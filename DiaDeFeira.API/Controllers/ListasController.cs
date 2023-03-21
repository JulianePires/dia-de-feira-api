using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Domain.Validations;
using DiaDeFeira.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiaDeFeira.API.Controllers
{
    [Route("api/listas")]
    [ApiController]
    public class ListasController : ControllerBase
    {
        private readonly IListasService _listasService;
        private readonly ListaCreateValidator _validator;

        public ListasController(IListasService listasService)
        {
            _listasService = listasService;
            _validator = new ListaCreateValidator();
        }

        [HttpGet]
        public async Task<List<Lista>> BuscaListas() =>
            await _listasService.BuscaTodasListas();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Lista>> BuscaLista(string id)
        {
            var lista = await _listasService.BuscaLista(id);

            if (lista is null)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CriaLista(ListaCreateDto listaCriacao)
        {
            var validator = await _validator.ValidateAsync(listaCriacao);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var novaLista = new Lista()
            {
                NomeLista = listaCriacao.NomeLista
            };

            await _listasService.CriaLista(novaLista);

            return CreatedAtAction(nameof(BuscaLista),
                new { id = novaLista.Id },
                novaLista);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveLista(string id)
        {
            var lista = await _listasService.BuscaLista(id);

            if (lista is null)
            {
                return NotFound();
            }

            await _listasService.RemoveLista(id);

            return NoContent();
        }

        [HttpPut("atualiza-itens/{id:length(24)}")]
        public async Task<IActionResult> AtualizaProdutosLista(string id, ListaEditDto listaEdicao)
        {
            var lista = await _listasService.BuscaLista(id);

            if (lista is null)
            {
                return NotFound();
            }

            var listaAtualizada = new Lista()
            {
                Id = lista.Id,
                NomeLista = lista.NomeLista,
                Itens = listaEdicao.Itens!,
                Finalizada = listaEdicao.Itens!.All(x => x.Adicionado == true) || lista.Finalizada
            };

            await _listasService.AtualizaLista(id, listaAtualizada);

            return NoContent();
        }

        [HttpPut("atualiza-nome/{id:length(24)}")]
        public async Task<IActionResult> AtualizaNomeLista(string id, ListaEditDto listaEdicao)
        {
            var lista = await _listasService.BuscaLista(id);

            if (lista is null)
            {
                return NotFound();
            }

            var listaAtualizada = new Lista()
            {
                Id = lista.Id,
                NomeLista = listaEdicao.NomeLista!,
                Itens = lista.Itens,
                Finalizada = lista.Finalizada
            };

            await _listasService.AtualizaLista(id, listaAtualizada);

            return NoContent();
        }

        [HttpPut("atualiza-status-finalizada/{id:length(24)}")]
        public async Task<IActionResult> AtualizaFinalizadaLista(string id, ListaEditDto listaEdicao)
        {
            var lista = await _listasService.BuscaLista(id);

            if (lista is null)
            {
                return NotFound();
            }

            var listaAtualizada = new Lista()
            {
                Id = lista.Id,
                NomeLista = lista.NomeLista,
                Itens = lista.Itens,
                Finalizada = (bool)listaEdicao.Finalizada!
            };

            await _listasService.AtualizaLista(id, listaAtualizada);

            return NoContent();
        }
    }
}

