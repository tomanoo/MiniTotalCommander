using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MiniTotalCommander
{
    public partial class Form1 : Form
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        int currentFocus;

        string drives = DriveInfo.GetDrives().ToString();
        public Form1()
        {
            InitializeComponent();
            //miniTCPanel1.CurrentPath = @"c:\";
            miniTCPanel1.LoadDrivers += MiniTCPanel1_LoadDrivers;
            miniTCPanel1.Delete_Directory += MiniTCPanel1_Delete_Directory;
            miniTCPanel2.Delete_Directory += MiniTCPanel2_Delete_Directory;
            miniTCPanel1.Copy_Directory += MiniTCPanel1_Copy_Directory;
            miniTCPanel2.Copy_Directory += MiniTCPanel2_Copy_Directory;
            miniTCPanel1.Move_Directory += MiniTCPanel1_Move_Directory;
            miniTCPanel2.Move_Directory += MiniTCPanel2_Move_Directory;


            //DriveInfo

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Console.WriteLine(allDrives);
            
            //Path
            // Path.
            //Directory
            //string currentDirectory = Directory.GetCurrentDirectory();

            //string[] directories = Directory.GetDirectories();
            //File
        }

        private void MiniTCPanel2_Move_Directory(MiniTCPanel obj)
        {
            // MessageBox.Show(obj.CurrentPath.Substring(obj.CurrentPath.LastIndexOf('\\') + 1));
            //Directory.Move(obj.CurrentPath.Substring(obj.CurrentPath.LastIndexOf('\\')), miniTCPanel1.CurrentPath);
            MessageBox.Show(obj.CurrentPath + '\\'+ @miniTCPanel1.CurrentPath);
            Directory.Move(@obj.CurrentPath + '\\', @miniTCPanel1.CurrentPath);
        }

        private void MiniTCPanel1_Move_Directory(MiniTCPanel obj)
        {
            MessageBox.Show(obj.CurrentPath.Substring(obj.CurrentPath.LastIndexOf('\\') + 1));
            Directory.Move(obj.CurrentPath.Substring(obj.CurrentPath.LastIndexOf('\\')), miniTCPanel2.CurrentPath);
        }

        private void MiniTCPanel2_Copy_Directory(MiniTCPanel obj)
        {
            throw new NotImplementedException();
        }

        private void MiniTCPanel1_Copy_Directory(MiniTCPanel obj)
        {
            MessageBox.Show(miniTCPanel2.CurrentPath);// + Path.GetDirectoryName(obj.CurrentPath));
            Directory.CreateDirectory(miniTCPanel2.CurrentPath);// +Path.GetDirectoryName(obj.CurrentPath));
        }

        private void MiniTCPanel2_Delete_Directory(MiniTCPanel obj)
        {
            Directory.Delete(obj.CurrentPath, true);
        }

        private void MiniTCPanel1_Delete_Directory(MiniTCPanel obj)
        {
            Directory.Delete(obj.CurrentPath, true);
        }



        /*  private MiniTCPanel MiniTCPanel1_GetCurrentPath(MiniTCPanel obj)
          {

          }*/


        private void MiniTCPanel1_LoadDrivers(MiniTCPanel obj)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFocus == 1)
                {
                    MiniTCPanel1_Delete_Directory(miniTCPanel1);
                    MessageBox.Show("Deleting " + miniTCPanel1.CurrentPath + " with content was successful.");
                }
                else if (currentFocus == 2)
                {
                    MiniTCPanel2_Delete_Directory(miniTCPanel2);
                    MessageBox.Show("Deleting " + miniTCPanel2.CurrentPath + " with content was successful.");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                MiniTCPanel1_Copy_Directory(miniTCPanel1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void miniTCPanel1_Enter(object sender, EventArgs e)
        {
            miniTCPanel1.Focus();
            currentFocus = 1;
        }

        private void miniTCPanel2_Enter(object sender, EventArgs e)
        {
            miniTCPanel2.Focus();
            currentFocus = 2;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFocus == 2)
                {
                    MiniTCPanel1_Move_Directory(miniTCPanel1);
                    MessageBox.Show("Moved " + miniTCPanel1.CurrentPath + " to " + miniTCPanel2.CurrentPath);
                }
                else if (currentFocus == 1)
                {
                    MiniTCPanel2_Move_Directory(miniTCPanel2);
                    MessageBox.Show("Moved " + miniTCPanel2.CurrentPath + " to " + miniTCPanel1.CurrentPath);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
