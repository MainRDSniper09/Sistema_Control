
using SFRepository.Entities;
using SFRepository.Interfaces;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class MedidaService : IMedidaService
    {
        private readonly IMedidaRepository _medidaRepository;
        public MedidaService(IMedidaRepository medidaRepository)
        {
            _medidaRepository = medidaRepository; 
        }
        public async Task<List<Medida>> Lista()
        {
            return await _medidaRepository.Lista(); 
        }
    }
}
