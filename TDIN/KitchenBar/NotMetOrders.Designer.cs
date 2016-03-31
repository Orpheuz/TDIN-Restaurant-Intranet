namespace KitchenBar
{
    partial class NotMetOrders
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
            this.itemListView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
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
            this.itemListView.Location = new System.Drawing.Point(71, 81);
            this.itemListView.MultiSelect = false;
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(653, 265);
            this.itemListView.TabIndex = 3;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
            this.itemListView.SelectedIndexChanged += new System.EventHandler(this.itemListView_SelectedIndexChanged);
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
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(561, 367);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(163, 42);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Take order";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(377, 367);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(163, 42);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Check orders taken";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // NotMetOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 445);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.itemListView);
            this.Name = "NotMetOrders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotMetOrders_FormClosed);
            this.Load += new System.EventHandler(this.NotMetOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}