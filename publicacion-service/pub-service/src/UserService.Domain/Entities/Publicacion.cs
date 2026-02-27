using System;

namespace PublicacionesService.Domain.Entities
{
    public class Publicacion
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Categoria { get; set; }

        public string Contenido { get; set; }

        public string AutorId { get; set; }

        public DateTime FechaCreacion { get; set; }
        public Publicacion()
        {
            Id = Guid.NewGuid();
            FechaCreacion = DateTime.UtcNow;
        }
    }
}