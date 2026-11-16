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


        public static void CargarIngredientesPrueba()
        {
            //Evitamos cargar los ingredientes mas de una vez
            if (CantidadIngredientes > 0)
            {
                return;
            }

            //Registramos el primer ingrediente
            Ingredientes[0] = new Ingrediente
            {
                ID = 1,
                Nombre = "Flor azul",
                Efecto1 = "Restaurar salud",
                Efecto2 = "Fortificar magia",
                Efecto3 = "Invisibilidad",
                Efecto4 = "Resistencia al fuego",
                Calidad = 2
            };

            //Registramos el segundo ingrediente
            Ingredientes[1] = new Ingrediente
            {
                ID = 2,
                Nombre = "Trigo",
                Efecto1 = "Restaurar salud",
                Efecto2 = "Fortificar magia",
                Efecto3 = "Regenerar aguante",
                Efecto4 = "Invisibilidad",
                Calidad = 3
            };

            //Registramos el tercer ingrediente
            Ingredientes[2] = new Ingrediente
            {
                ID = 3,
                Nombre = "Lavanda",
                Efecto1 = "Resistencia al fuego",
                Efecto2 = "Invisibilidad",
                Efecto3 = "Restaurar magia",
                Efecto4 = "Fortificar magia",
                Calidad = 1
            };

            //Registramos el cuarto ingrediente
            Ingredientes[3] = new Ingrediente
            {
                ID = 4,
                Nombre = "Raiz roja",
                Efecto1 = "Veneno",
                Efecto2 = "Debilidad al hielo",
                Efecto3 = "Danar aguante",
                Efecto4 = "Paralisis",
                Calidad = 2
            };

            //Actualizamos la cantidad de ingredientes registrados
            CantidadIngredientes = 4;

            //Establecemos el proximo ID disponible
            SiguienteIDIngrediente = 5;
        }


    }
}
