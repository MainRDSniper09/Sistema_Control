﻿

namespace SFRepository.Entities
{
    // Creamos nuestra entidad Medida
    public class Medida
    {
        public int IdMedida { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        public string Equivalente { get; set; }
        public int Valor { get; set; }
    }
}
