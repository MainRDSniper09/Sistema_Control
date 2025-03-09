using Microsoft.Web.WebView2.Core.Raw;
using SFPresentation.Utilidades.Objetos;
using SFPresentation.Utilidades;
using SFPresentation.ViewModels;
using SFServices.Implementation;
using SFServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFRepository.Entities;

namespace SFPresentation.Formularios
{
    public partial class frmUsuario : Form
    {
        private readonly IRolService _rolService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICorreoService _correoService;
        public frmUsuario(IUsuarioService usuarioService, IRolService rolService, ICorreoService correoService)
        {
            InitializeComponent();
            _rolService = rolService;
            _correoService = correoService;
            _usuarioService = usuarioService;
        }


        // Metodo para eliminar los tabs
        public void MostarTab(string tabName)
        {
            var TabsMenu = new TabPage[]
            {
                tabLista,tabNuevo,tabEditar
            };

            foreach (var tab in TabsMenu)
            {
                if (tab.Name != tabName)
                {
                    tab.Parent = null;
                }
                else
                {
                    tab.Parent = tabControlMain;
                }
            }
        }

        private async Task MostrarUsuarios(string buscar = "")
        {
            var listaUsuario = await _usuarioService.Lista(buscar);
            var listaVM = listaUsuario.Select(item => new UsuarioVM
            {
                IdUsuario = item.IdUsuario,
                IdRol = item.RefRol.IdRol,
                Rol = item.RefRol.Nombre,
                NombreCompleto = item.NombreCompleto,
                Correo = item.Correo,
                NombreUsuario = item.NombreUsuario,
                Activo = item.Activo,
                Habilitado = item.Activo == 1 ? "Si" : "No",

            }).ToList();

            dgvUsuarios.DataSource = listaVM;
            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdRol"].Visible = false;
            dgvUsuarios.Columns["Activo"].Visible = false;
        }

        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            MostarTab(tabLista.Name);
            dgvUsuarios.ImplementarConfiguracion("Editar"); // Mandamos a llamar nuestra configuracion previamente realizada
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ocupa todo nuestro cuadro hasta el final 
            await MostrarUsuarios();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[]
            {
                new OpcionCombo{Texto = "Si", Valor = 1},
                new OpcionCombo{Texto = "No", Valor = 0},
            };
            var listaRol = await _rolService.Lista();
            var items = listaRol.Select(item => new OpcionCombo { Texto = item.Nombre, Valor = item.IdRol }).ToArray();

            cbbRolNuevo.InsertarItems(items);
            cbbRolEditar.InsertarItems(items);

            cbbHabilitado.InsertarItems(itemsHabilitado);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarUsuarios(txbBuscar.Text); // Funcion para buscar 
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            cbbRolNuevo.SelectedIndex = 0;
            txbNombreCompletoNuevo.Text = "";
            txbCorreoNuevo.Text = "";
            txbNombreUsuarioNuevo.Text = "";
            MostarTab(tabNuevo.Name);
            cbbRolNuevo.Select();
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostarTab(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (txbNombreCompletoNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre completo");
                return;
            }
            if (txbCorreoNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el correo");
                return;
            }
            if (txbNombreUsuarioNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre de usuario");
                return;
            }

            var claveGenerada = Util.GenerateCode(); // AQUI se genera la clave 
            var claveSha256 = Util.ConvertToSha256(claveGenerada); // AQUI se covierte a Sha256

            var objeto = new Usuario
            {
                RefRol = new Rol
                {
                    IdRol = ((OpcionCombo)cbbRolNuevo.SelectedItem!).Valor
                },
                NombreCompleto = txbNombreCompletoNuevo.Text.Trim(),
                Correo = txbCorreoNuevo.Text.Trim(),
                NombreUsuario = txbNombreUsuarioNuevo.Text.Trim(),
                Clave = claveSha256
            };

            var respuesta = await _usuarioService.Crear(objeto);

            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                var mensaje = $@"
    <div style='font-family: Arial, sans-serif; padding: 20px; border: 1px solid #ddd; border-radius: 10px; background-color: #f9f9f9; max-width: 500px; margin: auto; text-align: center;'>
        <h2 style='color: #4CAF50;'>¡Bienvenido a Nuestra Plataforma!</h2>
        <p style='font-size: 16px; color: #333;'>Hola,</p>
        <p style='font-size: 16px; color: #333;'>Tu cuenta ha sido creada exitosamente.</p>
        <p style='font-size: 16px; color: #333;'><strong>Tu contraseña temporal es:</strong></p>
        <p style='font-size: 20px; font-weight: bold; color: #4CAF50; background-color: #e8f5e9; padding: 10px; border-radius: 5px; display: inline-block;'>{claveGenerada}</p>
        <p style='font-size: 16px; color: #333;'>Te recomendamos cambiar tu contraseña lo antes posible.</p>
        <br>
        <a href='#' style='display: inline-block; padding: 10px 20px; font-size: 16px; color: #fff; background-color: #4CAF50; text-decoration: none; border-radius: 5px;'>Ir a la plataforma</a>
        <br><br>
        <p style='font-size: 14px; color: #777;'>Si no solicitaste esta cuenta, ignora este mensaje.</p>
        <br>
        <hr style='border: 0; height: 1px; background: #ddd; margin: 20px 0;'>
        <p style='font-size: 12px; color: #555;'>Desarrollado por <strong>Juan Nicolás Barreto</strong></p>
        <p style='font-size: 12px; color: #555;'>&copy; {DateTime.Now.Year} Todos los derechos reservados.</p>
    </div>";

                await _correoService.Enviar(objeto.Correo, "Cuenta Creada", mensaje);



                await MostrarUsuarios();
                MostarTab(tabLista.Name);
            }


        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var usuarioSeleccionado = (UsuarioVM)dgvUsuarios.CurrentRow.DataBoundItem;

                cbbRolEditar.EstablecerValor(usuarioSeleccionado.IdRol);
                txbNombreCompletoEditar.Text = usuarioSeleccionado.NombreCompleto.ToString();
                txbCorreoEditar.Text = usuarioSeleccionado.Correo.ToString();
                txbNombreUsuarioEditar.Text = usuarioSeleccionado.NombreUsuario.ToString();

                cbbHabilitado.EstablecerValor(usuarioSeleccionado.Activo);

                MostarTab(tabEditar.Name);
                cbbRolEditar.Select();
            }
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostarTab(tabLista.Name);
        }

        private async void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (txbNombreCompletoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre completo");
                return;
            }
            if (txbCorreoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el correo");
                return;
            }
            if (txbNombreUsuarioEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre de usuario");
                return;
            }

            var usuarioSeleccionado = (UsuarioVM)dgvUsuarios.CurrentRow.DataBoundItem;

            var objeto = new Usuario
            {
                IdUsuario = usuarioSeleccionado.IdUsuario,
                RefRol = new Rol
                {
                    IdRol = ((OpcionCombo)cbbRolEditar.SelectedItem!).Valor
                },
                NombreCompleto = txbNombreCompletoEditar.Text.Trim(),
                Correo = txbCorreoEditar.Text.Trim(),
                NombreUsuario = txbNombreUsuarioEditar.Text.Trim(),
                Activo = ((OpcionCombo)cbbHabilitado.SelectedItem!).Valor
            };

            var respuesta = await _usuarioService.Editar(objeto);

            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                await MostrarUsuarios();
                MostarTab(tabLista.Name);
            }
        }
    }
}
