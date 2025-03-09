using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;
using SFServices.Interfaces;

namespace SFServices.Implementation
{
    public class CorreoService : ICorreoService
    {
        private readonly IConfiguration _configuracion;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;

        public CorreoService(IConfiguration configuracion)
        {
            _configuracion = configuracion;

            _host = _configuracion["Smtp:host"]!;
            _port = Convert.ToInt32(_configuracion["Smtp:port"]!);
            _user = _configuracion["Smtp:user"]!;
            _pass = _configuracion["Smtp:pass"]!;
        }

        public async Task Enviar(string para, string asunto, string mensajeHtml)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Soporte", _user)); // Nombre + correo remitente
                email.To.Add(new MailboxAddress("", para)); // Correo destinatario
                email.Subject = asunto;

                email.Body = new TextPart("html")
                {
                    Text = mensajeHtml
                };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_host, _port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_user, _pass);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
            }
        }
    }
}
