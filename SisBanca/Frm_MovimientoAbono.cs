using Banco.Entidades;
using Banco.Negocio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Windows.Forms;
using Banco.Datos;
using System.Net;
using System.Diagnostics;
using iTextSharp.text.pdf.qrcode;
using System.Drawing;
using iTextSharp.tool.xml.html;
using static iTextSharp.tool.xml.css.CSS;
using ZXing;
using ZXing.Common;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Font = System.Drawing.Font;

namespace SisBanca
{
    public partial class Frm_MovimientoAbono : Form
    {
        public Frm_MovimientoAbono()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
            a.panelDashboardIcono.Visible = true;
            this.Estado_restaurar(false);
        }

        int ID_MV_ABONO = 0;
        int ID_CUENTA = 0;
        int ID_PRESTAMO = 0;
        int ID_CLIENTE = 0;
        int ID_EM = 0;
        int ID_SUCURSAL = 0;
        int Estadoguarda = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_saldoAbonado.ReadOnly = !lestado;
        }

        private void Formato_abonoGeneral()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Visible = false;
            Dgv_principal.Columns[2].Visible = false;
            Dgv_principal.Columns[3].Visible = false;
            Dgv_principal.Columns[4].Visible = false;
            Dgv_principal.Columns[5].Visible = false;
            Dgv_principal.Columns[6].Width = 120;
            Dgv_principal.Columns[6].HeaderText = "REGISTRO";
            Dgv_principal.Columns[7].Width = 90;
            Dgv_principal.Columns[7].HeaderText = "SALIDAS";
            Dgv_principal.Columns[8].Width = 115;
            Dgv_principal.Columns[8].HeaderText = "NOMBRE";
            Dgv_principal.Columns[9].Width = 90;
            Dgv_principal.Columns[9].HeaderText = "1° APELLIDO";
            Dgv_principal.Columns[10].Width = 90;
            Dgv_principal.Columns[10].HeaderText = "2° APELLIDO";
            Dgv_principal.Columns[11].Width = 140;
            Dgv_principal.Columns[11].HeaderText = "SUCURSAL";
            Dgv_principal.Columns[12].Visible = false;
            Dgv_principal.Columns[13].Visible = false;
            Dgv_principal.Columns[14].Visible = false;
            Dgv_principal.Columns[15].Visible = false;
            Dgv_principal.Columns[16].Visible = false;
        }

        private void Listado_abonoGeneral(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_MovimientoAbono.ListadoMV_abonoGeneral(cTexto);
                this.Formato_abonoGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpia_texto()
        {
            Txt_cuenta.Text = "";
            Txt_cliente.Text = "";
            Txt_empleado.Text = "";
            Txt_prestamo.Text = "";
            Txt_sucursal.Text = "";
            Txt_saldoAbonado.Text = "";
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_MV_ABONO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value);
                this.ID_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                this.ID_PRESTAMO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value);
                this.ID_CLIENTE = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                this.ID_EM = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_EM"].Value);
                this.ID_SUCURSAL = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_SUCURSAL"].Value);


                Txt_cuenta.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["CODIGO_CUENTA"].Value);
                Txt_prestamo.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["MONTO_PRESTADO"].Value);
                string nomCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;

                string nomEmpleado = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_EMPLEADO"].Value);
                string apePateEmpleado = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE"].Value);
                string apeMateEmpleado = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE"].Value);

                Txt_empleado.Text = nomEmpleado + " " + apePateEmpleado + " " + apeMateEmpleado;

                Txt_sucursal.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["SUCURSAL"].Value);
                Txt_saldoAbonado.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["MONTO_SALIDA"].Value);
            }
        }

        private void FormatoMovimiento_Cuenta()
        {
            Dgv_cuentas.Columns[0].Visible = false;
            Dgv_cuentas.Columns[1].Width = 120;
            Dgv_cuentas.Columns[1].HeaderText = "NOMBRE";
            Dgv_cuentas.Columns[2].Width = 100;
            Dgv_cuentas.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_cuentas.Columns[3].Width = 100;
            Dgv_cuentas.Columns[3].HeaderText = "2° APELLIDO";
            Dgv_cuentas.Columns[4].Visible = false;
        }

        private void ListadoMovimiento_Cuenta()
        {
            try
            {
                Dgv_cuentas.DataSource = N_MovimientoAbono.MV_abonoCuenta();
                this.FormatoMovimiento_Cuenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoMovimiento_Prestamo()
        {
            Dgv_prestamos.Columns[0].Visible = false;
            Dgv_prestamos.Columns[1].Width = 120;
            Dgv_prestamos.Columns[1].HeaderText = "NOMBRE";
            Dgv_prestamos.Columns[2].Width = 100;
            Dgv_prestamos.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_prestamos.Columns[3].Width = 100;
            Dgv_prestamos.Columns[3].HeaderText = "2° APELLIDO";
            Dgv_prestamos.Columns[4].Visible = false;
            Dgv_prestamos.Columns[5].Visible = false;
        }

        private void ListadoMovimiento_Prestamo()
        {
            try
            {
                Dgv_prestamos.DataSource = N_MovimientoAbono.MV_abonoPrestamo();
                this.FormatoMovimiento_Prestamo();
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
            Dgv_clientes.Columns[2].Width = 110;
            Dgv_clientes.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_clientes.Columns[3].Width = 110;
            Dgv_clientes.Columns[3].HeaderText = "2° APELLIDO";
        }

        private void ListadoMovimiento_Cliente()
        {
            try
            {
                Dgv_clientes.DataSource = N_MovimientoAbono.MV_abonoCliente();
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
            Dgv_empleados.Columns[1].Width = 120;
            Dgv_empleados.Columns[1].HeaderText = "NOMBRE";
            Dgv_empleados.Columns[2].Width = 100;
            Dgv_empleados.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_empleados.Columns[3].Width = 100;
            Dgv_empleados.Columns[3].HeaderText = "2° APELLIDO";
        }

        private void ListadoMovimiento_Empleado()
        {
            try
            {
                Dgv_empleados.DataSource = N_MovimientoAbono.MV_abonoEmpleado();
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
                Dgv_sucursal.DataSource = N_MovimientoAbono.MV_abonoSucursal();
                this.FormatoMovimiento_Sucursal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarMovimiento_Cuenta()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_cuentas.CurrentRow.Cells["ID_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CUENTA = Convert.ToInt32(Dgv_cuentas.CurrentRow.Cells["ID_CUENTA"].Value);
                Txt_cuenta.Text = Convert.ToString(Dgv_cuentas.CurrentRow.Cells["CODIGO_CUENTA"].Value);
            }
        }

        private void SeleccionarMovimiento_Prestamo()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_prestamos.CurrentRow.Cells["ID_PRESTAMO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_PRESTAMO = Convert.ToInt32(Dgv_prestamos.CurrentRow.Cells["ID_PRESTAMO"].Value);
                Txt_prestamo.Text = Convert.ToString(Dgv_prestamos.CurrentRow.Cells["MONTO_PRESTADO"].Value);
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
                this.ID_CLIENTE = Convert.ToInt32(Dgv_clientes.CurrentRow.Cells["ID_CLIENTE"].Value);
                string nomCliente = Convert.ToString(Dgv_clientes.CurrentRow.Cells["NOM_CLIENTE"].Value);
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
                this.ID_EM = Convert.ToInt32(Dgv_empleados.CurrentRow.Cells["ID_EM"].Value);
                string nomEm = Convert.ToString(Dgv_empleados.CurrentRow.Cells["NOM_EMPLEADO"].Value);
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
            Txt_saldoAbonado.Focus();
            Txt_saldoAbonado.Text = "0.00";
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
            Txt_saldoAbonado.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value)))
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
                    this.ID_MV_ABONO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value);
                    Rpta = N_MovimientoAbono.Eliminar_MV_abono(this.ID_MV_ABONO);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_abonoGeneral("%");
                        this.Estado_restaurar(false);
                        this.ID_MV_ABONO = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_abonoGeneral(Txt_buscar.Text.Trim());
            this.Estado_restaurar(false);
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_cuenta.Text == String.Empty ||
                Txt_prestamo.Text == String.Empty ||
                Txt_cliente.Text == String.Empty ||
                Txt_empleado.Text == String.Empty ||
                Txt_sucursal.Text == String.Empty ||
                Txt_saldoAbonado.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else // Se procedería a registrar la información
            {
                string Rpta = "";
                E_MovimientoAbono oCl = new E_MovimientoAbono();

                oCl.ID_MV_ABONO = this.ID_MV_ABONO;
                oCl.ID_CUENTA = this.ID_CUENTA;
                oCl.ID_PRESTAMO = this.ID_PRESTAMO;
                oCl.ID_CLIENTE = this.ID_CLIENTE;
                oCl.ID_EM = this.ID_EM;
                oCl.ID_SUCURSAL = this.ID_SUCURSAL;
                oCl.MONTO_SALIDA = Convert.ToDecimal(Txt_saldoAbonado.Text);

                Rpta = N_MovimientoAbono.Guardar_MV_abono(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_abonoGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_MV_ABONO = 0;
                    lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
                    lbl_tipoCliente2.Text = "";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_MV_ABONO = 0;
            this.ID_CUENTA = 0;
            this.ID_PRESTAMO = 0;
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

        private void button10_Click(object sender, EventArgs e)
        {
            Pnl_empleados.Visible = false;
        }

        private void Btn_retornoCuentas_Click(object sender, EventArgs e)
        {
            Pnl_cuentas.Visible = false;
        }

        private void Btn_retornoPrestamos_Click(object sender, EventArgs e)
        {
            Pnl_prestamos.Visible = false;
        }

        private void Btn_retornoClientes_Click(object sender, EventArgs e)
        {
            Pnl_clientes.Visible = false;
        }

        private void Btn_lupaCuentas_Click(object sender, EventArgs e)
        {
            this.Pnl_cuentas.Location = Btn_lupaCuentas.Location;
            this.Pnl_cuentas.Visible = true;
            this.Pnl_clientes.Visible = false;
            this.Pnl_empleados.Visible = false;
            this.Pnl_prestamos.Visible = false;
            this.Pnl_sucursal.Visible = false;
        }

        private void Btn_lupaPrestamos_Click(object sender, EventArgs e)
        {
            this.Pnl_prestamos.Location = Btn_lupaPrestamos.Location;
            this.Pnl_prestamos.Visible = true;
            this.Pnl_clientes.Visible = false;
            this.Pnl_empleados.Visible = false;
            this.Pnl_cuentas.Visible = false;
            this.Pnl_sucursal.Visible = false;
        }

        private void Btn_lupaCliente_Click(object sender, EventArgs e)
        {
            this.Pnl_clientes.Location = Btn_lupaCliente.Location;
            this.Pnl_clientes.Visible = true;
            this.Pnl_prestamos.Visible = false;
            this.Pnl_empleados.Visible = false;
            this.Pnl_cuentas.Visible = false;
            this.Pnl_sucursal.Visible = false;
        }

        private void Btn_lupaEmpleados_Click(object sender, EventArgs e)
        {
            this.Pnl_empleados.Location = Btn_lupaEmpleados.Location;
            this.Pnl_empleados.Visible = true;
            this.Pnl_prestamos.Visible = false;
            this.Pnl_clientes.Visible = false;
            this.Pnl_cuentas.Visible = false;
            this.Pnl_sucursal.Visible = false;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
            Txt_saldoAbonado.Focus();
        }

        private void dataGridView5_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Empleado();
            Pnl_empleados.Visible = false;
            Txt_empleado.Focus();
        }

        private void Dgv_cuentas_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Cuenta();
            Pnl_cuentas.Visible = false;
            Txt_cuenta.Focus();
        }

        private void Dgv_prestamos_MouseClick(object sender, MouseEventArgs e)
        {
            this.SeleccionarMovimiento_Prestamo();
            Pnl_prestamos.Visible = false;
            Txt_prestamo.Focus();
        }

        private void Dgv_clientes_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Cliente();
            Pnl_clientes.Visible = false;
            Txt_cliente.Focus();
        }

        private void Frm_DetalleMovimiento_Load(object sender, EventArgs e)
        {
            ListadoMovimiento_Empleado();
            ListadoMovimiento_Cliente();
            ListadoMovimiento_Cuenta();
            ListadoMovimiento_Prestamo();
            ListadoMovimiento_Sucursal();
            this.Estado_restaurar(false);
            Listado_abonoGeneral(Txt_buscar.Text.Trim());
            lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
            lbl_tipoCliente2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Pnl_sucursal.Location = Btn_lupaSucursal.Location;
            this.Pnl_sucursal.Visible = true;
            this.Pnl_empleados.Visible = false;
            this.Pnl_prestamos.Visible = false;
            this.Pnl_clientes.Visible = false;
            this.Pnl_cuentas.Visible = false;
        }

        private void btn_retornoSucursal_Click(object sender, EventArgs e)
        {
            Pnl_sucursal.Visible = false;
        }

        private void Dgv_sucursal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarMovimiento_Sucursal();
            Pnl_sucursal.Visible = false;
            Txt_sucursal.Focus();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));

            string PaginaHTML_Texto = Properties.Resources.plantillaMovimientoAbono.ToString();

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
                filas += "<td>" + row.Cells["MONTO_PRESTADO"].Value.ToString() + "</td>";
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

        private void Listado_AbonosCaidos(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_MovimientoAbono.Listado_AbonosCaidos(cTexto);
                this.Formato_abonoGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Listado_ClientesPrincipales(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_MovimientoAbono.Listado_ClientesPrincipales(cTexto);
                this.Formato_abonoGeneral();
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
            this.Listado_AbonosCaidos(Txt_buscar.Text.Trim());
            lbl_tipoCliente.Text = "TRANSACCIONES ELIMINADAS";
            lbl_tipoCliente2.Text = "";
            this.Estado_restaurar(true);
        }

        private void btn_recuperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value)))
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
                    this.ID_MV_ABONO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_MV_ABONO"].Value);
                    Rpta = N_MovimientoAbono.Levantar_abonosCaidos(this.ID_MV_ABONO);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_AbonosCaidos("%");
                        this.ID_MV_ABONO = 0;
                        lbl_tipoCliente.Text = "CLIENTES TRANSACCIONALES";
                        lbl_tipoCliente2.Text = "";
                        MessageBox.Show("Registro Levantado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
            Txt_saldoAbonado.Focus();
        }

        private void btn_clientePrin_click(object sender, EventArgs e)
        {
            this.Listado_ClientesPrincipales(Txt_buscar.Text.Trim());
            this.Estado_restaurar(false);
            lbl_tipoCliente.Text = "";
            lbl_tipoCliente2.Text = "CLIENTES PRINCIPALES";
        }

        private void btn_ticket_click(object sender, EventArgs e)
        {
            // Abre el diálogo de impresión
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1; // Asocia el PrintDialog con el PrintDocument

            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print(); // Imprime usando el PrintDocument
            }

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define el tamaño personalizado para el PDF (en puntos, 1 pulgada = 72 puntos)
            float width = 400; // Ancho de la página en puntos
            float height = 600; // Altura de la página en puntos

            // Establece el tamaño de la página
            e.PageSettings.PaperSize = new PaperSize("Custom", (int)width, (int)height);

            // Ahora puedes dibujar el contenido en el PDF usando las coordenadas y medidas ajustadas.
            // Ten en cuenta que las posiciones y tamaños de fuente deben ajustarse para el nuevo tamaño de página.

            // Ejemplo de dibujo de texto en el nuevo tamaño de página
            e.Graphics.DrawString("Transacción de Abono", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            // Otros elementos del ticket...

            // Asegúrate de ajustar las coordenadas y tamaños según el nuevo tamaño de página.
        }


        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            // Asigna el documento de impresión al control PrintPreviewDialog
            printPreviewDialog1.Document = printDocument1;

            // Manejador de evento para el dibujo del ticket en el documento de impresión
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            // Muestra el preview al cargar el formulario
            printPreviewDialog1.ShowDialog();
        }
    }
}