using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Medico : Persona
    {
        public string Especialidad { get; set; }
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

        public Medico(string nombre,int edad, string especialidad): base(nombre, edad)
        {
            this.Especialidad = especialidad;
          
        }

        public void AsignarPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }
        public void EliminarPaciente(string nombrePaciente)
        {
            Pacientes.RemoveAll(p => p.Nombre == nombrePaciente);
        }

        public void ListarPacientes()
        {
             if(Pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes asignados");
            }
            else
            {
                foreach (Paciente item in Pacientes)
                {
                    Console.WriteLine($"-{item.Nombre} |  Diagnostico: {item.Enfermedad}");
                }
            }
            
        }

        public override string ToString()
        {
            return $"Medico {base.ToString()} | Especialidad: {Especialidad}";
        }



    }
}
