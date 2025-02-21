
using SFRepository.Entities;

namespace SFServices.Interfaces
{
    public interface IMedidaService
    {
        Task<List<Medida>> Lista();
    }
}
