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
        struct OpisKrzywejBeziera
        {

            public Point kpPunktP0;
            public Point kpPunktP1;
            public Point kpPunktP2;
            public Point kpPunktP3;

            public ushort kpNumerPunktuKontrolnego;
            public float kpPromieńPunktuKontrolnego;
        }
        OpisKrzywejBeziera kpKrzywaBeziera;
        Font FontOpisuPunktów = new Font("Arial", 10, FontStyle.Italic);

        struct OpisKrzywejKardynalnej
        {

            public PointF kpPunkt01;
            public PointF kpPunkt02;
            public PointF kpPunkt03;
            public PointF kpPunkt04;
            public PointF kpPunkt05;

            public ushort kpNumerPunktuKontrolnego;
            public float kpPromieńPunktuKontrolnego;
        }
        OpisKrzywejKardynalnej kpKrzywaKardynalna;



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
                {
                    kpRysownica.FillEllipse(kpPędzel,
                        kpPunkt.X - kpPromienPunktu,
                        kpPunkt.Y - kpPromienPunktu,
                        2 * kpPromienPunktu,
                        2 * kpPromienPunktu);
                }


                if (kprdbLiniaProsta.Checked)
                {
                    kpRysownica.DrawLine(kpPióro,
                        kpPunkt.X,
                        kpPunkt.Y,
                        e.Location.X,
                        e.Location.Y);
                }


                if (kprdbLiniaCiągłaKreślonaMyszą.Checked)
                {
                    kpRysownica.DrawLine(kpPióro,
                        kpPunkt.X,
                        kpPunkt.Y,
                        e.Location.X,
                        e.Location.Y);
                }


                if (kprdbProstokąt.Checked)
                {
                    ushort kpStopieńWielokąta = 4;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpRysownica.DrawRectangle(kpPióro, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                            kpSzerokość, kpWysokość);
                }


                if (kprdbKwadrat.Checked)
                {
                    ushort kpStopieńWielokąta = 4;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }


                if (kprdbOkrąg.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }


                if (kprdbKoło.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 0.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 360.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (kpKątPołożeniaPierwszegoWierzchołka +
                            i * kpKątMiędzyWierzchołkamiWielokąta) / 180));

                    }
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPolygon(kpPędzel, kpWierzchołkiWielokąta);
                }


                if (kprdbElipsa.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpRysownica.DrawEllipse(kpPióro, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                           kpSzerokość, kpWysokość);
                }


                if (kprdbKrzywaBeziera.Checked)
                {
                    if (kpgbWybierzFigurę.Enabled)
                    {
                        kpgbWybierzFigurę.Enabled = false;
                        kpKrzywaBeziera.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaBeziera.kpPromieńPunktuKontrolnego = 5;
                        kpKrzywaBeziera.kpPunktP0 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaBeziera.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaBeziera.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaBeziera.kpPunktP1 = e.Location; break;
                            case 2: kpKrzywaBeziera.kpPunktP2 = e.Location; break;
                            case 3: kpKrzywaBeziera.kpPunktP3 = e.Location; break;
                        }
                        if (kpKrzywaBeziera.kpNumerPunktuKontrolnego < 3)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaBeziera.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaBeziera.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            kpRysownica.DrawBezier(kpPióro,
                                kpKrzywaBeziera.kpPunktP0,
                                kpKrzywaBeziera.kpPunktP1,
                                kpKrzywaBeziera.kpPunktP2,
                                kpKrzywaBeziera.kpPunktP3);
                            kpgbWybierzFigurę.Enabled = true;
                        }
                    }
                }


                if (kprdbKrzywaKardynalna.Checked)
                {

                    if (kpgbWybierzFigurę.Enabled)
                    {
                        kpgbWybierzFigurę.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpRysownica.DrawCurve(kpPióro, points, 1.0f);
                            kpgbWybierzFigurę.Enabled = true;
                        }
                    }


                }


                if (kprdbFillRectangle.Checked)
                {
                    ushort kpStopieńWielokąta = 4;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillRectangle(kpPędzel, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                            kpSzerokość, kpWysokość);
                }


                if (kprdbFillElipse.Checked)
                {
                    ushort kpStopieńWielokąta = 360;
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                        kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillEllipse(kpPędzel, kpLewyGórnyNarożnikX, kpLewyGórnyNarożnikY,
                           kpSzerokość, kpWysokość);
                }


                if (kprdbDrawClosedCurve.Checked)
                {

                    if (kpgbWybierzFigurę.Enabled)
                    {
                        kpgbWybierzFigurę.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpRysownica.DrawClosedCurve(kpPióro, points);
                            kpgbWybierzFigurę.Enabled = true;
                        }
                    }
                }


                if (kprdbFillClosedCurve.Checked)
                {

                    if (kpgbWybierzFigurę.Enabled)
                    {
                        kpgbWybierzFigurę.Enabled = false;
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego = 0;
                        kpKrzywaKardynalna.kpPromieńPunktuKontrolnego = 4;
                        kpKrzywaKardynalna.kpPunkt01 = e.Location;

                        using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                        {
                            kpRysownica.FillEllipse(kpPędzel,
                                e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                            kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, kpPędzel, e.Location);
                        }
                    }
                    else
                    {
                        kpKrzywaKardynalna.kpNumerPunktuKontrolnego++;
                        switch (kpKrzywaKardynalna.kpNumerPunktuKontrolnego)
                        {
                            case 1: kpKrzywaKardynalna.kpPunkt02 = e.Location; break;
                            case 2: kpKrzywaKardynalna.kpPunkt03 = e.Location; break;
                            case 3: kpKrzywaKardynalna.kpPunkt04 = e.Location; break;
                            case 4: kpKrzywaKardynalna.kpPunkt05 = e.Location; break;
                        }
                        if (kpKrzywaKardynalna.kpNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Red))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush kpPędzel = new SolidBrush(Color.Black))
                            {
                                kpRysownica.FillEllipse(kpPędzel,
                                 e.Location.X - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                e.Location.Y - kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego,
                                2 * kpKrzywaKardynalna.kpPromieńPunktuKontrolnego);
                                kpRysownica.DrawString("p" + kpKrzywaKardynalna.kpNumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, kpPędzel, e.Location);
                            }
                            PointF[] points = {
                                kpKrzywaKardynalna.kpPunkt01,
                                kpKrzywaKardynalna.kpPunkt02,
                                kpKrzywaKardynalna.kpPunkt03,
                                kpKrzywaKardynalna.kpPunkt04,
                                kpKrzywaKardynalna.kpPunkt05};
                            kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                            kpRysownica.FillClosedCurve(kpPędzel, points);
                            kpgbWybierzFigurę.Enabled = true;
                        }
                    }
                }


                if (kprdbDrawPie.Checked)
                {

                    //Rectangle rect = new Rectangle(
                    //kpLewyGórnyNarożnikY, kpLewyGórnyNarożnikX, kpWysokość, kpSzerokość);
                    //kpRysownica.DrawPie(kpPióro, rect, 0.0f, 90.0f);

                }


                if (kprdbFillPie.Checked)
                {

                    Rectangle rect = new Rectangle(
       kpLewyGórnyNarożnikY, kpLewyGórnyNarożnikX, kpWysokość, kpSzerokość);
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPie(kpPędzel, rect, 0.0f, 90.0f);

                }


                if (kprdbDrawArc.Checked)
                {
                    ushort kpStopieńWielokąta = 1000;
                    int R = kpSzerokość;
                    double kpKątPołożeniaPierwszegoWierzchołka = 90.0;
                    double kpKątMiędzyWierzchołkamiWielokąta = 90.0 / kpStopieńWielokąta;
                    Point[] kpWierzchołkiWielokąta = new Point[kpStopieńWielokąta];
                    for (int i = 0; i < kpStopieńWielokąta; i++)
                    {
                        kpWierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX + (int)(R * Math.Cos(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 180.0));

                        kpWierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY + (int)(R * Math.Sin(Math.PI
                            * (kpKątPołożeniaPierwszegoWierzchołka + i * kpKątMiędzyWierzchołkamiWielokąta) / 180.0));

                    }
                    kpRysownica.DrawPolygon(kpPióro, kpWierzchołkiWielokąta);
                }

                if (kprdbWielokątForemny.Checked)
                {
                    
                    ushort StopieńWielokąta = (ushort)kpnumKąty.Value;
                    int R = kpSzerokość;
                    double KątPołożeniaPierwszegoWierzchołka = 0.0;
                    double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));

                        WierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));
                    }
                   
                    kpRysownica.DrawPolygon(kpPióro, WierzchołkiWielokąta);

                }

                if (kprdbWielokątWypełniony.Checked)
                {
                    ushort StopieńWielokąta = (ushort)kpnumKąty.Value;
                    int R = kpSzerokość;
                    double KątPołożeniaPierwszegoWierzchołka = 0.0;
                    double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        WierzchołkiWielokąta[i].X = kpLewyGórnyNarożnikX +
                          (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));

                        WierzchołkiWielokąta[i].Y = kpLewyGórnyNarożnikY +
                          (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                            i * KątMiędzyWierzchołkamiWielokąta) / 180));
                    }
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                    kpRysownica.FillPolygon(kpPędzel, WierzchołkiWielokąta);
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
