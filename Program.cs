using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static Centro hospital = new Centro("La Pachamama");
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Agregar médico");
                Console.WriteLine("2. Nuevo paciente");
                Console.WriteLine("3. Agregar personal administrativo");
                Console.WriteLine("4. Listar médicos");
                Console.WriteLine("5. Listar pacientes de un médico");
                Console.WriteLine("6. Eliminar a un médico");
                Console.WriteLine("7. Eliminar paciente de un médico");
                Console.WriteLine("8. Ver lista de personas del hospital");
                Console.WriteLine("9. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        hospital.CrearMedico();
                        break;

                    case "2":
                        hospital.NuevoPaciente();
                        break;

                    case "3":
                        hospital.CrearAdministrativo();
                        break;

                    case "4":
                        hospital.ListarMedicos();
                        break;

                    case "5":
                        hospital.ListarPacientes();
                        break;
                    case "6":
                        hospital.EliminarMedico();
                        break;
                    case "7":
                        hospital.EliminarPaciente();
                        break;

                    case "8":
                        hospital.ListarPersonas();
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }
        }
    }
}
