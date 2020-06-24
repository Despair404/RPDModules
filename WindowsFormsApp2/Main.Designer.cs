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
            this.SuspendLayout();
            // 
            // btnFOS
            // 
            this.btnFOS.Location = new System.Drawing.Point(23, 156);
            this.btnFOS.Name = "btnFOS";
            this.btnFOS.Size = new System.Drawing.Size(231, 53);
            this.btnFOS.TabIndex = 1;
            this.btnFOS.Text = "Фонд оценочных средств";
            this.btnFOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFOS.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFOS.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(23, 228);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 323);
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
    }
}