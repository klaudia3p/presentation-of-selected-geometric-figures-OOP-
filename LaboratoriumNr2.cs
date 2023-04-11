using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjektNr2_Plutka_62026.FiguryGeometryczne;

namespace ProjektNr2_Plutka_62026
{
    public partial class LaboratoriumNr2 : Form
    {
        //deklaracje pomocnicze
        const int Margines = 10;
        Graphics Rysownica;
        Punkt[] TFG;
        int IndexTFG;
        public LaboratoriumNr2()
        { 
            InitializeComponent();

            //rozmiar formularza
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X + Margines,
                Screen.PrimaryScreen.Bounds.Y + Margines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.80F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.75F);
            this.StartPosition = FormStartPosition.Manual;

            //lokalizacja pb
            pbRysownica.Location = new Point(this.Left + 20 *Margines, this.Top +5*Margines);
            pbRysownica.Size = new Size((int)(this.Width * 0.6F), (int)(this.Height * 0.6F));

            //utworzenie bitmapy
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);

            //utworzenie egzemplarza powierzchni graficznej
            Rysownica = Graphics.FromImage(pbRysownica.Image);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LaboratoriumNr2_Load(object sender, EventArgs e)
        {

        }
    }
}
