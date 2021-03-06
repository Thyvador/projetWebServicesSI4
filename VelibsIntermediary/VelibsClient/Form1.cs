﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VelibsIntermediary;

namespace VelibsClient
{
    public partial class Form1 : Form
    {
        VelibsService client;
        string currentContract;
        List<Station> stations;


        public Form1()
        {
            InitializeComponent();


            client = new VelibsService();
            LoadContracts();
        }

        private async void LoadContracts()
        {
            ListViewItem contracts = new ListViewItem();

            List<CompositeContract> compositeContracts = await client.GetContractsAsync();
            foreach (var contract in compositeContracts)
            {
                ContractsView.Items.Add(contract.Name);
            }
        }

        private void ContractsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            stations = new List<Station>();
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
            LoadSations();

        }

        private async void LoadSations()
        {
            foreach (var contract in await client.GetContractAsync(currentContract))
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
                stations.Add(new Station(name, contract.Address, contract.Number));
                ContractList.Items.Add(
                    new ListViewItem(new[] { name, contract.Address }));
            }
        }


        private void ContractList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContractList.SelectedIndices.Count <= 0)
            {
                return;
            }
            int index = ContractList.SelectedIndices[0];
            LoadStationsDetails(index);
        }

        private async void LoadStationsDetails(int index)
        {
            var station = await client.GetStationAsync(currentContract, stations[index].Number);
            BikesTextBox.Text = station.Available_Bikes.ToString();
            BikeStansTextBox.Text = station.Available_Bike_Stands.ToString();
            NameTextBox.Text = station.Name;
        }




        private class Station
        {
            public Station(string name, string address, int number)
            {
                Name = name;
                Address = address;
                Number = number;
            }

            public string Name { get; set; }
            public string Address { get; set; }
            public int Number { get; set; }
        }
    }
}
