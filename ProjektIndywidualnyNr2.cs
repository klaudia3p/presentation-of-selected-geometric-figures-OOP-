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
using static ProjektNr2_Plutka_62026.KPFiguryGeometryczne;

using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Drawing.Printing;
using static ProjektNr2_Plutka_62026.KPFiguryGeometryczne.kpPunkt;

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


        const int kpMargines = 10;
        Point kpPunkt = Point.Empty;
        Graphics kpRysownica;
        Pen kpPióro;
        SolidBrush kpPędzel;
        const ushort kpPromienPunktu = 2;
        List<kpPunkt> kpLFG = new List<kpPunkt>();
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
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                Bitmap bmp = new Bitmap(kppbRysownica.Width, kppbRysownica.Height);
                kppbRysownica.DrawToBitmap(bmp, kppbRysownica.ClientRectangle);
                bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
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
            kpPędzel.Color = kpPaletaKolorów.Color;
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
                    kpLFG.Add(new KPFiguryGeometryczne.kpPunkt(kpPunkt.X, kpPunkt.Y,
                        kptxtKolorLini.BackColor));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbLiniaProsta.Checked)
                {
                   
                    kpLFG.Add(new kpLiniaProsta(kpPunkt.X, kpPunkt.Y, e.Location.X, e.Location.Y,
                        kptxtKolorLini.BackColor, (DashStyle)kpcbStylLini.SelectedIndex,
                        kptbGrubośćLini.Value));
                    kpPióro.Color = kptxtKolorLini.BackColor;
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();
                }


                if (kprdbLiniaCiągłaKreślonaMyszą.Checked)
                {
                    //    kpRysownica.DrawLine(kpPióro,
                    //        kpPunkt.X,
                    //        kpPunkt.Y,
                    //        e.Location.X,
                    //        e.Location.Y);
                    kpLFG.Add(new kpLiniaCiągłaKreślonaMyszą(kpPunkt.X, kpPunkt.Y, e.Location.X, e.Location.Y,
                           kptxtKolorLini.BackColor, (DashStyle)kpcbStylLini.SelectedIndex,
                           kptbGrubośćLini.Value));
                    kpPióro.Color = kptxtKolorLini.BackColor;
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();
                }


                if (kprdbProstokąt.Checked)
                {
                    kpLFG.Add(new kpProstokąt(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kptxtKolorLini.BackColor,
                        (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbKwadrat.Checked)
                {
                    kpLFG.Add(new kpKwadrat(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kptxtKolorLini.BackColor,
                       (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbOkrąg.Checked)
                {
                
                    kpLFG.Add(new kpOkrąg(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kptxtKolorLini.BackColor,
                            (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbKoło.Checked)
                {
                    kpPędzel.Color = kpbtnKolorWypełnienia.BackColor;
                   
                    kpLFG.Add(new kpKoło(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kpbtnKolorWypełnienia.BackColor,
                            (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();
                }


                if (kprdbElipsa.Checked)
                {

                    kpLFG.Add(new kpElipsa(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kptxtKolorLini.BackColor,
                        (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();
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
                    kpLFG.Add(new kpKrzywaBeziera(kpPunkt.X, kpPunkt.Y, e.Location.X, e.Location.Y,
                  kptxtKolorLini.BackColor, (DashStyle)kpcbStylLini.SelectedIndex,
                  kptbGrubośćLini.Value));
                    kpPióro.Color = kptxtKolorLini.BackColor;
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

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

                    kpLFG.Add(new kpFillRectangle(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kpbtnKolorWypełnienia.BackColor,
                        (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbFillElipse.Checked)
                {
                    kpLFG.Add(new kpFillEllipse(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kpbtnKolorWypełnienia.BackColor,
                      (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();
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

                    kpLFG.Add(new kpDrawPie(kpPunkt.X, kpPunkt.Y,kpWysokość,kpSzerokość, kptxtKolorLini.BackColor,
                     (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbFillPie.Checked)
                {

                    kpLFG.Add(new kpFillPie(kpPunkt.X, kpPunkt.Y, kpWysokość, kpSzerokość, kpbtnKolorWypełnienia.BackColor,
                                 (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();

                }


                if (kprdbDrawArc.Checked)
                {
                    kpLFG.Add(new kpDrawArc(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość,0, 90, kptxtKolorLini.BackColor,
                        (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                    kppbRysownica.Refresh();
                }

                if (kprdbWielokątForemny.Checked)
                {

                    kpLFG.Add(new kpWielokątForemny(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość, kptxtKolorLini.BackColor,
                          (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);
                   
                    kppbRysownica.Refresh();

            }

                if (kprdbWielokątWypełniony.Checked)
                {

                    kpLFG.Add(new kpWielokątWypełniony(kpPunkt.X, kpPunkt.Y, kpSzerokość, kpWysokość,kpbtnKolorWypełnienia.BackColor,
                          (DashStyle)kpcbStylLini.SelectedIndex, kptbGrubośćLini.Value));
                    kpLFG[kpLFG.Count - 1].kpWykreśl(kpRysownica);

                    kppbRysownica.Refresh();
                }
            }
            kppbRysownica.Refresh();

        }

        private void kpbtnWczytaj_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
            openFileDialog1.Title = "Open an Image File";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                kppbRysownica.Image = bmp;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kpWybranyStyl = kpcbStylLini.SelectedItem.ToString();
           
            switch (kpWybranyStyl)
            {
                case "Solid":
                    kpPióro.DashStyle = DashStyle.Solid;
                    break;
                case "Dash":
                    kpPióro.DashStyle = DashStyle.Dash;
                    break;
                case "Dot":
                    kpPióro.DashStyle = DashStyle.Dot;
                    break;
                case "DashDot":
                    kpPióro.DashStyle = DashStyle.DashDot;
                    break;
                case "DashDotDot":
                    kpPióro.DashStyle = DashStyle.DashDotDot;
                    break;
                default:
                    break;
            }
        }

        private void kptbGrubośćLini_Scroll(object sender, EventArgs e)
        {

            int kplineWidth = kptbGrubośćLini.Value;
            kpPióro.Width = kplineWidth;
        }

        private void kpbtnKolorLini_Click(object sender, EventArgs e)
        {
            ColorDialog kpPaletaKolorów = new ColorDialog();
            kpPaletaKolorów.Color = kpbtnKolorWypełnienia.BackColor;

            if (kpPaletaKolorów.ShowDialog() == DialogResult.OK)
                kptxtKolorLini.BackColor = kpPaletaKolorów.Color;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Random rand = new Random();
            //int x = rand.Next(kppbRysownica.Width);
            //int y = rand.Next(kppbRysownica.Height);
            //int width = rand.Next(kppbRysownica.Width - x);
            //int height = rand.Next(kppbRysownica.Height - y);
            //Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            //Rectangle rect = new Rectangle(x, y, width, height);

            //Bitmap bmp = new Bitmap(kppbRysownica.Width, kppbRysownica.Height);
            //Graphics g = Graphics.FromImage(bmp);
            //g.FillRectangle(new SolidBrush(color), rect);
            //kppbRysownica.Image = bmp;
        }

        private void ProjektIndywidualnyNr2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void kpbtnPokazFigur_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            kpRysownica.Clear(kppbRysownica.BackColor);
            if(kprdbPokazAutomatyczny.Checked)
            {
                //wpisanie numeru figury startowej
                kptxtNumerFiguryIndeks.Text = 0.ToString();
                //uaktywniwne
                timer1.Enabled = true;
                //uaktywnienie przyciusku Wylącz pokaz
                kpbtnWyłączPokazSlajdów.Enabled = true;
                kpbtnPokazFigur.Enabled = false;
            }
            else
            {//uaktywniwnie przysiskow nastepny i poprzedni
                kpbtnNastępny.Enabled = true;
                kpbtnPoprzedni.Enabled = true;
                //odczytanie numeru figury wpisanej do  txt
                int N= ushort.Parse(kptxtNumerFiguryIndeks.Text);

                //wykreslenie pierwszyej figury
                kpLFG[N].kpPrzesuńDoNowegoXY(kppbRysownica, kpRysownica, 
                    kppbRysownica.Width/2, kppbRysownica.Height/2);
                kpbtnWyłączPokazSlajdów.Enabled = true;
                kpbtnPokazFigur.Enabled = false;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x = rand.Next(kppbRysownica.Width);
            int y = rand.Next(kppbRysownica.Height);
            int width = rand.Next(kppbRysownica.Width - x);
            int height = rand.Next(kppbRysownica.Height - y);
            Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Rectangle rect = new Rectangle(x, y, width, height);

            Bitmap bmp = new Bitmap(kppbRysownica.Width, kppbRysownica.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(color), rect);
            kppbRysownica.Image = bmp;
        }

        private void kpbtnPrzesuńFigury_Click(object sender, EventArgs e)
        {//deklaracja pomocnicze
            int Xn, Yn;
            Random kprnd = new Random();

            //wyczyszczenie powierzchni graficznej
            kpRysownica.Clear(kppbRysownica.BackColor);
            //okreslenie rozmiarow powierzchni graficznej
            int Xmax = kppbRysownica.Width;
            int Ymax = kppbRysownica.Height;
            //przesuwnaoe f geom z listy LFG
            for(int i = 0; i<kpLFG.Count; i++)
            {
                //wylososwanie nowego polozenia
                Xn = kprnd.Next(kpMargines, Xmax - kpMargines);
                Yn = kprnd.Next(kpMargines, Ymax - kpMargines);
                //przesuniecie do nowego polozenia
                kpLFG[i].kpPrzesuńDoNowegoXY(kppbRysownica, kpRysownica, Xn, Yn);
            }
            kppbRysownica.Refresh();
        }

        private void kptxtNumerFiguryIndeks_TextChanged(object sender, EventArgs e)
        {
            ushort N;
            if (!ushort.TryParse(kptxtNumerFiguryIndeks.Text, out N))
            {
                errorProvider1.SetError(kptxtNumerFiguryIndeks, "ERROR: w zapisie numeru indeksu figury geometrycznej wystąpił niedozwolony znak");
                return;
            }
            //sprawdzenie n na dozwolona gorna wartosc
            if(N> kpLFG.Count)
            {
                errorProvider1.SetError(kptxtNumerFiguryIndeks, "ERROR:  podano zbyt wysoką wartość(Przekroczono liczbę figur geometrycznych w LFG)");
                return;
            }

        }

        private void kppbRysownica_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
