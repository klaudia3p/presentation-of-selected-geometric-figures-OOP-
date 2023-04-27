namespace ProjektNr2_Plutka_62026
{
    partial class ProjektIndywidualnyNr2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kppbRysownica = new System.Windows.Forms.PictureBox();
            this.kpgbWybierzFigurę = new System.Windows.Forms.GroupBox();
            this.kpbtnCofnij = new System.Windows.Forms.Button();
            this.kprdbFillPie = new System.Windows.Forms.RadioButton();
            this.kprdbDrawArc = new System.Windows.Forms.RadioButton();
            this.kprdbKrzywaKardynalna = new System.Windows.Forms.RadioButton();
            this.kprdbFillElipse = new System.Windows.Forms.RadioButton();
            this.kprdbFillClosedCurve = new System.Windows.Forms.RadioButton();
            this.kprdbDrawPie = new System.Windows.Forms.RadioButton();
            this.kprdbDrawClosedCurve = new System.Windows.Forms.RadioButton();
            this.kprdbFillRectangle = new System.Windows.Forms.RadioButton();
            this.kprdbKrzywaBeziera = new System.Windows.Forms.RadioButton();
            this.kprdbLiniaCiągłaKreślonaMyszą = new System.Windows.Forms.RadioButton();
            this.kprdbWielokątWypełniony = new System.Windows.Forms.RadioButton();
            this.kprdbWielokątForemny = new System.Windows.Forms.RadioButton();
            this.kprdbProstokąt = new System.Windows.Forms.RadioButton();
            this.kprdbOkrąg = new System.Windows.Forms.RadioButton();
            this.kprdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.kprdbKwadrat = new System.Windows.Forms.RadioButton();
            this.kprdbKoło = new System.Windows.Forms.RadioButton();
            this.kprdbElipsa = new System.Windows.Forms.RadioButton();
            this.kprdbPunkt = new System.Windows.Forms.RadioButton();
            this.kpgbAtrybutyGraficzne = new System.Windows.Forms.GroupBox();
            this.kptxtKolorLini = new System.Windows.Forms.TextBox();
            this.kpcbStylLini = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kptbGrubośćLini = new System.Windows.Forms.TrackBar();
            this.kpbtnKolorWypełnienia = new System.Windows.Forms.Button();
            this.kpbtnKolorLini = new System.Windows.Forms.Button();
            this.kpbtnPrzesuńFigury = new System.Windows.Forms.Button();
            this.kpbtnPokazFigur = new System.Windows.Forms.Button();
            this.kpgbPokazFigur = new System.Windows.Forms.GroupBox();
            this.kprdbManualny = new System.Windows.Forms.RadioButton();
            this.kprdbPokazAutomatyczny = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.kptxtNumerFiguryIndeks = new System.Windows.Forms.TextBox();
            this.kpbtnWyłączPokazSlajdów = new System.Windows.Forms.Button();
            this.kpbtnPoprzedni = new System.Windows.Forms.Button();
            this.kpbtnNastępny = new System.Windows.Forms.Button();
            this.kpbtnZapisz = new System.Windows.Forms.Button();
            this.kpbtnWczytaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.kplblX = new System.Windows.Forms.Label();
            this.kplblY = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kppbRysownica)).BeginInit();
            this.kpgbWybierzFigurę.SuspendLayout();
            this.kpgbAtrybutyGraficzne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kptbGrubośćLini)).BeginInit();
            this.kpgbPokazFigur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kppbRysownica
            // 
            this.kppbRysownica.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.kppbRysownica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.kppbRysownica.Location = new System.Drawing.Point(26, 59);
            this.kppbRysownica.Name = "kppbRysownica";
            this.kppbRysownica.Size = new System.Drawing.Size(770, 454);
            this.kppbRysownica.TabIndex = 0;
            this.kppbRysownica.TabStop = false;
            this.kppbRysownica.MouseClick += new System.Windows.Forms.MouseEventHandler(this.kppbRysownica_MouseClick);
            this.kppbRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.kppbRysownica_MouseDown);
            this.kppbRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.kppbRysownica_MouseMove);
            this.kppbRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kppbRysownica_MouseUp);
            // 
            // kpgbWybierzFigurę
            // 
            this.kpgbWybierzFigurę.Controls.Add(this.kpbtnCofnij);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbFillPie);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbDrawArc);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbKrzywaKardynalna);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbFillElipse);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbFillClosedCurve);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbDrawPie);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbDrawClosedCurve);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbFillRectangle);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbKrzywaBeziera);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbLiniaCiągłaKreślonaMyszą);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbWielokątWypełniony);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbWielokątForemny);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbProstokąt);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbOkrąg);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbLiniaProsta);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbKwadrat);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbKoło);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbElipsa);
            this.kpgbWybierzFigurę.Controls.Add(this.kprdbPunkt);
            this.kpgbWybierzFigurę.Location = new System.Drawing.Point(814, 70);
            this.kpgbWybierzFigurę.Name = "kpgbWybierzFigurę";
            this.kpgbWybierzFigurę.Size = new System.Drawing.Size(285, 312);
            this.kpgbWybierzFigurę.TabIndex = 4;
            this.kpgbWybierzFigurę.TabStop = false;
            this.kpgbWybierzFigurę.Text = "Wybierz figurę lub linię krzywą";
            // 
            // kpbtnCofnij
            // 
            this.kpbtnCofnij.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kpbtnCofnij.Location = new System.Drawing.Point(36, 273);
            this.kpbtnCofnij.Name = "kpbtnCofnij";
            this.kpbtnCofnij.Size = new System.Drawing.Size(203, 33);
            this.kpbtnCofnij.TabIndex = 19;
            this.kpbtnCofnij.Text = "Cofnij (ostatnią figurę)";
            this.kpbtnCofnij.UseVisualStyleBackColor = true;
            // 
            // kprdbFillPie
            // 
            this.kprdbFillPie.AutoSize = true;
            this.kprdbFillPie.Location = new System.Drawing.Point(140, 220);
            this.kprdbFillPie.Name = "kprdbFillPie";
            this.kprdbFillPie.Size = new System.Drawing.Size(55, 17);
            this.kprdbFillPie.TabIndex = 18;
            this.kprdbFillPie.Text = "Fill Pie";
            this.kprdbFillPie.UseVisualStyleBackColor = true;
            // 
            // kprdbDrawArc
            // 
            this.kprdbDrawArc.AutoSize = true;
            this.kprdbDrawArc.Location = new System.Drawing.Point(140, 197);
            this.kprdbDrawArc.Name = "kprdbDrawArc";
            this.kprdbDrawArc.Size = new System.Drawing.Size(69, 17);
            this.kprdbDrawArc.TabIndex = 17;
            this.kprdbDrawArc.Text = "Draw Arc";
            this.kprdbDrawArc.UseVisualStyleBackColor = true;
            // 
            // kprdbKrzywaKardynalna
            // 
            this.kprdbKrzywaKardynalna.AutoSize = true;
            this.kprdbKrzywaKardynalna.Location = new System.Drawing.Point(140, 174);
            this.kprdbKrzywaKardynalna.Name = "kprdbKrzywaKardynalna";
            this.kprdbKrzywaKardynalna.Size = new System.Drawing.Size(115, 17);
            this.kprdbKrzywaKardynalna.TabIndex = 16;
            this.kprdbKrzywaKardynalna.Text = "Krzywa Kardynalna";
            this.kprdbKrzywaKardynalna.UseVisualStyleBackColor = true;
            // 
            // kprdbFillElipse
            // 
            this.kprdbFillElipse.AutoSize = true;
            this.kprdbFillElipse.Location = new System.Drawing.Point(140, 151);
            this.kprdbFillElipse.Name = "kprdbFillElipse";
            this.kprdbFillElipse.Size = new System.Drawing.Size(68, 17);
            this.kprdbFillElipse.TabIndex = 15;
            this.kprdbFillElipse.Text = "Fill Elipse";
            this.kprdbFillElipse.UseVisualStyleBackColor = true;
            // 
            // kprdbFillClosedCurve
            // 
            this.kprdbFillClosedCurve.AutoSize = true;
            this.kprdbFillClosedCurve.Location = new System.Drawing.Point(7, 236);
            this.kprdbFillClosedCurve.Name = "kprdbFillClosedCurve";
            this.kprdbFillClosedCurve.Size = new System.Drawing.Size(103, 17);
            this.kprdbFillClosedCurve.TabIndex = 14;
            this.kprdbFillClosedCurve.Text = "Fill Closed Curve";
            this.kprdbFillClosedCurve.UseVisualStyleBackColor = true;
            // 
            // kprdbDrawPie
            // 
            this.kprdbDrawPie.AutoSize = true;
            this.kprdbDrawPie.Location = new System.Drawing.Point(7, 212);
            this.kprdbDrawPie.Name = "kprdbDrawPie";
            this.kprdbDrawPie.Size = new System.Drawing.Size(68, 17);
            this.kprdbDrawPie.TabIndex = 13;
            this.kprdbDrawPie.Text = "Draw Pie";
            this.kprdbDrawPie.UseVisualStyleBackColor = true;
            // 
            // kprdbDrawClosedCurve
            // 
            this.kprdbDrawClosedCurve.AutoSize = true;
            this.kprdbDrawClosedCurve.Location = new System.Drawing.Point(7, 188);
            this.kprdbDrawClosedCurve.Name = "kprdbDrawClosedCurve";
            this.kprdbDrawClosedCurve.Size = new System.Drawing.Size(116, 17);
            this.kprdbDrawClosedCurve.TabIndex = 12;
            this.kprdbDrawClosedCurve.Text = "Draw Closed Curve";
            this.kprdbDrawClosedCurve.UseVisualStyleBackColor = true;
            // 
            // kprdbFillRectangle
            // 
            this.kprdbFillRectangle.AutoSize = true;
            this.kprdbFillRectangle.Location = new System.Drawing.Point(7, 164);
            this.kprdbFillRectangle.Name = "kprdbFillRectangle";
            this.kprdbFillRectangle.Size = new System.Drawing.Size(89, 17);
            this.kprdbFillRectangle.TabIndex = 11;
            this.kprdbFillRectangle.Text = "Fill Rectangle";
            this.kprdbFillRectangle.UseVisualStyleBackColor = true;
            // 
            // kprdbKrzywaBeziera
            // 
            this.kprdbKrzywaBeziera.AutoSize = true;
            this.kprdbKrzywaBeziera.Location = new System.Drawing.Point(7, 140);
            this.kprdbKrzywaBeziera.Name = "kprdbKrzywaBeziera";
            this.kprdbKrzywaBeziera.Size = new System.Drawing.Size(97, 17);
            this.kprdbKrzywaBeziera.TabIndex = 10;
            this.kprdbKrzywaBeziera.Text = "Krzywa Beziera";
            this.kprdbKrzywaBeziera.UseVisualStyleBackColor = true;
            // 
            // kprdbLiniaCiągłaKreślonaMyszą
            // 
            this.kprdbLiniaCiągłaKreślonaMyszą.AutoSize = true;
            this.kprdbLiniaCiągłaKreślonaMyszą.Location = new System.Drawing.Point(140, 116);
            this.kprdbLiniaCiągłaKreślonaMyszą.Name = "kprdbLiniaCiągłaKreślonaMyszą";
            this.kprdbLiniaCiągłaKreślonaMyszą.Size = new System.Drawing.Size(128, 30);
            this.kprdbLiniaCiągłaKreślonaMyszą.TabIndex = 9;
            this.kprdbLiniaCiągłaKreślonaMyszą.Text = "Linia Ciągła Kreślona \r\nmyszą";
            this.kprdbLiniaCiągłaKreślonaMyszą.UseVisualStyleBackColor = true;
            this.kprdbLiniaCiągłaKreślonaMyszą.CheckedChanged += new System.EventHandler(this.kprdbLiniaCiągłaKreślonaMyszą_CheckedChanged);
            // 
            // kprdbWielokątWypełniony
            // 
            this.kprdbWielokątWypełniony.AutoSize = true;
            this.kprdbWielokątWypełniony.Location = new System.Drawing.Point(7, 116);
            this.kprdbWielokątWypełniony.Name = "kprdbWielokątWypełniony";
            this.kprdbWielokątWypełniony.Size = new System.Drawing.Size(127, 17);
            this.kprdbWielokątWypełniony.TabIndex = 8;
            this.kprdbWielokątWypełniony.Text = "Wielokąt Wypełniony";
            this.kprdbWielokątWypełniony.UseVisualStyleBackColor = true;
            // 
            // kprdbWielokątForemny
            // 
            this.kprdbWielokątForemny.AutoSize = true;
            this.kprdbWielokątForemny.Location = new System.Drawing.Point(140, 92);
            this.kprdbWielokątForemny.Name = "kprdbWielokątForemny";
            this.kprdbWielokątForemny.Size = new System.Drawing.Size(110, 17);
            this.kprdbWielokątForemny.TabIndex = 7;
            this.kprdbWielokątForemny.Text = "Wielokąt Foremny";
            this.kprdbWielokątForemny.UseVisualStyleBackColor = true;
            // 
            // kprdbProstokąt
            // 
            this.kprdbProstokąt.AutoSize = true;
            this.kprdbProstokąt.Location = new System.Drawing.Point(140, 68);
            this.kprdbProstokąt.Name = "kprdbProstokąt";
            this.kprdbProstokąt.Size = new System.Drawing.Size(70, 17);
            this.kprdbProstokąt.TabIndex = 6;
            this.kprdbProstokąt.Text = "Prostokąt";
            this.kprdbProstokąt.UseVisualStyleBackColor = true;
            this.kprdbProstokąt.CheckedChanged += new System.EventHandler(this.kprdbProstokąt_CheckedChanged);
            // 
            // kprdbOkrąg
            // 
            this.kprdbOkrąg.AutoSize = true;
            this.kprdbOkrąg.Location = new System.Drawing.Point(140, 44);
            this.kprdbOkrąg.Name = "kprdbOkrąg";
            this.kprdbOkrąg.Size = new System.Drawing.Size(54, 17);
            this.kprdbOkrąg.TabIndex = 5;
            this.kprdbOkrąg.Text = "Okrąg";
            this.kprdbOkrąg.UseVisualStyleBackColor = true;
            // 
            // kprdbLiniaProsta
            // 
            this.kprdbLiniaProsta.AutoSize = true;
            this.kprdbLiniaProsta.Location = new System.Drawing.Point(140, 20);
            this.kprdbLiniaProsta.Name = "kprdbLiniaProsta";
            this.kprdbLiniaProsta.Size = new System.Drawing.Size(80, 17);
            this.kprdbLiniaProsta.TabIndex = 4;
            this.kprdbLiniaProsta.Text = "Linia Prosta";
            this.kprdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // kprdbKwadrat
            // 
            this.kprdbKwadrat.AutoSize = true;
            this.kprdbKwadrat.Location = new System.Drawing.Point(7, 92);
            this.kprdbKwadrat.Name = "kprdbKwadrat";
            this.kprdbKwadrat.Size = new System.Drawing.Size(64, 17);
            this.kprdbKwadrat.TabIndex = 3;
            this.kprdbKwadrat.Text = "Kwadrat";
            this.kprdbKwadrat.UseVisualStyleBackColor = true;
            this.kprdbKwadrat.CheckedChanged += new System.EventHandler(this.kprdbKwadrat_CheckedChanged);
            // 
            // kprdbKoło
            // 
            this.kprdbKoło.AutoSize = true;
            this.kprdbKoło.Location = new System.Drawing.Point(7, 68);
            this.kprdbKoło.Name = "kprdbKoło";
            this.kprdbKoło.Size = new System.Drawing.Size(48, 17);
            this.kprdbKoło.TabIndex = 2;
            this.kprdbKoło.Text = "Koło";
            this.kprdbKoło.UseVisualStyleBackColor = true;
            // 
            // kprdbElipsa
            // 
            this.kprdbElipsa.AutoSize = true;
            this.kprdbElipsa.Location = new System.Drawing.Point(7, 44);
            this.kprdbElipsa.Name = "kprdbElipsa";
            this.kprdbElipsa.Size = new System.Drawing.Size(53, 17);
            this.kprdbElipsa.TabIndex = 1;
            this.kprdbElipsa.Text = "Elipsa";
            this.kprdbElipsa.UseVisualStyleBackColor = true;
            // 
            // kprdbPunkt
            // 
            this.kprdbPunkt.AutoSize = true;
            this.kprdbPunkt.Location = new System.Drawing.Point(7, 20);
            this.kprdbPunkt.Name = "kprdbPunkt";
            this.kprdbPunkt.Size = new System.Drawing.Size(53, 17);
            this.kprdbPunkt.TabIndex = 0;
            this.kprdbPunkt.Text = "Punkt";
            this.kprdbPunkt.UseVisualStyleBackColor = true;
            // 
            // kpgbAtrybutyGraficzne
            // 
            this.kpgbAtrybutyGraficzne.Controls.Add(this.kptxtKolorLini);
            this.kpgbAtrybutyGraficzne.Controls.Add(this.kpcbStylLini);
            this.kpgbAtrybutyGraficzne.Controls.Add(this.label2);
            this.kpgbAtrybutyGraficzne.Controls.Add(this.kptbGrubośćLini);
            this.kpgbAtrybutyGraficzne.Controls.Add(this.kpbtnKolorWypełnienia);
            this.kpgbAtrybutyGraficzne.Controls.Add(this.kpbtnKolorLini);
            this.kpgbAtrybutyGraficzne.Location = new System.Drawing.Point(814, 388);
            this.kpgbAtrybutyGraficzne.Name = "kpgbAtrybutyGraficzne";
            this.kpgbAtrybutyGraficzne.Size = new System.Drawing.Size(285, 158);
            this.kpgbAtrybutyGraficzne.TabIndex = 5;
            this.kpgbAtrybutyGraficzne.TabStop = false;
            this.kpgbAtrybutyGraficzne.Text = "Atrybuty Graficzne";
            // 
            // kptxtKolorLini
            // 
            this.kptxtKolorLini.Location = new System.Drawing.Point(7, 54);
            this.kptxtKolorLini.Name = "kptxtKolorLini";
            this.kptxtKolorLini.Size = new System.Drawing.Size(100, 20);
            this.kptxtKolorLini.TabIndex = 5;
            // 
            // kpcbStylLini
            // 
            this.kpcbStylLini.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kpcbStylLini.FormattingEnabled = true;
            this.kpcbStylLini.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.kpcbStylLini.Location = new System.Drawing.Point(129, 20);
            this.kpcbStylLini.Name = "kpcbStylLini";
            this.kpcbStylLini.Size = new System.Drawing.Size(139, 23);
            this.kpcbStylLini.TabIndex = 4;
            this.kpcbStylLini.Text = "Wybierz styl lini";
            this.kpcbStylLini.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(126, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ustaw grubość lini";
            // 
            // kptbGrubośćLini
            // 
            this.kptbGrubośćLini.Location = new System.Drawing.Point(129, 80);
            this.kptbGrubośćLini.Maximum = 5;
            this.kptbGrubośćLini.Minimum = 1;
            this.kptbGrubośćLini.Name = "kptbGrubośćLini";
            this.kptbGrubośćLini.Size = new System.Drawing.Size(139, 45);
            this.kptbGrubośćLini.TabIndex = 2;
            this.kptbGrubośćLini.Value = 1;
            this.kptbGrubośćLini.Scroll += new System.EventHandler(this.kptbGrubośćLini_Scroll);
            // 
            // kpbtnKolorWypełnienia
            // 
            this.kpbtnKolorWypełnienia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kpbtnKolorWypełnienia.Location = new System.Drawing.Point(7, 80);
            this.kpbtnKolorWypełnienia.Name = "kpbtnKolorWypełnienia";
            this.kpbtnKolorWypełnienia.Size = new System.Drawing.Size(89, 45);
            this.kpbtnKolorWypełnienia.TabIndex = 1;
            this.kpbtnKolorWypełnienia.Text = "Kolor \r\nwypełnienia";
            this.kpbtnKolorWypełnienia.UseVisualStyleBackColor = true;
            this.kpbtnKolorWypełnienia.Click += new System.EventHandler(this.kpbtnKolorWypełnienia_Click);
            // 
            // kpbtnKolorLini
            // 
            this.kpbtnKolorLini.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kpbtnKolorLini.Location = new System.Drawing.Point(7, 20);
            this.kpbtnKolorLini.Name = "kpbtnKolorLini";
            this.kpbtnKolorLini.Size = new System.Drawing.Size(89, 31);
            this.kpbtnKolorLini.TabIndex = 0;
            this.kpbtnKolorLini.Text = "Kolor Lini";
            this.kpbtnKolorLini.UseVisualStyleBackColor = true;
            this.kpbtnKolorLini.Click += new System.EventHandler(this.kpbtnKolorLini_Click);
            // 
            // kpbtnPrzesuńFigury
            // 
            this.kpbtnPrzesuńFigury.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kpbtnPrzesuńFigury.Location = new System.Drawing.Point(814, 12);
            this.kpbtnPrzesuńFigury.Name = "kpbtnPrzesuńFigury";
            this.kpbtnPrzesuńFigury.Size = new System.Drawing.Size(239, 52);
            this.kpbtnPrzesuńFigury.TabIndex = 6;
            this.kpbtnPrzesuńFigury.Text = "Przesuń figury geometryczne do nowej \r\nlokalizacji";
            this.kpbtnPrzesuńFigury.UseVisualStyleBackColor = true;
            this.kpbtnPrzesuńFigury.Click += new System.EventHandler(this.kpbtnPrzesuńFigury_Click);
            // 
            // kpbtnPokazFigur
            // 
            this.kpbtnPokazFigur.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kpbtnPokazFigur.Location = new System.Drawing.Point(20, 545);
            this.kpbtnPokazFigur.Name = "kpbtnPokazFigur";
            this.kpbtnPokazFigur.Size = new System.Drawing.Size(155, 46);
            this.kpbtnPokazFigur.TabIndex = 7;
            this.kpbtnPokazFigur.Text = "Włącz pokaz figur";
            this.kpbtnPokazFigur.UseVisualStyleBackColor = true;
            this.kpbtnPokazFigur.Click += new System.EventHandler(this.kpbtnPokazFigur_Click);
            // 
            // kpgbPokazFigur
            // 
            this.kpgbPokazFigur.Controls.Add(this.kprdbManualny);
            this.kpgbPokazFigur.Controls.Add(this.kprdbPokazAutomatyczny);
            this.kpgbPokazFigur.Enabled = false;
            this.kpgbPokazFigur.Location = new System.Drawing.Point(214, 530);
            this.kpgbPokazFigur.Name = "kpgbPokazFigur";
            this.kpgbPokazFigur.Size = new System.Drawing.Size(281, 61);
            this.kpgbPokazFigur.TabIndex = 8;
            this.kpgbPokazFigur.TabStop = false;
            this.kpgbPokazFigur.Text = "Pokaz Figur";
            // 
            // kprdbManualny
            // 
            this.kprdbManualny.AutoSize = true;
            this.kprdbManualny.Enabled = false;
            this.kprdbManualny.Location = new System.Drawing.Point(134, 19);
            this.kprdbManualny.Name = "kprdbManualny";
            this.kprdbManualny.Size = new System.Drawing.Size(136, 30);
            this.kprdbManualny.TabIndex = 1;
            this.kprdbManualny.Text = "Manualny\r\n(sterowany przyciskami)";
            this.kprdbManualny.UseVisualStyleBackColor = true;
            this.kprdbManualny.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // kprdbPokazAutomatyczny
            // 
            this.kprdbPokazAutomatyczny.AutoSize = true;
            this.kprdbPokazAutomatyczny.Checked = true;
            this.kprdbPokazAutomatyczny.Enabled = false;
            this.kprdbPokazAutomatyczny.Location = new System.Drawing.Point(6, 19);
            this.kprdbPokazAutomatyczny.Name = "kprdbPokazAutomatyczny";
            this.kprdbPokazAutomatyczny.Size = new System.Drawing.Size(122, 30);
            this.kprdbPokazAutomatyczny.TabIndex = 0;
            this.kprdbPokazAutomatyczny.TabStop = true;
            this.kprdbPokazAutomatyczny.Text = "Automatyczny\r\n(sterowany zegarem)";
            this.kprdbPokazAutomatyczny.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Numer figury\r\n(indeks)";
            // 
            // kptxtNumerFiguryIndeks
            // 
            this.kptxtNumerFiguryIndeks.Location = new System.Drawing.Point(524, 570);
            this.kptxtNumerFiguryIndeks.Name = "kptxtNumerFiguryIndeks";
            this.kptxtNumerFiguryIndeks.Size = new System.Drawing.Size(100, 20);
            this.kptxtNumerFiguryIndeks.TabIndex = 10;
            this.kptxtNumerFiguryIndeks.TextChanged += new System.EventHandler(this.kptxtNumerFiguryIndeks_TextChanged);
            // 
            // kpbtnWyłączPokazSlajdów
            // 
            this.kpbtnWyłączPokazSlajdów.Enabled = false;
            this.kpbtnWyłączPokazSlajdów.Location = new System.Drawing.Point(646, 527);
            this.kpbtnWyłączPokazSlajdów.Name = "kpbtnWyłączPokazSlajdów";
            this.kpbtnWyłączPokazSlajdów.Size = new System.Drawing.Size(156, 23);
            this.kpbtnWyłączPokazSlajdów.TabIndex = 11;
            this.kpbtnWyłączPokazSlajdów.Text = "Wyłącz pokaz slajdów";
            this.kpbtnWyłączPokazSlajdów.UseVisualStyleBackColor = true;
            this.kpbtnWyłączPokazSlajdów.Click += new System.EventHandler(this.kpbtnWyłączPokazSlajdów_Click);
            // 
            // kpbtnPoprzedni
            // 
            this.kpbtnPoprzedni.Enabled = false;
            this.kpbtnPoprzedni.Location = new System.Drawing.Point(646, 557);
            this.kpbtnPoprzedni.Name = "kpbtnPoprzedni";
            this.kpbtnPoprzedni.Size = new System.Drawing.Size(75, 23);
            this.kpbtnPoprzedni.TabIndex = 12;
            this.kpbtnPoprzedni.Text = "Poprzedni";
            this.kpbtnPoprzedni.UseVisualStyleBackColor = true;
            this.kpbtnPoprzedni.Click += new System.EventHandler(this.kpbtnPoprzedni_Click);
            // 
            // kpbtnNastępny
            // 
            this.kpbtnNastępny.Enabled = false;
            this.kpbtnNastępny.Location = new System.Drawing.Point(727, 558);
            this.kpbtnNastępny.Name = "kpbtnNastępny";
            this.kpbtnNastępny.Size = new System.Drawing.Size(75, 23);
            this.kpbtnNastępny.TabIndex = 13;
            this.kpbtnNastępny.Text = "Następny";
            this.kpbtnNastępny.UseVisualStyleBackColor = true;
            this.kpbtnNastępny.Click += new System.EventHandler(this.kpbtnNastępny_Click);
            // 
            // kpbtnZapisz
            // 
            this.kpbtnZapisz.Location = new System.Drawing.Point(814, 556);
            this.kpbtnZapisz.Name = "kpbtnZapisz";
            this.kpbtnZapisz.Size = new System.Drawing.Size(137, 23);
            this.kpbtnZapisz.TabIndex = 14;
            this.kpbtnZapisz.Text = "Zapisz Bit mape w pliku";
            this.kpbtnZapisz.UseVisualStyleBackColor = true;
            this.kpbtnZapisz.Click += new System.EventHandler(this.kpbtnZapisz_Click);
            // 
            // kpbtnWczytaj
            // 
            this.kpbtnWczytaj.Location = new System.Drawing.Point(957, 557);
            this.kpbtnWczytaj.Name = "kpbtnWczytaj";
            this.kpbtnWczytaj.Size = new System.Drawing.Size(142, 23);
            this.kpbtnWczytaj.TabIndex = 15;
            this.kpbtnWczytaj.Text = "Wczytaj Bitmape z pliku";
            this.kpbtnWczytaj.UseVisualStyleBackColor = true;
            this.kpbtnWczytaj.Click += new System.EventHandler(this.kpbtnWczytaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Współrzędne myszy:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(199, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(375, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // kplblX
            // 
            this.kplblX.AutoSize = true;
            this.kplblX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kplblX.Location = new System.Drawing.Point(230, 25);
            this.kplblX.Name = "kplblX";
            this.kplblX.Size = new System.Drawing.Size(20, 19);
            this.kplblX.TabIndex = 19;
            this.kplblX.Text = "X";
            // 
            // kplblY
            // 
            this.kplblY.AutoSize = true;
            this.kplblY.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kplblY.Location = new System.Drawing.Point(403, 24);
            this.kplblY.Name = "kplblY";
            this.kplblY.Size = new System.Drawing.Size(19, 19);
            this.kplblY.TabIndex = 20;
            this.kplblY.Text = "Y";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ProjektIndywidualnyNr2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 704);
            this.Controls.Add(this.kplblY);
            this.Controls.Add(this.kplblX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kpbtnWczytaj);
            this.Controls.Add(this.kpbtnZapisz);
            this.Controls.Add(this.kpbtnNastępny);
            this.Controls.Add(this.kpbtnPoprzedni);
            this.Controls.Add(this.kpbtnWyłączPokazSlajdów);
            this.Controls.Add(this.kptxtNumerFiguryIndeks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kpgbPokazFigur);
            this.Controls.Add(this.kpbtnPokazFigur);
            this.Controls.Add(this.kpbtnPrzesuńFigury);
            this.Controls.Add(this.kpgbAtrybutyGraficzne);
            this.Controls.Add(this.kpgbWybierzFigurę);
            this.Controls.Add(this.kppbRysownica);
            this.Name = "ProjektIndywidualnyNr2";
            this.Text = "ProjektIndywidualnyNr2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjektIndywidualnyNr2_FormClosing);
            this.Load += new System.EventHandler(this.ProjektIndywidualnyNr2_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProjektIndywidualnyNr2_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.kppbRysownica)).EndInit();
            this.kpgbWybierzFigurę.ResumeLayout(false);
            this.kpgbWybierzFigurę.PerformLayout();
            this.kpgbAtrybutyGraficzne.ResumeLayout(false);
            this.kpgbAtrybutyGraficzne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kptbGrubośćLini)).EndInit();
            this.kpgbPokazFigur.ResumeLayout(false);
            this.kpgbPokazFigur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox kppbRysownica;
        private System.Windows.Forms.GroupBox kpgbWybierzFigurę;
        private System.Windows.Forms.Button kpbtnCofnij;
        private System.Windows.Forms.RadioButton kprdbFillPie;
        private System.Windows.Forms.RadioButton kprdbDrawArc;
        private System.Windows.Forms.RadioButton kprdbKrzywaKardynalna;
        private System.Windows.Forms.RadioButton kprdbFillElipse;
        private System.Windows.Forms.RadioButton kprdbFillClosedCurve;
        private System.Windows.Forms.RadioButton kprdbDrawPie;
        private System.Windows.Forms.RadioButton kprdbDrawClosedCurve;
        private System.Windows.Forms.RadioButton kprdbFillRectangle;
        private System.Windows.Forms.RadioButton kprdbKrzywaBeziera;
        private System.Windows.Forms.RadioButton kprdbLiniaCiągłaKreślonaMyszą;
        private System.Windows.Forms.RadioButton kprdbWielokątWypełniony;
        private System.Windows.Forms.RadioButton kprdbWielokątForemny;
        private System.Windows.Forms.RadioButton kprdbProstokąt;
        private System.Windows.Forms.RadioButton kprdbOkrąg;
        private System.Windows.Forms.RadioButton kprdbLiniaProsta;
        private System.Windows.Forms.RadioButton kprdbKwadrat;
        private System.Windows.Forms.RadioButton kprdbKoło;
        private System.Windows.Forms.RadioButton kprdbElipsa;
        private System.Windows.Forms.RadioButton kprdbPunkt;
        private System.Windows.Forms.GroupBox kpgbAtrybutyGraficzne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar kptbGrubośćLini;
        private System.Windows.Forms.Button kpbtnKolorWypełnienia;
        private System.Windows.Forms.Button kpbtnKolorLini;
        private System.Windows.Forms.ComboBox kpcbStylLini;
        private System.Windows.Forms.Button kpbtnPrzesuńFigury;
        private System.Windows.Forms.Button kpbtnPokazFigur;
        private System.Windows.Forms.GroupBox kpgbPokazFigur;
        private System.Windows.Forms.RadioButton kprdbManualny;
        private System.Windows.Forms.RadioButton kprdbPokazAutomatyczny;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kptxtNumerFiguryIndeks;
        private System.Windows.Forms.Button kpbtnWyłączPokazSlajdów;
        private System.Windows.Forms.Button kpbtnPoprzedni;
        private System.Windows.Forms.Button kpbtnNastępny;
        private System.Windows.Forms.Button kpbtnZapisz;
        private System.Windows.Forms.Button kpbtnWczytaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label kplblX;
        private System.Windows.Forms.Label kplblY;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox kptxtKolorLini;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}