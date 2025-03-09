namespace SFServices.Interfaces
{
    public interface ICorreoService
    {
        Task Enviar(string para, string asunto, string mensajeHtml);
    }
}
