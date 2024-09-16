using Banco.Entidades;
using Banco.Negocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisBanca
{
    public partial class Frm_UsuarioSistema : Form
    {
        public Frm_UsuarioSistema()
        {
            InitializeComponent();
        }

        int ID_USER      = 0;
        int Estadoguarda = 0; //Sin ninguna acción

        private void Estado_texto(bool lestado)
        {
            Txt_contraseña.ReadOnly = !lestado;
            Txt_usuario.ReadOnly = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_contraseña.Text    = "";
;           Txt_usuario.Text       = "";
            Chk_admin.Checked     = false;
            Chk_cuentas.Checked   = false;
            Chk_prestamos.Checked = false;
            Chk_tarjetas.Checked  = false;
        }

        private void Formato_us()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Width = 120;
            Dgv_principal.Columns[1].HeaderText = "REGISTRO";
            Dgv_principal.Columns[2].Width = 90;
            Dgv_principal.Columns[2].HeaderText = "USUARIO";
            Dgv_principal.Columns[3].Width = 90;
            Dgv_principal.Columns[3].HeaderText = "CONTRASEÑA";
            Dgv_principal.Columns[4].Width = 80;
            Dgv_principal.Columns[4].HeaderText = "ADMIN";
            Dgv_principal.Columns[5].Width = 80;
            Dgv_principal.Columns[5].HeaderText = "PRESATMOS";
            Dgv_principal.Columns[6].Width = 80;
            Dgv_principal.Columns[6].HeaderText = "CUENTAS";
            Dgv_principal.Columns[7].Width = 100;
            Dgv_principal.Columns[7].HeaderText = "TARJETAS";
        }

        private void Listado_us(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Usuarios.Listado_us(cTexto);
                this.Formato_us();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_reporte.Enabled = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_USER"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                Txt_usuario.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["USUARIO"].Value);
                Txt_contraseña.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["CONTRASEÑA"].Value);
                Chk_admin.Checked = Convert.ToBoolean(Dgv_principal.CurrentRow.Cells["ADMIN"].Value);
                Chk_cuentas.Checked = Convert.ToBoolean(Dgv_principal.CurrentRow.Cells["CUENTAS"].Value);
                Chk_prestamos.Checked = Convert.ToBoolean(Dgv_principal.CurrentRow.Cells["PRESTAMOS"].Value);
                Chk_tarjetas.Checked = Convert.ToBoolean(Dgv_principal.CurrentRow.Cells["TARJETAS"].Value);
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
            this.Estado_restaurar(false);
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro
            this.Estado_Botonesprincipales(false);
            this.Estado_restaurar(false);
            this.Estado_Botonesprocesos(true);
            Txt_usuario.Text = "";
            Txt_usuario.ReadOnly = false;
            Txt_contraseña.Text = "";
            Txt_contraseña.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1;
            Txt_usuario.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_restaurar(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Chk_admin.Enabled = true;
            Chk_cuentas.Enabled = true;
            Chk_prestamos.Enabled = true;
            Chk_tarjetas.Enabled = true;
            Txt_usuario.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_USER"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                    Rpta = N_Usuarios.Eliminar_us(this.ID_USER);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_us("%");
                        this.Estado_restaurar(false);
                        this.ID_USER = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_us(Txt_buscar.Text.Trim());
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
            this.Estado_restaurar(false);
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_usuario.Text    == String.Empty ||
                Txt_contraseña.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Usuarios oCl = new E_Usuarios();

                oCl.ID_USER    = this.ID_USER;
                oCl.USUARIO    = Txt_usuario.Text.Trim();
                oCl.CONTRASEÑA = Txt_contraseña.Text.Trim();
                oCl.ADMIN      = Chk_admin.Checked;
                oCl.CUENTAS    = Chk_cuentas.Checked;
                oCl.PRESTAMOS  = Chk_prestamos.Checked;
                oCl.TARJETAS   = Chk_tarjetas.Checked;

                Rpta = N_Usuarios.Guardar_us(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_us("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);

                    Txt_usuario.Text = "";
                    Txt_contraseña.Text = "";
                    Chk_admin.Checked = false;
                    Chk_cuentas.Checked = false;
                    Chk_prestamos.Checked = false;
                    Chk_tarjetas.Checked = false;

                    Txt_usuario.ReadOnly = true;
                    Txt_contraseña.ReadOnly = true;
                    Chk_admin.Enabled = false;
                    Chk_cuentas.Enabled = false;
                    Chk_prestamos.Enabled = false;
                    Chk_tarjetas.Enabled = false;

                    Tbc_principal.SelectedIndex = 0;
                    this.ID_USER = 0;
                    lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_USER      = 0;
            this.Estadoguarda = 0;
            Chk_admin.Checked = false;
            Chk_cuentas.Checked = false;
            Chk_prestamos.Checked = false;
            Chk_tarjetas.Checked = false;

            Chk_admin.Enabled = false;
            Chk_cuentas.Enabled = false;
            Chk_prestamos.Enabled = false;
            Chk_tarjetas.Enabled = false;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Frm_UsuarioSistema_Load(object sender, EventArgs e)
        {
            Listado_us(Txt_buscar.Text.Trim());
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
            this.Estado_restaurar(false);
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaUsuarioSistema.ToString();
            // Generar valores aleatorios para el RUC y el Nro
            Random random = new Random();
            string ruc = random.Next(100000000, 999999999).ToString(); // RUC de 10 dígitos
            string nro = random.Next(100000, 999999).ToString(); // Nro de 6 dígitos

            // Reemplazar los marcadores de posición en el HTML
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@RUC", ruc);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NRO", nro);

            string filas = string.Empty;

            foreach (DataGridViewRow row in Dgv_principal.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["FECHA_REGISTRO"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["USUARIO"].Value.ToString()        + "</td>";
                filas += "<td>" + row.Cells["CONTRASEÑA"].Value.ToString()     + "</td>";
                filas += "<td>" + row.Cells["ADMIN"].Value.ToString()          + "</td>";
                filas += "<td>" + row.Cells["PRESTAMOS"].Value.ToString()      + "</td>";
                filas += "<td>" + row.Cells["CUENTAS"].Value.ToString()        + "</td>";
                filas += "<td>" + row.Cells["TARJETAS"].Value.ToString()       + "</td>";
                filas += "</tr>";
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    // Agregamos la imagen del banner al documento
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.visa_256, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);

                    // -----------------------------------------------------------------------
                    iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(Properties.Resources.BannerYT, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img2.ScaleToFit(140, 60);
                    img2.Alignment = iTextSharp.text.Image.UNDERLYING;

                    // Ajusta el valor en el eje X para mover la imagen más a la derecha
                    float offsetX = 203; // Puedes ajustar este valor según tus necesidades
                    img2.SetAbsolutePosition(pdfDoc.LeftMargin + offsetX, pdfDoc.Top - 84);
                    pdfDoc.Add(img2);

                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    this.Estado_restaurar(false);
                    pdfDoc.Close();
                    stream.Close();

                    // Mostrar mensaje de validación
                    MessageBox.Show("El Reporte se ha generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Listado_tipoUsuarioCaido(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Usuarios.Listado_tipoUsuarioCaido(cTexto);
                this.Formato_us();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_restaurar(bool lestado)
        {
            btn_recuperar.Enabled = lestado;
        }

        private void btn_verEliminados_Click(object sender, EventArgs e)
        {
            this.Listado_tipoUsuarioCaido(Txt_buscar.Text.Trim());
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA ELIMINADOS";
            this.Estado_restaurar(true);
        }

        private void btn_recuperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_USER"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de restablecer el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                    Rpta = N_Usuarios.Levantar_UsuarioCaido(this.ID_USER);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_tipoUsuarioCaido("%");
                        this.ID_USER = 0;
                        MessageBox.Show("Registro Levantado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
                    }
                }
            }
        }
    }
}
