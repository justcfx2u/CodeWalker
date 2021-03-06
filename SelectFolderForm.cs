﻿using CodeWalker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeWalker
{
    public partial class SelectFolderForm : Form
    {

        public string SelectedFolder { get; set; }
        public DialogResult Result { get; set; } = DialogResult.Cancel;

        public SelectFolderForm()
        {
            InitializeComponent();
        }

        private void SelectFolderForm_Load(object sender, EventArgs e)
        {
            FolderTextBox.Text = Settings.Default.GTAFolder;
        }

        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.SelectedPath = FolderTextBox.Text;
            DialogResult res = FolderBrowserDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                FolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void FolderTextBox_TextChanged(object sender, EventArgs e)
        {
            SelectedFolder = FolderTextBox.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SelectedFolder))
            {
                MessageBox.Show("The folder \"" + SelectedFolder + "\" does not exist, or cannot be accessed. Please select another.");
                return;
            }
            if (!File.Exists(SelectedFolder + "\\gta5.exe"))
            {
                MessageBox.Show("GTA5.exe not found in folder:\n" + SelectedFolder);
                return;
            }
            Result = DialogResult.OK;
            Close();
        }
    }
}
