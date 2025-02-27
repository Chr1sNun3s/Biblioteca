using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca
{
    public class ValidacionEntrada : UserControl
    {
        private TextBox txtEntrada;
        private Label lblMensaje;
        private Button btnNumeros, btnLetras;

        public enum Validacion { None, OnlyNumbers, OnlyLetters }
        public Validacion Mode { get; set; } = Validacion.None;

        public ValidacionEntrada()
        {
            this.Width = 280;
            this.Height = 120;
            txtEntrada = new TextBox { Left = 20, Top = 10, Width = 250 };
         
            txtEntrada.KeyPress += BloquearEntradaNoValida;

            lblMensaje = new Label { Left = 20, Top = 40, Width = 240, ForeColor = System.Drawing.Color.Red };

            btnNumeros = new Button { Left = 20, Top = 70, Width = 120, Text = "Solo Números" };
            btnNumeros.Click += (sender, e) => { Mode = Validacion.OnlyNumbers; ValidarEntrada(null, null); };

            btnLetras = new Button { Left = 150, Top = 70, Width = 120, Text = "Solo Letras" };
            btnLetras.Click += (sender, e) => { Mode = Validacion.OnlyLetters; ValidarEntrada(null, null); };

            this.Controls.Add(txtEntrada);
            this.Controls.Add(lblMensaje);
            this.Controls.Add(btnNumeros);
            this.Controls.Add(btnLetras);
        }
        private void ValidarEntrada(object sender, EventArgs e)
        {
            string texto = txtEntrada.Text;

            if (Mode == Validacion.OnlyNumbers && !texto.All(char.IsDigit))
            {
                lblMensaje.Text = " Solo se permiten números.";
            }
            else if (Mode == Validacion.OnlyLetters && !texto.All(char.IsLetter))
            {
                lblMensaje.Text = " Solo se permiten letras.";
            }
            else
            {
                lblMensaje.Text = "";
            }
        }
        private void BloquearEntradaNoValida(object sender, KeyPressEventArgs e)
        {
            if (Mode == Validacion.OnlyNumbers && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b') 
            {
                e.Handled = true; // Cancela la entrada no válida
                lblMensaje.Text = "Solo se permiten números.";
            }
            else if (Mode == Validacion.OnlyLetters && !char.IsLetter(e.KeyChar) && e.KeyChar != '\b') 
            {
                e.Handled = true;
                lblMensaje.Text = "Solo se permiten letras .";
            }
        }
    }
}