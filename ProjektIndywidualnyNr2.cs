using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjektNr2_Plutka_62026.FiguryGeometryczne;

using System.Data.SqlClient;

namespace ProjektNr2_Plutka_62026
{
    public partial class ProjektIndywidualnyNr2 : Form
    {
        Point kpPunkt = Point.Empty;
        Graphics kpRysownica;
        Pen kpPióro;
        SolidBrush kpPędzel;
        const ushort kpPromienPunktu = 2;
        public ProjektIndywidualnyNr2()
        {
            InitializeComponent();
            kppbRysownica.Image = new Bitmap(kppbRysownica.Width, kppbRysownica.Height);
            kpRysownica = Graphics.FromImage(kppbRysownica.Image);
            kpPióro = new Pen(Color.Red, 1.7F);
            kpPióro.DashStyle = DashStyle.Dash;
            kpPióro.StartCap = LineCap.Round;
            kpPióro.EndCap = LineCap.Round;
            kpPędzel = new SolidBrush(DefaultBackColor);
        }

        private void kpbtnZapisz_Click(object sender, EventArgs e)
        {

            SaveFileDialog OknoWyboruPlikuDoZapisu = new SaveFileDialog();
            OknoWyboruPlikuDoZapisu.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            OknoWyboruPlikuDoZapisu.FilterIndex = 1;
            OknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            OknoWyboruPlikuDoZapisu.InitialDirectory = "E:\\";
            OknoWyboruPlikuDoZapisu.Title = "Wybór pliku do zapisu BitMapy";
            if (OknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter PlikZnakowy = new System.IO.StreamWriter(OknoWyboruPlikuDoZapisu.FileName);
                try
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: podczas zapisywania Bitmapy w pliku wystąpił błąd: " + ex.Message);
                }
                finally
                {
                    PlikZnakowy.Close();
                }
            }
            else
                MessageBox.Show("UWAGA: nie dokonano wyboru pliku i polecenia zapisu nie zostało zrealizowane");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ProjektIndywidualnyNr2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void kpbtnKolorWypełnienia_Click(object sender, EventArgs e)
        {
            ColorDialog kpPaletaKolorów = new ColorDialog();
            kpPaletaKolorów.Color = kpbtnKolorWypełnienia.BackColor;
            if (kpPaletaKolorów.ShowDialog() == DialogResult.OK)
                kpbtnKolorWypełnienia.BackColor = kpPaletaKolorów.Color;
            kpPaletaKolorów.Dispose();
        }

        private void kppbRysownica_MouseDown(object sender, MouseEventArgs e)
        {

            kplblX.Text = e.Location.X.ToString();
            kplblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
                kpPunkt = e.Location;

        }

        private void kppbRysownica_MouseUp(object sender, MouseEventArgs e)
        {

            kplblX.Text = e.Location.X.ToString();
            kplblY.Text = e.Location.Y.ToString();
            int kpLewyGórnyNarożnikX = (kpPunkt.X > e.Location.X) ? e.Location.X : kpPunkt.X;
            int kpLewyGórnyNarożnikY = (kpPunkt.Y > e.Location.Y) ? e.Location.Y : kpPunkt.Y;
            int kpSzerokość = Math.Abs(kpPunkt.X - e.Location.X);
            int kpWysokość = Math.Abs(kpPunkt.Y - e.Location.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (kprdbPunkt.Checked)
                    
                    kpRysownica.FillEllipse(kpPędzel,
                        kpPunkt.X - kpPromienPunktu,
                        kpPunkt.Y - kpPromienPunktu,
                        2 * kpPromienPunktu,
                        2 * kpPromienPunktu);
                if (kprdbLiniaProsta.Checked)
                    kpRysownica.DrawLine(kpPióro,
                        kpPunkt.X,
                        kpPunkt.Y,
                        e.Location.X,
                        e.Location.Y);
                if (kprdbLiniaCiągłaKreślonaMyszą.Checked)
                    kpRysownica.DrawLine(kpPióro,
                        kpPunkt.X,
                        kpPunkt.Y,
                        e.Location.X,
                        e.Location.Y);
               
                if (kprdbProstokąt.Checked)
                {
                    ushort kpStopieńWielokąta = 4;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpRysownica.DrawRectangle(kpPióro, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                            kpSzerokość, kpWysokość);
                }
                
            }
            kppbRysownica.Refresh();

        }

        private void kpbtnWczytaj_Click(object sender, EventArgs e)
        {

            OpenFileDialog OknoWyboruPlikuDoOdczytu = new OpenFileDialog();
            OknoWyboruPlikuDoOdczytu.Filter = "pdffiles (*.pdf)|*.pdf|All files(*.*)|*.*";
            OknoWyboruPlikuDoOdczytu.FilterIndex = 1;
            OknoWyboruPlikuDoOdczytu.RestoreDirectory = true;
            OknoWyboruPlikuDoOdczytu.InitialDirectory = "H:\\";
            OknoWyboruPlikuDoOdczytu.Title = "Wybór pliku do odczytuBitMapy";

            if (OknoWyboruPlikuDoOdczytu.ShowDialog() == DialogResult.OK)
            {
                string WierszDanych;
                string[] DaneWiersza;
                ushort LicznikWierszy;
                System.IO.StreamReader PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytu.FileName);

                LicznikWierszy = 0;
                while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    LicznikWierszy++;


                PlikZnakowy.Close();


                PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytu.FileName);

                try

                {
                    int NrWiersza = 0;

                    while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                    {
                        DaneWiersza = WierszDanych.Split(';');

                        DaneWiersza[0].Trim(); DaneWiersza[1].Trim(); DaneWiersza[2].Trim();


                    }


                    kppbRysownica.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: błąd operacji (działania) na pliku (wyświetlony komunikat): ---> " + ex.Message);
                }
                finally
                {
                    PlikZnakowy.Close();
                    PlikZnakowy.Dispose();
                }
            }
            else
                MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku' (z menu poziomu Plik) nie może być zrealizowana");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kptbGrubośćLini_Scroll(object sender, EventArgs e)
        {

        }

        private void kpbtnKolorLini_Click(object sender, EventArgs e)
        {
            ColorDialog kpPaletaKolorów = new ColorDialog();
            kpPaletaKolorów.Color = kpbtnKolorWypełnienia.BackColor;

            if (kpPaletaKolorów.ShowDialog() == DialogResult.OK)

                kpPaletaKolorów.Dispose();
            kpPióro.Color = kpPaletaKolorów.Color;
        }

        private void kprdbLiniaCiągłaKreślonaMyszą_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ProjektIndywidualnyNr2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void kprdbKwadrat_CheckedChanged(object sender, EventArgs e)
        {
            
           
        }

        private void kprdbProstokąt_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void kppbRysownica_MouseMove(object sender, MouseEventArgs e)
        {

            kplblX.Text = e.Location.X.ToString();
            kplblY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
            {
                if (kprdbLiniaCiągłaKreślonaMyszą.Checked)
                {
                    kpRysownica.DrawLine(kpPióro,
                       kpPunkt.X,
                       kpPunkt.Y,
                       e.Location.X,
                       e.Location.Y);
                    kpPunkt = e.Location;
                }
                kppbRysownica.Refresh();
            }
        }
    }
}
