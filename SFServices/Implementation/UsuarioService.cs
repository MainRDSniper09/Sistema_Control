
using SFRepository.Entities;
using SFRepository.Implementation;
using SFRepository.Interfaces;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task ActualizarClave(int idUsuario, string nuevaClave, int resetear)
        {
            await _usuarioRepository.ActualizarClave(idUsuario, nuevaClave, resetear);
        }

        public async Task<string> Crear(Usuario objeto)
        {
            return await _usuarioRepository.Crear(objeto);
        }

        public async Task<string> Editar(Usuario objeto)
        {
            return await _usuarioRepository.Editar(objeto);
        }

        public async Task<List<Usuario>> Lista(string buscar = "")
        {
            return await _usuarioRepository.Lista(buscar);
        }

        public async Task<Usuario> Login(string usuario, string clave)
        {
            return await _usuarioRepository.Login(usuario, clave);
        }

        public async Task<int> VerificarCorreo(string correo)
        {
            return await _usuarioRepository.VerificarCorreo(correo);
        }
    }
}
