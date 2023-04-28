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
            label2.Location =
                new Point(pbRysownica.Location.X + pbRysownica.Width + Margines,
                this.Top + 2 * Margines);
            chlbFiguryGeometryczne.Location =
                new Point(pbRysownica.Location.X + pbRysownica.Width + Margines,
                label2.Top + label2.Height + Margines);
            
            btnWłączPokazFigur.Location = new Point(btnStart.Location.X,
                pbRysownica.Location.Y + pbRysownica.Height + 2 * Margines);
            gpbTrybPokazu.Location = new Point(btnWłączPokazFigur.Location.X + btnWłączPokazFigur.Width +
                Margines, btnWłączPokazFigur.Location.Y);
            btnNastępna.Location = new Point(gpbTrybPokazu.Location.X + gpbTrybPokazu.Width +
                Margines, gpbTrybPokazu.Location.Y);
            
            btnPoprzednia.Location = new Point(btnNastępna.Location.X + btnNastępna.Width +
            3 * Margines, btnNastępna.Location.Y);
            label3.Location = new Point(btnPoprzednia.Location.X + btnPoprzednia.Width,
                pbRysownica.Location.Y + pbRysownica.Height + Margines / 4);
            txtBIndeks.Location = new Point(btnPoprzednia.Location.X + btnPoprzednia.Width +
                3 * Margines, btnPoprzednia.Location.Y);
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
                            TFG[IndexTFG].Wykreśl(Rysownica);
                            //przesuniecie  
                            IndexTFG++;
                            break;
                        }
                    case "Elipsa":
                        {
                            int OśMała = rnd.Next(Margines,Xmax/4);
                            int OśDuża = rnd.Next(Margines, Ymax/6);
                            TFG[IndexTFG] = new Elipsa(Xp, Yp, OśMała, OśDuża, Kolor, StylLini, GrubośćLini);
                            TFG[IndexTFG].Wykreśl(Rysownica);
                            IndexTFG++;
                            break;
                        }
                    case "Okrąg":
                        {
                            int Promień =rnd.Next(Margines,Xmax/4);
                            //utworzenie gzemplarza okregu i wpisanie jego referencji do tfg
                            TFG[IndexTFG] = new Okrąg(Xp, Yp, Promień, Kolor, StylLini, GrubośćLini);
                            TFG[IndexTFG].Wykreśl(Rysownica);
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
            btnPrzesuńdoNowegoXY.Enabled = true;

            //uaktywnienie innych przyciskow i kontrolek
            btnWłączPokazFigur.Enabled = true;
            gpbTrybPokazu.Enabled = true;


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

        private void btnWyłączPokaz_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            Rysownica.Clear(pbRysownica.BackColor);
            timer1.Enabled = false;
            btnWyłączPokaz.Enabled = false;
            btnWłączPokazFigur.Enabled= true;
            //ustalen ie rozmiaru powierzchni graficznej
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            int Yn, Xn;
            Random rnd = new Random();
            //wykreslenie wszystkich figur w nowym polozeniu
            for (int i=0;i<TFG.Length; i++)
            {
                //nowe polozenie
                Xn = rnd.Next(Margines, Xmax - Margines);
                Yn = rnd.Next(Margines, Ymax - Margines);
                TFG[i].PrzesuńDoNowegoXY(pbRysownica, Rysownica, Xn, Yn);
            }
            pbRysownica.Refresh();
            //usatwienie aktywnosci da 
            btnNastępna.Enabled = false;
            btnPoprzednia.Enabled = false;
            txtBIndeks.Enabled = false;
            rdbPokazZegarowy.Checked = true;

        }

        private void btnNastępna_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtBIndeks.Text);
            //wymazanie figury o numerze N
            TFG[N].Wymaż(pbRysownica, Rysownica);
            //wyznaczenie numeru kolejnej figury w pokazie
            if (N == (TFG.Length - 1))
                N = 0;
            else N++;
            //ustalen ie rozmiaru powierzchni graficznej
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            //przesuniecie z wykreslenien=m figury o numerze n
            TFG[N].PrzesuńDoNowegoXY(pbRysownica, Rysownica, Xmax / 2, Ymax / 2);
            pbRysownica.Refresh();
            //wpisanie aktualnego numeru N do kontrolki txtBIndex
            txtBIndeks.Text = N.ToString();
            Rysownica.Clear(pbRysownica.BackColor);
            pbRysownica.Refresh();
        }

        private void btnPoprzednia_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtBIndeks.Text);
            //wymazanie figury o numerze N
            TFG[N].Wymaż(pbRysownica, Rysownica);
            //wyznaczenie numeru poprzedniej figury w pokazie
            if (N == 0 )
                N= TFG.Length - 1;
            else N--;
            //ustalen ie rozmiaru powierzchni graficznej
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            //przesuniecie z wykreslenien=m figury o numerze n
            TFG[N].PrzesuńDoNowegoXY(pbRysownica, Rysownica, Xmax / 2, Ymax / 2);
            pbRysownica.Refresh();
            //wpisanie aktualnego numeru N do kontrolki txtBIndex
            txtBIndeks.Text = N.ToString();
            Rysownica.Clear(pbRysownica.BackColor);
            pbRysownica.Refresh();
        }

        private void txtBIndeks_TextChanged(object sender, EventArgs e)
        {
            ushort N;
            errorProvider1.Dispose();
            if (!ushort.TryParse(txtBIndeks.Text,  out N))
            {
                //jest blad
                errorProvider1.SetError(txtBIndeks, "ERROR: w podanym zapisie numeru indeksu figury wystąpił niedozwolony znak!");
                return;

            }
            //sprawdzenie czy nie nastapilo wyjscie poza zakres indeksu
            if((N>(TFG.Length - 1)))
                {
                //jest blad
                errorProvider1.SetError(txtBIndeks, "ERROR: podany indeks wykracza poza zakres indeksu TFG!");
                return;

            }

        }

        private void rdbPokazManualny_CheckedChanged(object sender, EventArgs e)
        {
            //uaktywnienie kontrolki textbox
            txtBIndeks.Enabled = true;
            txtBIndeks.Text = 0.ToString();
            btnNastępna.Enabled = true;
            btnPoprzednia.Enabled = true;

        }

        private void rdbPokazZegarowy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnWłączPokazFigur_Click(object sender, EventArgs e)
        {
            gpbTrybPokazu.Enabled = true;
            rdbPokazZegarowy.Enabled = true;
            rdbPokazManualny.Enabled = true;
            //aktywnosc dla przyciusku
            btnWyłączPokaz.Enabled = true;
            //wyczyszczenie powierzchni graficznej
            Rysownica.Clear(pbRysownica.BackColor);
            pbRysownica.Refresh();
            //rozpoznanie wybranego pokazu figur
            if(rdbPokazZegarowy.Checked)
            {
                //ustawienie num fig do pokazu w polu timer
                timer1.Tag = 0.ToString();
                timer1.Enabled = true;
                //wykreslenie pierwszej figury w pokazie

            }
            else
            {
                int N;
                N = int.Parse(txtBIndeks.Text);
                //ustalenie rozmiaru powierzchni graficznej
                int Xmax = pbRysownica.Width;
                int Ymax = pbRysownica.Height;
                //przesuniecie i wykrslenie pierwszej figury w pokazie
                TFG[N].PrzesuńDoNowegoXY(pbRysownica, Rysownica, Xmax / 2, Ymax / 2);
                pbRysownica.Refresh();
                //uaktywniwnie przcyciskow Nastepny i poprzednie
                btnNastępna.Enabled = true;
                btnPoprzednia.Enabled = true;

            }
            //ustawienie braku aktywnosci dla obslugiwanego przycisku
            btnWłączPokazFigur.Enabled = false;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //wymazanie aktualnej wykreslonej figury
            Rysownica.Clear(pbRysownica.BackColor);
            //ustalenie rozmiaru powierzchni graficznej
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            //wyznaczeni indeksu do pokazu
            int N = int.Parse(timer1.Tag.ToString());
            //przesuniecie wykreslenie figury geom ktoerj nr byl zapisany w polu time
            TFG[N].PrzesuńDoNowegoXY(pbRysownica, Rysownica, Xmax / 2, Ymax / 2);

            pbRysownica.Refresh();
            //wpisanie do pola tag nr nastepnej figury do wykreslenia
            timer1.Tag = (N+1) % (TFG.Length - 1);

        }
    }
}
