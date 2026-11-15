using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TPFINAL_PAZ.Models
{
    //Representa una pocion generada mediante la combinacion de dos ingredientes
    public class Pocion
    {
        //Identificador unico de la pocion
        public int ID { get; set; }

        //Nombre de la pocion generada
        public string Nombre { get; set; }

        //ID del primer ingrediente utilizado
        public int Ingrediente1ID { get; set; }

        //ID del segundo ingrediente utilizado
        public int Ingrediente2ID { get; set; }

        //Efectos compartidos por los ingredientes
        public string Efecto { get; set; }

        //Magnitud calculada automaticamente
        //1 = I, 2 = II, 3 = III.
        public int Magnitud { get; set; }
    }
}

