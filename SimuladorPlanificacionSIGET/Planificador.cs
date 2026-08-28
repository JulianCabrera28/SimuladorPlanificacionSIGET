using System;
using System.Collections.Generic;

namespace SimuladorPlanificacionSIGET
{
    public class Planificador
    {
        private List<Proceso> procesos;

        public Planificador()
        {
            procesos = new List<Proceso>();
        }

        public void AgregarProceso(Proceso proceso)
        {
            procesos.Add(proceso);
        }

        public void PasarAListos()
        {
            foreach (Proceso proceso in procesos)
            {
                if (proceso.Estado == EstadoProceso.Nuevo)
                {
                    proceso.Estado = EstadoProceso.Listo;
                }
            }
        }

        public void EjecutarProceso(Proceso proceso)
        {
            if (proceso.Estado != EstadoProceso.Listo)
            {
                return;
            }

            proceso.Estado = EstadoProceso.EnEjecucion;

            Console.WriteLine();
            Console.WriteLine($"Ejecutando: {proceso.Nombre}");

            while (proceso.TiempoRestante > 0)
            {
                Console.WriteLine(
                    $"Tiempo restante: {proceso.TiempoRestante}"
                );

                proceso.TiempoRestante--;
            }

            proceso.Estado = EstadoProceso.Terminado;

            Console.WriteLine($"Proceso terminado: {proceso.Nombre}");
        }

        public void EjecutarPorPrioridad()
        {
            while (true)
            {
                Proceso procesoSeleccionado = null;

                foreach (Proceso proceso in procesos)
                {
                    if (proceso.Estado == EstadoProceso.Listo)
                    {
                        if (procesoSeleccionado == null ||
                            proceso.Prioridad < procesoSeleccionado.Prioridad)
                        {
                            procesoSeleccionado = proceso;
                        }
                    }
                }

                if (procesoSeleccionado == null)
                {
                    break;
                }

                EjecutarProceso(procesoSeleccionado);
            }
        }

        public void EjecutarRoundRobin(int quantum)
        {
            bool quedanProcesos;

            do
            {
                quedanProcesos = false;

                foreach (Proceso proceso in procesos)
                {
                    if (proceso.Estado == EstadoProceso.Listo)
                    {
                        quedanProcesos = true;

                        proceso.Estado = EstadoProceso.EnEjecucion;

                        Console.WriteLine();
                        Console.WriteLine($"Ejecutando: {proceso.Nombre}");

                        int tiempoEjecutado = 0;

                        while (tiempoEjecutado < quantum &&
                               proceso.TiempoRestante > 0)
                        {
                            Console.WriteLine(
                                $"Tiempo restante: {proceso.TiempoRestante}"
                            );

                            proceso.TiempoRestante--;
                            tiempoEjecutado++;
                        }

                        if (proceso.TiempoRestante == 0)
                        {
                            proceso.Estado = EstadoProceso.Terminado;

                            Console.WriteLine(
                                $"Proceso terminado: {proceso.Nombre}"
                            );
                        }
                        else
                        {
                            proceso.Estado = EstadoProceso.Listo;

                            Console.WriteLine(
                                $"Quantum agotado. {proceso.Nombre} vuelve a Listo."
                            );
                        }
                    }
                }

            } while (quedanProcesos);
        }

        public void BloquearProceso(Proceso proceso)
        {
            if (proceso.Estado == EstadoProceso.EnEjecucion)
            {
                proceso.Estado = EstadoProceso.Bloqueado;

                Console.WriteLine(
                    $"Proceso bloqueado: {proceso.Nombre}"
                );
            }
        }

        public void DesbloquearProceso(Proceso proceso)
        {
            if (proceso.Estado == EstadoProceso.Bloqueado)
            {
                proceso.Estado = EstadoProceso.Listo;

                Console.WriteLine(
                    $"Proceso desbloqueado: {proceso.Nombre}"
                );
            }
        }

        public void MostrarProcesos()
        {
            foreach (Proceso proceso in procesos)
            {
                Console.WriteLine(
                    $"{proceso.Nombre} - Estado: {proceso.Estado}"
                );
            }
        }
    }
}