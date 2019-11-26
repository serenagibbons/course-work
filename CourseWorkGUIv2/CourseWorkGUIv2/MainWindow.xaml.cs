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
using ClassLibrary;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Data.Common;

namespace CourseWorkGUIv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CourseWork courseWork;

        string connString = @"server=(LocalDB)\MSSQLLocalDB;" +
                "database=CourseWork;" +
                "Trusted_Connection=True;" +
                "MultipleActiveResultSets=True;";

        SqlConnection sqlConn;
        string sql;
        SqlCommand command;
        SqlDataReader reader;

        //*****************************************************************************
        // Method: MainWindow
        //
        // Purpose: Initialize main window
        //*****************************************************************************
        public MainWindow()
        {
            InitializeComponent();
        }

        //*****************************************************************************
        // Method: Window_Loaded
        //
        // Purpose: Populates the submissions ListBox with data from the SQL Server 
        // database when the window is loaded
        //*****************************************************************************
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayData();
        }

        //*****************************************************************************
        // Method: DisplayData
        //
        // Purpose: Reads in data from the database and displays it in the submission
        // list box
        //*****************************************************************************
        private void DisplayData()
        {
            //SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open(); // Open the connection
            
            // Setup the SQL command
            sql = "SELECT * FROM Submission";
            command = new SqlCommand(sql, sqlConn);

            // Retrieve the data from the database
            reader = command.ExecuteReader();

            // Associate the ListBox with the SqlDataReader
            submissionListBox.ItemsSource = reader;
        }

        //*****************************************************************************
        // Method: AddData
        //
        // Purpose: Reads in data from the CourseWork object and adds it to the database
        //*****************************************************************************
        private void AddData(CourseWork c)
        {
            // delete all existing records before inserting new data
            string delete = "DELETE FROM Submission;";

            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            SqlCommand command = new SqlCommand(delete, sqlConn);
            int rowsAffected = command.ExecuteNonQuery();

            for (int i = 0; i < c.Submissions.Count; ++i)
            {
                // sql insert statement to insert input fields into new row
                string insert = "INSERT INTO Submission (AssignmentName, CategoryName, Grade)" +
                    "VALUES ('" + c.Submissions[i].AssignmentName + "', '" + c.Submissions[i].CategoryName + "', '" + c.Submissions[i].Grade + "');";

                sqlConn = new SqlConnection(connString);
                sqlConn.Open();

                command = new SqlCommand(insert, sqlConn);
                rowsAffected = command.ExecuteNonQuery();
            }

        }
        //*****************************************************************************
        // Method: ExitMenu_Handler
        //
        // Purpose: Close the window
        //*****************************************************************************
        private void ExitMenu_Handler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //*****************************************************************************
        // Method: AboutMenu_Handler
        //
        // Purpose: Display a pop up message about the program
        //*****************************************************************************
        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Course Work GUI\n" +
                "Version 2.0\n" +
                "Written by Serena Gibbons");
        }

        //*****************************************************************************
        // Method: ImportItem_Handler
        //
        // Purpose: Reads course work data from the selected course work JSON file 
        // into the database
        //*****************************************************************************
        private void ImportItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

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
                   
                // add data to the database
                AddData(courseWork);
                
                // display data from database in the submission listbox
                DisplayData();

            }
        }

        //*****************************************************************************
        // Method: SubmissionListBox_SelectionChanged
        //
        // Purpose: Display appropriate data when a submission is selected in the 
        // submission ListBox.
        //*****************************************************************************
        private void SubmissionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (submissionListBox.SelectedIndex > -1) { 
                // get the item selected               
                DbDataRecord record = (DbDataRecord)e.AddedItems[0];

                ShowSubmissionDetails(record);
            }
        }

        //*****************************************************************************
        // Method: ShowSubmissionDetails
        //
        // Purpose: Set textbox text's of the selected submission object
        //*****************************************************************************
        private void ShowSubmissionDetails(DbDataRecord record) 
        {
            // Setup the SQL command
            string sql = "SELECT * FROM Submission WHERE AssignmentName = '" + record.GetString(0) + "';";
            SqlCommand command = new SqlCommand(sql, sqlConn);

            // Retrieve the data from the database
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // set text fields
                    assignmentTextBox.Text = reader.GetString(0);
                    categoryTextBox.Text = reader.GetString(1);
                    gradeTextBox.Text = reader.GetDouble(2).ToString();
                }
            }
        }
    }
}