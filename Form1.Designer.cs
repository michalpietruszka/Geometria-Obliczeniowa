namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wspołrzędneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ukryjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pokazPunktyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointInPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ąToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przerwijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otoczkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.grahamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(749, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(665, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(207, 485);
            this.listBox1.TabIndex = 2;
            this.listBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zielony - Poligon\r\nNiebieski - Linia\r\nCzarny - Punkt";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wczytajToolStripMenuItem,
            this.wspołrzędneToolStripMenuItem,
            this.mBRToolStripMenuItem,
            this.pointInPolygonToolStripMenuItem,
            this.otoczkaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "MBR";
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem1});
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.wczytajToolStripMenuItem.Text = "Plik";
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.startToolStripMenuItem1.Text = "Wczytaj";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wspołrzędneToolStripMenuItem
            // 
            this.wspołrzędneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem2,
            this.ukryjToolStripMenuItem});
            this.wspołrzędneToolStripMenuItem.Name = "wspołrzędneToolStripMenuItem";
            this.wspołrzędneToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.wspołrzędneToolStripMenuItem.Text = "Wspołrzędne";
            // 
            // startToolStripMenuItem2
            // 
            this.startToolStripMenuItem2.Name = "startToolStripMenuItem2";
            this.startToolStripMenuItem2.Size = new System.Drawing.Size(101, 22);
            this.startToolStripMenuItem2.Text = "Start";
            this.startToolStripMenuItem2.Click += new System.EventHandler(this.AddFromCode);
            // 
            // ukryjToolStripMenuItem
            // 
            this.ukryjToolStripMenuItem.Name = "ukryjToolStripMenuItem";
            this.ukryjToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.ukryjToolStripMenuItem.Text = "Ukryj";
            this.ukryjToolStripMenuItem.Click += new System.EventHandler(this.ukryj_ListMenu_Click);
            // 
            // mBRToolStripMenuItem
            // 
            this.mBRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.usuńToolStripMenuItem,
            this.pokazPunktyToolStripMenuItem});
            this.mBRToolStripMenuItem.Name = "mBRToolStripMenuItem";
            this.mBRToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.mBRToolStripMenuItem.Text = "MBR";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.start_MBRMenu_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            this.usuńToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.usuńToolStripMenuItem.Text = "Usuń";
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuń_MBRMenu_Click);
            // 
            // pokazPunktyToolStripMenuItem
            // 
            this.pokazPunktyToolStripMenuItem.Name = "pokazPunktyToolStripMenuItem";
            this.pokazPunktyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.pokazPunktyToolStripMenuItem.Text = "Pokaz punkty";
            this.pokazPunktyToolStripMenuItem.Click += new System.EventHandler(this.pokazPunkty_MBRMenu_Click);
            // 
            // pointInPolygonToolStripMenuItem
            // 
            this.pointInPolygonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem3,
            this.startToolStripMenuItem4,
            this.ąToolStripMenuItem,
            this.przerwijToolStripMenuItem});
            this.pointInPolygonToolStripMenuItem.Name = "pointInPolygonToolStripMenuItem";
            this.pointInPolygonToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.pointInPolygonToolStripMenuItem.Text = "PointsInPolygon";
            // 
            // startToolStripMenuItem3
            // 
            this.startToolStripMenuItem3.Name = "startToolStripMenuItem3";
            this.startToolStripMenuItem3.Size = new System.Drawing.Size(119, 22);
            this.startToolStripMenuItem3.Text = "Rysuj";
            this.startToolStripMenuItem3.Click += new System.EventHandler(this.rysuj_PipMenu_Click);
            // 
            // startToolStripMenuItem4
            // 
            this.startToolStripMenuItem4.Name = "startToolStripMenuItem4";
            this.startToolStripMenuItem4.Size = new System.Drawing.Size(119, 22);
            this.startToolStripMenuItem4.Text = "Start";
            this.startToolStripMenuItem4.Click += new System.EventHandler(this.start_PipMenu_Click);
            // 
            // ąToolStripMenuItem
            // 
            this.ąToolStripMenuItem.Name = "ąToolStripMenuItem";
            this.ąToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.ąToolStripMenuItem.Text = "Wyczyść";
            this.ąToolStripMenuItem.Click += new System.EventHandler(this.Wyczysc_PipMenu_Click);
            // 
            // przerwijToolStripMenuItem
            // 
            this.przerwijToolStripMenuItem.Name = "przerwijToolStripMenuItem";
            this.przerwijToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.przerwijToolStripMenuItem.Text = "Przerwij";
            this.przerwijToolStripMenuItem.Click += new System.EventHandler(this.przerwij_PipMenu_Click);
            // 
            // otoczkaToolStripMenuItem
            // 
            this.otoczkaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem5,
            this.usuńToolStripMenuItem1});
            this.otoczkaToolStripMenuItem.Name = "otoczkaToolStripMenuItem";
            this.otoczkaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.otoczkaToolStripMenuItem.Text = "Otoczka";
            // 
            // startToolStripMenuItem5
            // 
            this.startToolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grahamToolStripMenuItem,
            this.toolStripMenuItem1});
            this.startToolStripMenuItem5.Name = "startToolStripMenuItem5";
            this.startToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem5.Text = "Start";
            // 
            // grahamToolStripMenuItem
            // 
            this.grahamToolStripMenuItem.Name = "grahamToolStripMenuItem";
            this.grahamToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grahamToolStripMenuItem.Text = "Graham";
            this.grahamToolStripMenuItem.Click += new System.EventHandler(this.grahamMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Jarvis";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.jarvisMenu_Click);
            // 
            // usuńToolStripMenuItem1
            // 
            this.usuńToolStripMenuItem1.Name = "usuńToolStripMenuItem1";
            this.usuńToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.usuńToolStripMenuItem1.Text = "Usuń";
            this.usuńToolStripMenuItem1.Click += new System.EventHandler(this.usuńToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mBRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wspołrzędneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ukryjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pokazPunktyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointInPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ąToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przerwijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otoczkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem grahamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

