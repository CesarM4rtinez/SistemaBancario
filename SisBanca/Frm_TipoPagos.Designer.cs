namespace SisBanca
{
    partial class Frm_TipoPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TipoPagos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_titulo_form = new System.Windows.Forms.Panel();
            this.lbl_tipoPago = new System.Windows.Forms.Label();
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
            this.Btn_retornar = new System.Windows.Forms.Button();
            this.Btn_guardar = new System.Windows.Forms.Button();
            this.Btn_cancelar = new System.Windows.Forms.Button();
            this.Txt_tipoPago = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_titulo_form.SuspendLayout();
            this.Tbc_principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_titulo_form
            // 
            this.pnl_titulo_form.BackColor = System.Drawing.Color.Tomato;
            this.pnl_titulo_form.Controls.Add(this.lbl_tipoPago);
            this.pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo_form.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_titulo_form.Name = "pnl_titulo_form";
            this.pnl_titulo_form.Size = new System.Drawing.Size(1021, 44);
            this.pnl_titulo_form.TabIndex = 41;
            // 
            // lbl_tipoPago
            // 
            this.lbl_tipoPago.AutoSize = true;
            this.lbl_tipoPago.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipoPago.ForeColor = System.Drawing.Color.White;
            this.lbl_tipoPago.Location = new System.Drawing.Point(8, 11);
            this.lbl_tipoPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tipoPago.Name = "lbl_tipoPago";
            this.lbl_tipoPago.Size = new System.Drawing.Size(192, 25);
            this.lbl_tipoPago.TabIndex = 0;
            this.lbl_tipoPago.Text = "TIPOS DE PAGO";
            // 
            // Btn_salir_cliente
            // 
            this.Btn_salir_cliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(168)))));
            this.Btn_salir_cliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_salir_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_salir_cliente.ForeColor = System.Drawing.Color.White;
            this.Btn_salir_cliente.Image = global::SisBanca.Properties.Resources.cerrar_sesion;
            this.Btn_salir_cliente.Location = new System.Drawing.Point(457, 404);
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
            this.Btn_reporte.Location = new System.Drawing.Point(349, 404);
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
            this.Btn_eliminar.Location = new System.Drawing.Point(241, 404);
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
            this.Btn_actualizar.Location = new System.Drawing.Point(133, 404);
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
            this.Btn_nuevo.Location = new System.Drawing.Point(25, 404);
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
            this.Tbc_principal.Size = new System.Drawing.Size(987, 320);
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
            this.tabPage1.Size = new System.Drawing.Size(979, 291);
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
            this.btn_recuperar.Location = new System.Drawing.Point(824, 16);
            this.btn_recuperar.Name = "btn_recuperar";
            this.btn_recuperar.Size = new System.Drawing.Size(57, 46);
            this.btn_recuperar.TabIndex = 54;
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
            this.btn_verEliminados.Location = new System.Drawing.Point(896, 16);
            this.btn_verEliminados.Name = "btn_verEliminados";
            this.btn_verEliminados.Size = new System.Drawing.Size(57, 46);
            this.btn_verEliminados.TabIndex = 53;
            this.btn_verEliminados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_verEliminados.UseVisualStyleBackColor = false;
            this.btn_verEliminados.Click += new System.EventHandler(this.btn_verEliminados_Click);
            // 
            // Dgv_principal
            // 
            this.Dgv_principal.AllowUserToAddRows = false;
            this.Dgv_principal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Menu;
            this.Dgv_principal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_principal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_principal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_principal.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_principal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(44)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_principal.ColumnHeadersHeight = 35;
            this.Dgv_principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_principal.EnableHeadersVisualStyles = false;
            this.Dgv_principal.Location = new System.Drawing.Point(11, 72);
            this.Dgv_principal.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_principal.Name = "Dgv_principal";
            this.Dgv_principal.ReadOnly = true;
            this.Dgv_principal.RowHeadersWidth = 51;
            this.Dgv_principal.Size = new System.Drawing.Size(960, 211);
            this.Dgv_principal.TabIndex = 4;
            this.Dgv_principal.DoubleClick += new System.EventHandler(this.Dgv_principal_DoubleClick_1);
            // 
            // Btn_buscar
            // 
            this.Btn_buscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_buscar.ForeColor = System.Drawing.Color.White;
            this.Btn_buscar.Location = new System.Drawing.Point(421, 23);
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
            this.Txt_buscar.Location = new System.Drawing.Point(86, 26);
            this.Txt_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_buscar.Name = "Txt_buscar";
            this.Txt_buscar.Size = new System.Drawing.Size(327, 22);
            this.Txt_buscar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Btn_retornar);
            this.tabPage2.Controls.Add(this.Btn_guardar);
            this.tabPage2.Controls.Add(this.Btn_cancelar);
            this.tabPage2.Controls.Add(this.Txt_tipoPago);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(979, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Btn_retornar
            // 
            this.Btn_retornar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_retornar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar.ForeColor = System.Drawing.Color.White;
            this.Btn_retornar.Location = new System.Drawing.Point(392, 158);
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
            this.Btn_guardar.Location = new System.Drawing.Point(277, 157);
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
            this.Btn_cancelar.Location = new System.Drawing.Point(162, 157);
            this.Btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_cancelar.Name = "Btn_cancelar";
            this.Btn_cancelar.Size = new System.Drawing.Size(101, 32);
            this.Btn_cancelar.TabIndex = 13;
            this.Btn_cancelar.Text = "Cancelar";
            this.Btn_cancelar.UseVisualStyleBackColor = false;
            this.Btn_cancelar.Visible = false;
            this.Btn_cancelar.Click += new System.EventHandler(this.Btn_cancelar_Click);
            // 
            // Txt_tipoPago
            // 
            this.Txt_tipoPago.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt_tipoPago.Location = new System.Drawing.Point(196, 78);
            this.Txt_tipoPago.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_tipoPago.Name = "Txt_tipoPago";
            this.Txt_tipoPago.ReadOnly = true;
            this.Txt_tipoPago.Size = new System.Drawing.Size(276, 22);
            this.Txt_tipoPago.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre del Prestamo: (*)";
            // 
            // Frm_TipoPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 490);
            this.Controls.Add(this.pnl_titulo_form);
            this.Controls.Add(this.Btn_salir_cliente);
            this.Controls.Add(this.Btn_reporte);
            this.Controls.Add(this.Btn_eliminar);
            this.Controls.Add(this.Btn_actualizar);
            this.Controls.Add(this.Btn_nuevo);
            this.Controls.Add(this.Tbc_principal);
            this.Name = "Frm_TipoPagos";
            this.Load += new System.EventHandler(this.Frm_TipoPagos_Load);
            this.pnl_titulo_form.ResumeLayout(false);
            this.pnl_titulo_form.PerformLayout();
            this.Tbc_principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_principal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo_form;
        private System.Windows.Forms.Label lbl_tipoPago;
        private System.Windows.Forms.Button Btn_salir_cliente;
        private System.Windows.Forms.Button Btn_reporte;
        private System.Windows.Forms.Button Btn_eliminar;
        private System.Windows.Forms.Button Btn_actualizar;
        private System.Windows.Forms.Button Btn_nuevo;
        private System.Windows.Forms.TabControl Tbc_principal;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Btn_retornar;
        private System.Windows.Forms.Button Btn_guardar;
        private System.Windows.Forms.Button Btn_cancelar;
        private System.Windows.Forms.TextBox Txt_tipoPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Btn_buscar;
        private System.Windows.Forms.TextBox Txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgv_principal;
        public System.Windows.Forms.Button btn_recuperar;
        public System.Windows.Forms.Button btn_verEliminados;
    }
}