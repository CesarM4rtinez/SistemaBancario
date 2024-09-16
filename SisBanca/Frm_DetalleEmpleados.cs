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
    public partial class Frm_DetalleEmpleados : Form
    {
        public Frm_DetalleEmpleados()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Estado_restaurar(false);
            lbl_empleados.Text = "EMPLEADOS";
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        int ID_EM = 0;
        int ID_USER = 0;
        int ID_CARGO_EM = 0;
        int ID_SUCURSAL = 0;
        int Estadoguarda = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_nomEmpleado.ReadOnly  = !lestado;
            Txt_apellidoPate.ReadOnly = !lestado;
            Txt_apellidoMate.ReadOnly = !lestado;
            Txt_direccion.ReadOnly    = !lestado;
            Txt_DNI.ReadOnly          = !lestado;
            Txt_sueldo.ReadOnly       = !lestado;
        }

        private void Formato_empleadoGeneral()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Visible = false;
            Dgv_principal.Columns[2].Visible = false;
            Dgv_principal.Columns[3].Visible = false;

            Dgv_principal.Columns[4].Width = 150;
            Dgv_principal.Columns[4].HeaderText = "REGISTRO";
            Dgv_principal.Columns[5].Width = 120;
            Dgv_principal.Columns[5].HeaderText = "NOMBRE";
            Dgv_principal.Columns[6].Width = 120;
            Dgv_principal.Columns[6].HeaderText = "1° APELLIDO";
            Dgv_principal.Columns[7].Width = 120;
            Dgv_principal.Columns[7].HeaderText = "2° APELLIDO";

            Dgv_principal.Columns[8].Width = 100;
            Dgv_principal.Columns[8].HeaderText = "DIRECCION";
            Dgv_principal.Columns[9].Width = 80;
            Dgv_principal.Columns[9].HeaderText = "DNI";
            Dgv_principal.Columns[10].Width = 80;
            Dgv_principal.Columns[10].HeaderText = "SUELDO";

            Dgv_principal.Columns[11].Width = 150;
            Dgv_principal.Columns[11].HeaderText = "CARGO";
            Dgv_principal.Columns[12].Width = 100;
            Dgv_principal.Columns[12].HeaderText = "USUARIO";
            Dgv_principal.Columns[13].Width = 200;
            Dgv_principal.Columns[13].HeaderText = "SUCURSAL";
        }

        private void Listado_empleadoGeneral(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Empleado.ListadoEmpleadoGeneral(cTexto);
                this.Formato_empleadoGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_texto()
        {
            Txt_usuario.Text = "";
            Txt_nomEmpleado.Text = "";
            Txt_DNI.Text = "";
            Txt_direccion.Text = "";
            Txt_cargo.Text = "";
            Txt_apellidoPate.Text = "";
            Txt_apellidoMate.Text = "";
            Txt_sueldo.Text = "";
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_EM"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_EM = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_EM"].Value);
                this.ID_CARGO_EM = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CARGO_EM"].Value);
                this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                this.ID_SUCURSAL = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);

                Txt_nomEmpleado.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_EMPLEADO"].Value);
                Txt_apellidoPate.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE"].Value);
                Txt_apellidoMate.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE"].Value);
                Txt_direccion.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DIRECCION"].Value);

                Txt_DNI.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DNI_EM"].Value);
                Txt_sueldo.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["SUELDO"].Value);
                Txt_cargo.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CARGO"].Value);
                Txt_usuario.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["USUARIO"].Value);
                Txt_sucursal.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DIRECCION"].Value);
            }
        }

        private void FormatoEmpleado_Cargo()
        {
            Dgv_cargo.Columns[0].Visible = false;
            Dgv_cargo.Columns[1].Width = 60;
            Dgv_cargo.Columns[1].HeaderText = "CARGO";
        }

        private void ListadoEmpleado_Cargo()
        {
            try
            {
                Dgv_cargo.DataSource = N_Empleado.empleadoCargo();
                this.FormatoEmpleado_Cargo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoEmpleado_Usuario()
        {
            Dgv_usuarios.Columns[0].Visible = false;
            Dgv_usuarios.Columns[1].Width = 60;
            Dgv_usuarios.Columns[1].HeaderText = "USUARIO";
        }

        private void ListadoEmpleado_Usuario()
        {
            try
            {
                Dgv_usuarios.DataSource = N_Empleado.empleadoUsuario();
                this.FormatoEmpleado_Usuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoEmpleado_Sucursal()
        {
            Dgv_sucursal.Columns[0].Visible = false;
            Dgv_sucursal.Columns[1].Width = 60;
            Dgv_sucursal.Columns[1].HeaderText = "SUCURSAL";
        }

        private void ListadoEmpleado_Sucursal()
        {
            try
            {
                Dgv_sucursal.DataSource = N_Empleado.empleadoSucursal();
                this.FormatoEmpleado_Sucursal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarEmpleado_Cargo()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_cargo.CurrentRow.Cells["ID_CARGO_EM"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CARGO_EM = Convert.ToInt32(Dgv_cargo.CurrentRow.Cells["ID_CARGO_EM"].Value);
                Txt_cargo.Text = Convert.ToString(Dgv_cargo.CurrentRow.Cells["NOM_CARGO"].Value);
            }
        }

        private void SeleccionarEmpleado_Usuario()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_usuarios.CurrentRow.Cells["ID_USER"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_USER = Convert.ToInt32(Dgv_usuarios.CurrentRow.Cells["ID_USER"].Value);
                Txt_usuario.Text = Convert.ToString(Dgv_usuarios.CurrentRow.Cells["USUARIO"].Value);
            }
        }

        private void SeleccionarEmpleado_sucursal()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_sucursal.CurrentRow.Cells["ID_SUCURSAL"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_SUCURSAL = Convert.ToInt32(Dgv_sucursal.CurrentRow.Cells["ID_SUCURSAL"].Value);
                Txt_sucursal.Text = Convert.ToString(Dgv_sucursal.CurrentRow.Cells["DIRECCION"].Value);
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;
            this.Estado_Botonesprincipales(false);
            this.Estado_restaurar(false);
            this.Estado_Botonesprocesos(true);
            this.Limpia_texto();
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_sueldo.Text = "0.00";
            lbl_empleados.Text = "EMPLEADOS";
            Txt_nomEmpleado.Focus();
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
            Txt_nomEmpleado.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_EM"].Value)))
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
                    this.ID_EM = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_EM"].Value);
                    Rpta = N_Empleado.Eliminar_empleado(this.ID_EM);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_empleadoGeneral("%");
                        this.Estado_restaurar(false);
                        this.ID_EM = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_empleadoGeneral(Txt_buscar.Text.Trim());
            this.Estado_restaurar(false);
            lbl_empleados.Text = "EMPLEADOS";
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_nomEmpleado.Text  == String.Empty ||
                Txt_apellidoPate.Text == String.Empty ||
                Txt_apellidoMate.Text == String.Empty ||
                Txt_direccion.Text    == String.Empty ||
                Txt_DNI.Text          == String.Empty ||
                Txt_sueldo.Text       == String.Empty ||
                Txt_cargo.Text        == String.Empty ||
                Txt_sucursal.Text     == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Empleado oCl = new E_Empleado();

                oCl.ID_EM        = this.ID_EM;
                oCl.ID_CARGO_EM  = this.ID_CARGO_EM;
                oCl.ID_USER      = this.ID_USER;
                oCl.ID_SUCURSAL  = this.ID_SUCURSAL;
                oCl.NOM_EMPLEADO = Txt_nomEmpleado.Text.Trim();
                oCl.APE_PATE     = Txt_apellidoPate.Text.Trim();
                oCl.APE_MATE     = Txt_apellidoMate.Text.Trim();
                oCl.DIRECCION    = Txt_direccion.Text.Trim();
                oCl.DNI_EM       = Txt_DNI.Text.Trim();
                oCl.SUELDO       = Convert.ToDecimal(Txt_sueldo.Text);

                Rpta = N_Empleado.Guardar_empleado(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_empleadoGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_EM = 0;
                    lbl_empleados.Text = "EMPLEADOS";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_EM = 0;
            this.ID_CARGO_EM = 0;
            this.ID_USER = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
            lbl_empleados.Text = "EMPLEADOS";
        }

        private void Btn_lupaCargo_Click(object sender, EventArgs e)
        {
            this.Pnl_cargos.Location = Btn_lupaCargo.Location;
            this.Pnl_cargos.Visible = true;
            this.Pnl_usuarios.Visible = false;
            this.Pnl_sucursal.Visible = false;
        }

        private void Btn_lupaUsuario_Click(object sender, EventArgs e)
        {
            this.Pnl_usuarios.Location = Btn_lupaUsuario.Location;
            this.Pnl_usuarios.Visible = true;
            this.Pnl_cargos.Visible = false;
            this.Pnl_sucursal.Visible = false;
        }

        private void Dgv_cargo_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarEmpleado_Cargo();
            Pnl_cargos.Visible = false;
            Txt_cargo.Focus();
        }

        private void Dgv_usuarios_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarEmpleado_Usuario();
            Pnl_usuarios.Visible = false;
            Txt_usuario.Focus();
        }

        private void Btn_retornoCargo_Click(object sender, EventArgs e)
        {
            Pnl_cargos.Visible = false;
        }

        private void Btn_retornoUsuario_Click(object sender, EventArgs e)
        {
            Pnl_usuarios.Visible = false;
        }


        private void Frm_DetalleEmpleados_Load(object sender, EventArgs e)
        {
            ListadoEmpleado_Cargo();
            ListadoEmpleado_Usuario();
            ListadoEmpleado_Sucursal();
            this.Estado_restaurar(false);
            Listado_empleadoGeneral(Txt_buscar.Text.Trim());
            lbl_empleados.Text = "EMPLEADOS";
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_retornoSucursal_Click(object sender, EventArgs e)
        {
            Pnl_sucursal.Visible = false;
        }

        private void Btn_buscarSucursal_Click(object sender, EventArgs e)
        {
            this.Pnl_sucursal.Location = Btn_lupaUsuario.Location;
            this.Pnl_sucursal.Visible = true;
            this.Pnl_cargos.Visible = false;
            this.Pnl_usuarios.Visible = false;
        }

        private void Dgv_sucursal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarEmpleado_sucursal();
            Pnl_sucursal.Visible = false;
            Txt_sucursal.Focus();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaEmpleados.ToString();
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
                filas += "<td>" + row.Cells["DNI_EM"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_EMPLEADO"].Value.ToString() + " " +
                         row.Cells["APE_PATE"].Value.ToString() + " " +
                         row.Cells["APE_MATE"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_CARGO"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SUELDO"].Value.ToString() + "</td>";
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
                    lbl_empleados.Text = "EMPLEADOS";
                    pdfDoc.Close();
                    stream.Close();

                    // Mostrar mensaje de validación
                    MessageBox.Show("El Reporte se ha generado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Listado_EmpleadosCaidos(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Empleado.Listado_EmpleadosCaidos(cTexto);
                this.Formato_empleadoGeneral();
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
            this.Listado_EmpleadosCaidos(Txt_buscar.Text.Trim());
            this.Estado_restaurar(true);
            lbl_empleados.Text = "EMPLEADOS ELIMINADOS";
        }

        private void btn_recuperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_EM"].Value)))
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
                    this.ID_EM = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_EM"].Value);
                    Rpta = N_Empleado.Levantar_empleadoCaido(this.ID_EM);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_EmpleadosCaidos("%");
                        this.ID_EM = 0;
                        MessageBox.Show("Registro Levantado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_empleados.Text = "EMPLEADOS";
                    }
                }
            }
        }
    }
}
