using System.ComponentModel.DataAnnotations;

namespace PublicacionesService.Application.DTOs
{
    public class CreatePublicacionDto
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        [MinLength(5, ErrorMessage = "El título debe tener al menos 5 caracteres.")]
        [MaxLength(100, ErrorMessage = "El título no puede superar los 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [MinLength(3, ErrorMessage = "La categoría debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "La categoría no puede superar los 50 caracteres.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio.")]
        [MinLength(10, ErrorMessage = "El contenido debe tener al menos 10 caracteres.")]
        [MaxLength(1000, ErrorMessage = "El contenido no puede superar los 1000 caracteres.")]
        public string Contenido { get; set; }
    }
}