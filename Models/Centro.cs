using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Centro
    {
        public string nombreHospital { get; set; }
        public List<Persona> _personas = new List<Persona>();
        public List<Medico> _medicos = new List<Medico>();


        public Centro(string nombre) 
        {
            nombreHospital = nombre;
        }
        public void ListarPersonas()
        {
            foreach (Persona persona in _personas)
            {
                Console.WriteLine($"- {persona.Nombre} | Dni: {persona.Dni} | Tipo: {persona.GetType().Name}");
            }
        }

        public void CrearMedico()
        {
            Console.WriteLine("Introduce los datos del Nuevo Medico:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            string dni = "1091387U";

            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine();

            Medico medico = new Medico(nombre, edad, dni,especialidad);

            _personas.Add(medico);
            _medicos.Add(medico);

            Console.Clear();
            Console.WriteLine($"{medico.ToString()}\n creado correctamente");
            
        }

        public void NuevoPaciente()
        {
            Console.WriteLine("Introduce los datos del Nuevo Medico:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            string dni = "1091387U";

            Random rnd = new Random();
            Medico medicoAsignado = _medicos[rnd.Next(_medicos.Count())];

            Paciente paciente = new Paciente(nombre, edad, dni, medicoAsignado);
            _personas.Add(paciente);

            Console.Clear();
            Console.WriteLine($"{paciente.ToString()}\n creado correctamente");
        }

        public void CrearAdministrativo()
        {

        }

        public void EliminarMedico() 
        {
            Console.WriteLine("Ingrese el dni del medico");
            string dni = Console.ReadLine();

            var medico = _personas.OfType<Medico>().FirstOrDefault(m => m.Dni == dni);

            if (medico != null)
            {
                _personas.Remove(medico);
                _medicos.Remove(medico);

                Console.WriteLine($"Medico {medico.Nombre} ha sido eliminado correctamente");

            }
            else
                Console.WriteLine("No se ha encontrado un medico con ese DNI");

            ReasignarPacientes(medico);
        }

        public void ReasignarPacientes(Medico medico) 
        {
            foreach (var item in medico.Pacientes)
            {
                Random rnd = new Random();
                Medico medicoAsignado = _medicos[rnd.Next(_medicos.Count())];
                item.Medico = medicoAsignado;
            
            }
        }
    }
}
