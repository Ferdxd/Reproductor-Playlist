using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Progra_Listas.ListaPuntos
{
    class Nodo
    {
        public string dato;
        public Nodo enlace;

        public Nodo(string x)
        {
            dato = x;
            enlace = null;
        }

        public Nodo(string x,Nodo n)
        {
            dato = x;
            enlace = n;
        }

        public string getDato()
        {
            return dato;
        }
        public Nodo getEnlace()
        {
            return enlace;
        }

        public void setEnlace(Nodo Enlace)
        {
            this.enlace = Enlace;
        }


    }
}
