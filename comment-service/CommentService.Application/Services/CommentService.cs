using CommentService.Application.DTOs;
using CommentService.Application.Interfaces;
using CommentService.Domain.Entities;
using CommentService.Domain.Interfaces;

namespace CommentService.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comment> CrearAsync(CreateCommentDto dto, string autorId)
        {
            var comment = new Comment
            {
                PostId = dto.PostId,
                Contenido = dto.Contenido,
                AutorId = autorId
            };

            await _repository.AddAsync(comment);
            return comment;
        }

        public async Task<IEnumerable<Comment>> ListarPorPostAsync(Guid postId)
        {
            return await _repository.GetByPostIdAsync(postId);
        }

        public async Task<bool> EditarAsync(Guid id, UpdateCommentDto dto, string autorId)
        {
            var comment = await _repository.GetByIdAsync(id);

            if (comment == null)
                return false;

            if (comment.AutorId != autorId)
                return false;

            comment.Contenido = dto.Contenido;

            await _repository.UpdateAsync(comment);
            return true;
        }

        public async Task<bool> EliminarAsync(Guid id, string autorId)
        {
            var comment = await _repository.GetByIdAsync(id);

            if (comment == null)
                return false;

            if (comment.AutorId != autorId)
                return false;

            await _repository.DeleteAsync(comment);
            return true;
        }
    }
}