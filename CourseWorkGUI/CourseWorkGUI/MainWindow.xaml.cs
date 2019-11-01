using Microsoft.Win32;
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
using ClassLibrary;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CourseWorkGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CourseWork courseWork;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                // display file path name
                txtFilename.Text = fileName;

                // instantiate couseWork
                courseWork = new CourseWork();

                // try reading from file, if exception thrown, break
                try
                {
                    FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    DataContractJsonSerializer input;
                    input = new DataContractJsonSerializer(typeof(CourseWork));
                    courseWork = (CourseWork)input.ReadObject(reader);
                    reader.Close();
                }
                catch (IOException)
                {
                    Console.WriteLine("Invalid file name.\n");
                    return;
                }

                // display course name and overall grade
                txtCourseName.Text = courseWork.CourseName;
                txtOverallGrade.Text = Math.Round(courseWork.CalculateGrade(), 2).ToString();
            }
        }
    }
}
