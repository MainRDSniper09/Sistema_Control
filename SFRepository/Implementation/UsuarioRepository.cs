using Microsoft.Data.SqlClient;
using SFRepository.DB;
using SFRepository.Entities;
using SFRepository.Interfaces;
using System.Data;

namespace SFRepository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // Conexion a la BD
        private readonly Conexion _conexion;
        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task ActualizarClave(int idUsuario, string nuevaClave, int resetear)
        {
            // Metodo para Editar
            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_actualizarClave", con);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@NuevaClave", nuevaClave);
                cmd.Parameters.AddWithValue("@Resetear", resetear);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    idUsuario = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value)!;
                }
                catch
                {
                    idUsuario = 0;
                }
            }
            
        }
       
       

        public async Task<string> Crear(Usuario objeto)
        {
            // Metodo para Crear
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_CrearUsuario", con);
                cmd.Parameters.AddWithValue("@IdRol", objeto.RefRol.IdRol);
                cmd.Parameters.AddWithValue("@Clave", objeto.Clave);
                cmd.Parameters.AddWithValue("@NombreUsuario", objeto.NombreUsuario);
                cmd.Parameters.AddWithValue("@NombreCompleto", objeto.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch
                {
                    respuesta = "Error(rp):No se pudo procesar";
                }

            }
            return respuesta;
        }

        public async Task<string> Editar(Usuario objeto)
        {
            // Metodo para Editar
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarUsuario", con);
                cmd.Parameters.AddWithValue("@IdUsuario", objeto.IdUsuario);
                cmd.Parameters.AddWithValue("@IdRol", objeto.RefRol.IdRol);
                cmd.Parameters.AddWithValue("@Activo", objeto.Activo);
                cmd.Parameters.AddWithValue("@NombreUsuario", objeto.NombreUsuario);
                cmd.Parameters.AddWithValue("@NombreCompleto", objeto.NombreCompleto);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.Add("@MsjError", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@MsjError"].Value)!;
                }
                catch
                {
                    respuesta = "Error(rp):No se pudo procesar";
                }

            }
            return respuesta;
        }

        public async Task<List<Usuario>> Lista(string buscar = "")
        {
            // Metodo para listar
            List<Usuario> lista = new List<Usuario>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaUsuario", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            RefRol = new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Nombre = dr["NombreRol"].ToString()!,
                            },
                            NombreCompleto = dr["NombreCompleto"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            NombreUsuario = dr["NombreUsuario"].ToString()!,
                            Activo = Convert.ToInt32(dr["Activo"]),
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Usuario?> Login(string usuario, string clave)
        {
            Usuario? objeto = null;

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_login", con);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario);
                cmd.Parameters.AddWithValue("@Clave", clave);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            NombreCompleto = dr["NombreCompleto"].ToString()!,
                            RefRol = new Rol
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Nombre = dr["NombreRol"].ToString()!,
                            },
                            Correo = dr["Correo"].ToString()!,
                            NombreUsuario = dr["NombreUsuario"].ToString()!,
                            ResetearClave = Convert.ToInt32(dr["ResetearClave"]),
                            Activo = Convert.ToInt32(dr["Activo"]),
                        };
                    }
                }
            }
            return objeto;
        }


        public async Task<int> VerificarCorreo(string correo)
        {
            // Metodo para Editar
            int idUsuario;

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_verificarCorreo", con);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    idUsuario = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value)!;
                }
                catch
                {
                    idUsuario = 0;
                }

            }
            return idUsuario;
        }
    }
}
