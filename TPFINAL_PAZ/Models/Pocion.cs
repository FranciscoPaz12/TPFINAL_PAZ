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

        //Array que almacena hasta cuatro efectos compartidos
        public string[] Efectos { get; set; } = new string[4];

        //Cantidad de efectos que contiene la pocion
        public int CantidadEfectos { get; set; }

        //Magnitud calculada automaticamente
        //1 = I, 2 = II, 3 = III.
        public int Magnitud { get; set; }
    }
}

