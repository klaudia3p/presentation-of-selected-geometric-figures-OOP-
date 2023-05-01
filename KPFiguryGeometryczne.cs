using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjektNr2_Plutka_62026.FiguryGeometryczne;
using static ProjektNr2_Plutka_62026.KPFiguryGeometryczne;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Net;

namespace ProjektNr2_Plutka_62026
{
    internal class KPFiguryGeometryczne
    {
        public class kpPunkt
        {
            const int kpPromieńPunktu = 5;
            public enum kpFiguryGeometryczne : byte
            { kpPunkt, kpLiniaProsta, kpElipsa, kpProstokąt, kpOkrąg, kpKwadrat, kpKoło, kpWielokątForemny,
                kpWielokątWypełniony, kpKrzywaBeziera, kpLiniaCiągłaKreślonaMyszą, kpFillRectangle,
                kpDrawClosedCurve, kpFillEllipse, kpKardynalna, kpDrawArc, kpFillPie, kpDrawPie, kpFillClosedCurve };
            public kpFiguryGeometryczne kpFigura
            {
                get;
                protected set;
            }
            public bool kpWidoczny
            {
                get;
                protected set;
            }
            public int kpŚrednicaPunktu
            {
                get;
                protected set;
            }
            public int kpX
            {
                get;
                protected set;
            }
            public int kpY
            {
                get;
                protected set;
            }

            public Color kpKolor
            {
                get;
                protected set;
            }
            public float kpGrubośćLini
            {
                get;
                protected set;
            }
            public DashStyle kpStylLini
            {
                get;
                protected set;
            }
            public Color kpKolorWypełnienia
            {
                get;
                protected set;
            }
            public kpPunkt(int kpX, int kpY)
            {
                kpFigura = kpFiguryGeometryczne.kpPunkt;
                kpWidoczny = false;
                kpŚrednicaPunktu = 2 * kpPromieńPunktu;
                this.kpX = kpX;
                this.kpY = kpY;
                //kpKolor = Color.Black;
                //kpGrubośćLini = 1.0F;
                //kpStylLini = DashStyle.Solid;
                //kpKolorWypełnienia = Color.LightCoral;
            }
            public kpPunkt(int kpX, int kpY, Color kpKolor) : this(kpX, kpY)
            {
                this.kpKolor = kpKolor;
            }
            public kpPunkt(int kpX, int kpY, Color kpKolor, int kpŚrednicaPunktu) : this(kpX, kpY, kpKolor)
            {
                this.kpŚrednicaPunktu = kpŚrednicaPunktu;
            }
            public virtual void kpWykreśl(Graphics kpRysownica)
            {
                //WERSJA 1

                SolidBrush kpPędzel = new SolidBrush(kpKolor);
                kpRysownica.FillEllipse(kpPędzel,
                    kpX - kpŚrednicaPunktu / 2,
                    kpY - kpŚrednicaPunktu / 2,
                    kpŚrednicaPunktu, kpŚrednicaPunktu);
                kpWidoczny = true;
                kpPędzel.Dispose();


                //WERSJA 2

                using (SolidBrush kpPędzel2 = new SolidBrush(kpKolor))
                {
                    kpRysownica.FillEllipse(kpPędzel2,
                        kpX - kpŚrednicaPunktu / 2,
                        kpY - kpŚrednicaPunktu / 2,
                        kpŚrednicaPunktu, kpŚrednicaPunktu);
                    kpWidoczny = true;
                }

            }
            public virtual void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (SolidBrush kpPędzel = new SolidBrush(kpKontrolka.BackColor))
                    {
                        kpRysownica.FillEllipse(kpPędzel,
                            kpX - kpŚrednicaPunktu / 2,
                            kpY - kpŚrednicaPunktu / 2,
                            kpŚrednicaPunktu, kpŚrednicaPunktu);
                        kpWidoczny = false;
                    }
            }
            public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {//nowe polozenie puktu
                kpX = kpXn; kpY = kpYn;
                //wykreslenie punktu w nowym polozeniu
                kpWykreśl(kpRysownica);

            }

        }//kpPunkt
        public class kpLiniaProsta : kpPunkt
        {
            int kpXk, kpYk;

