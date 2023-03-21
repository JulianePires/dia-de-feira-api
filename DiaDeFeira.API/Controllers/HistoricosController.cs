using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Domain.Validations;
using DiaDeFeira.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiaDeFeira.API.Controllers
{
    [Route("api/historicos")]
    [ApiController]
    public class HistoricosController : ControllerBase
    {
        private readonly IHistoricosService _historicosService;
        private readonly HistoricoCreateValidator _createValidator;
        private readonly HistoricoEditValidator _editValidator;

        public HistoricosController(IHistoricosService historicosService)
        {
            _historicosService = historicosService;
            _createValidator = new HistoricoCreateValidator();
            _editValidator = new HistoricoEditValidator();
        }

        [HttpGet("por-usuario/{id:length(24)}")]
        public async Task<ActionResult<Historico>> BuscaHistoricosPorUsuario(string idUsuario)
        {
            var historico = await _historicosService.BuscaHistoricosPorIdUsuario(idUsuario);

            if (historico is null)
            {
                return NotFound();
            }

            return Ok(historico);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Historico>> BuscaHistorico(string id)
        {
            var historico = await _historicosService.BuscaHistorico(id);

            if (historico is null)
            {
                return NotFound();
            }

            return Ok(historico);
        }

        [HttpPost]
        public async Task<IActionResult> CriaHistorico(HistoricoCreateDto historicoCreateDto)
        {
            var validator = await _createValidator.ValidateAsync(historicoCreateDto);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var novoHistorico = new Historico()
            {
                IdUsuario = historicoCreateDto.IdUsuario,
            };

            await _historicosService.CriaHistorico(novoHistorico);

            return CreatedAtAction(nameof(BuscaHistoricosPorUsuario),
                new { idUsuario = historicoCreateDto.IdUsuario },
                novoHistorico);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveHistorico(string id)
        {
            var historico = await _historicosService.BuscaHistorico(id);

            if (historico is null)
            {
                return NotFound();
            }

            await _historicosService.RemoveHistorico(id);

            return NoContent();
        }

        [HttpPut("atualiza-listas/{id:length(24)}")]
        public async Task<IActionResult> AtualizaCategoriaProduto(string id, HistoricoEditDto historicoEditDto)
        {
            var historico = await _historicosService.BuscaHistorico(id);

            if (historico is null)
            {
                return NotFound();
            }

            var historicoAtualizado = new Historico()
            {
                Id = historico.Id,
                IdUsuario = historico.IdUsuario,
                ListasId = historicoEditDto.ListasId
            };

            await _historicosService.AtualizaHistorico(id, historicoAtualizado);

            return NoContent();
        }
    }
}
