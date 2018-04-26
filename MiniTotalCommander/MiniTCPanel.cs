﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MiniTotalCommander
{
    public partial class MiniTCPanel : UserControl
    {
        static bool areDrivesLoaded = false;
        public event Action<MiniTCPanel> LoadDrivers;
        public event Action<MiniTCPanel> Delete_Directory;
        public event Action<MiniTCPanel> Copy_Directory;
        public event Action<MiniTCPanel> Move_Directory;

        public MiniTCPanel()
        {
            InitializeComponent();
            foreach (DriveInfo d in DriveInfo.GetDrives())
                if (d.IsReady)
                    drivesList.Items.Add(d);
            string[] directories = { };
        }

        public string CurrentPath
        {
            get { return currentPathBox.Text;  }
        }

        public string[] Drivers
        {
            set
            {
                if (value != null)
                    drivesList.Items.AddRange(value);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
            if (LoadDrivers != null)
                if (!areDrivesLoaded)
                {
                    areDrivesLoaded = true;
                    LoadDrivers(this);
                }
        }
        

        private void drivesList_SelectedIndexChanged(object sender, EventArgs e)
        {

            currentPathBox.Text = drivesList.SelectedItem.ToString();
            try
            {
                string[] directories = Directory.GetDirectories(drivesList.SelectedItem.ToString());
                string[] files = Directory.GetFiles(currentPathBox.Text);
                containerBox.Items.Clear();
                foreach (string d in directories)
                {
                    containerBox.Items.Add(d);//.Substring(d.LastIndexOf('\\') + 1));
                }
                foreach (string f in files)
                {
                    containerBox.Items.Add(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal string returnPath()
        {
            return currentPathBox.Text;
        }

        private void containerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string root = 
           //     drivesList.SelectedItem.ToString().Substring(drivesList.SelectedItem.ToString().LastIndexOf(':')-1);
            currentPathBox.Text = /*root + */containerBox.SelectedItem.ToString();
        }

        public void containerBox_DoubleClick(object sender, EventArgs e)
        {
            containerBox.Items.Clear();
            try
            {
                string[] subdirectories = Directory.GetDirectories(currentPathBox.Text);
                string[] files = Directory.GetFiles(currentPathBox.Text);
                foreach (string s in subdirectories)
                {
                    containerBox.Items.Add(s);//.Substring(s.LastIndexOf('\\') + 1));
                }
                foreach (string f in files)
                {
                    containerBox.Items.Add(f);// Path.GetFileName(f));
                }
                if (!Directory.Exists(currentPathBox.Text))
                {
                    string curr = currentPathBox.Text;
                    Process.Start(curr);
                }

            }
            catch (UnauthorizedAccessException ex)
            {
            //    string curr = currentPathBox.Text;
            //    Process.Start(currentPathBox.Text);
                MessageBox.Show(ex.Message);
            }
            catch (Win32Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch (IOException exc)
            {
                Process.Start(currentPathBox.Text);
                string xxx = Path.GetDirectoryName(currentPathBox.Text);
                string[] subdirectories = Directory.GetDirectories(xxx);
                string[] files = Directory.GetFiles(xxx);
                currentPathBox.Text = xxx;
                containerBox.Items.Clear();
                foreach (string s in subdirectories)
                {
                    containerBox.Items.Add(s);
                }
                foreach (string f in files)
                {
                    containerBox.Items.Add(f);
                }
            }
        }

        private void currentPathBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MiniTCPanel_Load(object sender, EventArgs e)
        {

        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                string parent = Directory.GetParent(currentPathBox.Text).ToString();
                containerBox.Items.Clear();
                string[] subdirectories;
                string[] files;
                if (containerBox.SelectedItem == null)
                {
                    subdirectories = Directory.GetDirectories(parent);
                    files = Directory.GetFiles(parent);
                }
                else
                {
                    //  Directory dir = Directory.SetCurrentDirectory(parent);
                    string path = currentPathBox.Text.Remove(currentPathBox.Text.LastIndexOf('\\'));
                    parent = Directory.GetParent(path).ToString();
                    subdirectories = Directory.GetDirectories(parent);
                    files = Directory.GetFiles(parent);
                }
                foreach (string s in subdirectories)
                {
                    containerBox.Items.Add(s);//.Substring(s.LastIndexOf('\\') + 1));
                }
                foreach (string f in files)
                {
                    containerBox.Items.Add(f);// Path.GetFileName(f));
                }
                if (!Directory.Exists(currentPathBox.Text))
                {
                    string curr = currentPathBox.Text;
                    Process.Start(curr);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
