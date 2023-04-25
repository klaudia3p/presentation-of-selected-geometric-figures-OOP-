using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjektNr2_Plutka_62026.FiguryGeometryczne;

namespace ProjektNr2_Plutka_62026
{
    internal class FiguryGeometryczne
    {
        //deklaracja głównej klasy baqzowej
        public class Punkt
        {
            //pomocnoiczr deklaracje
            const int PromieńPunktu = 5;
            //deklaracja typu wyliczeniowego
            public enum FiguryGeometryczne : byte
            { Punkt, Linia, Elipsa, Prostokąt, Okrąg, Kwadrat };
            //deklaracje atrybutów których wartości opisują konkretny egzemplarz figury geometrycznej
            public FiguryGeometryczne Figura
            {
                get;
                protected set;
            } //tylko dla tej klasy
            //atrybut widocznisci
            public bool Widoczny
            {
                get;
                protected set;
            }
            public int ŚrednicaPunktu
            {
                get;
                protected set;
            }
            public int X
            {
                get;
                protected set;
            }
            public int Y
            {
                get;
                protected set;
            }
            public Color Kolor
            {
                get;
                protected set;
            }
            //deklaracje atrybutów waznych dla klas potomnych
            public float GrubośćLini
            {
                get;
                protected set;
            }
            public DashStyle StylLini
            {
                get;
                protected set;
            }
            public Color KolorWypełnienia
            {
                get;
                protected set;
            }
            //deklaracja konstruktorów klasy Punkt
            public Punkt(int X, int Y)
            {
                Figura = FiguryGeometryczne.Punkt;
                Widoczny = false;
                ŚrednicaPunktu = 2 * PromieńPunktu;
                this.X = X;
                this.Y = Y;
                Kolor = Color.Black;
                GrubośćLini = 1.0F;
                StylLini = DashStyle.Solid;
                KolorWypełnienia = Color.LightCoral;
            }
            public Punkt(int X, int Y, Color Kolor) : this(X, Y)
            {
                //uaktualnienie koloru
                this.Kolor = Kolor;
            }
            public Punkt(int X, int Y, Color Kolor, int ŚrednicaPunktu) : this(X, Y, Kolor)
            {
                //uaktualnienie średnicy punktu
                this.ŚrednicaPunktu = ŚrednicaPunktu;
            }
            //deklaracje metod


            //deklaaracja metod wirtualnych
            public virtual void Wykreśl(Graphics Rysownica)
            {
                //WERSJA 1
                //utworzenie Pędzla
                SolidBrush Pędzel = new SolidBrush(Kolor);
                //wykreślenie punktu
                Rysownica.FillEllipse(Pędzel,
                    X - ŚrednicaPunktu / 2,
                    Y - ŚrednicaPunktu / 2,
                    ŚrednicaPunktu, ŚrednicaPunktu);
                //zapalenie atrybutu widocznosc
                Widoczny = true;
                //zwolnienie pióra
                Pędzel.Dispose();


                //WERSJA 2
                using (SolidBrush Pędzel2 = new SolidBrush(Kolor))
                {
                    //wykreślenie punktu
                    Rysownica.FillEllipse(Pędzel2,
                        X - ŚrednicaPunktu / 2,
                        Y - ŚrednicaPunktu / 2,
                        ŚrednicaPunktu, ŚrednicaPunktu);
                    //zapalenie atrybutu widocznosc
                    Widoczny = true;
                }

            }
            public virtual void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                //sprawdzenie atrybutu widoczosci
                if (Widoczny)
                    using (SolidBrush Pędzel = new SolidBrush(Kontrolka.BackColor))
                    {
                        //wymazanie punktu
                        Rysownica.FillEllipse(Pędzel,
                            X - ŚrednicaPunktu / 2,
                            Y - ŚrednicaPunktu / 2,
                            ŚrednicaPunktu, ŚrednicaPunktu);
                        //zgaszenie atrybutu widocznosc
                        Widoczny = false;
                    }
            }

