using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public enum TipoEntrada
    {
        Numeros,
        Letras,
        Alfanum
    }

    public class TextBoxAlfanumerico : TextBox
    {
        private TipoEntrada tipoEntrada = TipoEntrada.Alfanum;
        private Color colorBordePredeterminado = Color.Black;
        private Color colorBordeError = Color.Red;

        public TipoEntrada TipoEntradaPermitida
        {
            get { return tipoEntrada; }
            set { tipoEntrada = value; }
        }

        public TextBoxAlfanumerico()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.TextChanged += new EventHandler(OnTextChanged);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (ValidarTexto(this.Text))
            {
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.ControlText;
                this.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                this.BackColor = Color.LightPink;
                this.ForeColor = Color.White;
            }
        }

        private bool ValidarTexto(string texto)
        {
            switch (tipoEntrada)
            {
                case TipoEntrada.Numeros:
                    return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^\d*$");
                case TipoEntrada.Letras:
                    return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z]*$");
                case TipoEntrada.Alfanum:
                    return System.Text.RegularExpressions.Regex.IsMatch(texto, @"^[a-zA-Z0-9]*$");
                default:
                    return true;
            }
        }
    }

    public partial class Ftext : UserControl
    {
        private TextBoxAlfanumerico txtPersonalizado;
        private Button btnNumeros, btnLetras, btnAlfanum;

        public Ftext()
        {
            InitializeComponent();

          
            txtPersonalizado = new TextBoxAlfanumerico
            {
                TipoEntradaPermitida = TipoEntrada.Alfanum,
                Location = new Point(10, 10),
                Size = new Size(320, 30)
            };

            btnNumeros = new Button
            {
                Text = "Solo Numeros",
                Location = new Point(10, 50),
                Size = new Size(100, 30)
            };
            btnNumeros.Click += (sender, e) => txtPersonalizado.TipoEntradaPermitida = TipoEntrada.Numeros;

            btnLetras = new Button
            {
                Text = "Solo Letras",
                Location = new Point(120, 50),
                Size = new Size(100, 30)
            };
            btnLetras.Click += (sender, e) => txtPersonalizado.TipoEntradaPermitida = TipoEntrada.Letras;

            btnAlfanum = new Button
            {
                Text = "Alfanumerico",
                Location = new Point(230, 50),
                Size = new Size(100, 30)
            };
            btnAlfanum.Click += (sender, e) => txtPersonalizado.TipoEntradaPermitida = TipoEntrada.Alfanum;
            this.Controls.Add(txtPersonalizado);
            this.Controls.Add(btnNumeros);
            this.Controls.Add(btnLetras);
            this.Controls.Add(btnAlfanum);
        }

        private void Ftext_Load(object sender, EventArgs e)
        {

        }
    }
}
