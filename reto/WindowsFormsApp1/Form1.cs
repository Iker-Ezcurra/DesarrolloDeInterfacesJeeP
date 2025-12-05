using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using biblioteca;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool animando = false;

        bool dragging = false;
        Point dragCursorPoint;
        Point dragPictureBoxPoint;
        Image imagenOriginal;
        Image imagenTemporal;
        Image gif;
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            imagenOriginal = Image.FromFile("Recursos\\LectorDeBarraApagado.png");
            imagenTemporal = Image.FromFile("Recursos\\LectorDeBarrasEncendido.png");
            
            gif = Image.FromFile("Recursos\\Impresora.png");
            pictureBox14.Image = gif;

            userControl11.ActivarGif += UserControl11_ActivarGif;

            timer.Interval = 100;
            timer.Tick += Timer_tick;
            timer.Start();
        }

        private async void Timer_tick(object sender, EventArgs e)
        {
            if (animando)
            {
                pictureBox14.Image = Image.FromFile("Recursos\\express-thermal-print-animated-logo-small.gif");
                timer.Stop();

                await Task.Delay(2500);

                pictureBox14.Image = Image.FromFile("Recursos\\Imprimido.png");

                animando = false;

                timer.Start();
            }
        }

        private void UserControl11_ActivarGif(object sender, EventArgs e)
        {
            animando = true; 
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragPictureBoxPoint = pictureBox13.Location;
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging) {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                pictureBox13.Location = Point.Add(dragPictureBoxPoint, new Size(dif));
            }
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private async void pictureBox13_DoubleClick(object sender, EventArgs e)
        {
            pictureBox13.BackgroundImage = imagenTemporal;
            if (pictureBox13.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                userControl11.CargarProducto("Agenda", 1.0);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                userControl11.CargarProducto("Archivadores de colores", 1.2);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                userControl11.CargarProducto("Auriculares", 4.0);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                userControl11.CargarProducto("Cargador", 3.5);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                userControl11.CargarProducto("Cable USB", 2.5);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox6.Bounds))
            {
                userControl11.CargarProducto("Boligrafo", 0.7);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox7.Bounds))
            {
                userControl11.CargarProducto("Cinta aislante negra", 0.8);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox8.Bounds))
            {
                userControl11.CargarProducto("Cinta adhesiva ", 1.0);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox9.Bounds))
            {
                userControl11.CargarProducto("Carpeta de colores", 1.0);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                userControl11.CargarProducto("Cortauñas", 1.2);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox11.Bounds))
            {
                userControl11.CargarProducto("Collar de mascorta", 2.0);
                userControl11.MostrarProductos();
            }
            else if (pictureBox13.Bounds.IntersectsWith(pictureBox12.Bounds))
            {
                userControl11.CargarProducto("Coche", 3.0);
                userControl11.MostrarProductos();
            }
            await Task.Delay(1000);

            pictureBox13.BackgroundImage = imagenOriginal;
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
