using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        private string razonSocial;

        public float GananciasPorLocal { get => CalcularGanancia(Llamada.TipoLlamada.Local); }
        public float GananciasPorProvincial { get => CalcularGanancia(Llamada.TipoLlamada.provincial) ; }
        public float GananciasPorTotal { get => CalcularGanancia(Llamada.TipoLlamada.Todas); }
        public List<Llamada> Llamadas { get => this.listaDeLlamadas; }

        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string nombreEmpresa) : this()
        {
            this.razonSocial = nombreEmpresa;
        }

        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float acumulador = 0;
            foreach(Llamada item in this.listaDeLlamadas)
            {
                if(item is Local)
                {
                    if(tipo == Llamada.TipoLlamada.Local || tipo == Llamada.TipoLlamada.Todas)
                    {
                        acumulador += ((Local)item).CostoLlamada;
                    }
                }
                if(item is Provincial)
                {
                    if (tipo == Llamada.TipoLlamada.provincial || tipo == Llamada.TipoLlamada.Todas)
                    {
                        acumulador += ((Provincial)item).CostoLlamada;
                    }
                }
            }
            return acumulador;
        }
        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Razon social: {this.razonSocial}.");
            sb.AppendLine($"Ganancia total: {this.GananciasPorTotal}");
            sb.AppendLine($"Ganancia local: {this.GananciasPorLocal}");
            sb.AppendLine($"Ganancia provincial: {this.GananciasPorProvincial}");
            sb.AppendLine($"Llamadas: ");
            foreach(Llamada item in this.listaDeLlamadas)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("----------------------------------");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }
        private void AgregarLlamada(Llamada llamada)
        {
            this.listaDeLlamadas.Add(llamada);
        }
        public static bool operator ==(Centralita centralita, Llamada llamada)
        {
            foreach(Llamada item in centralita.listaDeLlamadas)
            {
                if(item == llamada)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Centralita centralita, Llamada llamada)
        {
            return !(centralita== llamada);
        }
        public static bool operator +(Centralita centralita, Llamada llamada)
        {
            if(centralita != llamada)
            {
                centralita.AgregarLlamada(llamada);
                return true;
            }
            return false;
        }
    }
}
