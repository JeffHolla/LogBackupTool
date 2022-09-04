using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackupTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            while (true)
            {
                // Scheduler for copy
                Thread.Sleep(TimeSpan.FromMinutes(5));

                try
                {
                    // Get drive to copy
                    string[] drives = Environment.GetLogicalDrives();
                    var driveToBackup = drives.First(x => x == "E:\\");

                    // Get all log files to backup
                    var logFiles = new DirectoryInfo(driveToBackup).GetFiles("*.log", SearchOption.AllDirectories);

                    // Copy files into dest folder
                    foreach (var file in logFiles)
                    {
                        File.Copy(file.FullName, @"C:\Users\UserName\Documents\" + file.Name);
                    }
                }
                catch (Exception) {}
            }
        }
    }
}
