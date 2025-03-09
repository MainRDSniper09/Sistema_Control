
using SFRepository.DB;
using SFRepository.Entities;
using SFRepository.Interfaces;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class ProductoService: IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<string> Crear(Producto objeto)
        {
            return await _productoRepository.Crear(objeto);
        }

        public async Task<string> Editar(Producto objeto)
        {
            return await _productoRepository.Editar(objeto);
        }

        public async Task<List<Producto>> Lista(string buscar = "")
        {
            return await _productoRepository.Lista(buscar);
        }

        public async Task<Producto> Obtener(string codigo)
        {
            return await _productoRepository.Obtener(codigo);
        }
    }
}
