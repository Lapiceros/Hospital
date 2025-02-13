using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Centro hospital = new Centro("La Pachamama");
            hospital.CrearMedico();
            hospital.ListarPersonas();
            Console.ReadKey();

        }
    }
}
