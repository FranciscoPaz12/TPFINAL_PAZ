using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFINAL_PAZ.Models;
using TPFINAL_PAZ.Data;

namespace TPFINAL_PAZ
{
    public partial class Form1 : Form
    {

        //Guardamos temporalmente los efectos de la pocion elaborada
        private string[] efectosElaborados = new string[4];

        //Contamos los efectos de la pocion elaborada
        private int cantidadEfectosElaborados = 0;

        //Guardamos temporalmente la magnitud calculada
        private int magnitudElaborada = 0;

        //Indicamos si existe una pocion lista para agregar
        private bool pocionElaborada = false;

        //Guardamos el ID de la pocion consultada
        private int idConsultado = -1;

        //Guardamos los ingredientes obtenidos desde TiDB Cloud
        private List<Ingrediente> ingredientesSQL = new List<Ingrediente>();




        //Constructor del formulario, se ejecuta cuando se crea una instancia de Form1
        public Form1()
        {
            InitializeComponent();

            //El ID se genera automaticamente en TiDB Cloud
            txtID.Text = "Automatico";

            //Cargamos los ingredientes desde TiDB Cloud
            CargarIngredientesSQL();

            //Mostramos automaticamente las pociones guardadas
            MostrarPociones();

        }

        private void CargarIngredientesSQL()
        {
            try
            {
                //Obtenemos los ingredientes desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                List<Ingrediente> lista = conexion.ObtenerIngredientes();

                //Guardamos los ingredientes en la lista del formulario
                ingredientesSQL = lista;

                //Limpiamos los ComboBox
                cmbIngrediente1.Items.Clear();
                cmbIngrediente2.Items.Clear();

                //Agregamos los nombres de los ingredientes
                foreach (Ingrediente ingrediente in ingredientesSQL)
                {
                    cmbIngrediente1.Items.Add(ingrediente.Nombre);
                    cmbIngrediente2.Items.Add(ingrediente.Nombre);
                }

                //Dejamos los ComboBox sin seleccion inicial
                cmbIngrediente1.SelectedIndex = -1;
                cmbIngrediente2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ingredientes: " + ex.Message);
            }
        }

        private void CampoSoloLectura_MouseDown(object sender, MouseEventArgs e)
        {
            //Quitamos el foco del campo de solo lectura
            this.ActiveControl = null;
        }

        private void MostrarPociones()
        {
            try
            {
                //Obtenemos las pociones desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                List<Pocion> lista = conexion.ObtenerPociones();

                //Limpiamos las filas y columnas anteriores
                dgvPociones.DataSource = null;
                dgvPociones.Rows.Clear();
                dgvPociones.Columns.Clear();

                //Creamos las columnas de la tabla
                dgvPociones.Columns.Add("ID", "ID");
                dgvPociones.Columns.Add("Nombre", "Nombre");
                dgvPociones.Columns.Add("Efecto", "Efecto");
                dgvPociones.Columns.Add("Magnitud", "Magnitud");

                //Recorremos las pociones obtenidas
                foreach (Pocion pocion in lista)
                {
                    //Preparamos el texto de los efectos
                    string efectosTexto = "";

                    for (int i = 0; i < pocion.CantidadEfectos; i++)
                    {
                        if (i > 0)
                        {
                            efectosTexto += ", ";
                        }

                        efectosTexto += pocion.Efectos[i];
                    }

                    //Convertimos la magnitud a numeros romanos
                    string magnitudRomana = pocion.Magnitud.ToString();

                    if (pocion.Magnitud == 1)
                    {
                        magnitudRomana = "I";
                    }
                    else if (pocion.Magnitud == 2)
                    {
                        magnitudRomana = "II";
                    }
                    else if (pocion.Magnitud == 3)
                    {
                        magnitudRomana = "III";
                    }

                    //Agregamos la pocion a la tabla
                    dgvPociones.Rows.Add(
                        pocion.ID,
                        pocion.Nombre,
                        efectosTexto,
                        magnitudRomana
                    );
                }

                //Configuramos la seleccion de filas
                dgvPociones.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvPociones.MultiSelect = false;
                dgvPociones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar pociones: " + ex.Message);
            }
        }


