using SFRepository.Entities;
using SFRepository.Implementation;
using SFRepository.Interfaces;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        public Task<List<Rol>> Lista()
        {
            return _rolRepository.Lista();
        }
    }
}
