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
using System.Windows.Forms;
using System.IO;

namespace File_Sorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, string> DictMois = new Dictionary<int, string>()
        {
            {1,"Janvier" },
            {2, "Fevrier"},
            {3, "Mars"},
            {4, "Avril"},
            {5, "Mai"},
            {6, "Juin"},
            {7, "Juillet"},
            {8, "Aout"},
            {9, "Septembre"},
            {10, "Octobre"},
            {11, "Novembre"},
            {12, "Decembre"}
        };


        public MainWindow()
        {
            //InitializeComponent();
            Console.WriteLine("damb");
            string path = GetFolderPath();
            if (!string.IsNullOrEmpty(path))
            {
                SortFiles(path);
            }
            Environment.Exit(0);
        }

        public string GetFolderPath()
        {
            string folderPath = "";
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    folderPath = folderBrowserDialog1.SelectedPath;

                }
            }
            return folderPath;
        }

        public void SortFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DateTime creat;
            //int count ...
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Name.StartsWith("IMG_") || file.Name.StartsWith("VID_"))
                {
                    string date = file.Name.Substring(4, 8);
                    try
                    {
                        //creat.Year = Convert.Todate.Substring(0, 4);
                        creat = new DateTime(year: int.Parse(date.Substring(0, 4)), month: int.Parse(date.Substring(4, 2)), day: int.Parse(date.Substring(6, 2)));
                        //string destFolder = string.Format(@"{0}\\{1}", creat.Year, creat.Month);
                        string destFolder = CheckAndCreateFolder(path, creat.Year, creat.Month, creat.Day);
                        file.MoveTo(System.IO.Path.Combine(destFolder,file.Name));
                    }
                    catch
                    {

                    }
                }
                //else
                //    Log(...)

            }
        }

        private string CheckAndCreateFolder(string path, int year, int month, int day)
        {
            DirectoryInfo DI;
            path = System.IO.Path.Combine(path, year.ToString());
            DI = new DirectoryInfo(path);
            if (!DI.Exists)
            {
                Directory.CreateDirectory(DI.FullName);
            }
            path = System.IO.Path.Combine(path, DictMois[month]);
            DI = new DirectoryInfo(path);
            if (!DI.Exists)
            {
                Directory.CreateDirectory(DI.FullName);
            }

            path = System.IO.Path.Combine(path, day.ToString());
            DI = new DirectoryInfo(path);
            if (!DI.Exists)
            {
                Directory.CreateDirectory(DI.FullName);
            }
            return path;
        }

    }
}
