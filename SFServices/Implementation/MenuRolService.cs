﻿
using SFRepository.Entities;
using SFRepository.Interfaces;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class MenuRolService : IMenuRolService
    {
        private readonly IMenuRolRepository _menuRolRepository;

        public MenuRolService(IMenuRolRepository menuRolRepository)
        {
            _menuRolRepository = menuRolRepository;
        }
        public async Task<List<MenuRol>> Lista(int idRol)
        {
            return await _menuRolRepository.Lista(idRol);
        }
    }
}
