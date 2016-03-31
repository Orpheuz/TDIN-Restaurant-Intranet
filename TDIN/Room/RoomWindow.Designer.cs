namespace Room
{
    partial class RoomWindow
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.radioButtonBar = new MetroFramework.Controls.MetroRadioButton();
            this.radioButtonKitchen = new MetroFramework.Controls.MetroRadioButton();
            this.localLabel = new MetroFramework.Controls.MetroLabel();
            this.quantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.priceUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableComboBox = new MetroFramework.Controls.MetroComboBox();
            this.descriptionComboBox = new MetroFramework.Controls.MetroComboBox();
            this.addOrderButton = new MetroFramework.Controls.MetroButton();
            this.quantityLabel = new MetroFramework.Controls.MetroLabel();
            this.priceLabel = new MetroFramework.Controls.MetroLabel();
            this.tableLabel = new MetroFramework.Controls.MetroLabel();
            this.descriptionLabel = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.itemListView = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Table = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deliverButton = new MetroFramework.Controls.MetroButton();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).BeginInit();
            this.metroTabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // notificationsTile
            // 
            this.notificationsTile.ActiveControl = null;
            this.notificationsTile.Location = new System.Drawing.Point(79, 26);
            this.notificationsTile.Name = "notificationsTile";
            this.notificationsTile.Size = new System.Drawing.Size(646, 337);
            this.notificationsTile.TabIndex = 2;
            this.notificationsTile.Text = "No order ready, vai ser pra sair prolly";
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
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(52, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(808, 447);
            this.metroTabControl1.TabIndex = 6;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.notificationsTile);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(800, 405);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Main window";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.radioButtonBar);
            this.metroTabPage2.Controls.Add(this.radioButtonKitchen);
            this.metroTabPage2.Controls.Add(this.localLabel);
            this.metroTabPage2.Controls.Add(this.quantityUpDown);
            this.metroTabPage2.Controls.Add(this.priceUpDown);
            this.metroTabPage2.Controls.Add(this.tableComboBox);
            this.metroTabPage2.Controls.Add(this.descriptionComboBox);
            this.metroTabPage2.Controls.Add(this.addOrderButton);
            this.metroTabPage2.Controls.Add(this.quantityLabel);
            this.metroTabPage2.Controls.Add(this.priceLabel);
            this.metroTabPage2.Controls.Add(this.tableLabel);
            this.metroTabPage2.Controls.Add(this.descriptionLabel);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(800, 405);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Add order";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // radioButtonBar
            // 
            this.radioButtonBar.AutoSize = true;
            this.radioButtonBar.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radioButtonBar.Location = new System.Drawing.Point(348, 292);
            this.radioButtonBar.Name = "radioButtonBar";
            this.radioButtonBar.Size = new System.Drawing.Size(53, 25);
            this.radioButtonBar.TabIndex = 23;
            this.radioButtonBar.Text = "Bar";
            this.radioButtonBar.UseSelectable = true;
            // 
            // radioButtonKitchen
            // 
            this.radioButtonKitchen.AutoSize = true;
            this.radioButtonKitchen.Checked = true;
            this.radioButtonKitchen.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radioButtonKitchen.Location = new System.Drawing.Point(200, 292);
            this.radioButtonKitchen.Name = "radioButtonKitchen";
            this.radioButtonKitchen.Size = new System.Drawing.Size(85, 25);
            this.radioButtonKitchen.TabIndex = 22;
            this.radioButtonKitchen.TabStop = true;
            this.radioButtonKitchen.Text = "Kitchen";
            this.radioButtonKitchen.UseSelectable = true;
            // 
            // localLabel
            // 
            this.localLabel.AutoSize = true;
            this.localLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.localLabel.Location = new System.Drawing.Point(94, 292);
            this.localLabel.Name = "localLabel";
            this.localLabel.Size = new System.Drawing.Size(60, 25);
            this.localLabel.TabIndex = 21;
            this.localLabel.Text = "Local: ";
            // 
            // quantityUpDown
            // 
            this.quantityUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityUpDown.Location = new System.Drawing.Point(200, 230);
            this.quantityUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.quantityUpDown.Name = "quantityUpDown";
            this.quantityUpDown.Size = new System.Drawing.Size(548, 29);
            this.quantityUpDown.TabIndex = 20;
            // 
            // priceUpDown
            // 
            this.priceUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceUpDown.Location = new System.Drawing.Point(200, 159);
            this.priceUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.priceUpDown.Name = "priceUpDown";
            this.priceUpDown.Size = new System.Drawing.Size(548, 29);
            this.priceUpDown.TabIndex = 19;
            // 
            // tableComboBox
            // 
            this.tableComboBox.FormattingEnabled = true;
            this.tableComboBox.ItemHeight = 23;
            this.tableComboBox.Location = new System.Drawing.Point(200, 89);
            this.tableComboBox.Name = "tableComboBox";
            this.tableComboBox.Size = new System.Drawing.Size(548, 29);
            this.tableComboBox.TabIndex = 18;
            this.tableComboBox.UseSelectable = true;
            // 
            // descriptionComboBox
            // 
            this.descriptionComboBox.FormattingEnabled = true;
            this.descriptionComboBox.ItemHeight = 23;
            this.descriptionComboBox.Location = new System.Drawing.Point(200, 27);
            this.descriptionComboBox.Name = "descriptionComboBox";
            this.descriptionComboBox.Size = new System.Drawing.Size(548, 29);
            this.descriptionComboBox.TabIndex = 17;
            this.descriptionComboBox.UseSelectable = true;
            // 
            // addOrderButton
            // 
            this.addOrderButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.addOrderButton.Highlight = true;
            this.addOrderButton.Location = new System.Drawing.Point(578, 342);
            this.addOrderButton.Name = "addOrderButton";
            this.addOrderButton.Size = new System.Drawing.Size(170, 42);
            this.addOrderButton.TabIndex = 16;
            this.addOrderButton.Text = "Add Order";
            this.addOrderButton.UseSelectable = true;
            this.addOrderButton.Click += new System.EventHandler(this.addOrderButton_Click);
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.quantityLabel.Location = new System.Drawing.Point(74, 230);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(81, 25);
            this.quantityLabel.TabIndex = 15;
            this.quantityLabel.Text = "Quantity:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.priceLabel.Location = new System.Drawing.Point(101, 163);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(53, 25);
            this.priceLabel.TabIndex = 14;
            this.priceLabel.Text = "Price:";
            // 
            // tableLabel
            // 
            this.tableLabel.AutoSize = true;
            this.tableLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.tableLabel.Location = new System.Drawing.Point(101, 96);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(54, 25);
            this.tableLabel.TabIndex = 13;
            this.tableLabel.Text = "Table:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.descriptionLabel.Location = new System.Drawing.Point(53, 31);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(101, 25);
            this.descriptionLabel.TabIndex = 12;
            this.descriptionLabel.Text = "Description:";
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.itemListView);
            this.metroTabPage4.Controls.Add(this.deliverButton);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(800, 405);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Ready orders";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
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
            this.itemListView.Location = new System.Drawing.Point(66, 30);
            this.itemListView.MultiSelect = false;
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(681, 310);
            this.itemListView.TabIndex = 7;
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
            this.Description.Width = 315;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 128;
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
            // deliverButton
            // 
            this.deliverButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.deliverButton.Highlight = true;
            this.deliverButton.Location = new System.Drawing.Point(577, 346);
            this.deliverButton.Name = "deliverButton";
            this.deliverButton.Size = new System.Drawing.Size(170, 42);
            this.deliverButton.TabIndex = 6;
            this.deliverButton.Text = "Deliver";
            this.deliverButton.UseSelectable = true;
            this.deliverButton.Click += new System.EventHandler(this.deliverButton_Click);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(800, 405);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Consult tables";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // RoomWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 508);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "RoomWindow";
            this.Text = "Room";
            this.Load += new System.EventHandler(this.ReadyOrder_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceUpDown)).EndInit();
            this.metroTabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile notificationsTile;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroRadioButton radioButtonBar;
        private MetroFramework.Controls.MetroRadioButton radioButtonKitchen;
        private MetroFramework.Controls.MetroLabel localLabel;
        private System.Windows.Forms.NumericUpDown quantityUpDown;
        private System.Windows.Forms.NumericUpDown priceUpDown;
        private MetroFramework.Controls.MetroComboBox tableComboBox;
        private MetroFramework.Controls.MetroComboBox descriptionComboBox;
        public MetroFramework.Controls.MetroButton addOrderButton;
        private MetroFramework.Controls.MetroLabel quantityLabel;
        private MetroFramework.Controls.MetroLabel priceLabel;
        private MetroFramework.Controls.MetroLabel tableLabel;
        private MetroFramework.Controls.MetroLabel descriptionLabel;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Table;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
        public MetroFramework.Controls.MetroButton deliverButton;
    }
}