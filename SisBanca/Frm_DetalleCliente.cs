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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisBanca
{
    public partial class Frm_DetalleCliente : Form
    {
        public Frm_DetalleCliente()
        {
            InitializeComponent();
        }

        int ID_CLIENTE    = 0;
        int ID_TP_PERSONA = 0;
        int Estadoguarda  = 0; //Sin ninguna acción

        private void Estado_texto(bool lestado)
        {   
            //Txt_tipo_persona.ReadOnly      = !lestado;
            Txt_nom_cliente.ReadOnly         = !lestado;
            Txt_nom_cliente.ReadOnly         = !lestado;
            Txt_ape_pate_cliente.ReadOnly    = !lestado;
            Txt_ape_mate_cliente.ReadOnly    = !lestado;
            Txt_direccion_cliente.ReadOnly   = !lestado;
            Txt_tel_cel_cliente.ReadOnly     = !lestado;
            Txt_tel_fijo_cliente.ReadOnly    = !lestado;
            Txt_DNI.ReadOnly                 = !lestado;
            Txt_cargo_cliente.ReadOnly       = !lestado;
            Txt_sueldo.ReadOnly              = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_tipo_persona.Text      = "";
            Txt_nom_cliente.Text       = "";
            Txt_ape_pate_cliente.Text  = "";
            Txt_ape_mate_cliente.Text  = "";
            Txt_direccion_cliente.Text = "";
            Txt_tel_cel_cliente.Text   = "";
            Txt_tel_fijo_cliente.Text  = "";
            Txt_DNI.Text               = "";
            Txt_cargo_cliente.Text     = "";
            Txt_sueldo.Text            = "";
        }

        private void Frm_DetalleCliente_Load(object sender, EventArgs e)
        {
            Listado_persona();
            this.Estado_restaurar(false);
            lbl_clientes.Text = "CLIENTES";
            Listado_cl(Txt_buscar.Text.Trim());
        }

        private void Formato_cl()
        {
            Dgv_principal.Columns[0].Visible     = false;
            Dgv_principal.Columns[1].Width       = 120;
            Dgv_principal.Columns[1].HeaderText  = "REGISTRO";
            Dgv_principal.Columns[2].Width       = 50;
            Dgv_principal.Columns[2].HeaderText  = "TIPO";
            Dgv_principal.Columns[3].Width       = 150;
            Dgv_principal.Columns[3].HeaderText  = "NOMBRE";
            Dgv_principal.Columns[4].Width       = 100;
            Dgv_principal.Columns[4].HeaderText  = "1° APELLIDO";
            Dgv_principal.Columns[5].Width       = 100;
            Dgv_principal.Columns[5].HeaderText  = "2° APELLIDO";
            Dgv_principal.Columns[6].Width       = 140;
            Dgv_principal.Columns[6].HeaderText  = "DIRECCIÓN";
            Dgv_principal.Columns[7].Width       = 90;
            Dgv_principal.Columns[7].HeaderText  = "MÓVIL";
            Dgv_principal.Columns[8].Width       = 90;
            Dgv_principal.Columns[8].HeaderText  = "FIJO";
            Dgv_principal.Columns[9].Width       = 80;
            Dgv_principal.Columns[9].HeaderText  = "DNI";
            Dgv_principal.Columns[10].Width      = 120;
            Dgv_principal.Columns[10].HeaderText = "CARGO";
            Dgv_principal.Columns[11].Width      = 80;
            Dgv_principal.Columns[11].HeaderText = "SUELDO";
            Dgv_principal.Columns[12].Visible    = false;
            Dgv_principal.Columns[13].Visible    = false;
        }

        private void Listado_cl(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Clientes.Listado_cl(cTexto);
                this.Formato_cl();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled         = lEstado;
            this.Btn_actualizar.Enabled    = lEstado;
            this.Btn_eliminar.Enabled      = lEstado;
            this.Btn_reporte.Enabled       = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CLIENTE            = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                this.ID_TP_PERSONA         = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PERSONA"].Value);
                Txt_tipo_persona.Text      = Convert.ToString(Dgv_principal.CurrentRow.Cells["TIPO_PERSONA"].Value);
                Txt_nom_cliente.Text       = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CLIENTE"].Value);
                Txt_ape_pate_cliente.Text  = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                Txt_ape_mate_cliente.Text  = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);
                Txt_direccion_cliente.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["DIRECCION_CLIENTE"].Value);
                Txt_tel_cel_cliente.Text   = Convert.ToString(Dgv_principal.CurrentRow.Cells["TEL_CEL_CLIENTE"].Value);
                Txt_tel_fijo_cliente.Text  = Convert.ToString(Dgv_principal.CurrentRow.Cells["TEL_FIJO_CLIENTE"].Value);
                Txt_DNI.Text               = Convert.ToString(Dgv_principal.CurrentRow.Cells["DNI"].Value);
                Txt_cargo_cliente.Text     = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CARGO_CLIENTE"].Value);
                Txt_sueldo.Text            = Convert.ToString(Dgv_principal.CurrentRow.Cells["SUELDO"].Value);
            }
        }

        private void Formato_TP_PERSONA()
        {
            Dgv_tipo_pers.Columns[1].Width = 200;
            Dgv_tipo_pers.Columns[1].HeaderText = "TIPO";
            Dgv_tipo_pers.Columns[0].Visible = false;
        }

        private void Listado_persona()
        {
            try
            {
                Dgv_tipo_pers.DataSource = N_Clientes.TIPO_PERSONA();
                this.Formato_TP_PERSONA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaPersona()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipo_pers.CurrentRow.Cells["ID_TP_PERSONA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TP_PERSONA = Convert.ToInt32(Dgv_tipo_pers.CurrentRow.Cells["ID_TP_PERSONA"].Value);
                Txt_tipo_persona.Text = Convert.ToString(Dgv_tipo_pers.CurrentRow.Cells["TIPO_PERSONA"].Value);
            }
        }

        private void Dgv_tipo_pers_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaPersona();
            Pnl_Tipo_personas.Visible = false;
            Txt_tipo_persona.Focus();
        }


        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_cl(Txt_buscar.Text.Trim());
            lbl_clientes.Text = "CLIENTES";
            this.Estado_restaurar(false);
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible  = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_lupa_Click(object sender, EventArgs e)
        {
            this.Pnl_Tipo_personas.Location = Btn_lupa.Location;
            this.Pnl_Tipo_personas.Visible  = true;
        }

        private void Btn_retorno_Click(object sender, EventArgs e)
        {
            Pnl_Tipo_personas.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Estado_restaurar(false);
            lbl_clientes.Text = "CLIENTES";
            Frm_Dashboard a =  new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;
            this.Estado_Botonesprincipales(false);
            this.Estado_restaurar(false);
            this.Estado_Botonesprocesos(true);
            this.Limpia_texto();
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_sueldo.Text = "0.00";
            lbl_clientes.Text = "CLIENTES";
            Txt_nom_cliente.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_TP_PERSONA = 0;
            this.ID_CLIENTE    = 0;
            this.Estadoguarda  = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
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
            Txt_nom_cliente.Focus();
        }
        
        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaClientes.ToString();
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
                filas += "<td>" + row.Cells["TIPO_PERSONA"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_CLIENTE"].Value.ToString()  + " " +
                         row.Cells["APE_PATE_CLIENTE"].Value.ToString()      + " " +
                         row.Cells["APE_MATE_CLIENTE"].Value.ToString()      + "</td>";
                filas += "<td>" + row.Cells["DNI"].Value.ToString()          + "</td>";
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

        private void Btn_guardar_Click_1(object sender, EventArgs e)
        {
            if (Txt_nom_cliente.Text       == String.Empty ||
                Txt_ape_pate_cliente.Text  == String.Empty ||
                Txt_ape_mate_cliente.Text  == String.Empty ||
                Txt_direccion_cliente.Text == String.Empty ||
                Txt_tel_cel_cliente.Text   == String.Empty ||
                Txt_tel_fijo_cliente.Text  == String.Empty ||
                Txt_DNI.Text               == String.Empty ||
                Txt_cargo_cliente.Text     == String.Empty ||
                Txt_sueldo.Text            == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Clientes oCl = new E_Clientes();

                oCl.ID_CLIENTE        = this.ID_CLIENTE;
                oCl.ID_TP_PERSONA     = this.ID_TP_PERSONA;
                oCl.NOM_CLIENTE       = Txt_nom_cliente.Text.Trim();
                oCl.APE_PATE_CLIENTE  = Txt_ape_pate_cliente.Text.Trim();
                oCl.APE_MATE_CLIENTE  = Txt_ape_mate_cliente.Text.Trim();
                oCl.DIRECCION_CLIENTE = Txt_direccion_cliente.Text.Trim();
                oCl.TEL_CEL_CLIENTE   = Txt_tel_cel_cliente.Text.Trim();
                oCl.TEL_FIJO_CLIENTE  = Txt_tel_fijo_cliente.Text.Trim();
                oCl.DNI               = Txt_DNI.Text.Trim();
                oCl.NOM_CARGO_CLIENTE = Txt_cargo_cliente.Text.Trim();
                oCl.SUELDO            = Convert.ToDecimal(Txt_sueldo.Text);

                Rpta = N_Clientes.Guardar_cl(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_cl("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_CLIENTE = 0;
                    lbl_clientes.Text = "CLIENTES";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value)))
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
                    this.ID_CLIENTE = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                    Rpta = N_Clientes.Eliminar_cl(this.ID_CLIENTE);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_cl("%");
                        this.Estado_restaurar(false);
                        this.ID_CLIENTE = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Listado_ClientesCaidos(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Clientes.Listado_ClientesCaidos(cTexto);
                this.Formato_cl();
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
            this.Listado_ClientesCaidos(Txt_buscar.Text.Trim());
            lbl_clientes.Text = "CLIENTES ELIMINADOS";
            this.Estado_restaurar(true);
        }

        private void btn_recuperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value)))
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
                    this.ID_CLIENTE = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                    Rpta = N_Clientes.Levantar_clienteCaido(this.ID_CLIENTE);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_ClientesCaidos("%");
                        this.ID_CLIENTE = 0;
                        MessageBox.Show("Registro Levantado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbl_clientes.Text = "CLIENTES";
                    }
                }
            }
        }
    }
}