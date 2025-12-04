using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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

        //Devuelve la cantidad del produto
        public int getCantidad(int i)
        {
            return productos[i].Cantidad;
        }

        //Devuelve el precio del produto
        public double getPrecio(int i)
        {
            return productos[i].Precio;
        }

        public void CargarProducto(String nombre, Double precio) 
        {
            //Por defedcto la cantidad siempre es 1
            int cantidad = 1;
            //Agrega un nuevo producto a la lista de productos
            productos.Add(new Producto { Nombre = nombre, Cantidad = cantidad, Precio = precio });
        }

        public void MostrarProductos()
        {
            //Reinicia la vista de la pantalla con la lista
            dataGridView1.DataSource = null;  
            dataGridView1.DataSource = productos;
        }

        //la clase producto con sus getters y setters
        public class Producto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public double Precio { get; set; }
        }

        //los siguitentes metodos son para agregar numero al textBox  y a la variable numero que hara de cantidad
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 1;
                textBox1.Text = numero.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (!punto)
            {
                numero = numero * 10 + 2;
                textBox1.Text=numero.ToString();
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
                textBox1.Text = numero.ToString();
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

        //Este metodo hasigna al producto que tiene selecionado su cantidad y limpia el textBox
        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null) {
                //Recoge el producto seleccionado 
                Producto p = dataGridView1.CurrentRow.DataBoundItem as Producto;

                if (p != null) {
                    //Cambia la cantidad
                    p.Cantidad = (int) numero;
                    //Resetea todo
                    numero = 0;
                    textBox1.Text = "";
                    dataGridView1.Refresh();
                }
            }
        }

        //Este metodo elimina la linea que tiene selecionado
        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) {
                //Recoge el producto seleccionado 
                Producto p = dataGridView1.CurrentRow.DataBoundItem as Producto;

                if (p != null) { 
                    //Elimina el producto
                    productos.Remove(p);
                    //Resetea la vista
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = productos;
                }
            }
        }

        //Este metodo muestra la suma del precio de todos los productos
        private void button13_Click(object sender, EventArgs e)
        {
            double total = 0;
            foreach (Producto p in productos) {
                total += p.Cantidad * p.Precio;
            }

            textBox2.Text = total.ToString();
        }

        //Este metodo envia una señal que da inicio a la animacion del ticket y limpia la pantalla
        private void button12_Click(object sender, EventArgs e)
        {
            ActivarGif?.Invoke(this, EventArgs.Empty);
            productos.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
        }
    }
}
