
using SFPresentation.Utilidades.Objetos;

namespace SFPresentation.Utilidades
{
    public static class CustomComboBox
    {
        public static void InsertarItems(this ComboBox combo, OpcionCombo[]items)
        {
            combo.Items.AddRange(items); // Primero agrego los items
            combo.DisplayMember = "Texto";
            combo.ValueMember = "Valor";
            combo.SelectedIndex = 0; // Siempre se seleccione el 0 
        }

        // Metodo para indicar que al editar un objeto este lo setee en su unidad correspondiente
        public static void EstablecerValor(this ComboBox combo, int valor)
        {
            foreach (OpcionCombo opcion in combo.Items)
            {
                if (opcion.Valor == valor)
                {
                    combo.SelectedItem = opcion;
                    break;
                }
            }
        }
    }
}
