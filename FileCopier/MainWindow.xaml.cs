using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;

namespace FileCopier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "FreshFiles";
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                Directory.CreateDirectory(desktopPath + "\\FreshFiles");
                string desktop = desktopPath + "\\FreshFiles";
                if (Documents.IsChecked == true)
                {
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    Copy(docPath, desktop);
                }
                if (Downloads.IsChecked == true)
                {
                    string downPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Download\\";
                    Copy(downPath, desktop);
                }
                if (Photos.IsChecked == true)
                {
                    string photoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    Copy(photoPath, desktop);
                }
                if (Videos.IsChecked == true)
                {
                    string VideoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                    Copy(VideoPath, desktop);
                }
                if (Music.IsChecked == true)
                {
                    string musicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    Copy(musicPath, desktop);
                }
                if (Desktop.IsChecked == true)
                {
                    string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    Copy(deskPath, desktop);
                }
                
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                Error.Content = err;
            }
            
           
        }
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            foreach (string dirPath in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourceDirectory, targetDirectory));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourceDirectory, targetDirectory), true);
        }
    }
}
