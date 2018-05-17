///
///
///     Made by Tomasz Węcławski
///
///

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
            miniTCPanel2.LoadDrivers += MiniTCPanel2_LoadDrivers;
            //  miniTCPanel1.LoadDirectories += MiniTCPanel1_LoadDirectories;
            //  miniTCPanel2.LoadDirectories += MiniTCPanel2_LoadDirectories;
            miniTCPanel1.LoadDirectories += MiniTCPanel1_LoadDirectories1;
            miniTCPanel2.LoadDirectories += MiniTCPanel2_LoadDirectories1;
            /*miniTCPanel1.Delete_Directory += MiniTCPanel1_Delete_Directory;
            miniTCPanel2.Delete_Directory += MiniTCPanel2_Delete_Directory;
            miniTCPanel1.Copy_Directory += MiniTCPanel1_Copy_Directory;
            miniTCPanel2.Copy_Directory += MiniTCPanel2_Copy_Directory;
            miniTCPanel1.Move_Directory += MiniTCPanel1_Move_Directory;
            miniTCPanel2.Move_Directory += MiniTCPanel2_Move_Directory;*/


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

        

        private string[] MiniTCPanel_LoadDirectories(MiniTCPanel obj, string d, string f)
        {
            try
            {
                string[] directories = Directory.GetDirectories(d);
                string[] files = Directory.GetFiles(f);
                string[] tmp = new string[directories.Length + files.Length];
                for (int i = 0; i < directories.Length - 1; i++)
                {
                    tmp[i] = directories[i];
                }
                for (int i = 0; i < files.Length - 1; i++)
                {
                    tmp[i + directories.Length] = files[i];
                    Console.WriteLine(files[i]);
                }
                return tmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private string[] MiniTCPanel2_LoadDirectories1(MiniTCPanel obj, string d, string f)
        {
            return MiniTCPanel_LoadDirectories(obj, d, f);
        }

        private string[] MiniTCPanel1_LoadDirectories1(MiniTCPanel obj, string d, string f)
        {
            return MiniTCPanel_LoadDirectories(obj, d, f);
        }
        /*   private string[] MiniTCPanel1_LoadDirectories(MiniTCPanel obj, string d, string f)
           {
               return MiniTCPanel_LoadDirectories(obj, d, f);
           }

           private string[] MiniTCPanel2_LoadDirectories(MiniTCPanel obj, string d, string f)
           {
               return MiniTCPanel_LoadDirectories(obj, d, f);
           }*/


        /*
         * 
         * 
         * Klikamy na folder, który chcemy przenieść,
         * natomiast w drugiej kontrolce (panelu, widoku)
         * wchodzimy do folder docelowy.
         * 
         * 
         */

        private void MiniTCPanel1_Move_Directory(MiniTCPanel obj)
        {
            // string sourceDir = obj.currentSelectedDirectory();
            // string destDir = miniTCPanel2.currentDir() + '\\' + 
            //      sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);
            string sourceDir = obj.returnSelectedItem();
            string destDir = miniTCPanel2.currentDir() + '\\' + sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);
            MessageBox.Show("Tu 1");
            MessageBox.Show(sourceDir + " to " + destDir);
            Directory.Move(sourceDir, destDir);
            obj.loadContent(miniTCPanel1, obj.CurrentPath, obj.CurrentPath);
            miniTCPanel2.loadContent(miniTCPanel2, miniTCPanel2.CurrentPath, miniTCPanel2.CurrentPath);
          //  obj.loadContent(obj, destDir, destDir);
        }
        private void MiniTCPanel2_Move_Directory(MiniTCPanel obj)
        {
            //string sourceDir = obj.currentSelectedDirectory();
            //string destDir = miniTCPanel1.currentDir() + '\\' +
            //      sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);
            string sourceDir = obj.returnSelectedItem();
            string destDir = miniTCPanel1.currentDir() + '\\' + sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);
            MessageBox.Show("Tu 2");
            MessageBox.Show(sourceDir + " to " + destDir);
            Directory.Move(sourceDir, destDir);
            // obj.loadContent(obj, destDir, destDir);
            obj.loadContent(miniTCPanel1, obj.CurrentPath, obj.CurrentPath);
            miniTCPanel1.loadContent(miniTCPanel1, miniTCPanel1.CurrentPath, miniTCPanel1.CurrentPath);
        }

        private void MiniTCPanel_Copy_Directory(/*MiniTCPanel obj, */string sourceDir, string destDir)
        {
            #region 1
            /* s = obj.currentSelectedDirectory();
             d = miniTCPanel2.currentDir() + '\\' +
                 obj.currentSelectedDirectory().Substring(obj.currentSelectedDirectory().LastIndexOf('\\') + 1);
             string sourceDir = obj.currentSelectedDirectory();
             string destDir = miniTCPanel2.currentDir() + '\\' +
                 obj.currentSelectedDirectory().Substring(obj.currentSelectedDirectory().LastIndexOf('\\') + 1);*/
            #endregion
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
          //  MessageBox.Show(sourceDir + " to " + destDir);

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            foreach(FileInfo file in files)
            {
                string tmp = Path.Combine(destDir, file.Name);
                //MessageBox.Show(file + " to " + tmp);
                file.CopyTo(tmp, false);
            }

            foreach(DirectoryInfo subDir in dirs)
            {
                string tmp = Path.Combine(destDir, subDir.Name);
                MiniTCPanel_Copy_Directory(subDir.FullName, tmp);
            }
        }

        /*   private void MiniTCPanel2_Copy_Directory(/*MiniTCPanel obj, ||string sourceDir, string destDir)
           {
             /*  string sourceDir = obj.currentSelectedDirectory();
               string destDir = miniTCPanel1.currentDir() + '\\' +
                   obj.currentSelectedDirectory().Substring(obj.currentSelectedDirectory().LastIndexOf('\\') + 1); ||
               DirectoryInfo dir = new DirectoryInfo(sourceDir);
               DirectoryInfo[] dirs = dir.GetDirectories();
               FileInfo[] files = dir.GetFiles();
               MessageBox.Show(sourceDir + " to " + destDir);

               if (!Directory.Exists(destDir))
               {
                   Directory.CreateDirectory(destDir);
               }

               foreach (FileInfo file in files)
               {
                   string tmp = Path.Combine(destDir, file.Name);
                   file.CopyTo(tmp, false);
               }

               foreach (DirectoryInfo subDir in dirs)
               {
                   string tmp = Path.Combine(destDir, subDir.Name);
                   MiniTCPanel2_Copy_Directory(subDir.FullName, tmp);
               }
           }*/

       /* private void MiniTCPanel1_Delete_Directory(MiniTCPanel obj)
        {
            Directory.Delete(obj.currentSelectedDirectory(), true);
        }
        */

        private void MiniTCPanel_Delete_Directory(MiniTCPanel obj)
        {
            FileAttributes attr = File.GetAttributes(obj.currentSelectedDirectory());
            if (attr.HasFlag(FileAttributes.Directory))
                Directory.Delete(obj.currentSelectedDirectory(), true);
            else
                File.Delete(obj.currentSelectedDirectory());

            if (miniTCPanel1.CurrentPath == miniTCPanel2.CurrentPath)
            {
                miniTCPanel1.loadContent(miniTCPanel1, miniTCPanel1.CurrentPath, miniTCPanel1.CurrentPath);
                miniTCPanel2.loadContent(miniTCPanel2, miniTCPanel2.CurrentPath, miniTCPanel2.CurrentPath);
            }
            else
            {
                obj.loadContent(obj, obj.CurrentPath, obj.CurrentPath);
            }
        }




        /*  private MiniTCPanel MiniTCPanel1_GetCurrentPath(MiniTCPanel obj)
          {

          }*/


        private void MiniTCPanel1_LoadDrivers(MiniTCPanel obj)
        {
           
        }

        private void MiniTCPanel2_LoadDrivers(MiniTCPanel obj)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFocus == 1)
                {
                    MiniTCPanel_Delete_Directory(miniTCPanel1);
                    MessageBox.Show("Deleting " + miniTCPanel1.currentSelectedDirectory() + " with content was successful.");
                }
                else if (currentFocus == 2)
                {
                    MiniTCPanel_Delete_Directory(miniTCPanel2);
                    MessageBox.Show("Deleting " + miniTCPanel2.currentSelectedDirectory() + " with content was successful.");
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
                if (currentFocus == 2)
                {
                    //  string sourceDir = miniTCPanel1.currentSelectedDirectory();
                    //string destDir = miniTCPanel2.currentDir() + '\\' +
                    //  sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);
                    string sourceDir = miniTCPanel1.returnSelectedItem();
                    string destDir = miniTCPanel2.currentDir() + '\\' +
                        sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);

                    MiniTCPanel_Copy_Directory(sourceDir, destDir);
                    MessageBox.Show("Copied " + sourceDir + " to " + destDir);
                    miniTCPanel2.loadContent(miniTCPanel2, miniTCPanel2.currentDir(), miniTCPanel2.currentDir());
                }
                else if (currentFocus == 1)
                {
                    //   string sourceDir = miniTCPanel2.currentSelectedDirectory();
                    // string destDir = miniTCPanel1.currentDir() + '\\' +
                    //   sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);
                    string sourceDir = miniTCPanel2.returnSelectedItem();
                    string destDir = miniTCPanel1.currentDir() + '\\' +
                        sourceDir.Substring(sourceDir.LastIndexOf('\\') + 1);


                    MiniTCPanel_Copy_Directory(sourceDir, destDir);
                    MessageBox.Show("Copied " + sourceDir + " to " + destDir);
                    miniTCPanel1.loadContent(miniTCPanel1, miniTCPanel1.currentDir(), miniTCPanel1.currentDir());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentFocus == 2)
                {
                    MiniTCPanel1_Move_Directory(miniTCPanel1);
                }
                else if (currentFocus == 1)
                {
                    MiniTCPanel2_Move_Directory(miniTCPanel2);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
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

    }
}
