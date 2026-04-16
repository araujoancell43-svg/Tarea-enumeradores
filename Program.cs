namespace Enumeradores
{
    internal class Program
    {
        // ENUM dentro de la clase
        enum EstadoSolicitud
        {
            Pendiente = 1,
            EnProceso,
            Completada,
            Cancelada
        }

        // CLASE dentro de Program
        class Solicitud
        {
            public int Id { get; set; }
            public string Cliente { get; set; }
            public string Descripcion { get; set; }
            public EstadoSolicitud Estado { get; set; }

            public void Mostrar()
            {
                Console.WriteLine($"ID: {Id}");
                Console.WriteLine($"Cliente: {Cliente}");
                Console.WriteLine($"Descripción: {Descripcion}");
                Console.WriteLine($"Estado: {Estado}");
                Console.WriteLine("------------------------");
            }
        }

        static List<Solicitud> lista = new List<Solicitud>();
        static int contadorId = 1;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("\nSISTEMA DE SOLICITUDES");
                Console.WriteLine("1. Registrar solicitud");
                Console.WriteLine("2. Mostrar solicitudes");
                Console.WriteLine("3. Cambiar estado");
                Console.WriteLine("4. Buscar por ID");
                Console.WriteLine("0. Salir");

                Console.Write("Seleccione: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;
                    case 2:
                        MostrarTodo();
                        break;
                    case 3:
                        CambiarEstado();
                        break;
                    case 4:
                        Buscar();
                        break;
                }

            } while (opcion != 0);
        }

        static void Registrar()
        {
            Solicitud s = new Solicitud();

            s.Id = contadorId++;

            Console.Write("Nombre del cliente: ");
            s.Cliente = Console.ReadLine();

            Console.Write("Descripción: ");
            s.Descripcion = Console.ReadLine();

            s.Estado = EstadoSolicitud.Pendiente;

            lista.Add(s);

            Console.WriteLine("Solicitud registrada.");
        }

        static void MostrarTodo()
        {
            foreach (var s in lista)
            {
                s.Mostrar();
            }
        }

        static void CambiarEstado()
        {
            Console.Write("Ingrese ID: ");
            int id = int.Parse(Console.ReadLine());

            var solicitud = lista.Find(s => s.Id == id);

            if (solicitud != null)
            {
                Console.WriteLine("Seleccione nuevo estado:");

                foreach (EstadoSolicitud estado in Enum.GetValues(typeof(EstadoSolicitud)))
                {
                    Console.WriteLine($"{(int)estado}. {estado}");
                }

                int opcion = int.Parse(Console.ReadLine());

                solicitud.Estado = (EstadoSolicitud)opcion;

                Console.WriteLine("Estado actualizado.");
            }
            else
            {
                Console.WriteLine("Solicitud no encontrada.");
            }
        }

        static void Buscar()
        {
            Console.Write("Ingrese ID: ");
            int id = int.Parse(Console.ReadLine());

            var solicitud = lista.Find(s => s.Id == id);

            if (solicitud != null)
            {
                solicitud.Mostrar();
            }
            else
            {
                Console.WriteLine("No existe.");
            }
        }
    }
}