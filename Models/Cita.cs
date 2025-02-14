using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Cita
    {
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaHora { get; set; }

        public Cita(Medico medico, Paciente paciente, DateTime fechaHora)
        {
            Medico = medico;
            Paciente = paciente;
            FechaHora = fechaHora;
        }

        public override string ToString()
        {
            return $"Cita: {FechaHora} - Dr/a {Medico.Nombre} con {Paciente.Nombre}";
        }
    }
}
