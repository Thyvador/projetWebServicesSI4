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
            this.ContractList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "City";
            this.columnHeader3.Width = 177;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 500);
            this.Controls.Add(this.ContractList);
            this.Controls.Add(this.ContractsView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ContractsView;
        private System.Windows.Forms.ListView ContractList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

