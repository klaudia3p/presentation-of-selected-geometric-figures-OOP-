using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjektNr2_Plutka_62026.FiguryGeometryczne;

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
            kpDrawClosedCurve, kpFillEllipse, kpKrzywaKardynalna, kpDrawArc, kpFillPie, kpDrawPie, kpFillClosedCurve};
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
        public class kpKoło: kpPunkt
        {
            protected int kpOśDuża, kpOśMała;
            public kpKoło(int kpx, int kpy, int kpośDuża, int kpośMała, Color kpKolor,
                DashStyle kpStylLini, float kpGrubośćLini) : base(kpx, kpy, kpKolor)
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
        }


    }//KPFiguryGeom

}//class Projekt
