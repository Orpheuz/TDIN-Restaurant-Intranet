namespace Room
{
    partial class Popup
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
            this.notificationsTile = new MetroFramework.Controls.MetroTile();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // notificationsTile
            // 
            this.notificationsTile.ActiveControl = null;
            this.notificationsTile.Location = new System.Drawing.Point(0, -7);
            this.notificationsTile.Name = "notificationsTile";
            this.notificationsTile.Size = new System.Drawing.Size(619, 360);
            this.notificationsTile.TabIndex = 3;
            this.notificationsTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.notificationsTile.TileImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.notificationsTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.notificationsTile.UseSelectable = true;
            this.notificationsTile.UseStyleColors = true;
            this.notificationsTile.Click += new System.EventHandler(this.notificationsTile_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 352);
            this.Controls.Add(this.notificationsTile);
            this.Name = "Popup";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile notificationsTile;
        private System.Windows.Forms.Timer timer1;
    }
}