using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repaso2_3D
{
    public partial class Form1 : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        public Form1()
        {
            InitializeComponent();
        }
        private void GuardarVehiculo()
        {
            FileStream stream = new FileStream("Alquileres.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.placa);
                writer.WriteLine(vehiculo.marca);
                writer.WriteLine(vehiculo.modelo);
                writer.WriteLine(vehiculo.color);
                writer.WriteLine(vehiculo.precioKilometro);
            }

            writer.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.placa = textBoxPlaca.Text;
            vehiculo.marca = textBoxMarca.Text;
            vehiculo.color = textBoxColor.Text;
            vehiculo.modelo = Convert.ToInt16(textBoxModelo.Text);
            vehiculo.precioKilometro = Convert.ToDecimal(textBoxPrecio.Text);

            int poscion = vehiculos.FindIndex(x => x.placa == textBoxPlaca.Text);
            if (poscion == -1)
            {
                vehiculos.Add(vehiculo);
                GuardarVehiculo();
            }
            else
            {
                MessageBox.Show("placa repetida");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAlquiler formAlquiler = new FormAlquiler();
            formAlquiler.Show();
        }
    }
}
