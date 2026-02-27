using System;

namespace CommentService.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Contenido { get; set; }
        public string AutorId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Comment()
        {
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.UtcNow;
        }
    }
}