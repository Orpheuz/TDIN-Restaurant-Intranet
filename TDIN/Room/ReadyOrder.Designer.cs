namespace Room
{
    partial class ReadyOrder
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.itemListView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(558, 370);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(170, 42);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Deliver";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // itemListView
            // 
            this.itemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Description,
            this.State,
            this.Table,
            this.Quantity,
            this.Price});
            this.itemListView.FullRowSelect = true;
            this.itemListView.GridLines = true;
            this.itemListView.HideSelection = false;
            this.itemListView.Location = new System.Drawing.Point(75, 78);
            this.itemListView.MultiSelect = false;
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(653, 265);
            this.itemListView.TabIndex = 5;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
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
            // ReadyOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 444);
            this.Controls.Add(this.itemListView);
            this.Controls.Add(this.metroButton1);
            this.Name = "ReadyOrder";
            this.Text = "Ready Orders";
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.ReadyOrder_Load);
        }

        #endregion
        public MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
    }
}