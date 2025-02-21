using SFRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFRepository.Interfaces
{
    // Interfaz de categoria
   public interface ICategoriaRepository
    {
        Task<List<Categoria>> Lista(string buscar = "");
        Task<string> Crear(Categoria objeto);
        Task<string> Editar(Categoria objeto);
    }
}
