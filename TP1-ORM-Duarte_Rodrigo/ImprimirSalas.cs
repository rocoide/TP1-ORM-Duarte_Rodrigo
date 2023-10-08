using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_ORM_Duarte_Rodrigo
{
    public class ImprimirSalas
    {
        public void Imprimir(List<SalaResponse> ListaSala) 
        {
            Console.WriteLine("");
            Console.WriteLine("   Salas disponibles para la funcion\n");
            foreach (SalaResponse SalaResponse in ListaSala) 
            {
                Console.WriteLine("   Id: " + SalaResponse.SalaId);
                Console.WriteLine("   Nombre: " + SalaResponse.Nombre);
                Console.WriteLine("   Capacidad: " + SalaResponse.Capacidad);
                Console.WriteLine("");
            }
        }
    }
}
