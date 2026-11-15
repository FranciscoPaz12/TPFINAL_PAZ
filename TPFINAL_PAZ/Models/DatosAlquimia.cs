using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFINAL_PAZ.Models
{
    internal class DatosAlquimia
    {

        //Array compartido para almacenar hasta 100 ingredientes
        public static Ingrediente[] Ingredientes = new Ingrediente[100];

        //Cantidad de ingredientes registrados
        public static int CantidadIngredientes = 0;

        //ID que se asignara al proximo ingrediente
        public static int SiguienteIDIngrediente = 1;

    }
}
