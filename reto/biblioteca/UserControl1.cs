using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static biblioteca.UserControl1;

namespace biblioteca
{
    public partial class UserControl1 : UserControl
    {
        double numero = 0;
        Boolean punto = false;
        List<Producto> productos = new List<Producto>();
        public event EventHandler ActivarGif;

        public UserControl1()
        {
            InitializeComponent();
        }

        public void CargarProducto(String nombre, Double precio) 
        {
            int cantidad = 1;
            productos.Add(new Producto { Nombre = nombre, Cantidad = cantidad, Precio = precio });
        }

        public void MostrarProductos()
        {
            dataGridView1.DataSource = null;  
            dataGridView1.DataSource = productos;
        }

        public class Producto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public double Precio { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 1;
                textBox1.Text = numero.ToString();
            }
            else { 
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 3;
                textBox1.Text = numero.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 4;
                textBox1.Text = numero.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 5;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 6;
                textBox1.Text = numero.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 7;
                textBox1.Text = numero.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 8;
                textBox1.Text = numero.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 9;
                textBox1.Text = numero.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10;
                textBox1.Text = numero.ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null) {
                Producto p = dataGridView1.CurrentRow.DataBoundItem as Producto;

                if (p != null) {
                    p.Cantidad = (int) numero;

                    numero = 0;
                    textBox1.Text = "";
                    dataGridView1.Refresh();
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) {
                Producto p = dataGridView1.CurrentRow.DataBoundItem as Producto;

                if (p != null) { 
                    productos.Remove(p);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = productos;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            double total = 0;
            foreach (Producto p in productos) {
                total += p.Cantidad * p.Precio;
            }

            textBox2.Text = total.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ActivarGif?.Invoke(this, EventArgs.Empty);
        }
    }
}
