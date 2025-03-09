
using SFRepository.Entities;

namespace SFServices.Interfaces
{
    public interface INegocioService
    {
        Task<Negocio> Obtener();
        Task Editar(Negocio objeto);
    }
}
