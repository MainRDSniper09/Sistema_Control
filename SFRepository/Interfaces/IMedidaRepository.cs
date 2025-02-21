// Interfaz de Medida
using SFRepository.Entities;

namespace SFRepository.Interfaces
{
    public interface IMedidaRepository
    {
        // Metodos - Contratos
        Task<List<Medida>> Lista(); 
    }
}
