namespace RPDModule
{
    partial class Main
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
            this.btnFOS = new MetroFramework.Controls.MetroTile();
            this.btnExit = new MetroFramework.Controls.MetroTile();
            this.btnMU = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // btnFOS
            // 
            this.btnFOS.Location = new System.Drawing.Point(23, 154);
            this.btnFOS.Name = "btnFOS";
            this.btnFOS.Size = new System.Drawing.Size(231, 53);
            this.btnFOS.TabIndex = 1;
            this.btnFOS.Text = "Оценочные средства";
            this.btnFOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFOS.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFOS.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnFOS.Click += new System.EventHandler(this.btnFOS_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(23, 298);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(231, 53);
            this.btnExit.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExit.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMU
            // 
            this.btnMU.BackColor = System.Drawing.Color.White;
            this.btnMU.Location = new System.Drawing.Point(23, 84);
            this.btnMU.Name = "btnMU";
            this.btnMU.Size = new System.Drawing.Size(231, 53);
            this.btnMU.TabIndex = 0;
            this.btnMU.Text = "Методические указания";
            this.btnMU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMU.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMU.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnMU.UseTileImage = true;
            this.btnMU.Click += new System.EventHandler(this.btnMU_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(23, 226);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(231, 53);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile1.TabIndex = 4;
            this.metroTile1.Text = "Администрирование";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 374);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFOS);
            this.Controls.Add(this.btnMU);
            this.Name = "Main";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Text = "РПД Модули";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnMU;
        private MetroFramework.Controls.MetroTile btnFOS;
        private MetroFramework.Controls.MetroTile btnExit;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}