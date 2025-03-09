using SFPresentation.Utilidades;
using SFPresentation.ViewModels;
using SFServices.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace SFPresentation.Formularios
{
    public partial class frmDetalleVenta : Form
    {
        private readonly IVentaService _ventaService;
        private readonly INegocioService _negocioService;
        public string _numeroVenta { get; set; } = null!;
        public frmDetalleVenta(INegocioService negocioService, IVentaService ventaService)
        {
            InitializeComponent();
            _negocioService = negocioService;
            _ventaService = ventaService;
        }

        private async void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            dgvDetalle.ImplementarConfiguracion();
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var detalleVenta = await _ventaService.ObtenerDetalle(_numeroVenta);

            var listaVM = detalleVenta.Select(item => new DetalleVentaVM
            {
                Producto = item.RefProducto.Descripcion,
                Precio = item.PrecioVenta,
                CantidadTexto = string.Concat(item.Cantidad, "", item.RefProducto.RefCategoria.RefMedida.Equivalente),
                Total = item.PrecioTotal,
            }).ToList();

            lblNumeroVenta.Text = _numeroVenta;
            dgvDetalle.DataSource = listaVM;
            dgvDetalle.Columns["IdProducto"].Visible = false;
            dgvDetalle.Columns["CantidadValor"].Visible = false;
        }

        private async void btnVerPDF_Click(object sender, EventArgs e)
        {

            var oNegocio = await _negocioService.Obtener();
            var oVenta = await _ventaService.Obtener(_numeroVenta);
            var oDetalleVenta = await _ventaService.ObtenerDetalle(_numeroVenta);
            oVenta.RefDetalleVenta = oDetalleVenta;

            if (string.IsNullOrEmpty(oNegocio.UrlLogo) || !Uri.IsWellFormedUriString(oNegocio.UrlLogo, UriKind.Absolute))
            {
                MessageBox.Show("La URL del logo no es válida.");
                return;
            }

            MemoryStream imagenLogo;
            using (var httpClient = new HttpClient())
            {
                var imageBytes = await httpClient.GetByteArrayAsync(oNegocio.UrlLogo); // Error AQUI
                imagenLogo = new MemoryStream(imageBytes);
            }
            var arrayPDF = Util.GeneratePDFVenta(oNegocio, oVenta, imagenLogo);

            using (SaveFileDialog sFileDialog = new SaveFileDialog())
            {
                sFileDialog.Filter = "PDF Files (*.pdf)|*pdf";
                sFileDialog.Title = "Guardar PDF";
                sFileDialog.DefaultExt = "pdf";
                sFileDialog.AddExtension = true;
                sFileDialog.FileName = $"{_numeroVenta}";

                if (sFileDialog.ShowDialog() == DialogResult.OK)
                {
                    await File.WriteAllBytesAsync(sFileDialog.FileName, arrayPDF);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = sFileDialog.FileName,
                        UseShellExecute = true,
                    });
                }

            }

        }

    }
}
