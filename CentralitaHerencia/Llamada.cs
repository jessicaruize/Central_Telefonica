using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public abstract class Llamada
    {
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;
        public enum TipoLlamada { Local, provincial, Todas };

        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }
        public abstract float CostoLlamada { get; }

        public float Duracion { get => duracion; }
        public string NroDestino { get => nroDestino; }
        public string NroOrigen { get => nroOrigen; }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nDuracion: " + this.Duracion);
            sb.AppendLine("Numero destino: " + this.NroDestino);
            sb.AppendLine("Numero origen: " + this.NroOrigen);
            return sb.ToString();
        }
        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            return (int)(llamada1.Duracion - llamada2.Duracion);
        }
        public static bool operator ==(Llamada llamada1, Llamada llamada2)
        {
            return (llamada1.Equals(llamada2) && llamada1.NroDestino == llamada2.NroDestino && llamada1.NroOrigen == llamada2.NroOrigen);
        }
        public static bool operator !=(Llamada llamada1, Llamada llamada2)
        {
            return !(llamada1 == llamada2);
        }
    }
}
