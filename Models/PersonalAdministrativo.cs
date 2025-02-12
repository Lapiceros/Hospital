using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    internal class PersonalAdministrativo: Persona
    {
        private string _puesto;

        public PersonalAdministrativo(string nombre, int edad, string dni, string puesto):base(nombre,edad, dni)
        {
            this._puesto = puesto;
        }
    }
}
