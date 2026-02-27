using System.ComponentModel.DataAnnotations;

namespace CommentService.Application.DTOs
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Contenido { get; set; }
    }
}