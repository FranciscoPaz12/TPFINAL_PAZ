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
    public partial class FormIngredientes : Form
    {
        public FormIngredientes()
        {

            InitializeComponent();

            //El ID se genera automaticamente en TiDB Cloud
            txtID.Text = "Automatico";

            //Seleccionamos la calidad normal por defecto
            rdCalidad2.Checked = true;

            //Mostramos la descripcion de la calidad seleccionada
            lblCalidad.Text = "Calidad normal";

            //Mostramos los ingredientes al abrir el formulario
            MostrarIngredientes();

        }


        private void FormIngredientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Si el usuario cierra con la X, terminamos la aplicacion
            if (e.CloseReason == CloseReason.UserClosing && !volverAMesa)
            {
                Application.Exit();
            }
        }

        private bool volverAMesa = false;

        //Guarda el ID del ingrediente consultado
        //El valor -1 indica que no hay ningun ingrediente consultado
        private int idConsultado = -1;


        private void rdCalidad1_CheckedChanged(object sender, EventArgs e)
        {
            //Si esta seleccionada la calidad I, mostramos su descripcion
            if (rdCalidad1.Checked)
            {
                lblCalidad.Text = "Mala calidad";
            }

        }

        private void rdCalidad2_CheckedChanged(object sender, EventArgs e)
        {
            //Si esta seleccionada la calidad II, mostramos su descripcion
            if (rdCalidad2.Checked)
            {
                lblCalidad.Text = "Calidad normal";
            }

        }

        private void rdCalidad3_CheckedChanged(object sender, EventArgs e)
        {
            //Si esta seleccionada la calidad III, mostramos su descripcion
            if (rdCalidad3.Checked)
            {
                lblCalidad.Text = "Buena calidad";
            }

        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verificamos que todos los campos esten completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto1.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto2.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto3.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto4.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            //Creamos el ingrediente con los datos del formulario
            Ingrediente nuevoIngrediente = new Ingrediente();

            nuevoIngrediente.Nombre = txtNombre.Text.Trim();
            nuevoIngrediente.Efecto1 = txtEfecto1.Text.Trim();
            nuevoIngrediente.Efecto2 = txtEfecto2.Text.Trim();
            nuevoIngrediente.Efecto3 = txtEfecto3.Text.Trim();
            nuevoIngrediente.Efecto4 = txtEfecto4.Text.Trim();

            //Asignamos la calidad seleccionada
            nuevoIngrediente.Calidad = 2;

            if (rdCalidad1.Checked)
            {
                nuevoIngrediente.Calidad = 1;
            }
            else if (rdCalidad3.Checked)
            {
                nuevoIngrediente.Calidad = 3;
            }

            try
            {
                //Guardamos el ingrediente en TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                int filasAfectadas = conexion.AgregarIngrediente(nuevoIngrediente);

                if (filasAfectadas > 0)
                {
                    //Reiniciamos la consulta anterior
                    idConsultado = -1;

                    //Actualizamos la tabla y limpiamos los campos
                    MostrarIngredientes();
                    LimpiarCampos();

                    MessageBox.Show("Ingrediente agregado correctamente en TiDB Cloud.");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el ingrediente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar ingrediente: " + ex.Message);
            }
        }


        private void MostrarIngredientes()
        {
            try
            {
                //Creamos la conexion con TiDB Cloud
                ConexionBD conexion = new ConexionBD();

                //Obtenemos los ingredientes desde la base de datos
                List<Ingrediente> lista = conexion.ObtenerIngredientes();

                //Limpiamos los datos anteriores de la tabla
                dgvIngredientes.DataSource = null;
                dgvIngredientes.Rows.Clear();
                dgvIngredientes.Columns.Clear();

                //Creamos las columnas de la tabla
                dgvIngredientes.Columns.Add("ID", "ID");
                dgvIngredientes.Columns.Add("Nombre", "Nombre");
                dgvIngredientes.Columns.Add("Efecto1", "Efecto 1");
                dgvIngredientes.Columns.Add("Efecto2", "Efecto 2");
                dgvIngredientes.Columns.Add("Efecto3", "Efecto 3");
                dgvIngredientes.Columns.Add("Efecto4", "Efecto 4");
                dgvIngredientes.Columns.Add("Calidad", "Calidad");

                //Configuramos la seleccion de filas completas
                dgvIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvIngredientes.MultiSelect = false;

                //Recorremos los ingredientes obtenidos desde SQL
                foreach (Ingrediente ingrediente in lista)
                {
                    //Convertimos la calidad numerica a numeros romanos
                    string calidadRomana = "";

                    if (ingrediente.Calidad == 1)
                    {
                        calidadRomana = "I";
                    }
                    else if (ingrediente.Calidad == 2)
                    {
                        calidadRomana = "II";
                    }
                    else
                    {
                        calidadRomana = "III";
                    }

                    //Agregamos el ingrediente a la tabla
                    dgvIngredientes.Rows.Add(
                        ingrediente.ID,
                        ingrediente.Nombre,
                        ingrediente.Efecto1,
                        ingrediente.Efecto2,
                        ingrediente.Efecto3,
                        ingrediente.Efecto4,
                        calidadRomana
                    );
                }

                //Quitamos la seleccion automatica
                dgvIngredientes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar ingredientes: " + ex.Message);
            }
        }


        private void LimpiarCampos()
        {
            //Limpiamos los campos de entrada
            txtNombre.Clear();
            txtEfecto1.Clear();
            txtEfecto2.Clear();
            txtEfecto3.Clear();
            txtEfecto4.Clear();

            //El ID se genera automaticamente en TiDB Cloud
            txtID.Text = "Automatico";

            //Restablecemos la calidad normal
            rdCalidad2.Checked = true;
            lblCalidad.Text = "Calidad normal";

            //Colocamos el cursor en el nombre del ingrediente
            txtNombre.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Verificamos que haya una fila seleccionada
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente de la tabla.");
                return;
            }

            //Obtenemos el ID seleccionado
            int id = Convert.ToInt32(
                dgvIngredientes.SelectedRows[0].Cells["ID"].Value
            );

            try
            {
                //Consultamos los ingredientes desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                List<Ingrediente> lista = conexion.ObtenerIngredientes();

                //Buscamos el ingrediente por su ID
                foreach (Ingrediente ingrediente in lista)
                {
                    if (ingrediente.ID == id)
                    {
                        //Mostramos los datos del ingrediente
                        txtID.Text = ingrediente.ID.ToString();
                        txtNombre.Text = ingrediente.Nombre;
                        txtEfecto1.Text = ingrediente.Efecto1;
                        txtEfecto2.Text = ingrediente.Efecto2;
                        txtEfecto3.Text = ingrediente.Efecto3;
                        txtEfecto4.Text = ingrediente.Efecto4;

                        //Seleccionamos la calidad correspondiente
                        rdCalidad1.Checked = ingrediente.Calidad == 1;
                        rdCalidad2.Checked = ingrediente.Calidad == 2;
                        rdCalidad3.Checked = ingrediente.Calidad == 3;

                        //Guardamos el ID consultado
                        idConsultado = ingrediente.ID;

                        MessageBox.Show("Ingrediente encontrado correctamente.");
                        return;
                    }
                }

                MessageBox.Show("No se encontro el ingrediente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar ingrediente: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificamos que haya una fila seleccionada
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente de la tabla.");
                return;
            }

            //Obtenemos el ID seleccionado
            int id = Convert.ToInt32(
                dgvIngredientes.SelectedRows[0].Cells["ID"].Value
            );

            //Verificamos que primero se haya consultado
            if (idConsultado != id)
            {
                MessageBox.Show("Primero debe consultar el ingrediente seleccionado.");
                return;
            }

            //Verificamos que todos los campos esten completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto1.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto2.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto3.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto4.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            //Creamos el ingrediente con los datos modificados
            Ingrediente ingrediente = new Ingrediente();

            ingrediente.ID = id;
            ingrediente.Nombre = txtNombre.Text.Trim();
            ingrediente.Efecto1 = txtEfecto1.Text.Trim();
            ingrediente.Efecto2 = txtEfecto2.Text.Trim();
            ingrediente.Efecto3 = txtEfecto3.Text.Trim();
            ingrediente.Efecto4 = txtEfecto4.Text.Trim();

            //Asignamos la calidad seleccionada
            ingrediente.Calidad = 2;

            if (rdCalidad1.Checked)
            {
                ingrediente.Calidad = 1;
            }
            else if (rdCalidad3.Checked)
            {
                ingrediente.Calidad = 3;
            }

            try
            {
                //Guardamos los cambios en TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                int filasAfectadas = conexion.ModificarIngrediente(ingrediente);

                if (filasAfectadas > 0)
                {
                    //Reiniciamos la consulta anterior
                    idConsultado = -1;

                    //Actualizamos la tabla y limpiamos los campos
                    MostrarIngredientes();
                    LimpiarCampos();

                    MessageBox.Show("Ingrediente modificado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se modifico el ingrediente. Verifique si hubo cambios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar ingrediente: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos que haya una fila seleccionada
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente para eliminar.");
                return;
            }

            //Obtenemos el ID seleccionado
            int id = Convert.ToInt32(
                dgvIngredientes.SelectedRows[0].Cells["ID"].Value
            );

            //Solicitamos confirmacion antes de eliminar
            DialogResult respuesta = MessageBox.Show(
                "¿Esta seguro de que desea eliminar este ingrediente?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                //Eliminamos el ingrediente desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                int filasAfectadas = conexion.EliminarIngrediente(id);

                if (filasAfectadas > 0)
                {
                    //Reiniciamos la consulta anterior
                    idConsultado = -1;

                    //Actualizamos la tabla y limpiamos los campos
                    MostrarIngredientes();
                    LimpiarCampos();

                    MessageBox.Show("Ingrediente eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("No se encontro el ingrediente para eliminar.");
                }
            }
            catch (MySqlConnector.MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "No se puede eliminar este ingrediente porque esta siendo utilizado por una pocion."
                    );
                }
                else
                {
                    MessageBox.Show("Error SQL al eliminar ingrediente: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar ingrediente: " + ex.Message);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            //Reiniciamos cualquier consulta anterior
            idConsultado = -1;

            //Limpiamos el texto utilizado para buscar
            txtBuscar.Clear();

            //Recuperamos todos los ingredientes almacenados en el array
            MostrarIngredientes();

            //Limpiamos los campos del formulario
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Obtenemos el texto ingresado
            string busqueda = txtBuscar.Text.Trim();

            //Verificamos que se haya ingresado un valor
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Ingrese un ID, nombre o efecto para buscar.");
                txtBuscar.Focus();
                return;
            }

            //Cancelamos cualquier consulta anterior
            idConsultado = -1;

            try
            {
                //Obtenemos los ingredientes desde TiDB Cloud
                ConexionBD conexion = new ConexionBD();
                List<Ingrediente> lista = conexion.ObtenerIngredientes();

                //Preparamos las columnas de la tabla
                dgvIngredientes.Rows.Clear();

                int encontrados = 0;

                //Recorremos los ingredientes obtenidos
                foreach (Ingrediente ingrediente in lista)
                {
                    //Buscamos por ID, nombre o cualquiera de los efectos
                    bool coincide =
                        ingrediente.ID.ToString() == busqueda ||
                        ingrediente.Nombre.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ingrediente.Efecto1.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ingrediente.Efecto2.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ingrediente.Efecto3.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ingrediente.Efecto4.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0;

                    if (coincide)
                    {
                        //Convertimos la calidad a numeros romanos
                        string calidad = "II";

                        if (ingrediente.Calidad == 1)
                        {
                            calidad = "I";
                        }
                        else if (ingrediente.Calidad == 3)
                        {
                            calidad = "III";
                        }

                        //Agregamos el ingrediente encontrado
                        dgvIngredientes.Rows.Add(
                            ingrediente.ID,
                            ingrediente.Nombre,
                            ingrediente.Efecto1,
                            ingrediente.Efecto2,
                            ingrediente.Efecto3,
                            ingrediente.Efecto4,
                            calidad
                        );

                        encontrados++;
                    }
                }

                //Quitamos la seleccion automatica
                dgvIngredientes.ClearSelection();

                //Limpiamos los campos del formulario
                LimpiarCampos();

                if (encontrados == 0)
                {
                    MessageBox.Show("No se encontraron ingredientes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar ingredientes: " + ex.Message);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            //Comprobamos si el usuario presiono Enter
            if (e.KeyCode == Keys.Enter)
            {
                //Ejecutamos la misma funcion que el boton Buscar
                btnBuscar.PerformClick();

                //Evitamos que Windows reproduzca el sonido de Enter
                e.SuppressKeyPress = true;
            }
        }

        private void btnMesaAlquimia_Click(object sender, EventArgs e)
        {
            //Indicamos que queremos regresar al formulario principal
            volverAMesa = true;

            //Cerramos solamente el gestor de ingredientes
            this.Close();
        }
    }
}
