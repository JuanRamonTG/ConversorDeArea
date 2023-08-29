using System;
using System.Windows.Forms;

namespace ConversorDeArea
{
    public partial class Form1 : Form
    {
        private string[] unidades = { "Pie Cuadrado", "Vara Cuadrada", "Yarda Cuadrada", "Metro Cuadrado", "Tareas", "Manzana", "Hectárea" };
        private decimal[] factores = { 1, 0.698777m, 0.836127m, 0.092903m, 0.024711m, 0.000671m, 0.0001m };

        public Form1()
        {
            InitializeComponent();

            cmbDe.Items.AddRange(unidades);
            cmbA.Items.AddRange(unidades);

            cmbDe.SelectedIndex = -1;
            cmbA.SelectedIndex = -1;
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValor.Text, out decimal valor) &&
                cmbDe.SelectedIndex >= 0 && cmbA.SelectedIndex >= 0)
            {
                int indiceDe = cmbDe.SelectedIndex;
                int indiceA = cmbA.SelectedIndex;

                decimal resultado = ConvertirUnidades(valor, indiceDe, indiceA);

                lblResultado.Text = resultado.ToString("0.####");
            }
            else
            {
                lblResultado.Text = "Error de entrada";
            }
        }

        private decimal ConvertirUnidades(decimal valor, int indiceDe, int indiceA)
        {
            return valor * factores[indiceDe] / factores[indiceA];
        }
    }
}