        private void LimpiarCampos()
        {
            //Limpiamos los campos despues de agregar una pocion
            txtID.Clear();
            txtNombre.Clear();
            txtEfecto.Clear();
            txtMagnitud.Clear();

            //Colocamos el cursor en el nombre de la pocion
            txtNombre.Focus();

            //El ID se genera automaticamente en TiDB Cloud
            txtID.Text = "Automatico";
        }



        private void btbAgregar_Click(object sender, EventArgs e)
        {
            //Verificamos que primero se haya elaborado una pocion
            if (!pocionElaborada)
            {
                MessageBox.Show("Primero debe elaborar una pocion.");
                return;
            }

            //Verificamos que la pocion tenga un nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para la pocion.");
                txtNombre.Focus();
                return;
            }

            //Verificamos que haya dos ingredientes seleccionados
            if (cmbIngrediente1.SelectedIndex == -1 ||
                cmbIngrediente2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione dos ingredientes.");
                return;
            }

            //Obtenemos los ingredientes desde TiDB Cloud
            Ingrediente ingrediente1 =
                ingredientesSQL[cmbIngrediente1.SelectedIndex];

            Ingrediente ingrediente2 =
                ingredientesSQL[cmbIngrediente2.SelectedIndex];

            //Creamos la nueva pocion
            Pocion nuevaPocion = new Pocion();

            nuevaPocion.Nombre = txtNombre.Text.Trim();
            nuevaPocion.Ingrediente1ID = ingrediente1.ID;
            nuevaPocion.Ingrediente2ID = ingrediente2.ID;
            nuevaPocion.Magnitud = magnitudElaborada;
            nuevaPocion.CantidadEfectos = cantidadEfectosElaborados;

            //Copiamos los efectos compartidos
            for (int i = 0; i < cantidadEfectosElaborados; i++)
            {
                nuevaPocion.Efectos[i] = efectosElaborados[i];
            }

            try
            {
                //Guardamos la pocion y sus efectos en TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                int idGenerado = conexion.AgregarPocion(nuevaPocion);

                //Actualizamos la tabla con las pociones de TiDB Cloud
                MostrarPociones();

                //Reiniciamos la elaboracion temporal
                pocionElaborada = false;
                cantidadEfectosElaborados = 0;
                magnitudElaborada = 0;
                idConsultado = -1;

                //Limpiamos los campos
                LimpiarCampos();

                //Informamos que la pocion fue guardada
                MessageBox.Show(
                    "Pocion agregada correctamente en TiDB Cloud. ID: " +
                    idGenerado
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar pocion: " + ex.Message);
            }
        }


        private void Ingrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Invalidamos la elaboracion cuando cambia un ingrediente
            pocionElaborada = false;
            cantidadEfectosElaborados = 0;
            magnitudElaborada = 0;

            //Limpiamos los resultados de la elaboracion anterior
            txtEfecto.Clear();
            txtMagnitud.Clear();
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Verificamos que haya una pocion seleccionada
            if (dgvPociones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una pocion para consultar.");
                return;
            }

            //Obtenemos el ID de la pocion seleccionada
            int idSeleccionado = Convert.ToInt32(
                dgvPociones.SelectedRows[0].Cells["ID"].Value
            );

