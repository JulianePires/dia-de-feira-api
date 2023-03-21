using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Domain.Validations;
using DiaDeFeira.API.Services;
using DiaDeFeira.API.Services.Interfaces;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DiaDeFeira.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;
        private readonly ProdutoRequestValidator _validator;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
            _validator = new ProdutoRequestValidator();
        }

        [HttpGet]
        public async Task<List<Produto>> BuscaProdutos() =>
            await _produtosService.BuscaTodosProdutos();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Produto>> BuscaProduto(string id)
        {
            var produto = await _produtosService.BuscaProduto(id);

            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpGet("{nomeProduto}")]
        public async Task<ActionResult<Produto>> BuscaProdutoPorNome(string nomeProduto)
        {
            var produto = await _produtosService.BuscaProdutoPorNome(nomeProduto);

            if (produto is null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> CriaProduto(ProdutoRequestDto produtoCriacao)
        {
            var validator = await _validator.ValidateAsync(produtoCriacao);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var novoProduto = new Produto()
            {
                NomeProduto = produtoCriacao.NomeProduto!,
                IdCategoria = produtoCriacao.IdCategoria!
            };

            await _produtosService.CriaProduto(novoProduto);

            return CreatedAtAction(nameof(BuscaProdutoPorNome),
                new { nomeProduto = produtoCriacao.NomeProduto },
                novoProduto);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveProduto(string id)
        {
            var produto = await _produtosService.BuscaProduto(id);

            if (produto is null)
            {
                return NotFound();
            }

            await _produtosService.RemoveProduto(id);

            return NoContent();
        }

        [HttpPut("atualiza-categoria-produto/{id:length(24)}")]
        public async Task<IActionResult> AtualizaCategoriaProduto(string id, ProdutoRequestDto atualizacaoProduto)
        {
            var produto = await _produtosService.BuscaProduto(id);

            if (produto is null)
            {
                return NotFound();
            }

            var produtoAtualizado = new Produto()
            {
                Id = produto.Id,
                NomeProduto = produto.NomeProduto,
                IdCategoria = atualizacaoProduto.IdCategoria!
            };

            await _produtosService.AtualizaProduto(id, produtoAtualizado);

            return NoContent();
        }

        [HttpPut("atualiza-nome-produto/{id:length(24)}")]
        public async Task<IActionResult> AtualizaNomeProduto(string id, ProdutoRequestDto atualizacaoProduto)
        {
            var produto = await _produtosService.BuscaProduto(id);

            if (produto is null)
            {
                return NotFound();
            }

            var produtoAtualizado = new Produto()
            {
                Id = produto.Id,
                NomeProduto = atualizacaoProduto.NomeProduto!,
                IdCategoria = produto.IdCategoria
            };

            await _produtosService.AtualizaProduto(id, produtoAtualizado);

            return NoContent();
        }

    }
}
