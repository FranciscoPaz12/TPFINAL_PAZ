using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TPFINAL_PAZ.Models;

namespace TPFINAL_PAZ.Data
{
    internal class ConexionBD
    {
        //Obtener los datos de conexion desde el archivo .env
        private string servidor = Environment.GetEnvironmentVariable("DB_HOST");
        private string puerto = Environment.GetEnvironmentVariable("DB_PORT");
        private string baseDatos = Environment.GetEnvironmentVariable("DB_NAME");
        private string usuario = Environment.GetEnvironmentVariable("DB_USER");
        private string contrasena = Environment.GetEnvironmentVariable("DB_PASSWORD");
        private string certificado = Environment.GetEnvironmentVariable("DB_SSL_CA");

        //Crear y devolver una conexion segura a TiDB Cloud
        public MySqlConnection ObtenerConexion()
        {
            //Validamos la configuracion antes de intentar conectar
            if (string.IsNullOrWhiteSpace(servidor) ||
                string.IsNullOrWhiteSpace(puerto) ||
                string.IsNullOrWhiteSpace(baseDatos) ||
                string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contrasena) ||
                string.IsNullOrWhiteSpace(certificado))
            {
                throw new InvalidOperationException(
                    "Faltan datos de conexion en el archivo .env.");
            }

            uint puertoNumerico;

            if (!uint.TryParse(puerto, out puertoNumerico) ||
                puertoNumerico == 0 ||
                puertoNumerico > 65535)
            {
                throw new InvalidOperationException(
                    "El puerto DB_PORT del archivo .env no es valido.");
            }

            if (!File.Exists(certificado))
            {
                throw new FileNotFoundException(
                    "No se encontro el certificado TLS configurado en DB_SSL_CA.");
            }

            MySqlConnectionStringBuilder configuracion = new MySqlConnectionStringBuilder();

            configuracion.Server = servidor;
            configuracion.Port = puertoNumerico;
            configuracion.Database = baseDatos;
            configuracion.UserID = usuario;
            configuracion.Password = contrasena;
            configuracion.SslMode = MySqlSslMode.VerifyFull;
            configuracion.SslCa = certificado;

            return new MySqlConnection(configuracion.ConnectionString);
        }

