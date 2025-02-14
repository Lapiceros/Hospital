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
        public List<Cita> CitasAgendadas = new List<Cita>();


        public Centro(string nombre) 
        {
            nombreHospital = nombre;

            Medico medico1 = new Medico("Juan", 34, "Porros");
            Medico medico2 = new Medico("Anna", 57, "vino tinto");
            

            Paciente paciente1 = new Paciente("blabla", 13, "Tiktok", medico1);
            Paciente paciente2 = new Paciente("Patriarcado", 200, "Machismo", medico2);
            Personas.Add(medico1);
            Personas.Add(medico2);
            Medicos.Add(medico1);
            Medicos.Add(medico2);
            Personas.Add(paciente2);
            Personas.Add(paciente1);

        }
        public void ListarPersonas(Type clase)
        {
            foreach (Persona persona in Personas)
            {
                if (persona.GetType() == clase)
                {
                    Console.WriteLine($"{persona.Nombre} | {persona.GetType()}");
                }
            }
        }
        public void ListarMedicos()
        {
            foreach (Medico medico in Medicos)
            {
                Console.WriteLine($"- {medico}");
            }
        }
        public void ListarPacientesMedico()
        {
            ListarMedicos();
            Console.Write("Nombre del médico: ");
            string nombre = Console.ReadLine();
            var medico = Medicos.OfType<Medico>().FirstOrDefault(m => m.Nombre == nombre);

            if (medico != null)
            {
                medico.ListarPacientes();
            }
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
            Console.WriteLine($"{medico}\n creado correctamente");
            
        }

        public void NuevoPaciente()
        {
            ListarMedicos();

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
            Console.WriteLine($"{admin}\n creado correctamente");

        }

        public void EliminarMedico() 
        {
            ListarMedicos();
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
                medico.ListarPacientes();

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

            if(medicoReemplazo != null) 
            { 
                foreach (var paciente in medico.Pacientes.ToList())
                {
                    paciente.Medico = medicoReemplazo;
                }
            }
            else
            {
                Console.WriteLine("No hay medico disponible");
            }


        }

        public void ModificarDatos()
        {
            Console.WriteLine("Introduce el tipo de persona que quiere modificar:");
            Console.WriteLine("1. Administrativo");
            Console.WriteLine("2. Medico");
            Console.WriteLine("3. Paciente");
            Console.WriteLine("4. Salir");

            switch (Console.ReadLine()) 
            {
                case "1":
                    ListarPersonas(typeof(PersonalAdministrativo));
                    break;
                case "2":
                    ListarPersonas(typeof (Medico));
                    break;
                case "3":
                    ListarPersonas(typeof (Paciente));
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }

            Console.WriteLine("Introduce el nombre de la persona a modificar");
            string nombre = Console.ReadLine();
            Persona persona = Personas.FirstOrDefault(p => p.Nombre == nombre);

            if (persona != null) 
            {
                Console.WriteLine($"{persona}");
                Console.WriteLine("Ingrese los nuevos datos (dejar en blanco para no modificar)");

                Console.Write("Nombre: ");
                string nombreNuevo = Console.ReadLine() ;
                persona.Nombre = nombreNuevo;

                Console.Write("Edad: ");
                int nuevaEdad = int.Parse(Console.ReadLine());
                persona.Edad = nuevaEdad;

                if(persona is Medico medico) 
                {
                    Console.Write("Introduce nueva especialidad: ");
                    string nuevaEspecialidad = Console.ReadLine();
                    if(!string.IsNullOrEmpty(nuevaEspecialidad)) medico.Especialidad = nuevaEspecialidad;
                }
                if (persona is Paciente paciente) 
                {
                    Console.Write("Introduce nueva enfermedad: ");

                    string nuevaEnfermedad = Console.ReadLine();
                    if(!string.IsNullOrEmpty(nuevaEnfermedad)) paciente.Enfermedad= nuevaEnfermedad;
                }
                if (persona is PersonalAdministrativo administrativo) 
                {
                    Console.Write("Introduce nuevo puesto: ");

                    string nuevoPuesto = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoPuesto)) administrativo.Puesto = nuevoPuesto;
                }
            }
            else
                Console.WriteLine("Persona no encontrada");

        }

        public void CrearCita()
        {
            ListarMedicos();
            Console.WriteLine("Introduce el nombre del medico para agendar una cita");
            string nombreMedico = Console.ReadLine();

            Medico medico = Medicos.FirstOrDefault(m => m.Nombre == nombreMedico);
            Paciente paciente = (Paciente)Personas.FirstOrDefault(p => p is Paciente && p.Nombre == SolicitarEntradaTexto("Nombre del paciente: "));
            if (medico != null && paciente != null)
            { 
                Console.WriteLine("Fecha y hora de la cita (yyyy-MM-dd HH:mm): ");
                DateTime fechaHora = DateTime.Parse(Console.ReadLine());

                Cita nuevaCita = new Cita(medico, paciente, fechaHora);
                CitasAgendadas.Add(nuevaCita);
                paciente.HistorialMedico.AgregarCita(nuevaCita);
                Console.WriteLine("Cita creada correctamente.");
            }
            else
            {
                Console.WriteLine("Médico o paciente no encontrado.");
            }
        }

    }
}
