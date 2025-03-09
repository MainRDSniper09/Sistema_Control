

using Microsoft.Data.SqlClient;
using SFRepository.DB;
using SFRepository.Entities;
using SFRepository.Interfaces;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SFRepository.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        // Conexion a la BD
        private readonly Conexion _conexion;
        public ProductoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }
        public async Task<string> Crear(Producto objeto)
        {
            // Metodo para Crear
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {

                con.Open();
                var cmd = new SqlCommand("sp_crearProducto", con);
                cmd.Parameters.AddWithValue("@IdCategoria", objeto.RefCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Codigo", objeto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", objeto.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", objeto.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", objeto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);
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

        public async Task<string> Editar(Producto objeto)
        {
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_EditarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // 🔹 Agregar todos los parámetros requeridos por el SP
                cmd.Parameters.AddWithValue("@IdProducto", objeto.IdProducto); // <- ❗FALTABA ESTE
                cmd.Parameters.AddWithValue("@IdCategoria", objeto.RefCategoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Codigo", objeto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", objeto.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", objeto.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", objeto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);
                cmd.Parameters.AddWithValue("@Activo", objeto.Activo);

                // 🔹 Configurar el parámetro de salida correctamente
                SqlParameter msjErrorParam = new SqlParameter("@MsjError", SqlDbType.VarChar, 100);
                msjErrorParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(msjErrorParam);

                try
                {
                    await cmd.ExecuteNonQueryAsync();

                    // Evitar que 'respuesta' sea null
                    respuesta = msjErrorParam.Value != DBNull.Value ? msjErrorParam.Value.ToString()! : "";

                }
                catch (Exception ex)
                {
                    respuesta = "Error(rp): No se pudo procesar - " + ex.Message;
                }
            }
            return respuesta;
        }


        public async Task<List<Producto>> Lista(string buscar = "")
        {
            // Metodo para listar
            List<Producto> lista = new List<Producto>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaProducto", con);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Producto
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            RefCategoria = new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Nombre = dr["NombreCategoria"].ToString()!,
                            },
                            Codigo = dr["Codigo"].ToString()!,
                            Descripcion = dr["Descripcion"].ToString()!,
                            PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Activo = Convert.ToInt32(dr["Activo"]),
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Producto> Obtener(string codigo)
        {
            Producto objeto = new Producto();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerProducto", con);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Producto
                        {

                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            RefCategoria = new Categoria
                            {
                                Nombre = dr["NombreCategoria"].ToString()!,
                                RefMedida = new Medida
                                {
                                    Equivalente = dr["Equivalente"].ToString()!,
                                    Valor = Convert.ToInt32(dr["Valor"]),
                                }
                            },
                            Codigo = dr["Codigo"].ToString()!,
                            Descripcion = dr["Descripcion"].ToString()!,
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                        };
                    }
                }
            }
            return objeto;
        }
    }
}
