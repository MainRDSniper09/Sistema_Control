
using SFRepository.Entities;

namespace SFRepository.Interfaces
{
    public interface IMenuRolRepository
    {
        Task<List<MenuRol>> Lista(int idRol);
    }
}
