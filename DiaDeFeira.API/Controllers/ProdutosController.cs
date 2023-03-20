using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Domain.Validations;
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

        [HttpGet("{nomeCategoria}")]
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
        public async Task<ErrorOr<IActionResult>> CriaProduto(ProdutoRequestDto produtoCriacao)
        {
            var validator = await _validator.ValidateAsync(produtoCriacao);

            if (!validator.IsValid)
            {
                return Error.Validation(validator.Errors.First().ErrorCode, validator.Errors.First().ErrorMessage);
            }

            var novoProduto = new Produto()
            {
                NomeProduto = produtoCriacao.NomeProduto,
                IdCategoria = produtoCriacao.IdCategoria!
            };

            await _produtosService.CriaProduto(novoProduto);

            return CreatedAtAction(nameof(BuscaProdutoPorNome),
                new { nomeProduto = produtoCriacao.NomeProduto },
                novoProduto);
        }
    }
}
