using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PublicacionesService.Application.DTOs;
using PublicacionesService.Application.Interfaces;

namespace PublicacionesService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPublicacionService _publicacionService;

        public PostController(IPublicacionService publicacionService)
        {
            _publicacionService = publicacionService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreatePublicacionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _publicacionService.CrearAsync(dto, userId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var publicaciones = await _publicacionService.ListarAsync();
            return Ok(publicaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(Guid id)
        {
            var publicacion = await _publicacionService.ObtenerPorIdAsync(id);

            if (publicacion == null)
                return NotFound("Publicación no encontrada.");

            return Ok(publicacion);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] UpdatePublicacionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _publicacionService.EditarAsync(id, dto, userId);

            if (!result)
                return Forbid("No tienes permiso para editar esta publicación.");

            return Ok("Publicación actualizada correctamente.");
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _publicacionService.EliminarAsync(id, userId);

            if (!result)
                return Forbid("No tienes permiso para eliminar esta publicación.");

            return Ok("Publicación eliminada correctamente.");
        }
    }
}