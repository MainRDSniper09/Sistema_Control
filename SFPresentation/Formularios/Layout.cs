using Microsoft.Extensions.DependencyInjection;
using SFPresentation.Utilidades;
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

namespace SFPresentation.Formularios
{

    public partial class Layout : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMenuRolService _menuRolService;
        public Layout(IServiceProvider serviceProvider, IMenuRolService menuRolService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _menuRolService = menuRolService;
        }

        private void MostrarFormulario<TForm>() where TForm : Form
        {
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls[0].Dispose();
            }

            var newForm = _serviceProvider.GetRequiredService<TForm>();
            newForm.TopLevel = false;
            newForm.TopMost = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;  // Hace que ocupe todo el panel
            panelMain.Controls.Add(newForm);
            panelMain.Tag = newForm;  // Mantiene referencia en el panel
            newForm.Show();  // IMPORTANTE: Muestra el formulario
        }

        private async void Layout_Load(object sender, EventArgs e)
        {
            msMenu.Renderer = new CustomToolStripRenderer();
            msMenu.Refresh();

            lblUsuario.Text = $"Usuario: {UsuarioSesion.NombreUsuario}";
            lblRol.Text = $"Usuario: {UsuarioSesion.Rol}";

            var listaPrincipal = await _menuRolService.Lista(UsuarioSesion.IdRol);

            var menusPadres = listaPrincipal.Where(x => x.IdMenuPadre == 0).ToList();
            var menusHijo = listaPrincipal.Where(x => x.IdMenuPadre != 0).ToList();

            var menus = new ToolStripMenuItem[]
            {
                mnVentas, mnInventario, mnReportes, mnUsuarios, mnConfiguracion
            };
            var subMenus = new ToolStripMenuItem[]
            {
                smNuevo, smHistorial, smProductos, smCategorias, smVentas
            };

            foreach (var menu in menus)
            {
                var encontrado = menusPadres.Exists(x => x.NombreMenu == menu.Tag.ToString() && x.Activo);

                if (encontrado)
                {
                    menu.Visible = true;
                }
                else
                {
                    menu.Visible = false;
                }


            }
            foreach (var submenu in subMenus)
            {
                var encontrado = menusHijo.Exists(x => x.NombreMenu == submenu.Tag.ToString() && x.Activo);

                if (encontrado)
                {
                    submenu.Visible = true;
                }
                else
                {
                    submenu.Visible = false;
                }


            }

        }

        private void smNuevo_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmVenta>();
        }

        private void smHistorial_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmHistorial>();
        }

        private void smProductos_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmProducto>();
        }

        private void smCategorias_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmCategoria>();
        }

        private void mnUsuarios_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmUsuario>();
        }

        private void mnConfiguracion_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmNegocio>();
        }

        private void linkCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void smVentas_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmReporteVenta>();
        }
    }
}
