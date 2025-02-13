using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class Persona
    {
        private string _nombre;
        private int _edad;
        private string _dni;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
        public string Dni { get => _dni; set => _dni = value; }

        public Persona(string nombre, int edad, string dni)
        {
            Nombre = nombre;
            Edad = edad;
            Dni = dni;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} | edad: {Edad} | Dni: {Dni}";
        }

    }
}
