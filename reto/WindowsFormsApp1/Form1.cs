using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using biblioteca;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool animando = false;

        //Estos atributos son para el lector de barras, con esto se puede arrastrar
        bool dragging = false;
        Point dragCursorPoint;
        Point dragPictureBoxPoint;
        //Estos nos ayudaran al funcionamiento picturebox de los tickets
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

        //En este metodo preparamos la animacion de crear un ticket, siempre esta escuchando a que animado sea true
        private async void Timer_tick(object sender, EventArgs e)
        {
            if (animando)
            {
                pictureBox14.Image = Image.FromFile("Recursos\\express-thermal-print-animated-logo-small.gif");
                //Deja de escuchar
                timer.Stop();
                //la duracion del gif
                await Task.Delay(2500);

                pictureBox14.Image = Image.FromFile("Recursos\\Imprimido.png");
                pictureBox14.Enabled = true;

                //se encarga de que no vuelva a entrar en el if
                animando = false;

                //Vuelve a escuchar que animando sea true
                timer.Start();
            }
        }

        //Dice que el controlador de usuario dio al boton de crear el ticket y cambia animado a true
        private void UserControl11_ActivarGif(object sender, EventArgs e)
        {
            animando = true; 
        }

        //Los siguientes tres metodos son los necesarios para el arrastre el picturebox
        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            //Se inicio el arrastre
            dragging = true;
            //Guarda la posicion del cursor
            dragCursorPoint = Cursor.Position;
            //Gurada la posicion del pictrueBox
            dragPictureBoxPoint = pictureBox13.Location;
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            //Comprueba si el usuario tiene agarrado el pictureBox
            if (dragging) {
                //Calcula la diferencia entre la posicion actual del cursor y la posicion donde empezo el arraste
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                //Mueve el pictureBox sumando la diferencia
                pictureBox13.Location = Point.Add(dragPictureBoxPoint, new Size(dif));
            }
        }

        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            //Finaliza el arrastre
            dragging = false;
        }

        private async void pictureBox13_DoubleClick(object sender, EventArgs e)
        {
            //Cambia temporalmente la imagen
            pictureBox13.BackgroundImage = imagenTemporal;
            //detecta si el pictureBox esta encima de otro
            if (pictureBox13.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                //Carga un producto en el controlador de usuario
                userControl11.CargarProducto("Agenda", 1.0);
                //Llama al metodo para mostrar por pantalla
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
            //Vuelve a la imagen original
            pictureBox13.BackgroundImage = imagenOriginal;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pictureBox14.Image = gif;

            //Esto es una idea descartada del ticket

            //reto/WindowsFromApp1/bin/Debug/Tickets
            //string rutaCarpeta = Path.Combine(Application.StartupPath, "Tickets");

            //string fechaHora = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string rutaArchivo = Path.Combine(rutaCarpeta, fechaHora+".txt");

            //Directory.CreateDirectory(rutaCarpeta);
        }
    }
}
