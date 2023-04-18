using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr2_Plutka_62026
{
    internal class KPFiguryGeometryczne
    {
        public class kpPunkt
        {
            const int kpPromieńPunktu = 5;
            public enum kpFiguryGeometryczne : byte
            { kpPunkt, kpLinia, kpElipsa, kpProstokąt, kpOkrąg, kpKwadrat };
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
                kpKolor = Color.Black;
                kpGrubośćLini = 1.0F;
                kpStylLini = DashStyle.Solid;
                kpKolorWypełnienia = Color.LightCoral;
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

    }//KPFiguryGeom

}//class Projekt
