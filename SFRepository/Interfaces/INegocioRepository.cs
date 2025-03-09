
using SFRepository.Entities;

namespace SFRepository.Interfaces
{
    public interface INegocioRepository
    {
        Task<Negocio> Obtener();
        Task Editar(Negocio objeto);
    }
}
