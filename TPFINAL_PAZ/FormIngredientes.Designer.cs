namespace TPFINAL_PAZ
{
    partial class FormIngredientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEfecto1 = new System.Windows.Forms.Label();
            this.lblEfecto2 = new System.Windows.Forms.Label();
            this.lblEfecto3 = new System.Windows.Forms.Label();
            this.lblEfecto4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEfecto1 = new System.Windows.Forms.TextBox();
            this.txtEfecto2 = new System.Windows.Forms.TextBox();
            this.txtEfecto3 = new System.Windows.Forms.TextBox();
            this.txtEfecto4 = new System.Windows.Forms.TextBox();
            this.grpCalidad = new System.Windows.Forms.GroupBox();
            this.lblCalidad = new System.Windows.Forms.Label();
            this.rdCalidad3 = new System.Windows.Forms.RadioButton();
            this.rdCalidad2 = new System.Windows.Forms.RadioButton();
            this.rdCalidad1 = new System.Windows.Forms.RadioButton();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMesaAlquimia = new System.Windows.Forms.Button();
            this.grpCalidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(155)))), ((int)(((byte)(73)))));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitulo.Location = new System.Drawing.Point(19, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(980, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SKYRIM - GESTOR DE INGREDIENTES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblID.Location = new System.Drawing.Point(26, 100);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblNombre.Location = new System.Drawing.Point(343, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // lblEfecto1
            // 
            this.lblEfecto1.AutoSize = true;
            this.lblEfecto1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfecto1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEfecto1.Location = new System.Drawing.Point(26, 175);
            this.lblEfecto1.Name = "lblEfecto1";
            this.lblEfecto1.Size = new System.Drawing.Size(48, 13);
            this.lblEfecto1.TabIndex = 3;
            this.lblEfecto1.Text = "Efecto 1";
            // 
            // lblEfecto2
            // 
            this.lblEfecto2.AutoSize = true;
            this.lblEfecto2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfecto2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEfecto2.Location = new System.Drawing.Point(343, 175);
            this.lblEfecto2.Name = "lblEfecto2";
            this.lblEfecto2.Size = new System.Drawing.Size(48, 13);
            this.lblEfecto2.TabIndex = 4;
            this.lblEfecto2.Text = "Efecto 2";
            // 
            // lblEfecto3
            // 
            this.lblEfecto3.AutoSize = true;
            this.lblEfecto3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfecto3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEfecto3.Location = new System.Drawing.Point(26, 250);
            this.lblEfecto3.Name = "lblEfecto3";
            this.lblEfecto3.Size = new System.Drawing.Size(48, 13);
            this.lblEfecto3.TabIndex = 5;
            this.lblEfecto3.Text = "Efecto 3";
            // 
            // lblEfecto4
            // 
            this.lblEfecto4.AutoSize = true;
            this.lblEfecto4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfecto4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblEfecto4.Location = new System.Drawing.Point(343, 250);
            this.lblEfecto4.Name = "lblEfecto4";
            this.lblEfecto4.Size = new System.Drawing.Size(48, 13);
            this.lblEfecto4.TabIndex = 6;
            this.lblEfecto4.Text = "Efecto 4";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(29, 116);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(270, 25);
            this.txtID.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(344, 116);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(270, 25);
            this.txtNombre.TabIndex = 8;
            // 
            // txtEfecto1
            // 
            this.txtEfecto1.BackColor = System.Drawing.Color.White;
            this.txtEfecto1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfecto1.Location = new System.Drawing.Point(29, 191);
            this.txtEfecto1.Name = "txtEfecto1";
            this.txtEfecto1.Size = new System.Drawing.Size(270, 25);
            this.txtEfecto1.TabIndex = 9;
            // 
            // txtEfecto2
            // 
            this.txtEfecto2.BackColor = System.Drawing.Color.White;
            this.txtEfecto2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfecto2.Location = new System.Drawing.Point(344, 191);
            this.txtEfecto2.Name = "txtEfecto2";
            this.txtEfecto2.Size = new System.Drawing.Size(270, 25);
            this.txtEfecto2.TabIndex = 10;
            // 
            // txtEfecto3
            // 
            this.txtEfecto3.BackColor = System.Drawing.Color.White;
            this.txtEfecto3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfecto3.Location = new System.Drawing.Point(29, 266);
            this.txtEfecto3.Name = "txtEfecto3";
            this.txtEfecto3.Size = new System.Drawing.Size(270, 25);
            this.txtEfecto3.TabIndex = 11;
            // 
            // txtEfecto4
            // 
            this.txtEfecto4.BackColor = System.Drawing.Color.White;
            this.txtEfecto4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfecto4.Location = new System.Drawing.Point(344, 266);
            this.txtEfecto4.Name = "txtEfecto4";
            this.txtEfecto4.Size = new System.Drawing.Size(270, 25);
            this.txtEfecto4.TabIndex = 12;
            // 
            // grpCalidad
            // 
            this.grpCalidad.Controls.Add(this.lblCalidad);
            this.grpCalidad.Controls.Add(this.rdCalidad3);
            this.grpCalidad.Controls.Add(this.rdCalidad2);
            this.grpCalidad.Controls.Add(this.rdCalidad1);
            this.grpCalidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCalidad.Location = new System.Drawing.Point(656, 96);
            this.grpCalidad.Name = "grpCalidad";
            this.grpCalidad.Size = new System.Drawing.Size(340, 220);
            this.grpCalidad.TabIndex = 13;
            this.grpCalidad.TabStop = false;
            this.grpCalidad.Text = "CALIDAD DEL INGREDIENTE";
            // 
            // lblCalidad
            // 
            this.lblCalidad.AutoSize = true;
            this.lblCalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            this.lblCalidad.Location = new System.Drawing.Point(85, 120);
            this.lblCalidad.Name = "lblCalidad";
            this.lblCalidad.Size = new System.Drawing.Size(127, 21);
            this.lblCalidad.TabIndex = 3;
            this.lblCalidad.Text = "Calidad normal";
            // 
            // rdCalidad3
            // 
            this.rdCalidad3.AutoSize = true;
            this.rdCalidad3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCalidad3.Location = new System.Drawing.Point(235, 55);
            this.rdCalidad3.Name = "rdCalidad3";
            this.rdCalidad3.Size = new System.Drawing.Size(43, 25);
            this.rdCalidad3.TabIndex = 2;
            this.rdCalidad3.Text = "III";
            this.rdCalidad3.UseVisualStyleBackColor = true;
            this.rdCalidad3.CheckedChanged += new System.EventHandler(this.rdCalidad3_CheckedChanged);
            // 
            // rdCalidad2
            // 
            this.rdCalidad2.AutoSize = true;
            this.rdCalidad2.Checked = true;
            this.rdCalidad2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCalidad2.Location = new System.Drawing.Point(135, 55);
            this.rdCalidad2.Name = "rdCalidad2";
            this.rdCalidad2.Size = new System.Drawing.Size(38, 25);
            this.rdCalidad2.TabIndex = 1;
            this.rdCalidad2.TabStop = true;
            this.rdCalidad2.Text = "II";
            this.rdCalidad2.UseVisualStyleBackColor = true;
            this.rdCalidad2.CheckedChanged += new System.EventHandler(this.rdCalidad2_CheckedChanged);
            // 
            // rdCalidad1
            // 
            this.rdCalidad1.AutoSize = true;
            this.rdCalidad1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCalidad1.Location = new System.Drawing.Point(35, 55);
            this.rdCalidad1.Name = "rdCalidad1";
            this.rdCalidad1.Size = new System.Drawing.Size(33, 25);
            this.rdCalidad1.TabIndex = 0;
            this.rdCalidad1.Text = "I";
            this.rdCalidad1.UseVisualStyleBackColor = true;
            this.rdCalidad1.CheckedChanged += new System.EventHandler(this.rdCalidad1_CheckedChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnAgregar.Location = new System.Drawing.Point(29, 346);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(170, 42);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnConsultar.Location = new System.Drawing.Point(229, 346);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(170, 42);
            this.btnConsultar.TabIndex = 15;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnModificar.Location = new System.Drawing.Point(429, 346);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(170, 42);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnEliminar.Location = new System.Drawing.Point(629, 346);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(170, 42);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.BackColor = System.Drawing.Color.Gainsboro;
            this.btnMostrarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarTodos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnMostrarTodos.Location = new System.Drawing.Point(829, 346);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(170, 42);
            this.btnMostrarTodos.TabIndex = 18;
            this.btnMostrarTodos.Text = "Mostrar todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.AllowUserToAddRows = false;
            this.dgvIngredientes.AllowUserToDeleteRows = false;
            this.dgvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Location = new System.Drawing.Point(24, 446);
            this.dgvIngredientes.MultiSelect = false;
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.ReadOnly = true;
            this.dgvIngredientes.RowHeadersVisible = false;
            this.dgvIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientes.Size = new System.Drawing.Size(920, 165);
            this.dgvIngredientes.TabIndex = 19;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(24, 410);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(115, 20);
            this.lblBuscar.TabIndex = 20;
            this.lblBuscar.Text = "Buscar ingrediente:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(144, 406);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(640, 25);
            this.txtBuscar.TabIndex = 21;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Location = new System.Drawing.Point(794, 396);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(150, 42);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMesaAlquimia
            // 
            this.btnMesaAlquimia.Location = new System.Drawing.Point(836, 626);
            this.btnMesaAlquimia.Name = "btnMesaAlquimia";
            this.btnMesaAlquimia.Size = new System.Drawing.Size(180, 35);
            this.btnMesaAlquimia.TabIndex = 23;
            this.btnMesaAlquimia.Text = "Ir a mesa de alquimia --->";
            this.btnMesaAlquimia.UseVisualStyleBackColor = true;
            this.btnMesaAlquimia.Click += new System.EventHandler(this.btnMesaAlquimia_Click);
            // 
            // FormIngredientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1034, 677);
            this.Controls.Add(this.btnMesaAlquimia);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvIngredientes);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grpCalidad);
            this.Controls.Add(this.txtEfecto4);
            this.Controls.Add(this.txtEfecto3);
            this.Controls.Add(this.txtEfecto2);
            this.Controls.Add(this.txtEfecto1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblEfecto4);
            this.Controls.Add(this.lblEfecto3);
            this.Controls.Add(this.lblEfecto2);
            this.Controls.Add(this.lblEfecto1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormIngredientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skyrim - Gestor de Ingredientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIngredientes_FormClosing);
            this.grpCalidad.ResumeLayout(false);
            this.grpCalidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEfecto1;
        private System.Windows.Forms.Label lblEfecto2;
        private System.Windows.Forms.Label lblEfecto3;
        private System.Windows.Forms.Label lblEfecto4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEfecto1;
        private System.Windows.Forms.TextBox txtEfecto2;
        private System.Windows.Forms.TextBox txtEfecto3;
        private System.Windows.Forms.TextBox txtEfecto4;
        private System.Windows.Forms.GroupBox grpCalidad;
        private System.Windows.Forms.Label lblCalidad;
        private System.Windows.Forms.RadioButton rdCalidad3;
        private System.Windows.Forms.RadioButton rdCalidad2;
        private System.Windows.Forms.RadioButton rdCalidad1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMesaAlquimia;
    }
}