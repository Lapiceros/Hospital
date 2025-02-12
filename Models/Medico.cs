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

        public Medico(string nombre,int edad, string dni, string especialidad): base(nombre, edad, dni)
        {
            this.especialidad = especialidad;
          
        }
        public void AsignarPacientes() { }
    }
}
