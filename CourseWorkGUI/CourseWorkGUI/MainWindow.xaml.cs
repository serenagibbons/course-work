//*****************************************************************************
// File: MainWindow.xaml.cs
//
// Purpose: Contains the business logic for MainWindow.xaml of CourseWorkGUI. 
// This partial class imports the ClassLibrary DLL and creates a graphical 
// user interface for displaying course work data.
//
// Written by: Serena Gibbons
//
// Compiler: Visual Studio 2017
//*****************************************************************************
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

        //*****************************************************************************
        // Method: OpenButton_Click
        //
        // Purpose: Opens the file dialog to allow the user to select a json file to open.
        //*****************************************************************************
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
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

                // clear all submission textboxes
                txtAssignmentName.Clear();
                txtSubAssignment.Clear();
                txtSubCateogry.Clear();
                txtSubGrade.Clear();

                // display course name and overall grade
                txtCourseName.Text = courseWork.CourseName;
                txtOverallGrade.Text = Math.Round(courseWork.CalculateGrade(), 2).ToString();

                // add to category listview
                for (int i = 0; i < courseWork.Categories.Count; ++i)
                {
                    listCategories.Items.Add(courseWork.Categories[i]);
                }

                // add to assignment listview
                for (int i = 0; i < courseWork.Assignments.Count; ++i)
                {
                    listAssignments.Items.Add(courseWork.Assignments[i]);
                }

                // add to submission listview
                for (int i = 0; i < courseWork.Submissions.Count; ++i)
                {
                    listSubmissions.Items.Add(courseWork.Submissions[i]);
                }
            }
        }

        //*****************************************************************************
        // Method: FindSubmissionButton_Click
        //
        // Purpose: Searches the submissions (inside of CourseWork instance) for the 
        // assignment name the user typed into the Target Assignment Name TextBox. 
        // If the submission is found, the submission textboxes will be populated with
        // submission information. If no submission is found, the submission textboxes
        // will be cleared.
        //*****************************************************************************
        private void FindSubmissionButton_Click(object sender, RoutedEventArgs e)
        {
            string assignment = txtAssignmentName.Text;
            Submission submission = courseWork.FindSubmission(assignment);

            // if submission is null clear all submission textboxes
            if (submission == null)
            {
                txtAssignmentName.Clear();
                txtSubAssignment.Clear();
                txtSubCateogry.Clear();
                txtSubGrade.Clear();
                return;
            }
            // submission found, set submission textboxes
            txtSubAssignment.Text = submission.AssignmentName;
            txtSubCateogry.Text = submission.CategoryName;
            txtSubGrade.Text = submission.Grade.ToString();
        }
    }
}
