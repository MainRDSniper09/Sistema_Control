using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPresentation.ViewModels
{
    public class CategoriaVM
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string IdMedida { get; set; }
        public string Medida { get; set; }
        public int Activo { get; set; }
        public string Habilitado { get; set; }
    }
}
