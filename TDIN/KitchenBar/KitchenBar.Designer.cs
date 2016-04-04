namespace KitchenBar
{
    partial class KitchenBar
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
            this.orderLV = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.changeStateButton = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderLV
            // 
            this.orderLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Description,
            this.State,
            this.Table,
            this.Quantity,
            this.Price});
            this.orderLV.FullRowSelect = true;
            this.orderLV.GridLines = true;
            this.orderLV.HideSelection = false;
            this.orderLV.Location = new System.Drawing.Point(73, 26);
            this.orderLV.MultiSelect = false;
            this.orderLV.Name = "orderLV";
            this.orderLV.Size = new System.Drawing.Size(653, 302);
            this.orderLV.TabIndex = 3;
            this.orderLV.UseCompatibleStateImageBehavior = false;
            this.orderLV.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 294;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 123;
            // 
            // Table
            // 
            this.Table.Text = "Table";
            this.Table.Width = 53;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 55;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 62;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Location = new System.Drawing.Point(57, 65);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(802, 421);
            this.metroTabControl1.TabIndex = 6;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.changeStateButton);
            this.metroTabPage1.Controls.Add(this.orderLV);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(794, 379);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Orders";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // changeStateButton
            // 
            this.changeStateButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.changeStateButton.Highlight = true;
            this.changeStateButton.Location = new System.Drawing.Point(563, 337);
            this.changeStateButton.Name = "changeStateButton";
            this.changeStateButton.Size = new System.Drawing.Size(163, 42);
            this.changeStateButton.TabIndex = 7;
            this.changeStateButton.Text = "Change State";
            this.changeStateButton.UseSelectable = true;
            this.changeStateButton.Click += new System.EventHandler(this.changeStateButton_Click);
            // 
            // KitchenBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 514);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "KitchenBar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Room_FormClosed);
            this.Load += new System.EventHandler(this.Orders_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView orderLV;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton changeStateButton;
    }
}