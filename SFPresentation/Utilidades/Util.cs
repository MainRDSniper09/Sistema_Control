
using SFRepository.Entities;
using System.Security.Cryptography;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace SFPresentation.Utilidades
{
    public static class Util
    {
        public static string GenerateCode()
        {
            var guid = Guid.NewGuid().ToString("N").Substring(0, 6);
            return guid;
        }

        public static string ConvertToSha256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2")); // Convierte a hexadecimal
                }

                return result.ToString();
            }
        }

        public static byte[] GeneratePDFVenta(Negocio oNegocio, Venta oVenta, Stream imageLogo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var arrayPDF = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);
                    page.Header().ShowOnce().Row(row =>
                    {
                        row.AutoItem().Height(60).Image(imageLogo); // Fix the issue by using the Image method
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().AlignCenter().Text(oNegocio.RazonSocial).Bold().FontSize(14);
                            col.Item().AlignCenter().Text(oNegocio.Direccion).FontSize(9);
                            col.Item().AlignCenter().Text(oNegocio.Celular).FontSize(9);
                            col.Item().AlignCenter().Text(oNegocio.Correo).FontSize(9);
                        });

                        row.ConstantItem(140).Column(col =>
                        {
                            col.Item().Border(1).BorderColor("#634883").AlignCenter().Text($"RUT {oNegocio.RUT}");
                            col.Item().Background("#634883").Border(1).BorderColor("#634883").AlignCenter().Text("Serie de Venta").FontColor("#fff");
                            col.Item().Border(1).BorderColor("#634883").AlignCenter().Text(oVenta.NumeroVenta);
                        });
                    });

                    page.Content().PaddingVertical(15).Column(col1 =>
                    {
                        col1.Spacing(10);
                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Row(row =>
                        {
                            row.RelativeItem().Text(txt =>
                            {
                                txt.Span("Cliente:").SemiBold().FontSize(10);
                                txt.Span(oVenta.NombreCliente).FontSize(10);
                            });
                            row.RelativeItem().Text(txt =>
                            {
                                txt.Span("Fecha Emisión:").SemiBold().FontSize(10);
                                txt.Span(oVenta.FechaRegistro).FontSize(10);
                            });
                        });

                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(colums =>
                            {
                                colums.RelativeColumn(3);
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                            });

                            tabla.Header(header =>
                            {
                                header.Cell().Background("#634883").Padding(2).Text("Producto").FontColor("#fff");
                                header.Cell().Background("#634883").Padding(2).Text("Precio").FontColor("#fff");
                                header.Cell().Background("#634883").Padding(2).Text("Cantidad").FontColor("#fff");
                                header.Cell().Background("#634883").Padding(2).Text("Total").FontColor("#fff");
                            });

                            foreach (DetalleVenta item in oVenta.RefDetalleVenta)
                            {
                                decimal cantidad = Convert.ToDecimal(item.Cantidad) / Convert.ToDecimal(item.RefProducto.RefCategoria.RefMedida.Valor);
                                string abreviatura = item.RefProducto.RefCategoria.RefMedida.Abreviatura.ToString();

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(item.RefProducto.Descripcion).FontSize(10);
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{oNegocio.SimboloMoneda}{item.PrecioVenta:0.00}").FontSize(10);
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{cantidad}{abreviatura}").FontSize(10);
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"{oNegocio.SimboloMoneda}{item.PrecioTotal}").FontSize(10);
                            }
                        });

                        col1.Item().AlignRight().Text($"{oNegocio.SimboloMoneda}{oVenta.PrecioTotal}").FontSize(10);
                    });

                    page.Footer().AlignRight().Text(txt =>
                    {
                        txt.Span("Página ").FontSize(10);
                        txt.CurrentPageNumber().FontSize(10);
                        txt.Span(" de ").FontSize(10);
                        txt.TotalPages().FontSize(10);
                    });
                });
            }).GeneratePdf();
            return arrayPDF;
        }

    }
}
