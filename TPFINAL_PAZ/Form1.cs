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

namespace TPFINAL_PAZ
{
    public partial class Form1 : Form
    {
        //Array que almacena hasta 100 objetos de tipo Pocion
        //Cada posicion puede tener una pocion diferente
        private Pocion[] pociones = new Pocion[100];
        
        //Contador que registra cuantas pociones tenemos almacenadas
        //Comienza en 0 porque inicialmente no hay pociones
        private int cantidadPociones = 0;

        //Guarda el proximo ID disponible para una nueva pocion.
        //Aumenta cada vez que se registra una pocion correctamente
        private int siguienteID = 1;

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




        //Constructor del formulario, se ejecuta cuando se crea una instancia de Form1
        public Form1()
        {
            InitializeComponent();

            //Mostramos el ID que recibira la proxima pocion
            txtID.Text = siguienteID.ToString();

            //Cargamos los ingredientes registrados al iniciar el formulario
            CargarIngredientes();

        }

        private void CampoSoloLectura_MouseDown(object sender, MouseEventArgs e)
        {
            //Quitamos el foco del campo de solo lectura
            this.ActiveControl = null;
        }

        private void CargarIngredientes()
        {
            //Limpiamos los ingredientes anteriores de ambos ComboBox
            cmbIngrediente1.Items.Clear();
            cmbIngrediente2.Items.Clear();

            //Recorremos el array compartido de ingredientes
            for (int i = 0; i < DatosAlquimia.CantidadIngredientes; i++)
            {
                //Obtenemos el ingrediente de la posicion actual
                Ingrediente ingrediente = DatosAlquimia.Ingredientes[i];

                //Agregamos el nombre a ambos ComboBox
                cmbIngrediente1.Items.Add(ingrediente.Nombre);
                cmbIngrediente2.Items.Add(ingrediente.Nombre);
            }

            //Dejamos ambos ComboBox sin una seleccion inicial
            cmbIngrediente1.SelectedIndex = -1;
            cmbIngrediente2.SelectedIndex = -1;
        }


