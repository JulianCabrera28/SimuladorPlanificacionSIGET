using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorPlanificacionSIGET
{
    public class Proceso
    {
        public string Nombre { get; set; }

        public int TiempoLlegada { get; set; }

        public int Prioridad { get; set; }

        public int TamanoDatos { get; set; }

        public int TiempoEjecucion { get; set; }

        public int TiempoRestante { get; set; }

        public EstadoProceso Estado { get; set; }
    }
}
