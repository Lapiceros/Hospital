using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Paciente : Persona
    {
        private string _enfermedad;
        private Medico _medicoCarteira;

        public Paciente(string nombre, int edad, string dni,Medico medicoCarteira): base(nombre, edad, dni)
        {
            _medicoCarteira = medicoCarteira;
        }

    }
}