            public virtual void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int Xn, int Yn)
            {//nowe polozenie puktu
                X = Xn; Y = Yn;
                //wykreslenie punktu w nowym polozeniu
                Wykreśl(Rysownica);

            }



        } //koniec klasy punkt



        //deklaracja klasy potomnej
        public class Linia : Punkt
        {
            //dodanie deklaracji niezbednych dla wykreslenia lini
            int Xk, Yk;
            int Xp, Yp;
            //deklaracje konstruktorów  
            public Linia(int Xp, int Yp, int Xk, int Yk) : base(Xp, Yp)
            {
                this.Xk = Xk;
                this.Yk = Yk;
                //ustawienie znacznika Linia
                Figura = FiguryGeometryczne.Linia;
            }
            public Linia(int Xp, int Yp, int Xk, int Yk, Color KolorLini,
                DashStyle StylLini, float GrubośćLini) : base(Xp, Yp, KolorLini)
            {
                //ustawinenie znacznika linia
                Figura = FiguryGeometryczne.Linia;
                this.Xk = Xk;
                this.Yk = Yk;
                this.StylLini = StylLini;
                this.GrubośćLini = GrubośćLini;

            }
            //nadpisanei metod wirtualnych
            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kolor, GrubośćLini))
                {
                    //ustawieniei stylu lini
                    Pióro.DashStyle = StylLini;
                    //wykreslenie lini
                    Rysownica.DrawLine(Pióro, X, Y, Xk, Yk);
                    //ustawienie atrybutu widocznosci
                    Widoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                if (Widoczny)
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLini))
                    {
                        //ustawieniei stylu lini
                        Pióro.DashStyle = StylLini;
                        //wymazanie lini
                        Rysownica.DrawLine(Pióro, X, Y, Xk, Yk);
                        //zgaszenie atrybutu widoczności
                        Widoczny = false;
                    }
            }
            public virtual void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int Xn, int Yn)
            {//deklaracje pom  dla wyzn przyrostu dx i dy oraz zmiany wspolrzednych lini
                int Dx, Dy;
                //wyznaczenie przyrostu Dx
                if (Xn > X)
                    Dx = Xn - X;
                else
                    Dx = X - Xn;

                //wyznaczenie przyrostu Dy
                if (Xn > Y)
                    Dy = Yn - Y;
                else
                    Dy = Y - Yn;
                //przesuniecie poczatku lini do nowego polozenia(Xn, Yn)
                X = Xn;
                Y = Yn;
                //przesuniecie konca lini do PrzesuńDoNowegoXY polozenia(Dx Dy)
                Xk = (Xk + Dx) % Kontrolka.Width;
                Yk = (Yk + Dy) % Kontrolka.Height;
                //wykreslenie lini w nowym polozeniu
                Wykreśl(Rysownica);

            }
        }//koniec linii

        public class Elipsa : Punkt
        {
            //dodanie nowych atrybutow niezbednych dla wykreslenia elipsy
            protected int OśDuża, OśMała;
            //deklaracja konstruktora
            public Elipsa(int x, int y, int ośDuża, int ośMała, Color KolorLini, DashStyle StylLini, float GrubośćLini) : base(x, y, KolorLini)
            {
                //ustawienie znacznika elipsy
                Figura = FiguryGeometryczne.Elipsa;
                //ustawienie atrybutu widocznosci
                Widoczny = false;
                //przechowanie w egzemplarzu klasy wartosci pozostalych parametrow konstruktora klasy elipsa

                OśDuża = ośDuża;
                OśMała = ośMała;
                this.StylLini = StylLini;
                this.GrubośćLini = GrubośćLini;

            }
            //nadpisanie metod wirtualnych klasy punkt
            public override void Wykreśl(Graphics Rysownica)
            {
                //wykrereslenie elispsy
                using (Pen Pióro = new Pen(Kolor, GrubośćLini))
                {
                    //ustawienie stylu lini
                    Pióro.DashStyle = StylLini;
                    //wykreslenie elipsy
                    Rysownica.DrawEllipse(Pióro, X - OśDuża / 2, Y - OśMała / 2, OśDuża, OśMała);
                    //zmiana atrybuty widocznosci
                    Widoczny = true;
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                //sprawdzenie atrybutu widocznosci
                if (Widoczny)
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLini))
                    {
                        //ustawieniei stylu lini
                        Pióro.DashStyle = StylLini;
                        //wymazanie lini
                        Rysownica.DrawEllipse(Pióro, X - OśDuża / 2, Y - OśMała / 2, OśDuża, OśMała);
                        //zgaszenie atrybutu widoczności
                        Widoczny = false;
                    }
            }
        }

        public class Okrąg : Elipsa
        {
            //deklaracja atrybutu promien
            public int Promień
            {
                get { return OśDuża; }
                set
                {
                    OśDuża = value;
                    OśMała = value;
                }
            }
            //konstruyktor
            public Okrąg(int x, int y, int Promień, Color KolorLini, DashStyle StylLini, 
                float GrubośćLini) : base(x, y, 2 * Promień, 2 * Promień, KolorLini, StylLini, GrubośćLini)
            {
                Figura = FiguryGeometryczne.Okrąg;
            }

        }
    }
    //deklaracja klasy okrag
   
}

