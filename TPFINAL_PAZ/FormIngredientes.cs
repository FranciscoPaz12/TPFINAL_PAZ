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
    public partial class FormIngredientes : Form
    {
        public FormIngredientes()
        {
            InitializeComponent();

            //Mostramos el primer ID disponible
            txtID.Text = siguienteID.ToString();

            //Seleccionamos la calidad normal por defecto
            rdCalidad2.Checked = true;

            //Mostramos la descripcion de la calidad seleccionada
            lblCalidad.Text = "Calidad normal";

        }


        //Array que permite almacenar hasta 100 ingredientes
        private Ingrediente[] ingredientes = new Ingrediente[100];

        //Cantidad de ingredientes que tenemos registrados
        private int cantidadIngredientes = 0;

        //Numero que utilizaremos para generar IDs automaticos
        private int siguienteID = 1;

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
            //Verificamos que el array tenga espacio disponible
            if (cantidadIngredientes >= ingredientes.Length)
            {
                MessageBox.Show("No se pueden agregar mas ingredientes.");
                return;
            }

            //Verificamos que todos los campos obligatorios esten completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto1.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto2.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto3.Text) ||
                string.IsNullOrWhiteSpace(txtEfecto4.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            //Creamos un nuevo objeto de tipo Ingrediente
            Ingrediente nuevoIngrediente = new Ingrediente();

            //Asignamos un ID automatico al ingrediente
            nuevoIngrediente.ID = siguienteID;

            //Guardamos el nombre y los cuatro efectos ingresados
            nuevoIngrediente.Nombre = txtNombre.Text.Trim();
            nuevoIngrediente.Efecto1 = txtEfecto1.Text.Trim();
            nuevoIngrediente.Efecto2 = txtEfecto2.Text.Trim();
            nuevoIngrediente.Efecto3 = txtEfecto3.Text.Trim();
            nuevoIngrediente.Efecto4 = txtEfecto4.Text.Trim();

            //Determinamos la calidad seleccionada, por defecto utilizamos calidad normal

            nuevoIngrediente.Calidad = 2;

            //Si seleccionamos I, asignamos mala calidad
            if (rdCalidad1.Checked)
            {
                nuevoIngrediente.Calidad = 1;
            }
            //Si seleccionamos III, asignamos buena calidad
            else if (rdCalidad3.Checked)
            {
                nuevoIngrediente.Calidad = 3;
            }

            //Configuramos la seleccion de filas completas
            dgvIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Permitimos seleccionar una sola fila
            dgvIngredientes.MultiSelect = false;

            //Guardamos el ingrediente en la siguiente posicion libre
            ingredientes[cantidadIngredientes] = nuevoIngrediente;

            //Aumentamos la cantidad de ingredientes registrados
            cantidadIngredientes++;

            //Incrementamos el ID para el proximo ingrediente
            siguienteID++;

            //Reiniciamos cualquier consulta anterior
            idConsultado = -1;

            //Actualizamos la tabla con los ingredientes registrados
            MostrarIngredientes();

            //Limpiamos los campos para permitir otra carga
            LimpiarCampos();

            //Informamos que la operacion fue exitosa
            MessageBox.Show("Ingrediente agregado correctamente.");
        }


        private void MostrarIngredientes()
        {
            //Quitamos cualquier origen de datos anterior
            dgvIngredientes.DataSource = null;

            //Eliminamos las filas y columnas anteriores
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

            //Recorremos las posiciones ocupadas del array
            for (int i = 0; i < cantidadIngredientes; i++)
            {
                //Convertimos la calidad numerica a numeros romanos
                string calidadRomana = "";

                if (ingredientes[i].Calidad == 1)
                {
                    calidadRomana = "I";
                }
                else if (ingredientes[i].Calidad == 2)
                {
                    calidadRomana = "II";
                }
                else
                {
                    calidadRomana = "III";
                }

                //Agregamos una fila con los datos del ingrediente
                dgvIngredientes.Rows.Add(
                    ingredientes[i].ID,
                    ingredientes[i].Nombre,
                    ingredientes[i].Efecto1,
                    ingredientes[i].Efecto2,
                    ingredientes[i].Efecto3,
                    ingredientes[i].Efecto4,
                    calidadRomana
                );
            }

            //Quitamos la seleccion automatica de la tabla
            dgvIngredientes.ClearSelection();
        }


        private void LimpiarCampos()
        {
            //Limpiamos los campos de entrada
            txtNombre.Clear();
            txtEfecto1.Clear();
            txtEfecto2.Clear();
            txtEfecto3.Clear();
            txtEfecto4.Clear();

            //Mostramos el siguiente ID automatico
            txtID.Text = siguienteID.ToString();

            //Restablecemos la calidad normal
            rdCalidad2.Checked = true;
            lblCalidad.Text = "Calidad normal";

            //Colocamos el cursor en el nombre del ingrediente
            txtNombre.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Verificamos que el usuario haya seleccionado una fila
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente de la tabla.");
                return;
            }

            //Obtenemos el ID de la fila seleccionada
            int id = Convert.ToInt32(
                dgvIngredientes.SelectedRows[0].Cells["ID"].Value
            );

            //Buscamos el ingrediente dentro del array
            for (int i = 0; i < cantidadIngredientes; i++)
            {
                //Comparamos el ID guardado con el ID seleccionado
                if (ingredientes[i].ID == id)
                {
                    //Mostramos los datos del ingrediente encontrado
                    txtID.Text = ingredientes[i].ID.ToString();
                    txtNombre.Text = ingredientes[i].Nombre;
                    txtEfecto1.Text = ingredientes[i].Efecto1;
                    txtEfecto2.Text = ingredientes[i].Efecto2;
                    txtEfecto3.Text = ingredientes[i].Efecto3;
                    txtEfecto4.Text = ingredientes[i].Efecto4;

                    //Seleccionamos la calidad correspondiente
                    rdCalidad1.Checked = ingredientes[i].Calidad == 1;
                    rdCalidad2.Checked = ingredientes[i].Calidad == 2;
                    rdCalidad3.Checked = ingredientes[i].Calidad == 3;


                    //Recordamos el ID del ingrediente que consultamos
                    idConsultado = ingredientes[i].ID;


                    //Informamos que encontramos el ingrediente
                    MessageBox.Show("Ingrediente encontrado correctamente.");
                    return;
                }
            }

            //Avisamos si no encontramos el ingrediente
            MessageBox.Show("No se encontro el ingrediente.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificamos que haya una fila seleccionada
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente de la tabla.");
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

            //Obtenemos el ID del ingrediente seleccionado
            int id = Convert.ToInt32(
                dgvIngredientes.SelectedRows[0].Cells["ID"].Value
            );

            //Verificamos que primero se haya consultado el ingrediente
            if (idConsultado != id)
            {
                MessageBox.Show("Primero debe consultar el ingrediente seleccionado.");
                return;
            }

            //Recorremos el array buscando el ingrediente
            for (int i = 0; i < cantidadIngredientes; i++)
            {
                //Comparamos los IDs para encontrar el registro correcto
                if (ingredientes[i].ID == id)
                {
                    //Actualizamos el nombre y los cuatro efectos
                    ingredientes[i].Nombre = txtNombre.Text.Trim();
                    ingredientes[i].Efecto1 = txtEfecto1.Text.Trim();
                    ingredientes[i].Efecto2 = txtEfecto2.Text.Trim();
                    ingredientes[i].Efecto3 = txtEfecto3.Text.Trim();
                    ingredientes[i].Efecto4 = txtEfecto4.Text.Trim();

                    //Actualizamos la calidad del ingrediente
                    if (rdCalidad1.Checked)
                    {
                        ingredientes[i].Calidad = 1;
                    }
                    else if (rdCalidad2.Checked)
                    {
                        ingredientes[i].Calidad = 2;
                    }
                    else
                    {
                        ingredientes[i].Calidad = 3;
                    }

                    //Reiniciamos el ID consultado para evitar modificaciones accidentales
                    idConsultado = -1;

                    //Actualizamos la tabla con los cambios
                    MostrarIngredientes();

                    //Limpiamos los campos del formulario
                    LimpiarCampos();

                    //Confirmamos que se guardaron las modificaciones
                    MessageBox.Show("Ingrediente modificado correctamente.");
                    return;
                }

            }

            //Avisamos si el ingrediente no existe en el array
            MessageBox.Show("No se encontro el ingrediente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos que haya un ingrediente seleccionado
            if (dgvIngredientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente para eliminar.");
                return;
            }

            //Obtenemos el ID del ingrediente seleccionado
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

            //Si el usuario elige No, cancelamos la operacion
            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            //Recorremos el array para buscar el ingrediente
            for (int i = 0; i < cantidadIngredientes; i++)
            {
                //Comprobamos si encontramos el ID seleccionado
                if (ingredientes[i].ID == id)
                {
                    //Desplazamos los ingredientes una posicion hacia la izquierda
                    for (int j = i; j < cantidadIngredientes - 1; j++)
                    {
                        ingredientes[j] = ingredientes[j + 1];
                    }

                    //Vaciamos la ultima posicion que estaba ocupada
                    ingredientes[cantidadIngredientes - 1] = null;

                    //Reducimos la cantidad de ingredientes registrados
                    cantidadIngredientes--;

                    //Reiniciamos la consulta anterior
                    idConsultado = -1;

                    //Actualizamos la tabla y limpiamos los campos
                    MostrarIngredientes();
                    LimpiarCampos();

                    //Informamos que el ingrediente fue eliminado
                    MessageBox.Show("Ingrediente eliminado correctamente.");
                    return;
                }
            }

            //Avisamos si no encontramos el ingrediente
            MessageBox.Show("No se encontro el ingrediente.");
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
            //Obtenemos el texto ingresado y eliminamos espacios sobrantes
            string busqueda = txtBuscar.Text.Trim();

            //Verificamos que el usuario haya escrito algo
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Ingrese un ID, nombre o efecto para buscar.");
                txtBuscar.Focus();
                return;
            }

            //Reiniciamos cualquier consulta anterior
            idConsultado = -1;

            //Mostramos nuevamente todos los ingredientes
            MostrarIngredientes();

            //Contador de ingredientes encontrados
            int encontrados = 0;

            //Comprobamos si la busqueda es un numero de ID
            int idBuscado;
            bool buscarPorID = int.TryParse(busqueda, out idBuscado);

            //Recorremos todas las filas desde la ultima hasta la primera
            for (int i = dgvIngredientes.Rows.Count - 1; i >= 0; i--)
            {
                //Obtenemos la fila actual
                DataGridViewRow fila = dgvIngredientes.Rows[i];

                //Obtenemos los datos del ingrediente
                int id = Convert.ToInt32(fila.Cells["ID"].Value);
                string nombre = fila.Cells["Nombre"].Value.ToString();
                string efecto1 = fila.Cells["Efecto1"].Value.ToString();
                string efecto2 = fila.Cells["Efecto2"].Value.ToString();
                string efecto3 = fila.Cells["Efecto3"].Value.ToString();
                string efecto4 = fila.Cells["Efecto4"].Value.ToString();

                //Variable que indica si encontramos una coincidencia
                bool coincide = false;

                if (buscarPorID)
                {
                    //Buscamos una coincidencia exacta con el ID
                    coincide = id == idBuscado;
                }
                else
                {
                    //Buscamos coincidencias en el nombre y los cuatro efectos
                    coincide =
                        nombre.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        efecto1.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        efecto2.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        efecto3.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        efecto4.IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                //Quitamos de la tabla las filas que no coinciden
                if (!coincide)
                {
                    dgvIngredientes.Rows.RemoveAt(i);
                }
                else
                {
                    //Aumentamos el contador de resultados
                    encontrados++;
                }
            }

            //Limpiamos los campos del formulario
            LimpiarCampos();

            //Informamos si no encontramos resultados
            if (encontrados == 0)
            {
                MessageBox.Show("No se encontraron ingredientes.");
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
    }
}
