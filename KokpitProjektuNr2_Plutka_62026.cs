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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sprawdzenie czy egzemplarz formularza KokpitProjektu2_pPlutka62026_Lab_Load byl juz utworzony i jest w kolekcji OpenForms
            foreach (Form Formularz in Application.OpenForms)
                if (Formularz.Name == "LaboratoriumNr2")
                {
                    //ukrywamy biezacy formularz
                    this.Hide();
                    //odsloniecie formularza SzeregLab
                    Formularz.Show();
                    //zakonczenie obslugi
                    return;
                }
            //utworzenie egzemplarza
            LaboratoriumNr2 AnalizatorSzeregu = new LaboratoriumNr2();
            this.Hide();
            AnalizatorSzeregu.Show();
        }
    }
}
