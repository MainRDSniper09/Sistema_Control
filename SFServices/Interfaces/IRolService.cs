using SFRepository.Entities;

namespace SFServices.Interfaces
{
    public interface IRolService
    {
        Task<List<Rol>> Lista();
    }
}
