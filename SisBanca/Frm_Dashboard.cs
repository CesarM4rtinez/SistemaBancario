using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisBanca
{
    public partial class Frm_Dashboard : Form
    {
        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Pnl_central.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        public Frm_Dashboard()
        {
            InitializeComponent();

            this.panelDetalleCliente.Visible = false;
            this.panelDetalleTarjetas.Visible = false;
            this.panelDetalleCuentas.Visible = false;
            this.panelDetalleEmpleados.Visible = false;
            this.panelDetalleMovimientos.Visible = false;
            this.panelDetallePrestamos.Visible = false;
        }

        private void BTN_CLENTES_Click(object sender, EventArgs e)
        {
            if (this.panelDetalleCliente.Visible == false)
            {
                this.panelDetalleCliente.Visible = true;
            }
            else
            {
                this.panelDetalleCliente.Visible = false;
            }
            this.panelDetalleTarjetas.Visible = false;
            this.panelDetalleCuentas.Visible = false;
            this.panelDetalleEmpleados.Visible = false;
            this.panelDetalleMovimientos.Visible = false;
            this.panelDetallePrestamos.Visible = false;
        }

        private void btn_tarjetasCredito_Click(object sender, EventArgs e)
        {
            if (this.panelDetalleTarjetas.Visible == false)
            {
                this.panelDetalleTarjetas.Visible = true;
            }
            else
            {
                this.panelDetalleTarjetas.Visible = false;
            }
            this.panelDetalleCliente.Visible = false;
            this.panelDetalleCuentas.Visible = false;
            this.panelDetalleEmpleados.Visible = false;
            this.panelDetalleMovimientos.Visible = false;
            this.panelDetallePrestamos.Visible = false;
        }

        private void btn_cuentasBanco_Click(object sender, EventArgs e)
        {
            if (this.panelDetalleCuentas.Visible == false)
            {
                this.panelDetalleCuentas.Visible = true;
            }
            else
            {
                this.panelDetalleCuentas.Visible = false;
            }
            this.panelDetalleCliente.Visible = false;
            this.panelDetalleTarjetas.Visible = false;
            this.panelDetalleEmpleados.Visible = false;
            this.panelDetalleMovimientos.Visible = false;
            this.panelDetallePrestamos.Visible = false;
        }

        private void btn_prestamos_Click(object sender, EventArgs e)
        {
            if (this.panelDetallePrestamos.Visible == false)
            {
                this.panelDetallePrestamos.Visible = true;
            }
            else
            {
                this.panelDetallePrestamos.Visible = false;
            }
            this.panelDetalleCliente.Visible = false;
            this.panelDetalleTarjetas.Visible = false;
            this.panelDetalleEmpleados.Visible = false;
            this.panelDetalleMovimientos.Visible = false;
            this.panelDetalleCuentas.Visible = false;
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            if (this.panelDetalleEmpleados.Visible == false)
            {
                this.panelDetalleEmpleados.Visible = true;
            }
            else
            {
                this.panelDetalleEmpleados.Visible = false;
            }
            this.panelDetalleCliente.Visible = false;
            this.panelDetalleTarjetas.Visible = false;
            this.panelDetallePrestamos.Visible = false;
            this.panelDetalleMovimientos.Visible = false;
            this.panelDetalleCuentas.Visible = false;
        }

        private void btn_movimientos_Click_1(object sender, EventArgs e)
        {
            if (this.panelDetalleMovimientos.Visible == false)
            {
                this.panelDetalleMovimientos.Visible = true;
            }
            else
            {
                this.panelDetalleMovimientos.Visible = false;
            }
            this.panelDetalleCliente.Visible = false;
            this.panelDetalleTarjetas.Visible = false;
            this.panelDetallePrestamos.Visible = false;
            this.panelDetalleCuentas.Visible = false;
            this.panelDetalleEmpleados.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lbl_fecha.Text = DateTime.Now.ToLongDateString();
            Lbl_hora.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_registroCliente_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_DetalleCliente());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_tipoCliente_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_TipoCliente());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_detalleTarjetasCred_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_TarjetasCredito());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_tipoTarjetas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_TiposTarjetas());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_cuentas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Cuentas());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_tipoCuentas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_TipoCuentas());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_detallePrestamo_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_DetallePrestamos());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_tipoPrestamo_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_TipoPrestamos());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_tipoPagoPrestamo_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_TipoPagos());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_detalleEmpleado_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_DetalleEmpleados());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_cargoEmpleado_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_CargoEmpleados());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_usauriosSistemas_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_UsuarioSistema());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_detalleMovimientos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_MovimientoAbono());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_pagoAbono_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_MovimientoCuenta());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_MV_prestamos_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_MovimientoTarjeta());
            Pnl_cuerpo.Visible = false;
        }

        private void btn_sucursales_Click(object sender, EventArgs e)
        {
            openChildForm(new Frm_Sucursales());
            Pnl_cuerpo.Visible = false;
        }
    }
}