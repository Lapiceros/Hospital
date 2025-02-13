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
        public List<Persona> Personas = new List<Persona>();
        public List<Medico> Medicos = new List<Medico>();


        public Centro(string nombre) 
        {
            nombreHospital = nombre;
        }
        public void ListarPersonas()
        {
            foreach (Persona persona in Personas)
            {
                Console.WriteLine($"- {persona.Nombre} | Tipo: {persona.GetType().Name}");
            }
        }
        public void ListarMedicos()
        {
            foreach (Medico medico in Medicos)
            {
                Console.WriteLine($"- {medico.ToString()}");
            }
        }
        public void ListarPacientes()
        {
            Console.Write("Nombre del médico: ");
            string nombreM2 = Console.ReadLine();
            Medico medico2 = Medicos.Find(m => m.Nombre == nombreM2);
            if (medico2 != null)
                medico2.ListarPacientes();
            else
                Console.WriteLine("Médico no encontrado.");
        }

        public void CrearMedico()
        {
            Console.WriteLine("Introduce los datos del Nuevo Medico:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());


            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine();

            Medico medico = new Medico(nombre, edad,especialidad);

            Personas.Add(medico);
            Medicos.Add(medico);

            Console.Clear();
            Console.WriteLine($"{medico.ToString()}\n creado correctamente");
            
        }

        public void NuevoPaciente()
        {
            Console.Write("Nombre del médico asignado: ");
            string nombre = Console.ReadLine();
            Medico medico = Medicos.Find(m => m.Nombre == nombre);

            if (medico != null)
            {
                Console.Write("Nombre del paciente: ");
                string nombrePaciente = Console.ReadLine();

                Console.Write("Edad: ");
                int edadPaciente = int.Parse(Console.ReadLine());

                Console.Write("Enfermedad: ");
                string enfermedad = Console.ReadLine();

                Paciente paciente = new Paciente(nombrePaciente, edadPaciente, enfermedad, medico);

                Personas.Add(paciente);
                medico.AsignarPaciente(paciente);

                Console.Clear();
                Console.WriteLine($"{paciente}\n creado correctamente");
            }
            else
                Console.WriteLine("Médico no encontrado.");

        }

        public void CrearAdministrativo()
        {
            Console.WriteLine("Introduce los datos del Nuevo personal administrativo:");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            string puesto = Console.ReadLine();

            PersonalAdministrativo admin = new PersonalAdministrativo(nombre, edad, puesto);
            Personas.Add(admin);

            Console.Clear();
            Console.WriteLine($"{admin.ToString()}\n creado correctamente");

        }

        public void EliminarMedico() 
        {
            Console.WriteLine("Ingrese el nombre del medico");
            string nombre = Console.ReadLine();

            var medico = Personas.OfType<Medico>().FirstOrDefault(m => m.Nombre == nombre);

            if (medico != null)
            {
                ReasignarPacientes(medico);
                Personas.Remove(medico);
                Medicos.Remove(medico);

                Console.WriteLine($"Dr/a {medico.Nombre} eliminado y pacientes reasignados.");
            }
            else
                Console.WriteLine("No se ha encontrado un medico con ese nombre");

        }
        public void EliminarPaciente()
        {
            Console.Write("Nombre del médico: ");
            string nombreMedico = Console.ReadLine();
            Medico medico = Medicos.Find(m => m.Nombre == nombreMedico);
            if (medico != null)
            {
                Console.Write("Nombre del paciente a eliminar: ");
                string nombrePaciente = Console.ReadLine();
                medico.EliminarPaciente(nombrePaciente);
            }
            else
                Console.WriteLine("Médico no encontrado.");
        }

        public void ReasignarPacientes(Medico medico) 
        {
            Medico medicoReemplazo = Medicos.FirstOrDefault(m => m != medico && m.Especialidad == medico.Especialidad);

            foreach (var paciente in medico.Pacientes.ToList())
            {
                paciente.Medico = medicoReemplazo;
            }

        }
    }
}
