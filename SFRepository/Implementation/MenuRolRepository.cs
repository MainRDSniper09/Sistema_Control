
using Microsoft.Data.SqlClient;
using SFRepository.DB;
using SFRepository.Entities;
using SFRepository.Interfaces;
using System.Data;

namespace SFRepository.Implementation
{
    public class MenuRolRepository : IMenuRolRepository
    {
        // Conexion a la BD
        private readonly Conexion _conexion;
        public MenuRolRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<List<MenuRol>> Lista(int idRol)
        {
            // Metodo para listar
            List<MenuRol> lista = new List<MenuRol>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_ObtenerMenus", con);
                cmd.Parameters.AddWithValue("@IdRol", idRol);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new MenuRol
                        {
                            NombreMenu = dr["NombreMenu"].ToString()!,
                            IdMenuPadre = Convert.ToInt32(dr["IdMenuPadre"]),
                            Activo = Convert.ToBoolean(dr["Activo"]),
                        });
                    }
                }
            }
            return lista;
        }
    }
}
