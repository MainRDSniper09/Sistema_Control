﻿// Clase Entidad Negocio
namespace SFRepository.Entities
{
    public class Negocio
    {
        public int IdNegocio { get; set; }
        public string RazonSocial { get; set; }
        public string RUT { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string SimboloMoneda { get; set; }
        public string NombreLogo { get; set; }
        public string UrlLogo { get; set; }
    }
}
