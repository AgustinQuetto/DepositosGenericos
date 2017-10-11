using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito<T>
    {
        private int _capacidadMaxima;
        private List<T> _lista;

        public Deposito(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<T>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad: " + this._capacidadMaxima);
                foreach (T aux in this._lista)
                {
                    sb.AppendLine(aux.ToString());
                }

            return sb.ToString();
        }

        public static bool operator +(Deposito<T> D, T A)
        {
            if (D._lista.Count + 1 <= D._capacidadMaxima)
            {
                    D._lista.Add(A);
                    return true;
            }
            return false;
        }

        public static bool operator -(Deposito<T> D, T A)
        {
            if (D.GetIndice(A) != -1)
            {
                D._lista.Remove(A);
                return true;
            }

            return false;
        }

        public int GetIndice(T a)
        {
            foreach (T aux in this._lista)
            {
                if (aux.Equals(a))
                {
                    return this._lista.IndexOf(aux);
                }
            }

            return -1;
        }

        public bool Agregar(T a)
        {
            if (this + a)
            {
                return true;
            }
            return false;
        }

        public bool Remover(T a)
        {
            if (this - a)
            {
                return true;
            }
            return false;
        }
    }
}