            try
            {
                //Consultamos las pociones desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                List<Pocion> lista = conexion.ObtenerPociones();

                //Buscamos la pocion seleccionada
                foreach (Pocion pocion in lista)
                {
                    if (pocion.ID == idSeleccionado)
                    {
                        //Reiniciamos cualquier elaboracion anterior
                        pocionElaborada = false;
                        cantidadEfectosElaborados = 0;
                        magnitudElaborada = 0;

                        //Guardamos el ID de la pocion consultada
                        idConsultado = pocion.ID;

                        //Mostramos el ID y el nombre
                        txtID.Text = pocion.ID.ToString();
                        txtNombre.Text = pocion.Nombre;

                        //Limpiamos las selecciones anteriores
                        cmbIngrediente1.SelectedIndex = -1;
                        cmbIngrediente2.SelectedIndex = -1;

                        //Buscamos los ingredientes originales
                        for (int i = 0; i < ingredientesSQL.Count; i++)
                        {
                            if (ingredientesSQL[i].ID == pocion.Ingrediente1ID)
                            {
                                cmbIngrediente1.SelectedIndex = i;
                            }

                            if (ingredientesSQL[i].ID == pocion.Ingrediente2ID)
                            {
                                cmbIngrediente2.SelectedIndex = i;
                            }
                        }

                        //Preparamos el texto de los efectos
                        string efectosTexto = "";

                        for (int i = 0; i < pocion.CantidadEfectos; i++)
                        {
                            if (i > 0)
                            {
                                efectosTexto += ", ";
                            }

                            efectosTexto += pocion.Efectos[i];
                        }

                        //Mostramos los efectos guardados
                        txtEfecto.Text = efectosTexto;

                        //Convertimos la magnitud a numeros romanos
                        if (pocion.Magnitud == 1)
                        {
                            txtMagnitud.Text = "I";
                        }
                        else if (pocion.Magnitud == 2)
                        {
                            txtMagnitud.Text = "II";
                        }
                        else
                        {
                            txtMagnitud.Text = "III";
                        }

                        return;
                    }
                }

                //Informamos si no encontramos la pocion
                idConsultado = -1;
                MessageBox.Show("No se encontro la pocion seleccionada.");
            }
            catch (Exception ex)
            {
                idConsultado = -1;
                MessageBox.Show("Error al consultar pocion: " + ex.Message);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificamos que primero se haya consultado una pocion
            if (idConsultado == -1)
            {
                MessageBox.Show("Primero debe consultar una pocion.");
                return;
            }

            //Verificamos que la pocion tenga un nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para la pocion.");
                txtNombre.Focus();
                return;
            }

