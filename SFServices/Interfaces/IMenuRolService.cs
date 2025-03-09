
using SFRepository.Entities;

namespace SFServices.Interfaces
{
    public interface IMenuRolService
    {
        Task<List<MenuRol>> Lista(int idRol);
    }
}
