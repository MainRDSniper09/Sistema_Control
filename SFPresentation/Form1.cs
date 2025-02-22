using SFServices.Interfaces;
using System.Threading.Tasks;

namespace SFPresentation
{
    public partial class Form1 : Form
    {
       // private readonly IMedidaService _medidaService;

        public Form1(IMedidaService medidaService)
        {
            InitializeComponent();
        //    _medidaService = medidaService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         //   var lista = await _medidaService.Lista();
        }
    }
}