        private void MostrarPociones()
        {
            //Eliminamos las filas y columnas anteriores de la tabla
            dgvPociones.DataSource = null;
            dgvPociones.Rows.Clear();
            dgvPociones.Columns.Clear();

            //Creamos las columnas que mostraran los datos
            dgvPociones.Columns.Add("ID", "ID");
            dgvPociones.Columns.Add("Nombre", "Nombre");
            dgvPociones.Columns.Add("Efecto", "Efecto");
            dgvPociones.Columns.Add("Magnitud", "Magnitud");

            //Recorremos el array hasta la cantidad de pociones guardadas
            for (int i = 0; i < cantidadPociones; i++)
            {

                //Creamos una variable para mostrar los efectos
                string efectosTexto = "";

                //Recorremos los efectos que tiene la pocion
                for (int j = 0; j < pociones[i].CantidadEfectos; j++)
                {
                    //Agregamos una coma entre los efectos
                    if (j > 0)
                    {
                        efectosTexto += ", ";
                    }

                    //Agregamos el efecto actual
                    efectosTexto += pociones[i].Efectos[j];
                }

                // Agregamos una fila con los datos de cada pocion
                dgvPociones.Rows.Add(
                    pociones[i].ID,
                    pociones[i].Nombre,
                    efectosTexto,
                    pociones[i].Magnitud
                );
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

            //Actualizamos el ID para la proxima pocion
            txtID.Text = siguienteID.ToString();
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

            //Verificamos que haya espacio disponible en el array
            if (cantidadPociones >= pociones.Length)
            {
                MessageBox.Show("No se pueden registrar mas pociones.");
                return;
            }

            //Obtenemos los ingredientes seleccionados
            Ingrediente ingrediente1 =
                DatosAlquimia.Ingredientes[cmbIngrediente1.SelectedIndex];

            Ingrediente ingrediente2 =
                DatosAlquimia.Ingredientes[cmbIngrediente2.SelectedIndex];

            //Creamos la nueva pocion
            Pocion nuevaPocion = new Pocion();

            nuevaPocion.ID = siguienteID;
            nuevaPocion.Nombre = txtNombre.Text.Trim();
            nuevaPocion.Ingrediente1ID = ingrediente1.ID;
            nuevaPocion.Ingrediente2ID = ingrediente2.ID;
            nuevaPocion.Magnitud = magnitudElaborada;
            nuevaPocion.CantidadEfectos = cantidadEfectosElaborados;

            //Copiamos los efectos compartidos a la pocion
            for (int i = 0; i < cantidadEfectosElaborados; i++)
            {
                nuevaPocion.Efectos[i] = efectosElaborados[i];
            }

            //Guardamos la pocion en el array
            pociones[cantidadPociones] = nuevaPocion;

            //Actualizamos los contadores
            cantidadPociones++;
            siguienteID++;

            //Actualizamos la tabla
            MostrarPociones();

            //Indicamos que la pocion fue guardada
            MessageBox.Show("Pocion agregada correctamente.");

            //Reiniciamos la elaboracion temporal
            pocionElaborada = false;
            cantidadEfectosElaborados = 0;
            magnitudElaborada = 0;

            //Limpiamos los campos
            LimpiarCampos();
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

            //Recorremos el array para buscar la pocion
            for (int i = 0; i < cantidadPociones; i++)
            {
                if (pociones[i].ID == idSeleccionado)
                {
                    //Guardamos el ID de la pocion consultada
                    idConsultado = pociones[i].ID;

                    //Mostramos el ID y el nombre
                    txtID.Text = pociones[i].ID.ToString();
                    txtNombre.Text = pociones[i].Nombre;

                    //Limpiamos las selecciones anteriores
                    cmbIngrediente1.SelectedIndex = -1;
                    cmbIngrediente2.SelectedIndex = -1;

                    //Buscamos los ingredientes originales
                    for (int j = 0; j < DatosAlquimia.CantidadIngredientes; j++)
                    {
                        if (DatosAlquimia.Ingredientes[j].ID == pociones[i].Ingrediente1ID)
                        {
                            cmbIngrediente1.SelectedIndex = j;
                        }

                        if (DatosAlquimia.Ingredientes[j].ID == pociones[i].Ingrediente2ID)
                        {
                            cmbIngrediente2.SelectedIndex = j;
                        }
                    }

                    //Preparamos el texto de los efectos
                    string efectosTexto = "";

                    //Recorremos los efectos guardados
                    for (int j = 0; j < pociones[i].CantidadEfectos; j++)
                    {
                        //Agregamos una coma entre los efectos
                        if (j > 0)
                        {
                            efectosTexto += ", ";
                        }

                        //Agregamos el efecto actual
                        efectosTexto += pociones[i].Efectos[j];
                    }

                    //Mostramos los efectos de la pocion
                    txtEfecto.Text = efectosTexto;

                    //Convertimos la magnitud a numeros romanos
                    if (pociones[i].Magnitud == 1)
                    {
                        txtMagnitud.Text = "I";
                    }
                    else if (pociones[i].Magnitud == 2)
                    {
                        txtMagnitud.Text = "II";
                    }
                    else
                    {
                        txtMagnitud.Text = "III";
                    }

                    //Invalidamos cualquier elaboracion pendiente
                    pocionElaborada = false;
                    cantidadEfectosElaborados = 0;
                    magnitudElaborada = 0;

                    return;
                }
            }

            //Informamos si no encontramos la pocion
            MessageBox.Show("No se encontro la pocion seleccionada.");
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

            //Buscamos la pocion consultada en el array
            for (int i = 0; i < cantidadPociones; i++)
            {
                if (pociones[i].ID == idConsultado)
                {
                    //Modificamos solamente el nombre
                    pociones[i].Nombre = txtNombre.Text.Trim();

                    //Actualizamos la tabla
                    MostrarPociones();

                    //Informamos que la pocion fue modificada
                    MessageBox.Show("Nombre de la pocion modificado correctamente.");

                    //Reiniciamos la consulta
                    idConsultado = -1;

                    //Invalidamos cualquier elaboracion pendiente
                    pocionElaborada = false;
                    cantidadEfectosElaborados = 0;
                    magnitudElaborada = 0;

                    //Limpiamos los campos
                    LimpiarCampos();

                    return;
                }
            }

            //Informamos si no encontramos la pocion
            MessageBox.Show("No se encontro la pocion consultada.");
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos que primero se haya consultado una pocion
            if (idConsultado == -1)
            {
                MessageBox.Show("Primero debe consultar una pocion.");
                return;
            }

            //Pedimos confirmacion antes de eliminar
            DialogResult respuesta = MessageBox.Show(
                "¿Esta seguro de eliminar esta pocion?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            //Cancelamos si el usuario selecciona No
            if (respuesta == DialogResult.No)
            {
                return;
            }

            //Buscamos la pocion consultada en el array
            for (int i = 0; i < cantidadPociones; i++)
            {
                if (pociones[i].ID == idConsultado)
                {
                    //Desplazamos las pociones una posicion hacia la izquierda
                    for (int j = i; j < cantidadPociones - 1; j++)
                    {
                        pociones[j] = pociones[j + 1];
                    }

                    //Limpiamos la ultima posicion utilizada
                    pociones[cantidadPociones - 1] = null;

                    //Reducimos la cantidad de pociones
                    cantidadPociones--;

                    //Actualizamos la tabla
                    MostrarPociones();

                    //Reiniciamos la consulta y la elaboracion
                    idConsultado = -1;
                    pocionElaborada = false;
                    cantidadEfectosElaborados = 0;
                    magnitudElaborada = 0;

                    //Limpiamos los campos
                    LimpiarCampos();

                    MessageBox.Show("Pocion eliminada correctamente.");
                    return;
                }
            }

            MessageBox.Show("No se encontro la pocion consultada.");
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

            //Actualizamos los ingredientes disponibles
            CargarIngredientes();
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

            //Obtenemos los ingredientes desde el array compartido
            Ingrediente ingrediente1 =
                DatosAlquimia.Ingredientes[cmbIngrediente1.SelectedIndex];

            Ingrediente ingrediente2 =
                DatosAlquimia.Ingredientes[cmbIngrediente2.SelectedIndex];


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
            //Obtenemos el texto ingresado en el buscador
            string busqueda = txtBuscar.Text.Trim();

            //Verificamos que se haya ingresado una busqueda
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Ingrese un ID, nombre o efecto para buscar.");
                return;
            }

            //Limpiamos las filas anteriores
            dgvPociones.Rows.Clear();

            //Contamos las pociones encontradas
            int encontradas = 0;

            //Recorremos todas las pociones almacenadas
            for (int i = 0; i < cantidadPociones; i++)
            {
                //Preparamos los efectos de la pocion
                string efectosTexto = "";

                //Recorremos los efectos guardados
                for (int j = 0; j < pociones[i].CantidadEfectos; j++)
                {
                    if (j > 0)
                    {
                        efectosTexto += ", ";
                    }

                    efectosTexto += pociones[i].Efectos[j];
                }

                //Buscamos coincidencias por ID, nombre o efectos
                bool coincideID = pociones[i].ID.ToString() == busqueda;

                bool coincideNombre = pociones[i].Nombre.IndexOf(
                    busqueda,
                    StringComparison.OrdinalIgnoreCase
                ) >= 0;

                bool coincideEfecto = efectosTexto.IndexOf(
                    busqueda,
                    StringComparison.OrdinalIgnoreCase
                ) >= 0;

                //Mostramos solamente las pociones coincidentes
                if (coincideID || coincideNombre || coincideEfecto)
                {
                    dgvPociones.Rows.Add(
                        pociones[i].ID,
                        pociones[i].Nombre,
                        efectosTexto,
                        pociones[i].Magnitud
                    );

                    encontradas++;
                }
            }

            //Informamos si no se encontraron coincidencias
            if (encontradas == 0)
            {
                MessageBox.Show("No se encontraron pociones.");
            }
        }
    }
}
