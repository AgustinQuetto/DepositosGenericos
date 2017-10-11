using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoDeCocinas
    {

        private int _capacidadMaxima;
        private List<Cocina> _lista;

        public DepositoDeCocinas(int capacidad)
        {
            this._capacidadMaxima = capacidad;
            this._lista = new List<Cocina>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad: " + this._capacidadMaxima);
                foreach (Cocina aux in this._lista)
                {
                    sb.AppendLine(aux.ToString());
                }

            return sb.ToString();
        }

        public static bool operator +(DepositoDeCocinas D, Cocina A)
        {
            if (D._lista.Count + 1 <= D._capacidadMaxima)
            {
                    D._lista.Add(A);
                    return true;
            }
            return false;
        }

        public static bool operator -(DepositoDeCocinas D, Cocina A)
        {
            if (D.GetIndice(A) != -1)
            {
                D._lista.Remove(A);
                return true;
            }

            return false;
        }

        public int GetIndice(Cocina a)
        {
            foreach (Cocina aux in this._lista)
            {
                if (aux == a)
                {
                    return this._lista.IndexOf(aux);
                }
            }

            return -1;
        }

        public bool Agregar(Cocina a)
        {
            if (this + a)
            {
                return true;
            }
            return false;
        }

        public bool Remover(Cocina a)
        {
            if (this - a)
            {
                return true;
            }
            return false;
        }

    }
}
