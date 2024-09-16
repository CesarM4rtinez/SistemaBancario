using Banco.Datos;
using Banco.Entidades;
using Banco.Negocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisBanca
{
    public partial class Frm_MovimientoTarjeta : Form
    {
        public Frm_MovimientoTarjeta()
        {
            InitializeComponent();
        }

        int ID_MV_TARJETA      = 0;
        int ID_TARJETA_CREDITO = 0;
        int ID_CLIENTE         = 0;
        int ID_EM              = 0;
        int ID_SUCURSAL        = 0;
        int Estadoguarda       = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_montoSalida.ReadOnly = !lestado;
        }

        private void Formato_tarjetaGeneral()
        {
            Dgv_principal.Columns[0].Visible     = false;
            Dgv_principal.Columns[1].Visible     = false;
            Dgv_principal.Columns[2].Visible     = false;
            Dgv_principal.Columns[3].Visible     = false;
            Dgv_principal.Columns[4].Visible     = false;            
            Dgv_principal.Columns[5].Width       = 100;
            Dgv_principal.Columns[5].HeaderText  = "REGISTRO";
            Dgv_principal.Columns[6].Width       = 90;
            Dgv_principal.Columns[6].HeaderText  = "SALIDAS";
            Dgv_principal.Columns[7].Width       = 90;
            Dgv_principal.Columns[7].HeaderText  = "NOMBRE";
            Dgv_principal.Columns[8].Width       = 80;
            Dgv_principal.Columns[8].HeaderText  = "1° APELLIDO";
            Dgv_principal.Columns[9].Width       = 80;
            Dgv_principal.Columns[9].HeaderText  = "2° APELLIDO";
            Dgv_principal.Columns[10].Width      = 180;
            Dgv_principal.Columns[10].HeaderText = "SUCURSAL";
            Dgv_principal.Columns[11].Visible    = false;
            Dgv_principal.Columns[12].Visible    = false;
            Dgv_principal.Columns[13].Visible    = false;
            Dgv_principal.Columns[14].Visible    = false;
        }

        private void Listado_tarjetaGeneral(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_MovimientoTarjeta.ListadoMV_tarjetaGeneral(cTexto);
                this.Formato_tarjetaGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_texto()
        {
            Txt_cliente.Text     = "";
            Txt_empleado.Text    = "";
            Txt_sucursal.Text    = "";
            Txt_tarjeta.Text     = "";
            Txt_montoSalida.Text = "";
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_MV_TARJETA      = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value);
                this.ID_TARJETA_CREDITO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value);
                this.ID_CLIENTE         = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                this.ID_EM              = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_EM"].Value);
                this.ID_SUCURSAL        = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);


                Txt_tarjeta.Text       = Convert.ToString(Dgv_principal.CurrentRow.Cells["CODIGO_TARJETA"].Value);
                string nomCliente      = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente  = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente  = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text       = nomCliente + " " + apePateCliente + " " + apeMateCliente;

                string nomEmpleado     = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_EMPLEADO"].Value);
                string apePateEmpleado = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE"].Value);
                string apeMateEmpleado = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE"].Value);

                Txt_empleado.Text      = nomEmpleado + " " + apePateEmpleado + " " + apeMateEmpleado;

                Txt_sucursal.Text      = Convert.ToString(Dgv_principal.CurrentRow.Cells["SUCURSAL"].Value);
                Txt_montoSalida.Text   = Convert.ToString(Dgv_principal.CurrentRow.Cells["MONTO_SALIDA"].Value);
            }
        }

        private void FormatoMovimiento_Tarjeta()
        {
            Dgv_tarjetas.Columns[0].Visible    = false;
            Dgv_tarjetas.Columns[1].HeaderText = "NOMBRE";
            Dgv_tarjetas.Columns[2].Width      = 80;
            Dgv_tarjetas.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_tarjetas.Columns[3].Width      = 80;
            Dgv_tarjetas.Columns[3].HeaderText = "2° APELLIDO";
            Dgv_tarjetas.Columns[4].Visible    = false;
        }

        private void ListadoMovimiento_Tarjeta()
        {
            try
            {
                Dgv_tarjetas.DataSource = N_MovimientoTarjeta.MV_tarjetaTarjeta();
                this.FormatoMovimiento_Tarjeta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoMovimiento_Cliente()
        {
            Dgv_clientes.Columns[0].Visible = false;
            Dgv_clientes.Columns[1].Width = 120;
            Dgv_clientes.Columns[1].HeaderText = "NOMBRE";
            Dgv_clientes.Columns[2].Width = 80;
            Dgv_clientes.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_clientes.Columns[3].Width = 110;
            Dgv_clientes.Columns[3].HeaderText = "2° APELLIDO";
        }

        private void ListadoMovimiento_Cliente()
        {
            try
            {
                Dgv_clientes.DataSource = N_MovimientoTarjeta.MV_tarjetaCliente();
                this.FormatoMovimiento_Cliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoMovimiento_Empleado()
        {
            Dgv_empleados.Columns[0].Visible = false;
            Dgv_empleados.Columns[1].Width = 100;
            Dgv_empleados.Columns[1].HeaderText = "EMPLEADO";
            Dgv_empleados.Columns[2].Width = 80;
            Dgv_empleados.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_empleados.Columns[3].Width = 120;
            Dgv_empleados.Columns[3].HeaderText = "2° APELLIDO";
        }

        private void ListadoMovimiento_Empleado()
        {
            try
            {
                Dgv_empleados.DataSource = N_MovimientoTarjeta.MV_tarjetaEmpleado();
                this.FormatoMovimiento_Empleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoMovimiento_Sucursal()
        {
            Dgv_sucursal.Columns[0].Visible = false;
            Dgv_sucursal.Columns[1].Width = 100;
            Dgv_sucursal.Columns[1].HeaderText = "DIRECCION";
        }

        private void ListadoMovimiento_Sucursal()
        {
            try
            {
                Dgv_sucursal.DataSource = N_MovimientoTarjeta.MV_tarjetaSucursal();
                this.FormatoMovimiento_Sucursal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarMovimiento_Tarjeta()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tarjetas.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TARJETA_CREDITO = Convert.ToInt32(Dgv_tarjetas.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value);
                Txt_tarjeta.Text        = Convert.ToString(Dgv_tarjetas.CurrentRow.Cells["CODIGO_TARJETA"].Value);
            }
        }

        private void SeleccionarMovimiento_Cliente()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_clientes.CurrentRow.Cells["ID_CLIENTE"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CLIENTE       = Convert.ToInt32(Dgv_clientes.CurrentRow.Cells["ID_CLIENTE"].Value);
                string nomCliente     = Convert.ToString(Dgv_clientes.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_clientes.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_clientes.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;
            }
        }

        private void SeleccionarMovimiento_Empleado()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_empleados.CurrentRow.Cells["ID_EM"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_EM       = Convert.ToInt32(Dgv_empleados.CurrentRow.Cells["ID_EM"].Value);
                string nomEm     = Convert.ToString(Dgv_empleados.CurrentRow.Cells["NOM_EMPLEADO"].Value);
                string apePateEm = Convert.ToString(Dgv_empleados.CurrentRow.Cells["APE_PATE"].Value);
                string apeMateEm = Convert.ToString(Dgv_empleados.CurrentRow.Cells["APE_MATE"].Value);

                Txt_empleado.Text = nomEm + " " + apePateEm + " " + apeMateEm;
            }
        }

        private void SeleccionarMovimiento_Sucursal()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_sucursal.CurrentRow.Cells["ID_SUCURSAL"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_SUCURSAL  = Convert.ToInt32(Dgv_sucursal.CurrentRow.Cells["ID_SUCURSAL"].Value);
                Txt_sucursal.Text = Convert.ToString(Dgv_sucursal.CurrentRow.Cells["DIRECCION"].Value);
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible  = lEstado;
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
            Txt_montoSalida.Focus();
            Txt_montoSalida.Text = "0.00";
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
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
            Txt_montoSalida.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value)))
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
                    this.ID_MV_TARJETA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value);
                    Rpta = N_MovimientoTarjeta.Eliminar_MV_tarjeta(this.ID_MV_TARJETA);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_tarjetaGeneral("%");
                        this.Estado_restaurar(false);
                        this.ID_MV_TARJETA = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
            this.Estado_restaurar(false);
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_tarjetaGeneral(Txt_buscar.Text.Trim());
            this.Estado_restaurar(false);
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
            Txt_montoSalida.Focus();
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_MV_TARJETA = 0;
            this.ID_TARJETA_CREDITO = 0;
            this.ID_CLIENTE = 0;
            this.ID_EM = 0;
            this.ID_SUCURSAL = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_tarjeta.Text     == String.Empty ||
                Txt_cliente.Text     == String.Empty ||
                Txt_empleado.Text    == String.Empty ||
                Txt_sucursal.Text    == String.Empty ||
                Txt_montoSalida.Text == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else // Se procedería a registrar la información
            {
                string Rpta = "";
                E_MovimientoTarjeta oCl = new E_MovimientoTarjeta();

                oCl.ID_MV_TARJETA      = this.ID_MV_TARJETA;
                oCl.ID_TARJETA_CREDITO = this.ID_TARJETA_CREDITO;
                oCl.ID_CLIENTE         = this.ID_CLIENTE;
                oCl.ID_EM              = this.ID_EM;
                oCl.ID_SUCURSAL        = this.ID_SUCURSAL;
                oCl.MONTO_SALIDA       = Convert.ToDecimal(Txt_montoSalida.Text);

                Rpta = N_MovimientoTarjeta.Guardar_MV_tarjeta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tarjetaGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_MV_TARJETA = 0;
                    lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
                    lbl_tipoCliente2.Text = "";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_retornoTarjeta_Click(object sender, EventArgs e)
        {
            Pnl_tarjetas.Visible = false;
        }

        private void Btn_retornoSucursal_Click(object sender, EventArgs e)
        {
            Pnl_sucursales.Visible = false;
        }

        private void Btn_retornoEmpleado_Click(object sender, EventArgs e)
        {
            Pnl_empleados.Visible = false;
        }

        private void Btn_retornoCliente_Click(object sender, EventArgs e)
        {
            Pnl_clientes.Visible = false;
        }

        private void btn_buscarTarjeta_Click(object sender, EventArgs e)
        {
            this.Pnl_tarjetas.Location = btn_buscarTarjeta.Location;
            this.Pnl_tarjetas.Visible = true;
            this.Pnl_clientes.Visible = false;
            this.Pnl_empleados.Visible = false;
            this.Pnl_sucursales.Visible = false;
        }

        private void btn_buscarSucursal_Click(object sender, EventArgs e)
        {
            this.Pnl_sucursales.Location = btn_buscarSucursal.Location;
            this.Pnl_sucursales.Visible = true;
            this.Pnl_clientes.Visible = false;
            this.Pnl_empleados.Visible = false;
            this.Pnl_tarjetas.Visible = false;
        }

        private void btn_buscarEmpleado_Click(object sender, EventArgs e)
        {
            this.Pnl_empleados.Location = btn_buscarEmpleado.Location;
            this.Pnl_empleados.Visible = true;
            this.Pnl_clientes.Visible = false;
            this.Pnl_sucursales.Visible = false;
            this.Pnl_tarjetas.Visible = false;
        }

        private void btn_buscarCliente_Click(object sender, EventArgs e)
        {
            this.Pnl_clientes.Location = btn_buscarCliente.Location;
            this.Pnl_clientes.Visible = true;
            this.Pnl_empleados.Visible = false;
            this.Pnl_sucursales.Visible = false;
            this.Pnl_tarjetas.Visible = false;
        }

        private void Frm_MovimientoTarjeta_Load(object sender, EventArgs e)
        {
            ListadoMovimiento_Empleado();
            ListadoMovimiento_Cliente();
            ListadoMovimiento_Tarjeta();
            ListadoMovimiento_Sucursal();
            this.Estado_restaurar(false);
            Listado_tarjetaGeneral(Txt_buscar.Text.Trim());
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
        }

        private void Dgv_tarjetas_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Tarjeta();
            Pnl_tarjetas.Visible = false;
            Txt_tarjeta.Focus();
        }

        private void Dgv_sucursal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Sucursal();
            Pnl_sucursales.Visible = false;
            Txt_sucursal.Focus();
        }

        private void Dgv_empleados_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Empleado();
            Pnl_empleados.Visible = false;
            Txt_empleado.Focus();
        }

        private void Dgv_clientes_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Cliente();
            Pnl_clientes.Visible = false;
            Txt_cliente.Focus();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaMovimientoTarjeta.ToString();
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
                filas += "<td>" + row.Cells["SUCURSAL"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NOM_CLIENTE"].Value.ToString() + " " +
                         row.Cells["APE_PATE_CLIENTE"].Value.ToString() + " " +
                         row.Cells["APE_MATE_CLIENTE"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["MONTO_SALIDA"].Value.ToString() + "</td>";
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

        private void Listado_MVtarjetasCaidas(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_MovimientoTarjeta.Listado_MVtarjetasCaidas(cTexto);
                this.Formato_tarjetaGeneral();
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
            this.Listado_MVtarjetasCaidas(Txt_buscar.Text.Trim());
            this.Estado_restaurar(true);
            lbl_tipoCliente.Text = "TRANSACCIONES ELIMINADAS";
            lbl_tipoCliente2.Text = "";
        }

        private void btn_recuperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value)))
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
                    this.ID_MV_TARJETA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_TARJETA"].Value);
                    Rpta = N_MovimientoTarjeta.Levantar_MVtarjetasCaidas(this.ID_MV_TARJETA);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_MVtarjetasCaidas("%");
                        this.ID_MV_TARJETA = 0;
                        lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
                        lbl_tipoCliente2.Text = "";
                        MessageBox.Show("Registro Levantado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Listado_ClientesPrincipales(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_MovimientoTarjeta.Listado_ClientesPrincipales(cTexto);
                this.Formato_tarjetaGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btn_clienPrin_Click(object sender, EventArgs e)
        {
            this.Listado_ClientesPrincipales(Txt_buscar.Text.Trim());
            this.Estado_restaurar(false);
            lbl_tipoCliente.Text = "";
            lbl_tipoCliente2.Text = "CLIENTES PRINCIPALES";
        }

        private void btn_ticket_Click(object sender, EventArgs e)
        {

        }
    }
}
