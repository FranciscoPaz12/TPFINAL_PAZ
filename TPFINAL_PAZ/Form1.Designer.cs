namespace TPFINAL_PAZ
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEfecto = new System.Windows.Forms.TextBox();
            this.txtMagnitud = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEfecto = new System.Windows.Forms.Label();
            this.lblMagnitud = new System.Windows.Forms.Label();
            this.btbAgregar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.dgvPociones = new System.Windows.Forms.DataGridView();
            this.lblIngrediente1 = new System.Windows.Forms.Label();
            this.lblIngrediente2 = new System.Windows.Forms.Label();
            this.cmbIngrediente1 = new System.Windows.Forms.ComboBox();
            this.cmbIngrediente2 = new System.Windows.Forms.ComboBox();
            this.btnElaborar = new System.Windows.Forms.Button();
            this.btnGestionarIngredientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPociones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitulo.Location = new System.Drawing.Point(324, 55);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(428, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SKYRIM - GESTOR DE ALQUIMIA";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtID.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtID.Location = new System.Drawing.Point(124, 207);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(250, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TabStop = false;
            this.txtID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CampoSoloLectura_MouseDown);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(674, 207);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtEfecto
            // 
            this.txtEfecto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEfecto.Location = new System.Drawing.Point(124, 271);
            this.txtEfecto.Name = "txtEfecto";
            this.txtEfecto.ReadOnly = true;
            this.txtEfecto.Size = new System.Drawing.Size(250, 20);
            this.txtEfecto.TabIndex = 3;
            this.txtEfecto.TabStop = false;
            this.txtEfecto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CampoSoloLectura_MouseDown);
            // 
            // txtMagnitud
            // 
            this.txtMagnitud.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMagnitud.Location = new System.Drawing.Point(674, 271);
            this.txtMagnitud.Name = "txtMagnitud";
            this.txtMagnitud.ReadOnly = true;
            this.txtMagnitud.Size = new System.Drawing.Size(250, 20);
            this.txtMagnitud.TabIndex = 4;
            this.txtMagnitud.TabStop = false;
            this.txtMagnitud.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CampoSoloLectura_MouseDown);
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblID.Location = new System.Drawing.Point(120, 183);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(170, 21);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "ID";
            this.lblID.Click += new System.EventHandler(this.lblID_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblNombre.Location = new System.Drawing.Point(670, 183);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(170, 21);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre de la poción";
            // 
            // lblEfecto
            // 
            this.lblEfecto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfecto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEfecto.Location = new System.Drawing.Point(120, 247);
            this.lblEfecto.Name = "lblEfecto";
            this.lblEfecto.Size = new System.Drawing.Size(170, 21);
            this.lblEfecto.TabIndex = 7;
            this.lblEfecto.Text = "Efecto";
            // 
            // lblMagnitud
            // 
            this.lblMagnitud.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMagnitud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblMagnitud.Location = new System.Drawing.Point(670, 247);
            this.lblMagnitud.Name = "lblMagnitud";
            this.lblMagnitud.Size = new System.Drawing.Size(170, 21);
            this.lblMagnitud.TabIndex = 8;
            this.lblMagnitud.Text = "Magnitud";
            // 
            // btbAgregar
            // 
            this.btbAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btbAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btbAgregar.Location = new System.Drawing.Point(132, 368);
            this.btbAgregar.Name = "btbAgregar";
            this.btbAgregar.Size = new System.Drawing.Size(140, 40);
            this.btbAgregar.TabIndex = 9;
            this.btbAgregar.Text = "Agregar";
            this.btbAgregar.UseVisualStyleBackColor = false;
            this.btbAgregar.Click += new System.EventHandler(this.btbAgregar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnConsultar.Location = new System.Drawing.Point(292, 368);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(140, 40);
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnModificar.Location = new System.Drawing.Point(452, 368);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(140, 40);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnEliminar.Location = new System.Drawing.Point(612, 368);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 40);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMostrarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMostrarTodos.Location = new System.Drawing.Point(772, 368);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(140, 40);
            this.btnMostrarTodos.TabIndex = 13;
            this.btnMostrarTodos.Text = "Mostrar todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // dgvPociones
            // 
            this.dgvPociones.AllowUserToAddRows = false;
            this.dgvPociones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPociones.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPociones.Location = new System.Drawing.Point(124, 420);
            this.dgvPociones.Name = "dgvPociones";
            this.dgvPociones.ReadOnly = true;
            this.dgvPociones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPociones.Size = new System.Drawing.Size(800, 180);
            this.dgvPociones.TabIndex = 14;
            // 
            // lblIngrediente1
            // 
            this.lblIngrediente1.AutoSize = true;
            this.lblIngrediente1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrediente1.Location = new System.Drawing.Point(191, 105);
            this.lblIngrediente1.Name = "lblIngrediente1";
            this.lblIngrediente1.Size = new System.Drawing.Size(112, 21);
            this.lblIngrediente1.TabIndex = 15;
            this.lblIngrediente1.Text = "Ingrediente 1";
            // 
            // lblIngrediente2
            // 
            this.lblIngrediente2.AutoSize = true;
            this.lblIngrediente2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrediente2.Location = new System.Drawing.Point(741, 105);
            this.lblIngrediente2.Name = "lblIngrediente2";
            this.lblIngrediente2.Size = new System.Drawing.Size(112, 21);
            this.lblIngrediente2.TabIndex = 16;
            this.lblIngrediente2.Text = "Ingrediente 2";
            // 
            // cmbIngrediente1
            // 
            this.cmbIngrediente1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngrediente1.FormattingEnabled = true;
            this.cmbIngrediente1.Location = new System.Drawing.Point(52, 147);
            this.cmbIngrediente1.Name = "cmbIngrediente1";
            this.cmbIngrediente1.Size = new System.Drawing.Size(390, 21);
            this.cmbIngrediente1.TabIndex = 17;
            // 
            // cmbIngrediente2
            // 
            this.cmbIngrediente2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngrediente2.FormattingEnabled = true;
            this.cmbIngrediente2.Location = new System.Drawing.Point(602, 147);
            this.cmbIngrediente2.Name = "cmbIngrediente2";
            this.cmbIngrediente2.Size = new System.Drawing.Size(390, 21);
            this.cmbIngrediente2.TabIndex = 18;
            // 
            // btnElaborar
            // 
            this.btnElaborar.AutoSize = true;
            this.btnElaborar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElaborar.Location = new System.Drawing.Point(434, 307);
            this.btnElaborar.Name = "btnElaborar";
            this.btnElaborar.Size = new System.Drawing.Size(177, 40);
            this.btnElaborar.TabIndex = 19;
            this.btnElaborar.Text = "Elaborar Poción";
            this.btnElaborar.UseVisualStyleBackColor = true;
            this.btnElaborar.Click += new System.EventHandler(this.btnElaborar_Click);
            // 
            // btnGestionarIngredientes
            // 
            this.btnGestionarIngredientes.Location = new System.Drawing.Point(12, 630);
            this.btnGestionarIngredientes.Name = "btnGestionarIngredientes";
            this.btnGestionarIngredientes.Size = new System.Drawing.Size(180, 35);
            this.btnGestionarIngredientes.TabIndex = 20;
            this.btnGestionarIngredientes.Text = "<--- Gestionar Ingredientes";
            this.btnGestionarIngredientes.UseVisualStyleBackColor = true;
            this.btnGestionarIngredientes.Click += new System.EventHandler(this.btnGestionarIngredientes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1034, 677);
            this.Controls.Add(this.btnGestionarIngredientes);
            this.Controls.Add(this.btnElaborar);
            this.Controls.Add(this.cmbIngrediente2);
            this.Controls.Add(this.cmbIngrediente1);
            this.Controls.Add(this.lblIngrediente2);
            this.Controls.Add(this.lblIngrediente1);
            this.Controls.Add(this.dgvPociones);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btbAgregar);
            this.Controls.Add(this.lblMagnitud);
            this.Controls.Add(this.lblEfecto);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtMagnitud);
            this.Controls.Add(this.txtEfecto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skyrim - Gestor de Alquimia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPociones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEfecto;
        private System.Windows.Forms.TextBox txtMagnitud;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEfecto;
        private System.Windows.Forms.Label lblMagnitud;
        private System.Windows.Forms.Button btbAgregar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.DataGridView dgvPociones;
        private System.Windows.Forms.Label lblIngrediente1;
        private System.Windows.Forms.Label lblIngrediente2;
        private System.Windows.Forms.Button btnElaborar;
        public System.Windows.Forms.ComboBox cmbIngrediente1;
        public System.Windows.Forms.ComboBox cmbIngrediente2;
        private System.Windows.Forms.Button btnGestionarIngredientes;
    }
}

