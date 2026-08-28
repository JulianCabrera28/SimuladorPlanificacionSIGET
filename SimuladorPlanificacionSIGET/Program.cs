using System;

namespace SimuladorPlanificacionSIGET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("   SIMULADOR DE PLANIFICACION DEL SIGET");
            Console.WriteLine("==========================================");

            // PROCESOS PARA EL ALGORITMO DE PRIORIDAD

            Proceso emergencia = new Proceso
            {
                Nombre = "Emergencia de trafico",
                TiempoLlegada = 0,
                Prioridad = 1,
                TamanoDatos = 50,
                TiempoEjecucion = 4,
                TiempoRestante = 4,
                Estado = EstadoProceso.Nuevo
            };

            Proceso semaforos = new Proceso
            {
                Nombre = "Gestion de semaforos",
                TiempoLlegada = 1,
                Prioridad = 2,
                TamanoDatos = 30,
                TiempoEjecucion = 6,
                TiempoRestante = 6,
                Estado = EstadoProceso.Nuevo
            };

            Proceso sensores = new Proceso
            {
                Nombre = "Procesamiento de sensores",
                TiempoLlegada = 2,
                Prioridad = 3,
                TamanoDatos = 80,
                TiempoEjecucion = 8,
                TiempoRestante = 8,
                Estado = EstadoProceso.Nuevo
            };

            Planificador planificador = new Planificador();

            planificador.AgregarProceso(emergencia);
            planificador.AgregarProceso(semaforos);
            planificador.AgregarProceso(sensores);

            Console.WriteLine();
            Console.WriteLine("=== ESTADO INICIAL ===");

            planificador.MostrarProcesos();

            Console.WriteLine();
            Console.WriteLine("=== PROCESOS PASAN A LISTOS ===");

            planificador.PasarAListos();

            planificador.MostrarProcesos();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("       ALGORITMO: PRIORIDAD");
            Console.WriteLine("==========================================");

            planificador.EjecutarPorPrioridad();

            Console.WriteLine();
            Console.WriteLine("=== ESTADO FINAL - PRIORIDAD ===");

            planificador.MostrarProcesos();

            Console.WriteLine();
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();

            Console.Clear();

            // PRUEBA DEL ESTADO BLOQUEADO

            Console.WriteLine("==========================================");
            Console.WriteLine("          PRUEBA DE ESTADO BLOQUEADO");
            Console.WriteLine("==========================================");

            Proceso procesoBloqueado = new Proceso
            {
                Nombre = "Control de incidente vial",
                TiempoLlegada = 3,
                Prioridad = 1,
                TamanoDatos = 40,
                TiempoEjecucion = 5,
                TiempoRestante = 5,
                Estado = EstadoProceso.EnEjecucion
            };

            Planificador planificadorBloqueo = new Planificador();

            planificadorBloqueo.AgregarProceso(procesoBloqueado);

            Console.WriteLine();
            Console.WriteLine("Estado inicial:");

            planificadorBloqueo.MostrarProcesos();

            Console.WriteLine();

            planificadorBloqueo.BloquearProceso(procesoBloqueado);

            Console.WriteLine();
            Console.WriteLine("Estado despues de bloquear:");

            planificadorBloqueo.MostrarProcesos();

            Console.WriteLine();

            planificadorBloqueo.DesbloquearProceso(procesoBloqueado);

            Console.WriteLine();
            Console.WriteLine("Estado despues de desbloquear:");

            planificadorBloqueo.MostrarProcesos();

            Console.WriteLine();
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();

            Console.Clear();

            // PROCESOS PARA EL ALGORITMO ROUND ROBIN

            Proceso emergenciaRR = new Proceso
            {
                Nombre = "Emergencia de trafico",
                TiempoLlegada = 0,
                Prioridad = 1,
                TamanoDatos = 50,
                TiempoEjecucion = 4,
                TiempoRestante = 4,
                Estado = EstadoProceso.Nuevo
            };

            Proceso semaforosRR = new Proceso
            {
                Nombre = "Gestion de semaforos",
                TiempoLlegada = 1,
                Prioridad = 2,
                TamanoDatos = 30,
                TiempoEjecucion = 6,
                TiempoRestante = 6,
                Estado = EstadoProceso.Nuevo
            };

            Proceso sensoresRR = new Proceso
            {
                Nombre = "Procesamiento de sensores",
                TiempoLlegada = 2,
                Prioridad = 3,
                TamanoDatos = 80,
                TiempoEjecucion = 8,
                TiempoRestante = 8,
                Estado = EstadoProceso.Nuevo
            };

            Planificador planificadorRR = new Planificador();

            planificadorRR.AgregarProceso(emergenciaRR);
            planificadorRR.AgregarProceso(semaforosRR);
            planificadorRR.AgregarProceso(sensoresRR);

            Console.WriteLine("==========================================");
            Console.WriteLine("       ALGORITMO: ROUND ROBIN");
            Console.WriteLine("==========================================");

            planificadorRR.PasarAListos();

            Console.WriteLine();
            Console.WriteLine("=== ESTADO INICIAL ROUND ROBIN ===");

            planificadorRR.MostrarProcesos();

            Console.WriteLine();
            Console.WriteLine("=== EJECUCION ROUND ROBIN ===");
            Console.WriteLine("Quantum utilizado: 2");

            planificadorRR.EjecutarRoundRobin(2);

            Console.WriteLine();
            Console.WriteLine("=== ESTADO FINAL - ROUND ROBIN ===");

            planificadorRR.MostrarProcesos();

            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine("       SIMULACION FINALIZADA");
            Console.WriteLine("==========================================");

            Console.ReadLine();
        }
    }
}