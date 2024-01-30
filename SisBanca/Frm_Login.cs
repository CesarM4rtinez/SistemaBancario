using Banco.Datos;
using Banco.Entidades;
using Banco.Negocio;
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SisBanca
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Login_us(txtUsuario.Text, txtContraseña.Text);
        }

        private void Login_us(string USUARIO, string CONTRASEÑA)
        {
            try
            {
                DataTable data_login = new DataTable();
                DataTable dataTable = N_Usuarios.Login_us(USUARIO, CONTRASEÑA);
                data_login = dataTable;
                if (data_login.Rows.Count > 0)
                {
                    string cNombres  = "";
                    string cCargo    = "";
                    bool   bAdmin    = false;
                    bool   bPrestamo = false;
                    bool   bCuentas  = false;
                    bool   bTarjetas = false;

                    cCargo    = Convert.ToString(data_login.Rows[0][10]);
                    cNombres  = Convert.ToString(data_login.Rows[0][11]);
                    bAdmin    = Convert.ToBoolean(data_login.Rows[0][13]);
                    bPrestamo = Convert.ToBoolean(data_login.Rows[0][14]);
                    bCuentas  = Convert.ToBoolean(data_login.Rows[0][15]);
                    bTarjetas = Convert.ToBoolean(data_login.Rows[0][16]);

                    Frm_Dashboard oDashBoard       = new Frm_Dashboard();
                    oDashBoard.Lbl_nombres_us.Text = "Nombres: " + cNombres;
                    oDashBoard.Lbl_cargo.Text      = "Cargo: "   + cCargo;
                    oDashBoard.Chk_admin.Checked   = bAdmin;

                    if (bAdmin == true) // Usuario Administrador
                    {
                        oDashBoard.btn_empleados.Enabled           = true;
                        oDashBoard.btn_cliente.Enabled             = true;
                        oDashBoard.btn_cuentasBanco.Enabled        = true;
                        oDashBoard.btn_tarjetasCredito.Enabled     = true;
                        oDashBoard.btn_prestamos.Enabled           = true;
                    }

                    else if (bPrestamo == true) // Usuario Víctor Martínez
                    {
                        oDashBoard.btn_movimientos.Enabled         = true;
                        oDashBoard.btn_prestamos.Enabled           = true;

                        oDashBoard.btn_cuentasBanco.Enabled        = false;
                        oDashBoard.btn_tarjetasCredito.Enabled     = false;
                        oDashBoard.btn_empleados.Enabled           = true;
                        oDashBoard.btn_cliente.Enabled             = false;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;
                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                        oDashBoard.btn_MV_cuentas.Enabled          = false;
                        oDashBoard.btn_MV_tarjetas.Enabled         = false;
                    }

                    else if (bCuentas == true) // Usuario Héctor Mérino
                    {
                        oDashBoard.btn_cuentasBanco.Enabled        = true;
                        oDashBoard.btn_movimientos.Enabled         = true;
                        oDashBoard.btn_MV_cuentas.Enabled          = true;

                        oDashBoard.btn_tarjetasCredito.Enabled     = false;
                        oDashBoard.btn_prestamos.Enabled           = false;
                        oDashBoard.btn_empleados.Enabled           = false;
                        oDashBoard.btn_cliente.Enabled             = false;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;

                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                        oDashBoard.btn_MV_abono.Enabled            = false;
                        oDashBoard.btn_MV_tarjetas.Enabled         = false;
                    }

                    else if (bTarjetas == true) // Usuario Miguel Ayala
                    {
                        oDashBoard.btn_movimientos.Enabled         = true;
                        oDashBoard.btn_MV_tarjetas.Enabled         = true;
                        oDashBoard.btn_tarjetasCredito.Enabled     = true;
                        oDashBoard.btn_detalleTarjetasCred.Enabled = true;

                        oDashBoard.btn_cuentasBanco.Enabled        = false;
                        oDashBoard.btn_MV_cuentas.Enabled          = false;
                        
                        oDashBoard.btn_prestamos.Enabled           = false;
                        oDashBoard.btn_empleados.Enabled           = false;
                        oDashBoard.btn_cliente.Enabled             = false;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;

                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                        oDashBoard.btn_MV_abono.Enabled            = false;
                    }

                    else if (bAdmin == false) // Usuario Melvin Esteven
                    {
                        oDashBoard.btn_movimientos.Enabled         = false;
                        oDashBoard.btn_MV_cuentas.Enabled          = false;
                        oDashBoard.btn_MV_tarjetas.Enabled         = false;
                        oDashBoard.btn_MV_abono.Enabled            = false;

                        oDashBoard.btn_prestamos.Enabled           = false;
                        oDashBoard.btn_cuentasBanco.Enabled        = false;
                        oDashBoard.btn_tarjetasCredito.Enabled     = false;
                        oDashBoard.btn_empleados.Enabled           = false;
                        oDashBoard.btn_cliente.Enabled             = true;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;
                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                    }
                    oDashBoard.Show();
                    oDashBoard.FormClosed += Logout;
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Acceso denegado", "Aviso del Sistema");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text    = "";
            txtContraseña.Text = "";
            this.Show();
            txtUsuario.Focus();
        }
    }
}