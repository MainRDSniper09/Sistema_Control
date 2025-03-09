using SFRepository.Entities;
using SFRepository.Interfaces;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class NegocioService : INegocioService
    {
        private readonly INegocioRepository _negocioRepository;

        public NegocioService(INegocioRepository negocioRepository)
        {
            _negocioRepository = negocioRepository;
        }

        public async Task<Negocio> Obtener()
        {
            // Implementa la lógica para obtener el negocio desde el repositorio
            return await _negocioRepository.Obtener();
        }

        public async Task Editar(Negocio objeto)
        {
            // Implementa la lógica para editar el negocio en el repositorio
            await _negocioRepository.Editar(objeto);
        }
    }
}
