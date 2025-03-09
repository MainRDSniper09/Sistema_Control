using SFServices.Recursos.Cloudinary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFServices.Interfaces
{
    public interface ICloudinaryService
    {
        Task<CloudinaryResponse> SubirImagen(string nombreImagen, Stream formatoImagen);
        Task<bool> EliminarImagen(string publicid);
    }
}
