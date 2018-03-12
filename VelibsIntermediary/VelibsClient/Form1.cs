using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelibsClient
{
    public partial class Form1 : Form
    {
        VelibsIntermediary.VelibsService client;
        string currentContract;
        public Form1()
        {
            InitializeComponent();


                client = new VelibsIntermediary.VelibsService();
            ListViewItem contracts = new ListViewItem();


            foreach (var contract in client.GetContracts())
            {
                ContractsView.Items.Add(contract.Name);
            }
        }

        private void ContractsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContractsView.SelectedIndices.Count <= 0)
            {
                return;
            }
            int index = ContractsView.SelectedIndices[0];
            if (currentContract == ContractsView.Items[index].Text)
            {
                return;
            }

            currentContract = ContractsView.Items[index].Text;
            ContractList.Items.Clear();
            foreach (var contract in client.GetContract(currentContract))
            {
                string name;
                if (contract.Name.Contains("-"))
                {
                    name = contract.Name.Split('-')[1];
                }
                else
                {
                    name = contract.Name;
                }
                ContractList.Items.Add(
                    new ListViewItem(new[] {
                        name,
                        contract.Address}));
            }
            
        }
    }
}
