namespace ProjektNr2_Plutka_62026
{
    partial class LaboratoriumNr2
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
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnPrzesuńdoNowegoXY = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnWłączPokazFigur = new System.Windows.Forms.Button();
            this.btnWyłączPokaz = new System.Windows.Forms.Button();
            this.gpbTrybPokazu = new System.Windows.Forms.GroupBox();
            this.rdbPokazManualny = new System.Windows.Forms.RadioButton();
            this.rdbPokazZegarowy = new System.Windows.Forms.RadioButton();
            this.btnPoprzednia = new System.Windows.Forms.Button();
            this.btnNastępna = new System.Windows.Forms.Button();
            this.txtBIndeks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gpbTrybPokazu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.BackColor = System.Drawing.SystemColors.Info;
            this.pbRysownica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbRysownica.Location = new System.Drawing.Point(180, 12);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(611, 341);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj liczbę figur \r\ndo prezentacji:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(21, 149);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 20);
            this.txtN.TabIndex = 2;
            this.txtN.TextChanged += new System.EventHandler(this.txtN_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(34, 187);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 37);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chlbFiguryGeometryczne
            // 
            this.chlbFiguryGeometryczne.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chlbFiguryGeometryczne.FormattingEnabled = true;
            this.chlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrąg",
            "Prostokąt",
            "Kwadrat",
            "itd"});
            this.chlbFiguryGeometryczne.Location = new System.Drawing.Point(815, 89);
            this.chlbFiguryGeometryczne.Name = "chlbFiguryGeometryczne";
            this.chlbFiguryGeometryczne.Size = new System.Drawing.Size(152, 172);
            this.chlbFiguryGeometryczne.TabIndex = 4;
            this.chlbFiguryGeometryczne.SelectedIndexChanged += new System.EventHandler(this.chlbFiguryGeometryczne_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(828, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zaznacz figury \r\ndo prezentacji:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnPrzesuńdoNowegoXY
            // 
            this.btnPrzesuńdoNowegoXY.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrzesuńdoNowegoXY.Location = new System.Drawing.Point(8, 230);
            this.btnPrzesuńdoNowegoXY.Name = "btnPrzesuńdoNowegoXY";
            this.btnPrzesuńdoNowegoXY.Size = new System.Drawing.Size(166, 80);
            this.btnPrzesuńdoNowegoXY.TabIndex = 6;
            this.btnPrzesuńdoNowegoXY.Text = "Przesunięcie wszystkich figur \r\ndo nowego położenia";
            this.btnPrzesuńdoNowegoXY.UseVisualStyleBackColor = true;
            this.btnPrzesuńdoNowegoXY.Click += new System.EventHandler(this.btnPrzesuńdoNowegoXY_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnWłączPokazFigur
            // 
            this.btnWłączPokazFigur.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWłączPokazFigur.Location = new System.Drawing.Point(8, 316);
            this.btnWłączPokazFigur.Name = "btnWłączPokazFigur";
            this.btnWłączPokazFigur.Size = new System.Drawing.Size(166, 54);
            this.btnWłączPokazFigur.TabIndex = 7;
            this.btnWłączPokazFigur.Text = "Włączenie pokazu figur";
            this.btnWłączPokazFigur.UseVisualStyleBackColor = true;
            this.btnWłączPokazFigur.Click += new System.EventHandler(this.btnWłączPokazFigur_Click);
            // 
            // btnWyłączPokaz
            // 
            this.btnWyłączPokaz.Enabled = false;
            this.btnWyłączPokaz.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWyłączPokaz.Location = new System.Drawing.Point(8, 377);
            this.btnWyłączPokaz.Name = "btnWyłączPokaz";
            this.btnWyłączPokaz.Size = new System.Drawing.Size(166, 57);
            this.btnWyłączPokaz.TabIndex = 8;
            this.btnWyłączPokaz.Text = "Wyłączenie pokazu figur";
            this.btnWyłączPokaz.UseVisualStyleBackColor = true;
            this.btnWyłączPokaz.Click += new System.EventHandler(this.btnWyłączPokaz_Click);
            // 
            // gpbTrybPokazu
            // 
            this.gpbTrybPokazu.Controls.Add(this.rdbPokazManualny);
            this.gpbTrybPokazu.Controls.Add(this.rdbPokazZegarowy);
            this.gpbTrybPokazu.Enabled = false;
            this.gpbTrybPokazu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gpbTrybPokazu.Location = new System.Drawing.Point(8, 440);
            this.gpbTrybPokazu.Name = "gpbTrybPokazu";
            this.gpbTrybPokazu.Size = new System.Drawing.Size(417, 56);
            this.gpbTrybPokazu.TabIndex = 9;
            this.gpbTrybPokazu.TabStop = false;
            this.gpbTrybPokazu.Text = "Tryb pokazu figur geometrycznych";
            // 
            // rdbPokazManualny
            // 
            this.rdbPokazManualny.AutoSize = true;
            this.rdbPokazManualny.Enabled = false;
            this.rdbPokazManualny.Location = new System.Drawing.Point(229, 25);
            this.rdbPokazManualny.Name = "rdbPokazManualny";
            this.rdbPokazManualny.Size = new System.Drawing.Size(186, 23);
            this.rdbPokazManualny.TabIndex = 1;
            this.rdbPokazManualny.Text = "Manualny(przyciskowy)";
            this.rdbPokazManualny.UseVisualStyleBackColor = true;
            this.rdbPokazManualny.CheckedChanged += new System.EventHandler(this.rdbPokazManualny_CheckedChanged);
            // 
            // rdbPokazZegarowy
            // 
            this.rdbPokazZegarowy.AutoSize = true;
            this.rdbPokazZegarowy.Checked = true;
            this.rdbPokazZegarowy.Enabled = false;
            this.rdbPokazZegarowy.Location = new System.Drawing.Point(13, 26);
            this.rdbPokazZegarowy.Name = "rdbPokazZegarowy";
            this.rdbPokazZegarowy.Size = new System.Drawing.Size(190, 23);
            this.rdbPokazZegarowy.TabIndex = 0;
            this.rdbPokazZegarowy.TabStop = true;
            this.rdbPokazZegarowy.Text = "Automatyczny Zegarowy";
            this.rdbPokazZegarowy.UseVisualStyleBackColor = true;
            this.rdbPokazZegarowy.CheckedChanged += new System.EventHandler(this.rdbPokazZegarowy_CheckedChanged);
            // 
            // btnPoprzednia
            // 
            this.btnPoprzednia.Enabled = false;
            this.btnPoprzednia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPoprzednia.Location = new System.Drawing.Point(44, 509);
            this.btnPoprzednia.Name = "btnPoprzednia";
            this.btnPoprzednia.Size = new System.Drawing.Size(130, 34);
            this.btnPoprzednia.TabIndex = 10;
            this.btnPoprzednia.Text = "Poprzednia";
            this.btnPoprzednia.UseVisualStyleBackColor = true;
            this.btnPoprzednia.Click += new System.EventHandler(this.btnPoprzednia_Click);
            // 
            // btnNastępna
            // 
            this.btnNastępna.Enabled = false;
            this.btnNastępna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNastępna.Location = new System.Drawing.Point(249, 509);
            this.btnNastępna.Name = "btnNastępna";
            this.btnNastępna.Size = new System.Drawing.Size(134, 34);
            this.btnNastępna.TabIndex = 11;
            this.btnNastępna.Text = "Następna";
            this.btnNastępna.UseVisualStyleBackColor = true;
            this.btnNastępna.Click += new System.EventHandler(this.btnNastępna_Click);
            // 
            // txtBIndeks
            // 
            this.txtBIndeks.Enabled = false;
            this.txtBIndeks.Location = new System.Drawing.Point(461, 488);
            this.txtBIndeks.Name = "txtBIndeks";
            this.txtBIndeks.Size = new System.Drawing.Size(100, 20);
            this.txtBIndeks.TabIndex = 12;
            this.txtBIndeks.TextChanged += new System.EventHandler(this.txtBIndeks_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(463, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Indeks figury";
            // 
            // LaboratoriumNr2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 562);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBIndeks);
            this.Controls.Add(this.btnNastępna);
            this.Controls.Add(this.btnPoprzednia);
            this.Controls.Add(this.gpbTrybPokazu);
            this.Controls.Add(this.btnWyłączPokaz);
            this.Controls.Add(this.btnWłączPokazFigur);
            this.Controls.Add(this.btnPrzesuńdoNowegoXY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chlbFiguryGeometryczne);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbRysownica);
            this.Name = "LaboratoriumNr2";
            this.Text = "LaboratoriumNr2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaboratoriumNr2_FormClosing);
            this.Load += new System.EventHandler(this.LaboratoriumNr2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gpbTrybPokazu.ResumeLayout(false);
            this.gpbTrybPokazu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckedListBox chlbFiguryGeometryczne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnPrzesuńdoNowegoXY;
        private System.Windows.Forms.GroupBox gpbTrybPokazu;
        private System.Windows.Forms.Button btnWyłączPokaz;
        private System.Windows.Forms.Button btnWłączPokazFigur;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnNastępna;
        private System.Windows.Forms.Button btnPoprzednia;
        private System.Windows.Forms.RadioButton rdbPokazManualny;
        private System.Windows.Forms.RadioButton rdbPokazZegarowy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBIndeks;
    }
}