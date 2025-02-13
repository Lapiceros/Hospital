using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Medico : Persona
    {
        private string especialidad;
        private List<Paciente> _pacientes = new List<Paciente>();

        public List<Paciente> Pacientes { get { return _pacientes; } }

        public Medico(string nombre,int edad, string dni, string especialidad): base(nombre, edad, dni)
        {
            this.especialidad = especialidad;
          
        }
        public void AsignarPacientes(Paciente paciente) 
        {
            _pacientes.Add(paciente);
        }

        public void ListarPacientes()
        {
            foreach (Paciente item in _pacientes)
            {
                Console.WriteLine($"-{item.Dni} |  Diagnostico: {item.Enfermedad}");
            };
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Tipo: {GetType().Name} | Especialidad: {especialidad}";
        }



    }
}
