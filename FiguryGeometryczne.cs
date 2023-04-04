using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            public enum FiguryGeometryczne: byte 
            { Punkt, Linia, Elipsa, Prostokąt, Okrąg, Kwadrat};
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
            public Punkt(int X, int Y, Color Kolor): this(X,Y)
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
                using (SolidBrush Pędzel2 = new SolidBrush (Kolor))
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

        } //koniec klasy punkt


        //deklaracja klasy potomnej
        public class Linia: Punkt
        {
            //dodanie deklaracji niezbednych dla wykreslenia lini
            int Xk, Yk;
            //deklaracje konstruktorów  
            public  Linia (int Xp, int Yp, int Xk, int Yk):base(Xp,Yp)
            {
                this.Xk = Xk;
                this.Yk = Yk;
                //ustawienie znacznika Linia
                Figura = FiguryGeometryczne.Linia;
            }
            public Linia(int Xp, int Yp, int Xk, int Yk, Color KolorLini, 
                DashStyle StylLini, float GrubośćLini):base(Xp,Yp,KolorLini)
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
                    using(Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLini))
                    {
                        //ustawieniei stylu lini
                        Pióro.DashStyle = StylLini;
                        //wymazanie lini
                        Rysownica.DrawLine(Pióro, X, Y, Xk, Yk);
                        //zgaszenie atrybutu widoczności
                        Widoczny = false;
                    }
            }
        }
    }
}
