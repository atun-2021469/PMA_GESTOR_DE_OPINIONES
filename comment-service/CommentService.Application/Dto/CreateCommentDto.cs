using System.ComponentModel.DataAnnotations;

namespace CommentService.Application.DTOs
{
    public class CreateCommentDto
    {
        [Required]
        public Guid PostId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Contenido { get; set; }
    }
}