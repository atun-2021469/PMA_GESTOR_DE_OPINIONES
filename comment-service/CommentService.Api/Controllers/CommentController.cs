using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CommentService.Application.DTOs;
using CommentService.Application.Interfaces;

namespace CommentService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Crear(CreateCommentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _service.CrearAsync(dto, userId);

            return Ok(result);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> ListarPorPost(Guid postId)
        {
            var result = await _service.ListarPorPostAsync(postId);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, UpdateCommentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _service.EditarAsync(id, dto, userId);

            if (!result)
                return Forbid();

            return Ok("Comentario actualizado.");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _service.EliminarAsync(id, userId);

            if (!result)
                return Forbid();

            return Ok("Comentario eliminado.");
        }
    }
}