
using Microsoft.Data.SqlClient;
using SFRepository.DB;
using SFRepository.Entities;
using SFRepository.Interfaces;
using System.Data;

namespace SFRepository.Implementation
{
    public class VentaRepository : IVentaRepository
    {
        // Conexion a la BD
        private readonly Conexion _conexion;
        public VentaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<List<Venta>> Lista(string fechaInicio, string fechaFin, string buscar = "")
        {
            // Metodo para listar
            List<Venta> lista = new List<Venta>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_listaVenta", con);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@Buscar", buscar);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Venta
                        {
                            NumeroVenta = (dr["NumeroVenta"].ToString()!),
                            usuarioRegistro = new Usuario
                            {
                                NombreUsuario = (dr["NombreUsuario"].ToString()!),
                            },
                            NombreCliente = (dr["NombreCliente"].ToString()!),
                            PrecioTotal = Convert.ToDecimal(dr["PrecioTotal"]),
                            PagoCon = Convert.ToDecimal(dr["PagoCon"]),
                            Cambio = Convert.ToDecimal(dr["Cambio"]),


                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Venta> Obtener(string numeroVenta)
        {
            Venta objeto = new Venta();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_obtenerVenta", con);
                cmd.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        objeto = new Venta()
                        {
                            IdVenta = Convert.ToInt32(dr["IdVenta"]),
                            NumeroVenta = dr["NumeroVenta"].ToString()!,
                            usuarioRegistro = new Usuario
                            {
                                NombreUsuario = dr["NombreUsuario"].ToString()!
                            },
                            NombreCliente = dr["NombreCliente"].ToString()!,
                            PrecioTotal = Convert.ToDecimal(dr["PrecioTotal"]),
                            PagoCon = Convert.ToDecimal(dr["PagoCon"]),
                            Cambio = Convert.ToDecimal(dr["Cambio"]),
                            FechaRegistro = (dr["FechaRegistro"].ToString()!)
                        };
                    }
                }
            }
            return objeto;
        }


        public async Task<List<DetalleVenta>> ObtenerDetalle(string numeroVenta)
        {
            // Metodo para listar
            List<DetalleVenta> lista = new List<DetalleVenta>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_ObtenerDetalleVenta", con);
                cmd.Parameters.AddWithValue("@NumeroVenta", numeroVenta);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new DetalleVenta
                        {
                            RefProducto = new Producto
                            {
                                Descripcion = dr["Descripcion"].ToString()!,
                                RefCategoria = new Categoria
                                {
                                    RefMedida = new Medida
                                    {
                                        Abreviatura = dr["Abreviatura"].ToString()!,
                                        Valor = Convert.ToInt32(dr["Valor"]),
                                    }
                                }
                            },
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            PrecioTotal = Convert.ToDecimal(dr["PrecioTotal"]),

                        });
                    }
                }
            }
            return lista;
        }

        public async Task<string> Registrar(string ventaXml)
        {
            // Metodo para Crear
            string respuesta = "";

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_registrarVenta", con);
                cmd.Parameters.AddWithValue("@VentaXml", ventaXml);
                cmd.Parameters.Add("@NumeroVenta", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    respuesta = Convert.ToString(cmd.Parameters["@NumeroVenta"].Value)!;
                }
                catch
                {
                    respuesta = "Error(rp):No se pudo procesar";
                }

            }
            return respuesta;
        }

        public async Task<List<DetalleVenta>> Reporte(string fechaInicio, string fechaFin)
        {
            // Metodo para listar
            List<DetalleVenta> lista = new List<DetalleVenta>();

            using (var con = _conexion.ObtenerSQLConexion())
            {
                con.Open();
                var cmd = new SqlCommand("sp_reporteVenta", con);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new DetalleVenta
                        {
                            RefVenta = new Venta
                            {
                                NumeroVenta = (dr["NumeroVenta"].ToString()!),
                                usuarioRegistro = new Usuario
                                {
                                    NombreUsuario = (dr["NombreUsuario"].ToString()!),
                                },
                                FechaRegistro = (dr["FechaRegistro"].ToString()!),
                            },
                            RefProducto = new Producto
                            {
                                Descripcion = (dr["Producto"].ToString()!),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                            },
                            PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioTotal = Convert.ToDecimal(dr["PrecioTotal"]),
                            
                        });
                    }
                }
            }
            return lista;
        }
    }
}
