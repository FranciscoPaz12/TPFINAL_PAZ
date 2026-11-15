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

        }
           



        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {

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

            //Variable para guardar el efecto que comparten
            string efectoComun = "";

            //Recorremos los efectos del primer ingrediente
            for (int i = 0; i < 4; i++)
            {
                //Comparamos cada efecto con los del segundo ingrediente
                for (int j = 0; j < 4; j++)
                {
                    //Verificamos que los efectos coincidan
                    if (!string.IsNullOrWhiteSpace(efectos1[i]) &&
                        string.Equals(
                            efectos1[i].Trim(),
                            efectos2[j]?.Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    {
                        //Guardamos el efecto encontrado
                        efectoComun = efectos1[i].Trim();

                        break;
                    }
                }

                //Detenemos la busqueda si encontramos una coincidencia
                if (efectoComun != "")
                {
                    break;
                }
            }

            //Verificamos si los ingredientes comparten algun efecto
            if (efectoComun == "")
            {
                MessageBox.Show("Los ingredientes no comparten ningun efecto.");

                txtEfecto.Clear();

                return;
            }

            //Mostramos el efecto compartido en el formulario
            txtEfecto.Text = efectoComun;

        }
    }
}
