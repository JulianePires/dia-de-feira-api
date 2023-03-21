using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Domain.Validations;
using DiaDeFeira.API.Services;
using DiaDeFeira.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiaDeFeira.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;
        private readonly UsuarioCreateValidation _createValidation;
        private readonly UsuarioEditValidator _editValidator;
        private readonly UsuarioLoginValidator _loginValidator;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
            _editValidator = new UsuarioEditValidator();
            _loginValidator = new UsuarioLoginValidator();
            _createValidation = new UsuarioCreateValidation();
        }

        [HttpGet]
        public async Task<List<Usuario>> BuscaUsuarios() =>
            await _usuariosService.BuscaTodosUsuarios();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Usuario>> BuscaUsuario(string id)
        {
            var usuario = await _usuariosService.BuscaUsuario(id);

            if (usuario is null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriaUsuario(UsuarioCreateDto usuarioCreateDto)
        {
            var validator = await _createValidation.ValidateAsync(usuarioCreateDto);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var novoUsuario = new Usuario()
            {
                NomeUsuario = usuarioCreateDto.NomeUsuario,
                Email = usuarioCreateDto.Email,
                Senha = usuarioCreateDto.Senha
            };

            await _usuariosService.CriaUsuario(novoUsuario);

            return Created("Usuário criado com sucesso!", novoUsuario);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveUsuario(string id)
        {
            var produto = await _usuariosService.BuscaUsuario(id);

            if (produto is null)
            {
                return NotFound();
            }

            await _usuariosService.RemoveUsuario(id);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario(UsuarioLoginDto usuarioLogin)
        {
            var validator = await _loginValidator.ValidateAsync(usuarioLogin);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            await _usuariosService.LoginUsuario(usuarioLogin);

            return Ok("Usuario autenticado!");
        }

    }
}
