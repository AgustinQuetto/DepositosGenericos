using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoDeAutos
    {
        private int _capacidadMaxima;
        private List<Auto> _lista;

        public DepositoDeAutos(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Auto>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad: "+this._capacidadMaxima);
                foreach (Auto aux in this._lista)
                {
                    sb.AppendLine(aux.ToString());
                }

            return sb.ToString();
        }

        public static bool operator +(DepositoDeAutos D, Auto A)
        {
            if (D._lista.Count + 1 <= D._capacidadMaxima)
            {
                    D._lista.Add(A);
                    return true;
            }
            return false;
        }

        public static bool operator -(DepositoDeAutos D, Auto A)
        {
            if (D.GetIndice(A) != -1)
            {
                D._lista.Remove(A);
                return true;
            }

            return false;
        }

        public int GetIndice(Auto a)
        {
            foreach (Auto aux in this._lista)
            {
                if (aux == a)
                {
                    return this._lista.IndexOf(aux);
                }
            }

            return -1;
        }

        public bool Agregar(Auto a)
        {
            if (this + a)
            {
                return true;
            }
            return false;
        }

        public bool Remover(Auto a)
        {
            if (this - a)
            {
                return true;
            }
            return false;
        }

    }
}
