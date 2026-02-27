using PublicacionesService.Application.DTOs;
using PublicacionesService.Application.Interfaces;
using PublicacionesService.Domain.Entities;
using PublicacionesService.Domain.Interfaces;

namespace PublicacionesService.Application.Services
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IPublicacionRepository _repository;

        public PublicacionService(IPublicacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Publicacion> CrearAsync(CreatePublicacionDto dto, string autorId)
        {
            var publicacion = new Publicacion
            {
                Titulo = dto.Titulo,
                Categoria = dto.Categoria,
                Contenido = dto.Contenido,
                AutorId = autorId
            };

            await _repository.AddAsync(publicacion);

            return publicacion;
        }

        public async Task<IEnumerable<Publicacion>> ListarAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Publicacion?> ObtenerPorIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> EditarAsync(Guid id, UpdatePublicacionDto dto, string autorId)
        {
            var publicacion = await _repository.GetByIdAsync(id);

            if (publicacion == null)
                return false;

            if (publicacion.AutorId != autorId)
                return false;

            publicacion.Titulo = dto.Titulo;
            publicacion.Categoria = dto.Categoria;
            publicacion.Contenido = dto.Contenido;

            await _repository.UpdateAsync(publicacion);

            return true;
        }

        public async Task<bool> EliminarAsync(Guid id, string autorId)
        {
            var publicacion = await _repository.GetByIdAsync(id);

            if (publicacion == null)
                return false;

            if (publicacion.AutorId != autorId)
                return false;

            await _repository.DeleteAsync(publicacion);

            return true;
        }
    }
}