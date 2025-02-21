

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SFRepository.DB
{
    // Clase Conexion a DB
    public class Conexion
    {
        private readonly IConfiguration _configuracion; // Acceder al archivo json
        private readonly string _cadenaSql;

        public Conexion(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _cadenaSql = _configuracion.GetConnectionString("CadenaSql");
        }

        // Metodo Obtener nuestra cadena de conexion
        public SqlConnection ObtenerSQLConexion()
        {
            return new SqlConnection("_cadenaSql");
        }
    }
}
