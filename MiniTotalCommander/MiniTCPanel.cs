using System;
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
        private static bool isItemSelected = false;
        private string currentDirectory;
        private string selectedDirectory;
        public event Action<MiniTCPanel> LoadDrivers;
        public event Func<MiniTCPanel, string[]> LoadDirectories;
        /*public event Action<MiniTCPanel> Delete_Directory;
        public event Action<MiniTCPanel> Copy_Directory;
        public event Action<MiniTCPanel> Move_Directory;*/

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
            set { if(value != null)
                    currentPathBox.Text = value; }
        }

        public string currentDir()
        {
            return currentDirectory;
        }

        public string currentSelectedDirectory()
        {
            return selectedDirectory;
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
            if (LoadDirectories != null)
            {
                containerBox.Items.Clear();
                currentPathBox.Text = drivesList.SelectedItem.ToString();
                //containerBox.Items.AddRange(LoadDirectories(this));
                string[] tmp = LoadDirectories(this);
                foreach(string d in tmp)
                {
                    Console.WriteLine(d);
                    containerBox.Items.Add(d);
                }
                //powinno zostać tylko to
                //try
                //{
                //    string[] directories = Directory.GetDirectories(drivesList.SelectedItem.ToString());
                //    string[] files = Directory.GetFiles(currentPathBox.Text);
                //    foreach (string d in directories)
                //    {
                //        containerBox.Items.Add(d);//.Substring(d.LastIndexOf('\\') + 1));
                //    }
                //    foreach (string f in files)
                //    {
                //        containerBox.Items.Add(f);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
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
            //currentPathBox.Text = /*root + */containerBox.SelectedItem.ToString();
            currentDirectory = containerBox.SelectedItem.ToString();
            selectedDirectory = containerBox.SelectedItem.ToString();
            bool isfile;
            try
            {
                FileAttributes attr = File.GetAttributes(currentDirectory);
                if (attr.HasFlag(FileAttributes.Directory))
                    isfile = false;
                else
                    isfile = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (containerBox.SelectedIndex != -1)
            {
                isItemSelected = true;
            }
            else
            {
                isItemSelected = false;
            }

        }

        public void containerBox_DoubleClick(object sender, EventArgs e)
        {
            containerBox.Items.Clear();
            currentPathBox.Text = currentDirectory;
            isItemSelected = false;
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
                subdirectories = Directory.GetDirectories(parent);
                files = Directory.GetFiles(parent);
                #region if else
                /* if (!isItemSelected)
                 {
                     // subdirectories = Directory.GetDirectories(parent);
                     //files = Directory.GetFiles(parent);
                     subdirectories = Directory.GetDirectories(currentPathBox.Text);
                     files = Directory.GetFiles(currentPathBox.Text);
                     currentPathBox.Text = parent;

                 }
                 else
                 {
                     //  Directory dir = Directory.SetCurrentDirectory(parent);
                    // string path = currentPathBox.Text.Remove(currentPathBox.Text.LastIndexOf('\\'));
                    // parent = //parent.Remove(parent.LastIndexOf('\\'));// Directory.GetParent(path).ToString();
                     parent = Directory.GetParent(parent).ToString();

                     subdirectories = Directory.GetDirectories(parent);
                     files = Directory.GetFiles(parent);
                     currentPathBox.Text = parent;
                 }*/
                #endregion
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

                currentDirectory = Directory.GetParent(currentDirectory).ToString();
                if (isItemSelected)
                    currentPathBox.Text = Directory.GetParent(currentDirectory).ToString();
                else
                    currentPathBox.Text = currentDirectory;
                isItemSelected = false;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
