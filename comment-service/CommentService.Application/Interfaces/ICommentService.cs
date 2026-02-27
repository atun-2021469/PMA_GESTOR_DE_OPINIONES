using CommentService.Application.DTOs;
using CommentService.Domain.Entities;

namespace CommentService.Application.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> CrearAsync(CreateCommentDto dto, string autorId);
        Task<IEnumerable<Comment>> ListarPorPostAsync(Guid postId);
        Task<bool> EditarAsync(Guid id, UpdateCommentDto dto, string autorId);
        Task<bool> EliminarAsync(Guid id, string autorId);
    }
}