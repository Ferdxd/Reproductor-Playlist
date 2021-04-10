using Proyecto_Progra_Listas.ListaPuntos;
using Proyecto_Progra_Listas.ListasOrdenadas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor_PlaylistsProgra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] archivo, ruta;
        bool reproducir = true;
        ListaOrden rutas = new ListaOrden();
        ListaOrden canciones = new ListaOrden();
        int iterador=0;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (reproducir)
            {
                axWindowsMediaPlayer1.URL = rutas.buscarPosicion(iterador + 1).dato.ToString();
                reproducir = false;
            }
            axWindowsMediaPlayer1.Ctlcontrols.play();
            lblCancion.Text = canciones.buscarPosicion(iterador).dato.ToString();

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.URL = rutas.buscarPosicion(listBox1.SelectedIndex+1).dato.ToString();
            }
            catch
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.URL = "";
                axWindowsMediaPlayer1.close();
            }
            iterador = listBox1.SelectedIndex+1;
            lblCancion.Text = canciones.buscarPosicion(iterador).dato.ToString();

        }

    

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            iterador++;
            axWindowsMediaPlayer1.URL = rutas.buscarPosicion(iterador).dato.ToString();
            lblCancion.Text = canciones.buscarPosicion(iterador).dato.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            iterador--;
            axWindowsMediaPlayer1.URL = rutas.buscarPosicion(iterador).dato.ToString();
            lblCancion.Text = canciones.buscarPosicion(iterador).dato.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void lblCancion_Click(object sender, EventArgs e)
        {
           
        }

     

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                rutas.eliminar(rutas.buscarPosicion(iterador).dato.ToString());
                canciones.eliminar(canciones.buscarPosicion(iterador).dato.ToString());
                listBox1.Items.RemoveAt(iterador - 1);    
        }

       
     
        private void btnAgregar_Click(object sender, EventArgs e)
        {
         
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK){
                archivo = openFileDialog1.SafeFileNames;
                ruta = openFileDialog1.FileNames;
                for(int i = 0; i < archivo.Length; i++)
                {
                    rutas.insertaOrden(ruta[i]);
                    canciones.insertaOrden(archivo[i]);
                }
            }

            Nodo n;
            n = canciones.primero;
            while (n != null)
            {
                listBox1.Items.Add(n.dato.ToString());
                n = n.enlace;

            }


        }
    }
}
