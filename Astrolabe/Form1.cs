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
using Galactic.Configuration;

namespace Astrolabe
{
    public partial class Form1 : Form
    {

        private ConfigurationItem configItem = null;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(String fileNameAndPath)
        {
            InitializeComponent();
            openFile(fileNameAndPath);
            
        }
        /// <summary>
        /// Runs the necessary steps to open the file with path 
        /// specified in the argument. 
        /// Provides a single method for logic that may be called 
        /// from several other methods.
        /// </summary>
        /// <param name="fileNameAndPath"></param>
        private void openFile(String fileNameAndPath)
        {
            // Get the configuration item from the file specified by the user.
            FileInfo fileInfo = new FileInfo(fileNameAndPath);
            configItem = new ConfigurationItem(fileInfo.DirectoryName, fileInfo.Name.Replace(".config", ""), true);

            // Load the data from the file.
            nameLabel.Text = configItem.Name;
            valueTextBox.Text = configItem.Value;

            openFileLabel.Visible = false;
            openFileButton.Visible = false;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".config";
            saveDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
            saveDialog.Title = "Create New Configuration File";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(saveDialog.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.DefaultExt = ".config";
            openDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
            openDialog.Title = "Open Configuration File";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(openDialog.FileName);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nameLabel.Text = "";
            valueTextBox.Text = "";
            configItem = null;

            openFileLabel.Visible = true;
            openFileButton.Visible = true;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".config";
            saveDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
            saveDialog.Title = "Save Configuration File As";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the configuration item from the file specified by the user.
                FileInfo fileInfo = new FileInfo(saveDialog.FileName);
                ConfigurationItem newConfigItem = new ConfigurationItem(fileInfo.DirectoryName, fileInfo.Name.Replace(".config", ""), true);

                // Save the data shown in the interface to the file.
                newConfigItem.Value = valueTextBox.Text;

                // Set the new file as active in the interface.
                configItem = newConfigItem;

                // Load the data from the file.
                nameLabel.Text = configItem.Name;
                valueTextBox.Text = configItem.Value;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configItem.Value = valueTextBox.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }
    }
}
