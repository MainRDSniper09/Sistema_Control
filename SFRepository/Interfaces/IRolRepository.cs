
using SFRepository.Entities;

namespace SFRepository.Interfaces
{
    public interface IRolRepository
    {
        Task<List<Rol>> Lista();
    }
}
