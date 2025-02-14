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
        private Medico _medico;

        public string Enfermedad { get => _enfermedad; }
        public Medico Medico
        { 
            get => _medico; 
            set 
            { 
                _medico = value;  
                _medico?.Pacientes.Add(this);
            } 
        }

        public Paciente(string nombre, int edad,string enfermedad, Medico medico): base(nombre, edad)
        {
            _enfermedad = enfermedad;
            Medico = medico;
        }

        public override string ToString()
        {
            return $"Paciente {base.ToString()} | Medico Asignado: {Medico.Nombre} | Enfermedad: {Enfermedad}";
        }

    }
}
