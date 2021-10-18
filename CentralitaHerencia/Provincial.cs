using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial : Llamada
    {
        public enum Franja { Franja_1, Franja_2, Franja_3 }
        private Franja franjaHoraria;
        public Provincial(Franja miFranja, Llamada llamada)
            : this(llamada.NroOrigen, miFranja, llamada.Duracion, llamada.NroDestino) 
        {
        }
        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base (duracion, destino, origen)
        {
            this.franjaHoraria = miFranja;
        }
        public override float CostoLlamada { get => CalcularCosto(); }
        private float CalcularCosto()
        {
            float costo = 0;
            switch(this.franjaHoraria)
            {
                case Franja.Franja_1:
                    costo = 0.99F * base.Duracion;
                    break;
                case Franja.Franja_2:
                    costo = 1.25F * base.Duracion;
                    break;
                default:
                    costo = 0.66F * base.Duracion;
                    break;
            }
            return costo;
        }
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Costo llamada: {this.CostoLlamada.ToString("00.0")}");
            sb.AppendLine($"Franja horaria: {this.franjaHoraria}\n");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
        public override bool Equals(object obj)
        {
            return obj is Provincial;
        }

    }
}
