﻿
using System.Windows.Forms;
using Newtonsoft.Json;
using InventoryManager.Data;
using System.IO;
using InventoryManager.Winforms.ViewModels;

namespace InventoryManager.Winforms
{
    public partial class MainForm : Form
    {
        private WorldViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                if (mViewModel != value)
                {
                    mViewModel = value;
                    worldViewModelBindingSource.DataSource = mViewModel;
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
        }

        private void SelectFileButton_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName; 
            }
        }
        private WorldViewModel mViewModel;

        private void playerNameTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
