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
using System.Data.SqlClient;

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
                "Trusted_Connection=True;";

        //*****************************************************************************
        // Method: MainWindow
        //
        // Purpose: Initialize main window
        //*****************************************************************************
        public MainWindow()
        {
            InitializeComponent();
            courseWork = new CourseWork();
        }

        //*****************************************************************************
        // Method: Window_Loaded
        //
        // Purpose: Populates the submissions ListBox with data from the SQL Server 
        // database when the window is loaded
        //*****************************************************************************
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // AddData();
            // DisplayData();
        }

        //*****************************************************************************
        // Method: DisplayData
        //
        // Purpose: Reads in data from the database and displays it in the submission
        // list box
        //*****************************************************************************
        private void DisplayData()
        {
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open(); // Open the connection

            // Setup the SQL command
            string sql = "SELECT * FROM Submission";
            SqlCommand command = new SqlCommand(sql, sqlConn);

            // Retrieve the data from the database
            SqlDataReader reader = command.ExecuteReader();

            // Associate the ListBox with the SqlDataReader, this will automatically populate the ListBox.
            //submissionListBox.ItemsSource = reader;
            submissionListBox.Items.Add(reader["AssignmentName"]);
        }

        //*****************************************************************************
        // Method: AddData
        //
        // Purpose: Reads in data from the CourseWork object into the database
        //*****************************************************************************
        private void AddData()
        {
            for (int i = 0; i < courseWork.Submissions.Count; ++i)
            {
                // sql insert statement to insert input fields into new row
                string insert = "INSERT INTO Submission (AssignmnetName, CategoryName, Grade)" +
                    "VALUES ('" + courseWork.Submissions[i].AssignmentName + "', '" + courseWork.Submissions[i].CategoryName + "', '" + courseWork.Submissions[i].Grade + "');";

                SqlConnection sqlConn;
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();

                SqlCommand command = new SqlCommand(insert, sqlConn);
                int rowsAffected = command.ExecuteNonQuery();
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

        }
    }
}
