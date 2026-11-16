using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFINAL_PAZ.Data
{
    internal class ConexionBD
    {
        //Datos para conectarnos a la base de datos local
        private string cadenaConexion =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=skyrim_alquimia;" +
            "User ID=root;" +
            "Password=;";

        //Crea y devuelve una conexion a MySQL
        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;
        }
        
public int ContarIngredientes()
{
    //Creamos la conexion utilizando nuestro metodo
    using (MySqlConnection conexion = ObtenerConexion())
    {
        //Abrimos la conexion con la base de datos
        conexion.Open();

        //Preparamos la consulta SQL
        string consulta = "SELECT COUNT(*) FROM Ingredientes";

        //Creamos el comando que ejecutara la consulta
        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
        {
            //Ejecutamos la consulta y obtenemos el resultado
            int cantidad = Convert.ToInt32(comando.ExecuteScalar());

            return cantidad;
        }
    }
}

    }
}
