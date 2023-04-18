using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        ushort IndexTFG;
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
            //label1.Location =
            //    new Point(pbRysownica.Location.X - pbRysownica.Width + Margines,
            //    this.Top + 2 * Margines);
            label2.Location =
                new Point(pbRysownica.Location.X + pbRysownica.Width + Margines,
                this.Top + 2 * Margines);
            chlbFiguryGeometryczne.Location =
                new Point(pbRysownica.Location.X + pbRysownica.Width + Margines,
                label2.Top + label2.Height + Margines);
            //txtN.Location =
            //    new Point(pbRysownica.Location.Y + pbRysownica.Top + Margines,
            //    label1.Left + label1.Left + Margines);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ushort N;
            //zgaszenie errorpro
            errorProvider1.Dispose();
            Random rnd = new Random();
            int Xmax, Ymax;
            int Xp, Yp;
            Color Kolor;
            float GrubośćLini;
            DashStyle StylLini;

            //pobranie liczby figur do prezentacji
            N = ushort.Parse(txtN.Text);
            //utworzenie egzemplarza tablicy figur geom
            TFG = new Punkt[N];
            IndexTFG = 0;
            //rozmiar powierzni graficznej
            Xmax = pbRysownica.Width; Ymax = pbRysownica.Height;
            //utworzenie kolekcji wybranych figur geom
            CheckedListBox.CheckedItemCollection WybraneFG = chlbFiguryGeometryczne.CheckedItems;
            //tworzenie egzemplarzy fg i wpisanie do tfg ich referencji oraz wykreslenie
            for (ushort i = 0; i < N; i++)
            {
                Xp = rnd.Next(Margines, Xmax- Margines);
                Yp = rnd.Next(Margines, Ymax - Margines);
                Kolor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                GrubośćLini = (float)(rnd.NextDouble() * ((double) Margines - 0.5) + 0.5);
                //wylosownaie stylu lini
                switch (rnd.Next(0,5))
                {
                    case 0: StylLini = DashStyle.Solid; break;
                    case 1: StylLini = DashStyle.Dash; break;
                    case 2: StylLini = DashStyle.Dot; break;
                    case 3: StylLini = DashStyle.DashDot; break;
                    case 4: StylLini = DashStyle.DashDotDot; break;
                        default: StylLini = DashStyle.Solid; break;
                }
                //wylosowanie jednej z wybranych figur geometrycznych, utworzenie dla niej egzemplarza i jej wykreslenie
                switch (WybraneFG[rnd.Next(WybraneFG.Count)].ToString())
                {
                    case "Punkt":
                        {
                            //utworzenie egzemplarza Punkt i wpisanie jego referncji do TFG
                            TFG[IndexTFG] = new Punkt(Xp, Yp, Kolor);
                            //wykreslenie figury geometrycznej
                            TFG[IndexTFG].Wykreśl(Rysownica);
                            //przesuniecie  indextfg na wolna pozucje
                            IndexTFG++;
                            break;
                        }
                    case "Linia":
                        {
                           //wylosowanie wspolrzednych konca lini
                           int Xk = rnd.Next(Margines, Xmax- Margines);
                            int Yk = rnd.Next(Margines, Ymax- Margines);
                            //utworzenie egzemplarza lini i wpisanie jej referencji do TFG
                            TFG[IndexTFG] = new Linia(Xp, Yp, Xk, Yk, Kolor, StylLini, GrubośćLini);
                            //przesuniecie  
                            IndexTFG++;
                            break;
                        }
                        default:
                        {
                            MessageBox.Show("UWAGA: tej figury jeszcze nie wykreślam :(");
                            break;
                        }
                        //kolejne case dla kolejnych figur 

                }//od switcha

            }//od for
            //odswiezenie powierzchni graficznej
            pbRysownica.Refresh();
            //ustwienie stanu braku aktywnosci dla przycisku start
            btnStart.Enabled = false;
            //uaktywnienie innych przyciskow i kontrolek


        }

        private void txtN_TextChanged(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort N;
            //zgaszenie kontorlki errorprovider
            errorProvider1.Dispose();
            //sprawdzenie czy do kontrolki txtN wpisamo liczbe naturalna
            if (!ushort.TryParse(txtN.Text, out N))
            {
                errorProvider1.SetError(txtN, "ERROR: w zapisie liczby figur wystąpił niedozwolony znak");
                    return;
            }
            //ustawienie stanu braku aktywnosci dla kontrolki txtN
            txtN.Enabled = false;
            //sprawdzenie czy zpstaly wybrane figury geometryczne do prezentacji
            if (chlbFiguryGeometryczne.CheckedItems.Count > 0)
                //uaktywnieni przycisku polecen start
                btnStart.Enabled = true;
            else
                //zapalenie kontrolki errorprovider przy kontrolce chlbFiguryGeom.
                errorProvider1.SetError(chlbFiguryGeometryczne, "UWAGA: Musisz wybrać co najmniej jedną figurę geometryczną");

        }

        private void chlbFiguryGeometryczne_SelectedIndexChanged(object sender, EventArgs e)
        {
            //zgaszenie kontrolki errorprovider
            errorProvider1.Dispose();
            //sprawdzenie czy juz podano liczbe figur do prezentacji
            if (!txtN.Enabled)
                btnStart.Enabled = true;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void LaboratoriumNr2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy chcesz zamknąć ten formularz i przejść do formularza głownego?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (OknoMessage == DialogResult.Yes)
            {
                foreach (Form Formularz in Application.OpenForms)
                    if (Formularz.Name == "KokpitProjektuNr2_Plutka_62026")
                    {
                        this.Hide();
                        Formularz.Show();
                        return;
                    }

            }
            else
                e.Cancel = true;
        }

        private void btnPrzesuńdoNowegoXY_Click(object sender, EventArgs e)
        {
            //deklaracej= pomocnicze
            Random rnd = new Random();
            int Xmax, Ymax;
            int Xn, Yn;
            //wyczyszczenie powierzchni graficznej
            Rysownica.Clear(pbRysownica.BackColor);
            //odczytanie rozmiaru powierzchni graficznej
            Xmax = pbRysownica.Width;
            Ymax = pbRysownica.Height;
            //przesuniecie wsszytskich fig geom do nowego polozenia
            for (int i=0; i<TFG.Length; i++)
            {
                //wylososwanie nowego polozenia
                Xn = rnd.Next(Margines, Xmax - Margines);
                Yn = rnd.Next(Margines, Ymax - Margines);
                //przesuniecie z wykresleniem itej fg
                TFG[i].PrzesuńDoNowegoXY(pbRysownica, Rysownica, Xn, Yn);
            }
            //odswiezenie powierzchni graficznej
            pbRysownica.Refresh();

        }//od btn

    }
}
