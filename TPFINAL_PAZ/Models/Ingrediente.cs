using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TPFINAL_PAZ.Models
{
    // Representa un ingrediente utilizado en la alquimia.
    // Cada ingrediente tiene cuatro efectos y una calidad.
    public class Ingrediente
    {
        // Identificador unico del ingrediente.
        public int ID { get; set; }

        // Nombre del ingrediente.
        public string Nombre { get; set; }

        // Primer efecto alquimico.
        public string Efecto1 { get; set; }

        // Segundo efecto alquimico.
        public string Efecto2 { get; set; }

        // Tercer efecto alquimico.
        public string Efecto3 { get; set; }

        // Cuarto efecto alquimico.
        public string Efecto4 { get; set; }

        // Calidad del ingrediente:
        // 1 = Mala, 2 = Normal, 3 = Buena.
        public int Calidad { get; set; }
    }
}