            public kpLiniaProsta(int kpXp, int kpYp, int kpXk, int kpYk) : base(kpXp, kpYp)
            {
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                kpFigura = kpFiguryGeometryczne.kpLiniaProsta;
            }
            public kpLiniaProsta(int kpXp, int kpYp, int kpXk, int kpYk, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpXp, kpYp, kpKolorLini)
            {

                kpFigura = kpFiguryGeometryczne.kpLiniaProsta;
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                {
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                        kpWidoczny = false;
                    }
                }
            }
            public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {
                int kpDx, kpDy;
                if (kpXn > kpX)
                    kpDx = kpXn - kpX;
                else
                    kpDx = kpX - kpXn;
                if (kpXn > kpY)
                    kpDy = kpYn - kpY;
                else
                    kpDy = kpY - kpYn;
                kpX = kpXn;
                kpY = kpYn;
                kpXk = (kpXk + kpDx) % kpKontrolka.Width;
                kpYk = (kpYk + kpDy) % kpKontrolka.Height;
                kpWykreśl(kpRysownica);
            }

        }//linia
        public class kpElipsa : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpElipsa(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpElipsa;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawEllipse(kpPióro, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawEllipse(kpPióro, kpX - kpOśDuża / 2, kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                        kpWidoczny = false;
                    }
            }

        }//elipsa
        public class kpOkrąg : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpOkrąg(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpOkrąg;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawEllipse(kpPióro, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2, kpOśDuża, kpOśDuża);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawEllipse(kpPióro, kpX - kpOśDuża / 2, kpY - kpOśMała / 2, kpOśDuża, kpOśDuża);
                        kpWidoczny = false;
                    }
            }
        }//okrag
        public class kpKoło : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpKoło(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolor,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolor)
            {
                kpFigura = kpFiguryGeometryczne.kpKoło;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (SolidBrush kpPędzel = new SolidBrush(kpKolor))
                {
                    kpRysownica.FillEllipse(kpPędzel, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2,
                        kpOśDuża, kpOśDuża);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (SolidBrush kpPędzel = new SolidBrush(kpKontrolka.BackColor))
                    {
                        kpRysownica.FillEllipse(kpPędzel, kpX - kpOśDuża / 2,
                            kpY - kpOśMała / 2,
                            kpOśDuża, kpOśDuża);
                        kpWidoczny = false;
                    }
            }
        }//kolo
        public class kpProstokąt : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpProstokąt(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpProstokąt;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawRectangle(kpPióro, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawRectangle(kpPióro, kpX - kpOśDuża / 2, kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                        kpWidoczny = false;
                    }
            }
        }//prostokat
        public class kpFillRectangle : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpFillRectangle(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolor,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolor)
            {
                kpFigura = kpFiguryGeometryczne.kpFillRectangle;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (SolidBrush kpPędzel = new SolidBrush(kpKolor))
                {
                    kpRysownica.FillRectangle(kpPędzel, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (SolidBrush kpPędzel = new SolidBrush(kpKontrolka.BackColor))
                    {
                        kpRysownica.FillRectangle(kpPędzel, kpX - kpOśDuża / 2, kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                        kpWidoczny = false;
                    }
            }
        }//fillRectangle
        public class kpKwadrat : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpKwadrat(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpKwadrat;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawRectangle(kpPióro, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2, kpOśDuża, kpOśDuża);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawRectangle(kpPióro, kpX - kpOśDuża / 2,
                            kpY - kpOśMała / 2, kpOśDuża, kpOśDuża);
                        kpWidoczny = false;
                    }
            }
        }//kwadrat
        public class kpFillEllipse : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpFillEllipse(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpFillEllipse;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (SolidBrush kpPędzel = new SolidBrush(kpKolor))
                {
                    kpRysownica.FillEllipse(kpPędzel, kpX - kpOśDuża / 2,
                        kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (SolidBrush kpPędzel = new SolidBrush(kpKontrolka.BackColor))
                    {
                        kpRysownica.FillEllipse(kpPędzel, kpX - kpOśDuża / 2, kpY - kpOśMała / 2, kpOśDuża, kpOśMała);
                        kpWidoczny = false;
                    }
            }
        }//fillellipse
        public class kpDrawPie : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            Rectangle rectl;
            public kpDrawPie(int kpX, int kpY, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpX, kpY, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpDrawPie;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;
                Rectangle rect = new Rectangle(kpX, kpY, kpośDuża, kpośMała);
                rectl = rect;
            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawPie(kpPióro, rectl, 0.0f, 90.0f);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawPie(kpPióro, rectl, 0.0f, 90.0f);
                        kpWidoczny = false;
                    }
            }
        }//drawpie
        public class kpFillPie : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            Rectangle rectl;
            public kpFillPie(int kpX, int kpY, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpX, kpY, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpFillPie;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;
                Rectangle rect = new Rectangle(kpX, kpY, kpośDuża, kpośMała);
                rectl = rect;
            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (SolidBrush kpPędzel = new SolidBrush(kpKolor))
                {
                    kpRysownica.FillPie(kpPędzel, rectl, 0.0f, 90.0f);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (SolidBrush kpPędzel = new SolidBrush(kpKontrolka.BackColor))
                    {
                        kpRysownica.FillPie(kpPędzel, rectl, 0.0f, 90.0f);
                        kpWidoczny = false;
                    }
            }
          
        }//fillpie
        public class kpDrawArc : kpPunkt
        {
            protected int kpOśDuża, kpOśMała, kpSweepAngle, kpStartAngle;
            public kpDrawArc(int kpx, int kpy, int kpośDuża, int kpośMała, int sweepAngle, int startAngle, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpDrawArc;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                kpSweepAngle = sweepAngle;
                kpStartAngle = startAngle;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawArc(kpPióro, kpX, kpY, kpOśDuża, kpOśDuża, kpSweepAngle, kpStartAngle);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawArc(kpPióro, kpX, kpY, kpOśDuża, kpOśDuża, kpSweepAngle, kpStartAngle);
                        kpWidoczny = false;
                    }
            }
        }//darwarc
        public class kpWielokątForemny : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            Point[] WierzchołkiWielokąta;
            public kpWielokątForemny(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpWielokątForemny;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;


            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                ushort StopieńWielokąta = 5;
                int R = kpOśMała;
                double KątPołożeniaPierwszegoWierzchołka = 0.0;
                double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    WierzchołkiWielokąta[i].X = kpX - kpOśDuża / 2 +
                      (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                        i * KątMiędzyWierzchołkamiWielokąta) / 180));

                    WierzchołkiWielokąta[i].Y = kpY - kpOśMała / 2 +
                      (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                        i * KątMiędzyWierzchołkamiWielokąta) / 180));
                }
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawPolygon(kpPióro, WierzchołkiWielokąta);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawPolygon(kpPióro, WierzchołkiWielokąta);
                        kpWidoczny = false;
                    }
            }
        }//wielokat foremny
        public class kpWielokątWypełniony : kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            Point[] WierzchołkiWielokąta;
            public kpWielokątWypełniony(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolorLini)
            {
                kpFigura = kpFiguryGeometryczne.kpWielokątWypełniony;
                kpWidoczny = false;
                kpOśDuża = kpośDuża;
                kpOśMała = kpośMała;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;


            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                ushort StopieńWielokąta = 5;
                int R = kpOśMała;
                double KątPołożeniaPierwszegoWierzchołka = 0.0;
                double KątMiędzyWierzchołkamiWielokąta = 360.0 / StopieńWielokąta;
                Point[] WierzchołkiWielokąta = new Point[StopieńWielokąta];
                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    WierzchołkiWielokąta[i].X = kpX - kpOśDuża / 2 +
                      (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                        i * KątMiędzyWierzchołkamiWielokąta) / 180));

                    WierzchołkiWielokąta[i].Y = kpY - kpOśMała / 2 +
                      (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                        i * KątMiędzyWierzchołkamiWielokąta) / 180));
                }
                using (SolidBrush kpPędzel = new SolidBrush(kpKolor))
                {
                    kpRysownica.FillPolygon(kpPędzel, WierzchołkiWielokąta);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                    using (SolidBrush kpPędzel = new SolidBrush(kpKontrolka.BackColor))
                    {
                        kpRysownica.FillPolygon(kpPędzel, WierzchołkiWielokąta);
                        kpWidoczny = false;
                    }
            }
        }//wielokat wypelniony
        public class kpLiniaCiągłaKreślonaMyszą : kpPunkt
        {
            int kpXk, kpYk;
            int kpXp, kpYp;
            public kpLiniaCiągłaKreślonaMyszą(int kpXp, int kpYp, int kpXk, int kpYk) : base(kpXp, kpYp)
            {
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                kpFigura = kpFiguryGeometryczne.kpLiniaCiągłaKreślonaMyszą;
            }
            public kpLiniaCiągłaKreślonaMyszą(int kpXp, int kpYp, int kpXk, int kpYk, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpXp, kpYp, kpKolorLini)
            {

                kpFigura = kpFiguryGeometryczne.kpLiniaCiągłaKreślonaMyszą;
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }
            public override void kpWykreśl(Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                    kpWidoczny = true;
                }
            }
            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                {
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                        kpWidoczny = false;
                    }
                }
            }
            public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {
                int kpDx, kpDy;
                if (kpXn > kpX)
                    kpDx = kpXn - kpX;
                else
                    kpDx = kpX - kpXn;
                if (kpXn > kpY)
                    kpDy = kpYn - kpY;
                else
                    kpDy = kpY - kpYn;
                kpX = kpXn;
                kpY = kpYn;
                kpXk = (kpXk + kpDx) % kpKontrolka.Width;
                kpYk = (kpYk + kpDy) % kpKontrolka.Height;
                kpWykreśl(kpRysownica);
            }

        }//linia ciagla kreslona mysza
        public class kpKrzywaBeziera : kpPunkt
        {
            int kpX, kpY;

            Point startPoint = new Point();
            Point controlPoint1 = new Point();
            Point controlPoint2 = new Point();
            Point endPoint = new Point();
            private int x;
            private int y;
            private Color backColor;
            private DashStyle selectedIndex;
            private int value;

            // public kpKrzywaBeziera(float kpX1, float kpY1, float kpX2, float kpY2, float kpX3, float kpY3, float kpX4, float kpY4) : base(kpX1, kpY1)
            // {
            //     this.kpX1 = kpX1;
            //     this.kpY1 = kpY1;
            //     this.kpX2 = kpX2;
            //     this.kpY2 = kpY2;
            //     this.kpX3 = kpX3;
            //     this.kpY3 = kpY3;
            //     this.kpX4 = kpX4;
            //     this.kpY4 = kpY4;
            //     kpFigura = kpFiguryGeometryczne.kpKrzywaBeziera;
            //}
            public kpKrzywaBeziera(int kpX,int kpY,Point kstartPoint, Point controlPoint1, Point controlPoint2, Point endPoint, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpX, kpY, kpKolorLini)
            {
                this.kpX = kpX;
                this.kpY = kpY;
                kpFigura = kpFiguryGeometryczne.kpKrzywaBeziera;
                
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }

            public kpKrzywaBeziera(int kpX, int kpY, int x, int y, Color backColor, DashStyle selectedIndex, int value) : base(kpX, kpY)
            {
                this.x = x;
                this.y = y;
                this.backColor = backColor;
                this.selectedIndex = selectedIndex;
                this.value = value;
            }

            public void kpWykreśl(Point endPoint, Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;
                    kpRysownica.DrawBezier(kpPióro, startPoint, controlPoint1, controlPoint2, endPoint);
                    kpWidoczny = true;
                }
            }