        //Consultar la cantidad de ingredientes registrados
        public int ContarIngredientes()
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT COUNT(*) FROM ingredientes";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        public List<Ingrediente> ObtenerIngredientes()
        {
            //Creamos una lista para guardar los resultados
            List<Ingrediente> lista = new List<Ingrediente>();

            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Consultamos todos los ingredientes ordenados por ID
                string consulta = "SELECT ID, Nombre, Efecto1, Efecto2, Efecto3, Efecto4, Calidad FROM ingredientes ORDER BY ID";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    //Recorremos los registros devueltos por SQL
                    while (lector.Read())
                    {
                        Ingrediente ingrediente = new Ingrediente();

                        ingrediente.ID = Convert.ToInt32(lector["ID"]);
                        ingrediente.Nombre = lector["Nombre"].ToString();
                        ingrediente.Efecto1 = lector["Efecto1"].ToString();
                        ingrediente.Efecto2 = lector["Efecto2"].ToString();
                        ingrediente.Efecto3 = lector["Efecto3"].ToString();
                        ingrediente.Efecto4 = lector["Efecto4"].ToString();
                        ingrediente.Calidad = Convert.ToInt32(lector["Calidad"]);

                        lista.Add(ingrediente);
                    }
                }
            }

            //Devolvemos los ingredientes encontrados
            return lista;
        }

        public int AgregarIngrediente(Ingrediente ingrediente)
        {
            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Preparamos la consulta para agregar el ingrediente
                string consulta = @"INSERT INTO ingredientes
                    (Nombre, Efecto1, Efecto2, Efecto3, Efecto4, Calidad)
                    VALUES
                    (@nombre, @efecto1, @efecto2, @efecto3, @efecto4, @calidad)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    //Asignamos los valores a los parametros
                    comando.Parameters.AddWithValue("@nombre", ingrediente.Nombre);
                    comando.Parameters.AddWithValue("@efecto1", ingrediente.Efecto1);
                    comando.Parameters.AddWithValue("@efecto2", ingrediente.Efecto2);
                    comando.Parameters.AddWithValue("@efecto3", ingrediente.Efecto3);
                    comando.Parameters.AddWithValue("@efecto4", ingrediente.Efecto4);
                    comando.Parameters.AddWithValue("@calidad", ingrediente.Calidad);

                    //Ejecutamos la consulta y devolvemos las filas afectadas
                    return comando.ExecuteNonQuery();
                }
            }
        }

        public int ModificarIngrediente(Ingrediente ingrediente)
        {
            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Preparamos la consulta para modificar el ingrediente
                string consulta = @"UPDATE ingredientes SET
            Nombre = @nombre,
            Efecto1 = @efecto1,
            Efecto2 = @efecto2,
            Efecto3 = @efecto3,
            Efecto4 = @efecto4,
            Calidad = @calidad
            WHERE ID = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    //Asignamos los valores del ingrediente
                    comando.Parameters.AddWithValue("@id", ingrediente.ID);
                    comando.Parameters.AddWithValue("@nombre", ingrediente.Nombre);
                    comando.Parameters.AddWithValue("@efecto1", ingrediente.Efecto1);
                    comando.Parameters.AddWithValue("@efecto2", ingrediente.Efecto2);
                    comando.Parameters.AddWithValue("@efecto3", ingrediente.Efecto3);
                    comando.Parameters.AddWithValue("@efecto4", ingrediente.Efecto4);
                    comando.Parameters.AddWithValue("@calidad", ingrediente.Calidad);

                    //Ejecutamos la modificacion
                    return comando.ExecuteNonQuery();
                }
            }
        }

        public int EliminarIngrediente(int id)
        {
            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Eliminamos solamente el ingrediente indicado
                string consulta = "DELETE FROM ingredientes WHERE ID = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    //Enviamos el ID como parametro
                    comando.Parameters.AddWithValue("@id", id);

                    //Devolvemos la cantidad de filas eliminadas
                    return comando.ExecuteNonQuery();
                }
            }
        }

        public int AgregarPocion(Pocion pocion)
        {
            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Iniciamos una transaccion para guardar todo junto
                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        //Guardamos los datos principales de la pocion
                        string consulta = @"INSERT INTO pociones
                    (Nombre, Ingrediente1ID, Ingrediente2ID, Magnitud)
                    VALUES
                    (@nombre, @ingrediente1, @ingrediente2, @magnitud)";

                        int idPocion;

                        using (MySqlCommand comando = new MySqlCommand(
                            consulta, conexion, transaccion))
                        {
                            comando.Parameters.AddWithValue("@nombre", pocion.Nombre);
                            comando.Parameters.AddWithValue("@ingrediente1", pocion.Ingrediente1ID);
                            comando.Parameters.AddWithValue("@ingrediente2", pocion.Ingrediente2ID);
                            comando.Parameters.AddWithValue("@magnitud", pocion.Magnitud);

                            comando.ExecuteNonQuery();

                            //Obtenemos el ID generado automaticamente por TiDB
                            idPocion = Convert.ToInt32(comando.LastInsertedId);
                        }

                        //Guardamos cada efecto de la pocion
                        for (int i = 0; i < pocion.CantidadEfectos; i++)
                        {
                            string consultaEfecto = @"INSERT INTO efectospocion
                        (PocionID, NombreEfecto)
                        VALUES
                        (@pocionID, @nombreEfecto)";

                            using (MySqlCommand comandoEfecto = new MySqlCommand(
                                consultaEfecto, conexion, transaccion))
                            {
                                comandoEfecto.Parameters.AddWithValue("@pocionID", idPocion);
                                comandoEfecto.Parameters.AddWithValue(
                                    "@nombreEfecto", pocion.Efectos[i]);

                                comandoEfecto.ExecuteNonQuery();
                            }
                        }

                        //Confirmamos todos los cambios
                        transaccion.Commit();

                        return idPocion;
                    }
                    catch
                    {
                        //Cancelamos los cambios si ocurre un error
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Pocion> ObtenerPociones()
        {
            //Creamos la lista de pociones
            List<Pocion> lista = new List<Pocion>();

            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Consultamos las pociones y sus efectos
                string consulta = @"SELECT
            p.ID,
            p.Nombre,
            p.Ingrediente1ID,
            p.Ingrediente2ID,
            p.Magnitud,
            e.NombreEfecto
            FROM pociones p
            LEFT JOIN efectospocion e ON e.PocionID = p.ID
            ORDER BY p.ID, e.ID";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    Pocion pocionActual = null;

                    while (lector.Read())
                    {
                        int id = Convert.ToInt32(lector["ID"]);

                        //Creamos una pocion cuando cambia el ID
                        if (pocionActual == null || pocionActual.ID != id)
                        {
                            pocionActual = new Pocion();

                            pocionActual.ID = id;
                            pocionActual.Nombre = lector["Nombre"].ToString();
                            pocionActual.Ingrediente1ID =
                                Convert.ToInt32(lector["Ingrediente1ID"]);
                            pocionActual.Ingrediente2ID =
                                Convert.ToInt32(lector["Ingrediente2ID"]);
                            pocionActual.Magnitud =
                                Convert.ToInt32(lector["Magnitud"]);

                            pocionActual.CantidadEfectos = 0;

                            lista.Add(pocionActual);
                        }

                        //Agregamos los efectos asociados a la pocion
                        if (lector["NombreEfecto"] != DBNull.Value &&
                            pocionActual.CantidadEfectos < pocionActual.Efectos.Length)
                        {
                            pocionActual.Efectos[pocionActual.CantidadEfectos] =
                                lector["NombreEfecto"].ToString();

                            pocionActual.CantidadEfectos++;
                        }
                    }
                }
            }

            return lista;
        }

        public int ModificarNombrePocion(int id, string nombre)
        {
            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Modificamos solamente el nombre de la pocion
                string consulta = @"UPDATE pociones
                            SET Nombre = @nombre
                            WHERE ID = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    //Asignamos los parametros
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nombre", nombre);

                    //Ejecutamos la modificacion
                    return comando.ExecuteNonQuery();
                }
            }
        }

        public int EliminarPocion(int id)
        {
            //Abrimos la conexion con TiDB Cloud
            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();

                //Eliminamos la pocion por su ID
                string consulta = "DELETE FROM pociones WHERE ID = @id";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    //Asignamos el ID de la pocion
                    comando.Parameters.AddWithValue("@id", id);

                    //Ejecutamos la eliminacion
                    return comando.ExecuteNonQuery();
                }
            }
        }



    }
}
