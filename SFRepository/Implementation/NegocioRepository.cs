
using Microsoft.Data.SqlClient;
using SFRepository.DB;
using SFRepository.Entities;
using SFRepository.Interfaces;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SFRepository.Implementation
{
    public class NegocioRepository : INegocioRepository
    {
        // Conexion a la BD
        private readonly Conexion _conexion;
        public NegocioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task Editar(Negocio objeto)
        {
            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_editarNegocio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RazonSocial", objeto.RazonSocial);
                cmd.Parameters.AddWithValue("@RUT", objeto.RUT);
                cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                cmd.Parameters.AddWithValue("@Celular", objeto.Celular);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@SimboloMoneda", objeto.SimboloMoneda);
                cmd.Parameters.AddWithValue("@NombreLogo", objeto.NombreLogo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@UrlLogo", objeto.UrlLogo ?? (object)DBNull.Value);

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar negocio: " + ex.Message);
                }
            }
        }

        public async Task<Negocio> Obtener()
        {
            Negocio objeto = new Negocio();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerNegocio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Negocio()
                        {
                            RazonSocial = dr["RazonSocial"].ToString()!,
                            RUT = dr["RUT"].ToString()!,
                            Direccion = dr["Direccion"].ToString()!,
                            Celular = dr["Celular"].ToString()!,
                            Correo = dr["Correo"].ToString()!,
                            SimboloMoneda = dr["SimboloMoneda"].ToString()!,
                            NombreLogo = dr["NombreLogo"].ToString()!,
                            UrlLogo = dr["UrlLogo"].ToString()!
                        };
                    }
                }
            }
            return objeto;
        }

        Task INegocioRepository.Editar(Negocio objeto)
        {
            return Editar(objeto);
        }
    }
}