public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                {
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawBezier(kpPióro, startPoint, controlPoint1, controlPoint2, endPoint);
                        kpWidoczny = false;
                    }
                }
            }
        public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {
                int kpDx, kpDy;
                if (kpXn > kpX)
                    kpDx = kpXn - kpX;
                else
                    kpDx = kpX - kpXn;
                if (kpXn > kpY)
                    kpDy = kpYn - kpY;
                else
                    kpDy = kpY - kpYn;
                kpX = kpXn;
                kpY = kpYn;
                kpX = (kpX + kpDx) % kpKontrolka.Width;
                kpY = (kpY + kpDy) % kpKontrolka.Height;
                kpWykreśl(kpRysownica);
            }

    

    }//krzywa beziera
        public class kpKardynalna : kpPunkt
        {


            int kpXk, kpYk;
            int kpXp, kpYp;
            public kpKardynalna(int kpXp, int kpYp, int kpXk, int kpYk) : base(kpXp, kpYp)
            {
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                kpFigura = kpFiguryGeometryczne.kpKardynalna;
            }
            public kpKardynalna(int kpXp, int kpYp, int kpXk, int kpYk, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpXp, kpYp, kpKolorLini)
            {

                kpFigura = kpFiguryGeometryczne.kpKardynalna;
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }


            public void kpWykreśl(Point endPoint, Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;

                    kpWidoczny = true;
                }
            }

            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                {
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                        kpWidoczny = false;
                    }
                }
            }
            public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {
                int kpDx, kpDy;
                if (kpXn > kpX)
                    kpDx = kpXn - kpX;
                else
                    kpDx = kpX - kpXn;
                if (kpXn > kpY)
                    kpDy = kpYn - kpY;
                else
                    kpDy = kpY - kpYn;
                kpX = kpXn;
                kpY = kpYn;
                kpXk = (kpXk + kpDx) % kpKontrolka.Width;
                kpYk = (kpYk + kpDy) % kpKontrolka.Height;
                kpWykreśl(kpRysownica);
            }



        }//kardynalna
        public class kpDrawClosedCurve : kpPunkt
        {


            int kpXk, kpYk;
            int kpXp, kpYp;
            public kpDrawClosedCurve(int kpXp, int kpYp, int kpXk, int kpYk) : base(kpXp, kpYp)
            {
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                kpFigura = kpFiguryGeometryczne.kpDrawClosedCurve;
            }
            public kpDrawClosedCurve(int kpXp, int kpYp, int kpXk, int kpYk, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpXp, kpYp, kpKolorLini)
            {

                kpFigura = kpFiguryGeometryczne.kpDrawClosedCurve;
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }


            public void kpWykreśl(Point endPoint, Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;

                    kpWidoczny = true;
                }
            }

            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                {
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        //kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                        kpWidoczny = false;
                    }
                }
            }
            public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {
                int kpDx, kpDy;
                if (kpXn > kpX)
                    kpDx = kpXn - kpX;
                else
                    kpDx = kpX - kpXn;
                if (kpXn > kpY)
                    kpDy = kpYn - kpY;
                else
                    kpDy = kpY - kpYn;
                kpX = kpXn;
                kpY = kpYn;
                kpXk = (kpXk + kpDx) % kpKontrolka.Width;
                kpYk = (kpYk + kpDy) % kpKontrolka.Height;
                kpWykreśl(kpRysownica);
            }



        }//draw closed curve
        public class kpFillClosedCurve : kpPunkt
        {


            int kpXk, kpYk;
            int kpXp, kpYp;
            public kpFillClosedCurve(int kpXp, int kpYp, int kpXk, int kpYk) : base(kpXp, kpYp)
            {
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                kpFigura = kpFiguryGeometryczne.kpFillClosedCurve;
            }
            public kpFillClosedCurve(int kpXp, int kpYp, int kpXk, int kpYk, Color kpKolorLini,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpXp, kpYp, kpKolorLini)
            {

                kpFigura = kpFiguryGeometryczne.kpFillClosedCurve;
                this.kpXk = kpXk;
                this.kpYk = kpYk;
                this.kpStylLini = kpStylLini;
                this.kpGrubośćLini = kpGrubośćLini;

            }


            public void kpWykreśl(Point endPoint, Graphics kpRysownica)
            {
                using (Pen kpPióro = new Pen(kpKolor, kpGrubośćLini))
                {
                    kpPióro.DashStyle = kpStylLini;

                    kpWidoczny = true;
                }
            }

            public override void kpWymaż(Control kpKontrolka, Graphics kpRysownica)
            {
                if (kpWidoczny)
                {
                    using (Pen kpPióro = new Pen(kpKontrolka.BackColor, kpGrubośćLini))
                    {
                        kpPióro.DashStyle = kpStylLini;
                        //kpRysownica.DrawLine(kpPióro, kpX, kpY, kpXk, kpYk);
                        kpWidoczny = false;
                    }
                }
            }
            public virtual void kpPrzesuńDoNowegoXY(Control kpKontrolka, Graphics kpRysownica, int kpXn, int kpYn)
            {
                int kpDx, kpDy;
                if (kpXn > kpX)
                    kpDx = kpXn - kpX;
                else
                    kpDx = kpX - kpXn;
                if (kpXn > kpY)
                    kpDy = kpYn - kpY;
                else
                    kpDy = kpY - kpYn;
                kpX = kpXn;
                kpY = kpYn;
                kpXk = (kpXk + kpDx) % kpKontrolka.Width;
                kpYk = (kpYk + kpDy) % kpKontrolka.Height;
                kpWykreśl(kpRysownica);
            }



        }//fill closed curve
    }//KPFiguryGeom

    }//class Projekt
