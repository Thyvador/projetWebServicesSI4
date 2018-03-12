namespace VelibsClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ContractsView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContractList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.BikesTextBox = new System.Windows.Forms.TextBox();
            this.BikeStansTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ContractsView
            // 
            this.ContractsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.ContractsView.Location = new System.Drawing.Point(12, 12);
            this.ContractsView.MultiSelect = false;
            this.ContractsView.Name = "ContractsView";
            this.ContractsView.Size = new System.Drawing.Size(177, 462);
            this.ContractsView.TabIndex = 0;
            this.ContractsView.UseCompatibleStateImageBehavior = false;
            this.ContractsView.View = System.Windows.Forms.View.Details;
            this.ContractsView.SelectedIndexChanged += new System.EventHandler(this.ContractsView_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "City";
            this.columnHeader3.Width = 177;
            // 
            // ContractList
            // 
            this.ContractList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ContractList.Location = new System.Drawing.Point(243, 12);
            this.ContractList.Name = "ContractList";
            this.ContractList.Size = new System.Drawing.Size(325, 454);
            this.ContractList.TabIndex = 1;
            this.ContractList.UseCompatibleStateImageBehavior = false;
            this.ContractList.View = System.Windows.Forms.View.Details;
            this.ContractList.SelectedIndexChanged += new System.EventHandler(this.ContractList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adress";
            this.columnHeader2.Width = 170;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(595, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Available bikes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Available bike stands:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(759, 87);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.ReadOnly = true;
            this.NameTextBox.Size = new System.Drawing.Size(100, 22);
            this.NameTextBox.TabIndex = 5;
            // 
            // BikesTextBox
            // 
            this.BikesTextBox.Location = new System.Drawing.Point(759, 126);
            this.BikesTextBox.Name = "BikesTextBox";
            this.BikesTextBox.ReadOnly = true;
            this.BikesTextBox.Size = new System.Drawing.Size(100, 22);
            this.BikesTextBox.TabIndex = 6;
            // 
            // BikeStansTextBox
            // 
            this.BikeStansTextBox.Location = new System.Drawing.Point(759, 172);
            this.BikeStansTextBox.Name = "BikeStansTextBox";
            this.BikeStansTextBox.ReadOnly = true;
            this.BikeStansTextBox.Size = new System.Drawing.Size(100, 22);
            this.BikeStansTextBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 500);
            this.Controls.Add(this.BikeStansTextBox);
            this.Controls.Add(this.BikesTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ContractList);
            this.Controls.Add(this.ContractsView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ContractsView;
        private System.Windows.Forms.ListView ContractList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox BikesTextBox;
        private System.Windows.Forms.TextBox BikeStansTextBox;
    }
}

