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
    public partial class FBoton : UserControl
    {
        public FBoton()
        {
            InitializeComponent();
            BotonC miBoton = new BotonC();
            miBoton.Text = "Boton";
            miBoton.ColorFondo = Color.LightBlue;
            miBoton.Location = new Point(50, 50);
            miBoton.Size = new Size(180, 50);


            this.Controls.Add(miBoton);
        }

        private void FBoton_Load(object sender, EventArgs e)
        {
        }
        public class BotonC : Button
        {
            private Color colorFondo;

            public Color ColorFondo
            {
                get { return colorFondo; }
                set { colorFondo = value; }
            }

            public BotonC()
            {
                this.MouseEnter += new EventHandler(OnMouseEnter);
                this.MouseLeave += new EventHandler(OnMouseLeave);
                this.MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
                this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
            }

            private void OnMouseEnter(object sender, EventArgs e)
            {
                if (colorFondo != null)
                {
                    this.BackColor = colorFondo;
                }
            }
            private void OnMouseLeave(object sender, EventArgs e)
            {
                this.BackColor = SystemColors.Control;
            }
            private void OnMouseDoubleClick(object sender, MouseEventArgs e)
            {
                DialogResult result = MessageBox.Show(
                    "Mensaje confirmado",
                    "¿Confirmar con doble click?",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.OnClick(e);
                }
            }
        }
    }
}

