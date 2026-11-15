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
        //Aumenta cada vez que se registra una pocion correctamente.
        private int siguienteID = 1;


        //Constructor del formulario, se ejecuta cuando se crea una instancia de Forms1
        public Form1()
        {
            InitializeComponent();

            //Mostramos el ID que recibira la proxima pocion
            txtID.Text = siguienteID.ToString();
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
                // Agregamos una fila con los datos de cada pocion
                dgvPociones.Rows.Add(
                    pociones[i].ID,
                    pociones[i].Nombre,
                    pociones[i].Efecto,
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

            //Colocamos el cursor en el campo ID
            txtID.Focus();

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
    }
}
