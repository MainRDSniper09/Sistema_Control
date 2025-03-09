
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using SFPresentation.Utilidades;
using SFServices.Implementation;
using SFServices.Interfaces;
using System.Threading.Tasks;

namespace SFPresentation.Formularios
{
    public partial class frmLogin : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ICorreoService _correoService;
        private readonly IServiceProvider _serviceProvider;

        public frmLogin(IUsuarioService usuarioService, ICorreoService correoService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _correoService = correoService;
            _serviceProvider = serviceProvider;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txbUsuario.Select();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {

            var encontrado = await _usuarioService.Login(txbUsuario.Text, Util.ConvertToSha256(txbContrasena.Text));

            if (encontrado == null)
            {
                MessageBox.Show("No se encontró el usuario");
                return;
            }
            if (encontrado.Activo == 0)
            {
                MessageBox.Show("El usuario no esta activo");
                return;
            }
            if (encontrado.ResetearClave == 1)
            {
                var _formActualizarClave = _serviceProvider.GetRequiredService<frmActualizarClave>();
                _formActualizarClave._idUsuario = encontrado.IdUsuario;
                var resultado = _formActualizarClave.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txbContrasena.Text = "";
                    txbContrasena.Select();
                    MessageBox.Show("La contraseña fue actualizada, vuelva a ingresar");
                }

            }
            else
            {
                UsuarioSesion.idUsuario = encontrado.IdUsuario;
                UsuarioSesion.NombreUsuario = encontrado.NombreUsuario;
                UsuarioSesion.NombreCompleto = encontrado.NombreCompleto;
                UsuarioSesion.IdRol = encontrado.RefRol.IdRol;
                UsuarioSesion.Rol = encontrado.RefRol.Nombre;

                // TODO: Cambiar Formulario layout 
                var _formLayout = _serviceProvider.GetRequiredService<Layout>();
                this.Hide();
                txbUsuario.Text = "";
                txbContrasena.Text = "";

                _formLayout.Show();
                _formLayout.FormClosed += (sender, e) =>
                {
                    this.Show();
                    txbUsuario.Select();
                };
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void linkOlvideContrasena_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var correo = Interaction.InputBox("Ingrese su correo de usuario", "Olvide mi contraseña", "");
            var idusuario = await _usuarioService.VerificarCorreo(correo);
            if (idusuario == 0)
            {
                MessageBox.Show("No se tiene ningun usuario con el correo ingresado");
                return;
            }
            var claveGenerada = Util.GenerateCode();
            var claveSha256 = Util.ConvertToSha256(claveGenerada);

            await _usuarioService.ActualizarClave(idusuario, claveSha256, 1);

            var mensaje = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    padding: 20px;
                }}
                .container {{
                    max-width: 500px;
                    background: white;
                    padding: 20px;
                    border-radius: 8px;
                    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
                    text-align: center;
                }}
                .title {{
                    font-size: 20px;
                    font-weight: bold;
                    color: #333;
                }}
                .message {{
                    font-size: 16px;
                    color: #555;
                    margin-top: 10px;
                }}
                .password {{
                    font-size: 18px;
                    font-weight: bold;
                    color: #007bff;
                    padding: 10px;
                    background: #f0f8ff;
                    display: inline-block;
                    border-radius: 5px;
                    margin-top: 15px;
                }}
                .footer {{
                    font-size: 14px;
                    color: #777;
                    margin-top: 20px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='title'>🔒 Contraseña Restablecida</div>
                <div class='message'>
                    Hemos generado una nueva contraseña temporal para su cuenta.<br>
                    Use la siguiente contraseña para iniciar sesión y luego cámbiela en la configuración de su cuenta.
                </div>
                <div class='password'>{claveGenerada}</div>
                <div class='footer'>Si no solicitó este cambio, ignore este mensaje.</div>
            </div>
        </body>
        </html>
    ";
            await _correoService.Enviar(correo, "🔑 Restablecimiento de Contraseña", mensaje);

            MessageBox.Show("Su contraseña fue actualizada, revise su correo");
        }
    }
}
