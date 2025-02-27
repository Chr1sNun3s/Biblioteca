using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Biblioteca
{
    public class RFC : UserControl
    {
        private TextBox txtRFC;
        private Label lblMensaje;
        private Button btnValidar;

        public RFC()
        {
            this.Width = 300;
            this.Height = 160;

            txtRFC = new TextBox { Left = 20, Top = 20, Width = 200 };
            lblMensaje = new Label { Left = 20, Top = 50, Width = 320, ForeColor = System.Drawing.Color.Red };

            btnValidar = new Button { Left = 20, Top = 80, Width = 120, Text = "Validar RFC" };
            btnValidar.Click += BtnValidar_Click;
      
            this.Controls.Add(txtRFC);
            this.Controls.Add(lblMensaje);
            this.Controls.Add(btnValidar);
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            string rfc = txtRFC.Text;       
            string rfcCorregido = RFC.Corregir(rfc);

            if (RFC.EstaValido(rfcCorregido))
            {
                lblMensaje.Text = "RFC válido: " + rfcCorregido;
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = $"RFC no válido. Ejemplo correcto: XXXX123456XXX ";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    

        public static bool EstaValido(string rfc)
        {
            string patron = @"^[A-Z]{4}\d{6}[A-Z0-9]{3}$"; // 4 letras, 6 números, 2 o 3 caracteres al final          
            rfc = rfc.ToUpper();         
            return Regex.IsMatch(rfc, patron);
        }
        
        public static string Corregir(string rfc)
        {
            rfc = rfc.ToUpper();
            rfc = rfc.Replace(" ", "").Trim();
            return rfc;
        }
    }
}
