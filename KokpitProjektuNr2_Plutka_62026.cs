using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr2_Plutka_62026
{
    public partial class KokpitProjektuNr2_Plutka_62026 : Form
    {
        public KokpitProjektuNr2_Plutka_62026()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
                if (Formularz.Name == "ProjektIndywidualnyNr2")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }
            ProjektIndywidualnyNr2 AnalizatorSzeregu = new ProjektIndywidualnyNr2();
            this.Hide();
            AnalizatorSzeregu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
                if (Formularz.Name == "LaboratoriumNr2")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }
            LaboratoriumNr2 AnalizatorSzeregu = new LaboratoriumNr2();
            this.Hide();
            AnalizatorSzeregu.Show();
        }
    }
}