            try
            {
                //Modificamos el nombre en TiDB Cloud
                ConexionBD conexion = new ConexionBD();

                int filasAfectadas = conexion.ModificarNombrePocion(
                    idConsultado,
                    txtNombre.Text.Trim()
                );

                if (filasAfectadas > 0)
                {
                    //Actualizamos la tabla desde TiDB Cloud
                    MostrarPociones();

                    //Reiniciamos la consulta
                    idConsultado = -1;

                    //Invalidamos cualquier elaboracion pendiente
                    pocionElaborada = false;
                    cantidadEfectosElaborados = 0;
                    magnitudElaborada = 0;

                    //Limpiamos los campos
                    LimpiarCampos();

                    MessageBox.Show(
                        "Nombre de la pocion modificado correctamente."
                    );
                }
                else
                {
                    MessageBox.Show(
                        "No se modifico la pocion. Verifique si hubo cambios."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar pocion: " + ex.Message);
            }

        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos que primero se haya consultado una pocion
            if (idConsultado == -1)
            {
                MessageBox.Show("Primero debe consultar una pocion.");
                return;
            }

            //Solicitamos confirmacion antes de eliminar
            DialogResult respuesta = MessageBox.Show(
                "¿Esta seguro de eliminar esta pocion y sus efectos?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            //Cancelamos si el usuario selecciona No
            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                //Eliminamos la pocion desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                int filasAfectadas = conexion.EliminarPocion(idConsultado);

                if (filasAfectadas > 0)
                {
                    //Reiniciamos la consulta y la elaboracion
                    idConsultado = -1;
                    pocionElaborada = false;
                    cantidadEfectosElaborados = 0;
                    magnitudElaborada = 0;

                    //Actualizamos la tabla desde TiDB Cloud
                    MostrarPociones();

                    //Limpiamos los campos
                    LimpiarCampos();

                    MessageBox.Show("Pocion eliminada correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontro la pocion para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar pocion: " + ex.Message);
            }
        }


        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            //Limpiamos el buscador
            txtBuscar.Clear();

            //Mostramos todas las pociones almacenadas
            MostrarPociones();
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void btnGestionarIngredientes_Click(object sender, EventArgs e)
        {
            //Ocultamos temporalmente la mesa de alquimia
            this.Hide();

            //Abrimos el gestor de ingredientes
            using (FormIngredientes gestor = new FormIngredientes())
            {
                gestor.ShowDialog();
            }

            //Volvemos a mostrar la mesa de alquimia
            this.Show();

            //Actualizamos los ingredientes desde TiDB Cloud
            CargarIngredientesSQL();
        }

        private void btnElaborar_Click(object sender, EventArgs e)
        {
            //Invalidamos cualquier elaboracion anterior
            pocionElaborada = false;
            cantidadEfectosElaborados = 0;
            magnitudElaborada = 0;

            //Limpiamos los resultados anteriores
            txtEfecto.Clear();
            txtMagnitud.Clear();

            //Verificamos que se hayan seleccionado dos ingredientes
            if (cmbIngrediente1.SelectedIndex == -1 ||
                cmbIngrediente2.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione dos ingredientes.");
                return;
            }

            //Verificamos que sean ingredientes diferentes
            if (cmbIngrediente1.SelectedIndex == cmbIngrediente2.SelectedIndex)
            {
                MessageBox.Show("Debe seleccionar dos ingredientes diferentes.");
                return;
            }

            //Obtenemos los ingredientes desde la lista de TiDB Cloud
            Ingrediente ingrediente1 =
                ingredientesSQL[cmbIngrediente1.SelectedIndex];

            Ingrediente ingrediente2 =
                ingredientesSQL[cmbIngrediente2.SelectedIndex];


            //Guardamos los cuatro efectos del primer ingrediente
            string[] efectos1 =
                {
                    ingrediente1.Efecto1,
                    ingrediente1.Efecto2,
                    ingrediente1.Efecto3,
                    ingrediente1.Efecto4
                };

            //Guardamos los cuatro efectos del segundo ingrediente
            string[] efectos2 =
                {
                    ingrediente2.Efecto1,
                    ingrediente2.Efecto2,
                    ingrediente2.Efecto3,
                    ingrediente2.Efecto4
                };


            //Creamos un array para guardar los efectos compartidos
            string[] efectosComunes = new string[4];

            //Contamos cuantos efectos compartidos encontramos
            int cantidadEfectos = 0;

            //Recorremos los efectos del primer ingrediente
            for (int i = 0; i < 4; i++)
            {
                //Comparamos cada efecto con los del segundo ingrediente
                for (int j = 0; j < 4; j++)
                {
                    //Verificamos que los efectos coincidan
                    if (!string.IsNullOrWhiteSpace(efectos1[i]) &&
                        !string.IsNullOrWhiteSpace(efectos2[j]) &&
                        string.Equals(
                            efectos1[i].Trim(),
                            efectos2[j].Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    {
                        //Verificamos que el efecto no este repetido
                        bool repetido = false;

                        for (int k = 0; k < cantidadEfectos; k++)
                        {
                            if (string.Equals(
                                efectosComunes[k],
                                efectos1[i].Trim(),
                                StringComparison.OrdinalIgnoreCase))
                            {
                                repetido = true;
                                break;
                            }
                        }

                        //Guardamos el efecto si no esta repetido
                        if (!repetido)
                        {
                            efectosComunes[cantidadEfectos] = efectos1[i].Trim();
                            cantidadEfectos++;
                        }
                    }
                }
            }

            //Verificamos si encontramos efectos compartidos
            if (cantidadEfectos == 0)
            {
                MessageBox.Show("Los ingredientes no comparten ningun efecto.");

                txtEfecto.Clear();

                return;
            }

            //Creamos una variable para mostrar los efectos
            string efectosTexto = "";

            //Recorremos los efectos compartidos
            for (int i = 0; i < cantidadEfectos; i++)
            {
                //Separamos los efectos con una coma
                if (i > 0)
                {
                    efectosTexto += ", ";
                }

                //Agregamos el efecto actual
                efectosTexto += efectosComunes[i];
            }

            //Mostramos todos los efectos compartidos
            txtEfecto.Text = efectosTexto;


            //Calculamos el promedio de calidad de ambos ingredientes
            double promedio = (ingrediente1.Calidad + ingrediente2.Calidad) / 2.0;

            //Redondeamos hacia arriba para obtener la magnitud
            int magnitud = (int)Math.Ceiling(promedio);

            //Convertimos la magnitud a numeros romanos
            string magnitudRomana = "";

            if (magnitud == 1)
            {
                magnitudRomana = "I";
            }
            else if (magnitud == 2)
            {
                magnitudRomana = "II";
            }
            else
            {
                magnitudRomana = "III";
            }

            //Mostramos la magnitud calculada
            txtMagnitud.Text = magnitudRomana;

            //Guardamos los efectos calculados temporalmente
            for (int i = 0; i < cantidadEfectos; i++)
            {
                efectosElaborados[i] = efectosComunes[i];
            }

            //Guardamos la cantidad de efectos y la magnitud
            cantidadEfectosElaborados = cantidadEfectos;
            magnitudElaborada = magnitud;

            //Indicamos que la pocion esta lista para agregar
            pocionElaborada = true;

        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Obtenemos el texto ingresado
            string busqueda = txtBuscar.Text.Trim();

            //Verificamos que se haya ingresado una busqueda
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Ingrese un ID, nombre o efecto para buscar.");
                return;
            }

            try
            {
                //Consultamos las pociones desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                List<Pocion> lista = conexion.ObtenerPociones();

                //Limpiamos las filas anteriores
                dgvPociones.Rows.Clear();

                //Reiniciamos la pocion consultada
                idConsultado = -1;

                //Contamos las coincidencias
                int encontradas = 0;

                foreach (Pocion pocion in lista)
                {
                    //Preparamos los efectos de la pocion
                    string efectosTexto = "";

                    for (int i = 0; i < pocion.CantidadEfectos; i++)
                    {
                        if (i > 0)
                        {
                            efectosTexto += ", ";
                        }

                        efectosTexto += pocion.Efectos[i];
                    }

                    //Buscamos coincidencias por ID, nombre o efecto
                    bool coincideID = pocion.ID.ToString() == busqueda;

                    bool coincideNombre = pocion.Nombre.IndexOf(
                        busqueda,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0;

                    bool coincideEfecto = efectosTexto.IndexOf(
                        busqueda,
                        StringComparison.OrdinalIgnoreCase
                    ) >= 0;

                    if (coincideID || coincideNombre || coincideEfecto)
                    {
                        //Convertimos la magnitud a numeros romanos
                        string magnitudRomana = pocion.Magnitud.ToString();

                        if (pocion.Magnitud == 1)
                        {
                            magnitudRomana = "I";
                        }
                        else if (pocion.Magnitud == 2)
                        {
                            magnitudRomana = "II";
                        }
                        else if (pocion.Magnitud == 3)
                        {
                            magnitudRomana = "III";
                        }

                        //Mostramos la pocion encontrada
                        dgvPociones.Rows.Add(
                            pocion.ID,
                            pocion.Nombre,
                            efectosTexto,
                            magnitudRomana
                        );

                        encontradas++;
                    }
                }

                //Quitamos la seleccion automatica
                dgvPociones.ClearSelection();

                //Informamos si no encontramos coincidencias
                if (encontradas == 0)
                {
                    MessageBox.Show("No se encontraron pociones.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar pociones: " + ex.Message);
            }
        }
    }
}
