using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal abstract class Persona
    {
        protected string _nombre;
        protected int _edad;
        protected string _dni;

        protected Persona(string nombre, int edad, string dni)
        {
            _nombre = nombre;
            _edad = edad;
            _dni = dni;
        }
    }
}
