namespace SisBanca
{
    partial class Frm_Cuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cuentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_titulo_form = new System.Windows.Forms.Panel();
            this.lbl_cuentas = new System.Windows.Forms.Label();
            this.Btn_salir_cliente = new System.Windows.Forms.Button();
            this.Btn_reporte = new System.Windows.Forms.Button();
            this.Btn_eliminar = new System.Windows.Forms.Button();
            this.Btn_actualizar = new System.Windows.Forms.Button();
            this.Btn_nuevo = new System.Windows.Forms.Button();
            this.Tbc_principal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_recuperar = new System.Windows.Forms.Button();
            this.btn_verEliminados = new System.Windows.Forms.Button();
            this.Dgv_principal = new System.Windows.Forms.DataGridView();
            this.Btn_buscar = new System.Windows.Forms.Button();
            this.Txt_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Pnl_tipoCuenta = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Dgv_tipoCuentas = new System.Windows.Forms.DataGridView();
            this.Pnl_tipoCliente = new System.Windows.Forms.Panel();
            this.Btn_retorno = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Dgv_personas = new System.Windows.Forms.DataGridView();
            this.Btn_lupaCliente = new System.Windows.Forms.Button();
            this.Txt_saldo = new System.Windows.Forms.TextBox();
            this.Btn_retornar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_tipoCuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_lupaCuenta = new System.Windows.Forms.Button();
            this.pnl_titulo_form.SuspendLayout();
            this.Tbc_principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.Pnl_tipoCuenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_tipoCuentas)).BeginInit();
            this.Pnl_tipoCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_personas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titulo_form
            // 
            this.pnl_titulo_form.BackColor = System.Drawing.Color.Tomato;
            this.pnl_titulo_form.Controls.Add(this.lbl_cuentas);
            this.pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo_form.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titulo_form.Name = "pnl_titulo_form";
            this.pnl_titulo_form.Size = new System.Drawing.Size(1780, 44);
            this.pnl_titulo_form.TabIndex = 41;
            // 
            // lbl_cuentas
            // 
            this.lbl_cuentas.AutoSize = true;
            this.lbl_cuentas.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cuentas.ForeColor = System.Drawing.Color.White;
            this.lbl_cuentas.Location = new System.Drawing.Point(8, 11);
            this.lbl_cuentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cuentas.Name = "lbl_cuentas";
            this.lbl_cuentas.Size = new System.Drawing.Size(117, 25);
            this.lbl_cuentas.TabIndex = 0;
            this.lbl_cuentas.Text = "CUENTAS";
            // 
            // Btn_salir_cliente
            // 
            this.Btn_salir_cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_salir_cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_salir_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir_cliente.ForeColor = System.Drawing.Color.White;
            this.Btn_salir_cliente.Image = global::SisBanca.Properties.Resources.cerrar_sesion;
            this.Btn_salir_cliente.Location = new System.Drawing.Point(459, 618);
            this.Btn_salir_cliente.Name = "Btn_salir_cliente";
            this.Btn_salir_cliente.Size = new System.Drawing.Size(100, 74);
            this.Btn_salir_cliente.TabIndex = 46;
            this.Btn_salir_cliente.Text = "Salir";
            this.Btn_salir_cliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_salir_cliente.UseVisualStyleBackColor = false;
            this.Btn_salir_cliente.Click += new System.EventHandler(this.Btn_salir_cliente_Click);
            // 
            // Btn_reporte
            // 
            this.Btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_reporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_reporte.ForeColor = System.Drawing.Color.White;
            this.Btn_reporte.Image = global::SisBanca.Properties.Resources.reporte;
            this.Btn_reporte.Location = new System.Drawing.Point(351, 618);
            this.Btn_reporte.Name = "Btn_reporte";
            this.Btn_reporte.Size = new System.Drawing.Size(100, 74);
            this.Btn_reporte.TabIndex = 45;
            this.Btn_reporte.Text = "Reporte";
            this.Btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_reporte.UseVisualStyleBackColor = false;
            this.Btn_reporte.Click += new System.EventHandler(this.Btn_reporte_Click);
            // 
            // Btn_eliminar
            // 
            this.Btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_eliminar.ForeColor = System.Drawing.Color.White;
            this.Btn_eliminar.Image = global::SisBanca.Properties.Resources.borrar;
            this.Btn_eliminar.Location = new System.Drawing.Point(243, 618);
            this.Btn_eliminar.Name = "Btn_eliminar";
            this.Btn_eliminar.Size = new System.Drawing.Size(100, 74);
            this.Btn_eliminar.TabIndex = 44;
            this.Btn_eliminar.Text = "Eliminar";
            this.Btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_eliminar.UseVisualStyleBackColor = false;
            this.Btn_eliminar.Click += new System.EventHandler(this.Btn_eliminar_Click);
            // 
            // Btn_actualizar
            // 
            this.Btn_actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_actualizar.ForeColor = System.Drawing.Color.White;
            this.Btn_actualizar.Image = global::SisBanca.Properties.Resources.actualizar;
            this.Btn_actualizar.Location = new System.Drawing.Point(135, 618);
            this.Btn_actualizar.Name = "Btn_actualizar";
            this.Btn_actualizar.Size = new System.Drawing.Size(100, 74);
            this.Btn_actualizar.TabIndex = 43;
            this.Btn_actualizar.Text = "Actualizar";
            this.Btn_actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_actualizar.UseVisualStyleBackColor = false;
            this.Btn_actualizar.Click += new System.EventHandler(this.Btn_actualizar_Click);
            // 
            // Btn_nuevo
            // 
            this.Btn_nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_nuevo.ForeColor = System.Drawing.Color.White;
            this.Btn_nuevo.Image = global::SisBanca.Properties.Resources.agregar_carpeta;
            this.Btn_nuevo.Location = new System.Drawing.Point(27, 618);
            this.Btn_nuevo.Name = "Btn_nuevo";
            this.Btn_nuevo.Size = new System.Drawing.Size(100, 74);
            this.Btn_nuevo.TabIndex = 42;
            this.Btn_nuevo.Text = "Nuevo";
            this.Btn_nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_nuevo.UseVisualStyleBackColor = false;
            this.Btn_nuevo.Click += new System.EventHandler(this.Btn_nuevo_Click);
            // 
            // Tbc_principal
            // 
            this.Tbc_principal.Controls.Add(this.tabPage1);
            this.Tbc_principal.Controls.Add(this.tabPage2);
            this.Tbc_principal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tbc_principal.Location = new System.Drawing.Point(16, 74);
            this.Tbc_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Tbc_principal.Name = "Tbc_principal";
            this.Tbc_principal.SelectedIndex = 0;
            this.Tbc_principal.Size = new System.Drawing.Size(1751, 541);
            this.Tbc_principal.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_recuperar);
            this.tabPage1.Controls.Add(this.btn_verEliminados);
            this.tabPage1.Controls.Add(this.Dgv_principal);
            this.tabPage1.Controls.Add(this.Btn_buscar);
            this.tabPage1.Controls.Add(this.Txt_buscar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1743, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_recuperar
            // 
            this.btn_recuperar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_recuperar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_recuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recuperar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_recuperar.Image = ((System.Drawing.Image)(resources.GetObject("btn_recuperar.Image")));
            this.btn_recuperar.Location = new System.Drawing.Point(1587, 11);
            this.btn_recuperar.Name = "btn_recuperar";
            this.btn_recuperar.Size = new System.Drawing.Size(57, 46);
            this.btn_recuperar.TabIndex = 50;
            this.btn_recuperar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_recuperar.UseVisualStyleBackColor = false;
            this.btn_recuperar.Click += new System.EventHandler(this.btn_recuperar_Click);
            // 
            // btn_verEliminados
            // 
            this.btn_verEliminados.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_verEliminados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_verEliminados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verEliminados.ForeColor = System.Drawing.Color.Transparent;
            this.btn_verEliminados.Image = global::SisBanca.Properties.Resources.idea_32;
            this.btn_verEliminados.Location = new System.Drawing.Point(1659, 11);
            this.btn_verEliminados.Name = "btn_verEliminados";
            this.btn_verEliminados.Size = new System.Drawing.Size(57, 46);
            this.btn_verEliminados.TabIndex = 49;
            this.btn_verEliminados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_verEliminados.UseVisualStyleBackColor = false;
            this.btn_verEliminados.Click += new System.EventHandler(this.btn_verEliminados_Click);
            // 
            // Dgv_principal
            // 
            this.Dgv_principal.AllowUserToAddRows = false;
            this.Dgv_principal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Menu;
            this.Dgv_principal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv_principal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_principal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_principal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_principal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv_principal.ColumnHeadersHeight = 35;
            this.Dgv_principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_principal.EnableHeadersVisualStyles = false;
            this.Dgv_principal.Location = new System.Drawing.Point(11, 67);
            this.Dgv_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_principal.Name = "Dgv_principal";
            this.Dgv_principal.ReadOnly = true;
            this.Dgv_principal.RowHeadersWidth = 51;
            this.Dgv_principal.Size = new System.Drawing.Size(1724, 437);
            this.Dgv_principal.TabIndex = 5;
            this.Dgv_principal.DoubleClick += new System.EventHandler(this.Dgv_principal_DoubleClick_1);
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.ForeColor = System.Drawing.Color.White;
            this.Btn_buscar.Location = new System.Drawing.Point(419, 23);
            this.Btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_buscar.Name = "Btn_buscar";
            this.Btn_buscar.Size = new System.Drawing.Size(100, 28);
            this.Btn_buscar.TabIndex = 2;
            this.Btn_buscar.Text = "Buscar";
            this.Btn_buscar.UseVisualStyleBackColor = false;
            this.Btn_buscar.Click += new System.EventHandler(this.Btn_buscar_Click);
            // 
            // Txt_buscar
            // 
            this.Txt_buscar.Location = new System.Drawing.Point(84, 26);
            this.Txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(327, 22);
            this.Txt_buscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Pnl_tipoCuenta);
            this.tabPage2.Controls.Add(this.Pnl_tipoCliente);
            this.tabPage2.Controls.Add(this.Btn_lupaCliente);
            this.tabPage2.Controls.Add(this.Txt_saldo);
            this.tabPage2.Controls.Add(this.Btn_retornar);
            this.tabPage2.Controls.Add(this.Btn_guardar);
            this.tabPage2.Controls.Add(this.Btn_cancelar);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.Txt_tipoCuenta);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Txt_cliente);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.Btn_lupaCuenta);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1743, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Pnl_tipoCuenta
            // 
            this.Pnl_tipoCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(104)))), ((int)(((byte)(137)))));
            this.Pnl_tipoCuenta.Controls.Add(this.button1);
            this.Pnl_tipoCuenta.Controls.Add(this.label5);
            this.Pnl_tipoCuenta.Controls.Add(this.Dgv_tipoCuentas);
            this.Pnl_tipoCuenta.Location = new System.Drawing.Point(1018, 30);
            this.Pnl_tipoCuenta.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_tipoCuenta.Name = "Pnl_tipoCuenta";
            this.Pnl_tipoCuenta.Size = new System.Drawing.Size(333, 207);
            this.Pnl_tipoCuenta.TabIndex = 54;
            this.Pnl_tipoCuenta.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::SisBanca.Properties.Resources.deshacer;
            this.button1.Location = new System.Drawing.Point(276, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 53;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "TIPOS DE CUENTAS";
            // 
            // Dgv_tipoCuentas
            // 
            this.Dgv_tipoCuentas.AllowUserToAddRows = false;
            this.Dgv_tipoCuentas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Menu;
            this.Dgv_tipoCuentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Dgv_tipoCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_tipoCuentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_tipoCuentas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_tipoCuentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_tipoCuentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.Dgv_tipoCuentas.ColumnHeadersHeight = 35;
            this.Dgv_tipoCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_tipoCuentas.EnableHeadersVisualStyles = false;
            this.Dgv_tipoCuentas.Location = new System.Drawing.Point(9, 36);
            this.Dgv_tipoCuentas.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_tipoCuentas.Name = "Dgv_tipoCuentas";
            this.Dgv_tipoCuentas.ReadOnly = true;
            this.Dgv_tipoCuentas.RowHeadersWidth = 51;
            this.Dgv_tipoCuentas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Dgv_tipoCuentas.Size = new System.Drawing.Size(312, 160);
            this.Dgv_tipoCuentas.TabIndex = 20;
            this.Dgv_tipoCuentas.DoubleClick += new System.EventHandler(this.Dgv_tipoCuentas_DoubleClick);
            // 
            // Pnl_tipoCliente
            // 
            this.Pnl_tipoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(104)))), ((int)(((byte)(137)))));
            this.Pnl_tipoCliente.Controls.Add(this.Btn_retorno);
            this.Pnl_tipoCliente.Controls.Add(this.label8);
            this.Pnl_tipoCliente.Controls.Add(this.Dgv_personas);
            this.Pnl_tipoCliente.Location = new System.Drawing.Point(510, 256);
            this.Pnl_tipoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_tipoCliente.Name = "Pnl_tipoCliente";
            this.Pnl_tipoCliente.Size = new System.Drawing.Size(670, 207);
            this.Pnl_tipoCliente.TabIndex = 18;
            this.Pnl_tipoCliente.Visible = false;
            // 
            // Btn_retorno
            // 
            this.Btn_retorno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retorno.Image = global::SisBanca.Properties.Resources.deshacer;
            this.Btn_retorno.Location = new System.Drawing.Point(615, 5);
            this.Btn_retorno.Name = "Btn_retorno";
            this.Btn_retorno.Size = new System.Drawing.Size(45, 28);
            this.Btn_retorno.TabIndex = 53;
            this.Btn_retorno.UseVisualStyleBackColor = true;
            this.Btn_retorno.Click += new System.EventHandler(this.Btn_retorno_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "LISTA DE CLIENTES";
            // 
            // Dgv_personas
            // 
            this.Dgv_personas.AllowUserToAddRows = false;
            this.Dgv_personas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Menu;
            this.Dgv_personas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.Dgv_personas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_personas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_personas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_personas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_personas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Dgv_personas.ColumnHeadersHeight = 35;
            this.Dgv_personas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_personas.EnableHeadersVisualStyles = false;
            this.Dgv_personas.Location = new System.Drawing.Point(9, 36);
            this.Dgv_personas.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_personas.Name = "Dgv_personas";
            this.Dgv_personas.ReadOnly = true;
            this.Dgv_personas.RowHeadersWidth = 51;
            this.Dgv_personas.Size = new System.Drawing.Size(651, 160);
            this.Dgv_personas.TabIndex = 20;
            this.Dgv_personas.DoubleClick += new System.EventHandler(this.Dgv_personas_DoubleClick);
            // 
            // Btn_lupaCliente
            // 
            this.Btn_lupaCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_lupaCliente.Image = global::SisBanca.Properties.Resources.lupa_3d;
            this.Btn_lupaCliente.Location = new System.Drawing.Point(458, 133);
            this.Btn_lupaCliente.Name = "Btn_lupaCliente";
            this.Btn_lupaCliente.Size = new System.Drawing.Size(50, 37);
            this.Btn_lupaCliente.TabIndex = 55;
            this.Btn_lupaCliente.UseVisualStyleBackColor = true;
            this.Btn_lupaCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // Txt_saldo
            // 
            this.Txt_saldo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_saldo.Location = new System.Drawing.Point(173, 232);
            this.Txt_saldo.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_saldo.MaxLength = 150;
            this.Txt_saldo.Name = "Txt_saldo";
            this.Txt_saldo.ReadOnly = true;
            this.Txt_saldo.Size = new System.Drawing.Size(274, 22);
            this.Txt_saldo.TabIndex = 46;
            // 
            // Btn_retornar
            // 
            this.Btn_retornar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_retornar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar.ForeColor = System.Drawing.Color.White;
            this.Btn_retornar.Location = new System.Drawing.Point(368, 325);
            this.Btn_retornar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_retornar.Name = "Btn_retornar";
            this.Btn_retornar.Size = new System.Drawing.Size(101, 32);
            this.Btn_retornar.TabIndex = 15;
            this.Btn_retornar.Text = "Retornar";
            this.Btn_retornar.UseVisualStyleBackColor = false;
            this.Btn_retornar.Visible = false;
            this.Btn_retornar.Click += new System.EventHandler(this.Btn_retornar_Click);
            // 
            // Btn_guardar
            // 
            this.Btn_guardar.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_guardar.ForeColor = System.Drawing.Color.White;
            this.Btn_guardar.Location = new System.Drawing.Point(253, 324);
            this.Btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_guardar.Name = "Btn_guardar";
            this.Btn_guardar.Size = new System.Drawing.Size(101, 32);
            this.Btn_guardar.TabIndex = 14;
            this.Btn_guardar.Text = "Guardar";
            this.Btn_guardar.UseVisualStyleBackColor = false;
            this.Btn_guardar.Visible = false;
            this.Btn_guardar.Click += new System.EventHandler(this.Btn_guardar_Click);
            // 
            // Btn_cancelar
            // 
            this.Btn_cancelar.BackColor = System.Drawing.Color.LightCoral;
            this.Btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.Btn_cancelar.Location = new System.Drawing.Point(138, 324);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(101, 32);
            this.Btn_cancelar.TabIndex = 13;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Visible = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "$ Saldo Actual: (*)";
            // 
            // Txt_tipoCuenta
            // 
            this.Txt_tipoCuenta.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_tipoCuenta.Location = new System.Drawing.Point(173, 66);
            this.Txt_tipoCuenta.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_tipoCuenta.Name = "Txt_tipoCuenta";
            this.Txt_tipoCuenta.ReadOnly = true;
            this.Txt_tipoCuenta.Size = new System.Drawing.Size(276, 22);
            this.Txt_tipoCuenta.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Cuenta: (*)";
            // 
            // Txt_cliente
            // 
            this.Txt_cliente.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_cliente.Location = new System.Drawing.Point(173, 140);
            this.Txt_cliente.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_cliente.MaxLength = 20;
            this.Txt_cliente.Name = "Txt_cliente";
            this.Txt_cliente.ReadOnly = true;
            this.Txt_cliente.Size = new System.Drawing.Size(276, 22);
            this.Txt_cliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente: (*)";
            // 
            // Btn_lupaCuenta
            // 
            this.Btn_lupaCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_lupaCuenta.Image = global::SisBanca.Properties.Resources.lupa_3d;
            this.Btn_lupaCuenta.Location = new System.Drawing.Point(458, 64);
            this.Btn_lupaCuenta.Name = "Btn_lupaCuenta";
            this.Btn_lupaCuenta.Size = new System.Drawing.Size(50, 37);
            this.Btn_lupaCuenta.TabIndex = 52;
            this.Btn_lupaCuenta.UseVisualStyleBackColor = true;
            this.Btn_lupaCuenta.Click += new System.EventHandler(this.Btn_lupa_Click);
            // 
            // Frm_Cuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1780, 709);
            this.Controls.Add(this.pnl_titulo_form);
            this.Controls.Add(this.Btn_salir_cliente);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Tbc_principal);
            this.Name = "Frm_Cuentas";
            this.Load += new System.EventHandler(this.Frm_Cuentas_Load);
            this.pnl_titulo_form.ResumeLayout(false);
            this.pnl_titulo_form.PerformLayout();
            this.Tbc_principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.Pnl_tipoCuenta.ResumeLayout(false);
            this.Pnl_tipoCuenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_tipoCuentas)).EndInit();
            this.Pnl_tipoCliente.ResumeLayout(false);
            this.Pnl_tipoCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_personas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo_form;
        private System.Windows.Forms.Label lbl_cuentas;
        private System.Windows.Forms.Button Btn_salir_cliente;
        private System.Windows.Forms.TabControl Tbc_principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel Pnl_tipoCliente;
        private System.Windows.Forms.Button Btn_retorno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView Dgv_personas;
        private System.Windows.Forms.TextBox Txt_saldo;
        private System.Windows.Forms.Button Btn_retornar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_tipoCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_lupaCuenta;
        private System.Windows.Forms.Panel Pnl_tipoCuenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView Dgv_tipoCuentas;
        private System.Windows.Forms.Button Btn_lupaCliente;
        private System.Windows.Forms.DataGridView Dgv_principal;
        public System.Windows.Forms.Button Btn_reporte;
        public System.Windows.Forms.Button Btn_eliminar;
        public System.Windows.Forms.Button Btn_actualizar;
        public System.Windows.Forms.Button Btn_nuevo;
        public System.Windows.Forms.Button btn_recuperar;
        public System.Windows.Forms.Button btn_verEliminados;
    }
}