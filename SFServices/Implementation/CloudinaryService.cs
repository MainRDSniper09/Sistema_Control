using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using SFServices.Interfaces;
using SFServices.Recursos.Cloudinary;

namespace SFServices.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuracion;
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            _configuracion = configuration;
            var CloudName = _configuracion["Cloudinary:CloudName"];
            var ApiKey = _configuracion["Cloudinary:ApiKey"];
            var ApiSecret = _configuracion["Cloudinary:ApiSecret"];

            _cloudinary = new Cloudinary(new Account(CloudName, ApiKey, ApiSecret));
        }

        public async Task<bool> EliminarImagen(string publicid)
        {
            var deleteParams = new DeletionParams(publicid);
            var deleteResult = await _cloudinary.DestroyAsync(deleteParams);

            if (deleteResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<CloudinaryResponse> SubirImagen(string nombreImagen, Stream formatoImagen)
        {
            var cloudinaryResponse = new CloudinaryResponse();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(nombreImagen, formatoImagen),
                AssetFolder = "sistemaControlWF"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                cloudinaryResponse.PublicId = uploadResult.PublicId;
                cloudinaryResponse.SecureUrl = uploadResult.SecureUrl.ToString();
            }
            else
            {
                cloudinaryResponse.PublicId = "";
            }

            return cloudinaryResponse;
        }
    }
}
