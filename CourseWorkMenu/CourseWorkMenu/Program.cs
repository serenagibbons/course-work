//*****************************************************************************
// File: Program.cs
//
// Purpose: Contains the class definition for Program. Program imports the
// ClassLibrary DLL containing the classes Category, Assignment, Submission,
// and CourseWorkUnitTesting. Program displays a menu to select and perform 
// serializationa and deserialization.
//
// Written By: Serena Gibbons
//
// Compiler: Visual Studio 2017
//
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using ClassLibrary;
using System.Runtime.Serialization.Json;

namespace CourseWorkMenu
{
    class Program
    {

        static void Main(string[] args)
        {
            string menuSelection;

            // instantiate objects to use with serialization/deserialization
            Category category = new Category();
            Assignment assignment = new Assignment();
            Submission submission = new Submission();

            // file names
            string fileName;

            do
            {
                // display menu
                Console.WriteLine("\nCourse Work Menu");
                Console.WriteLine("-------------------");
                Console.WriteLine("1 - Read Category from JSON file");
                Console.WriteLine("2 - Read Category from XML file");
                Console.WriteLine("3 - Write Category to JSON file");
                Console.WriteLine("4 - Write Category to XML file");
                Console.WriteLine("5 - Display Category data on screen");
                Console.WriteLine("6 - Read Assignment from JSON file");
                Console.WriteLine("7 - Read Assignment from XML file");
                Console.WriteLine("8 - Write Assignment to JSON file");
                Console.WriteLine("9 - Write Assignment to XML file");
                Console.WriteLine("10 - Display Assignment data on screen");
                Console.WriteLine("11 - Read Submission from JSON file");
                Console.WriteLine("12 - Read Submission from XML file");
                Console.WriteLine("13 - Write Submission to JSON file");
                Console.WriteLine("14 - Write Submission to XML file");
                Console.WriteLine("15 - Display Submission data on screen");
                Console.WriteLine("16 - Exit");
                Console.Write("Enter Choice: ");

                // read and store user's selection
                menuSelection = Console.ReadLine();
                Console.WriteLine();

                // perform unit testing based on user's input or exit the program
                switch (menuSelection)
                {
                    case "1": // Read Category from JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractJsonSerializer input;
                            input = new DataContractJsonSerializer(typeof(Category));
                            category = (Category)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                            break;
                        }
                        break;
                    case "2": // Read Category from XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractSerializer input;
                            input = new DataContractSerializer(typeof(Category));
                            category = (Category)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                            break;
                        }
                        break;
                    case "3": // Write Category to JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();

                        // change category variables
                        category.Name = "Homework";
                        category.Percentage = 35;

                        // serialization code
                        FileStream cjWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractJsonSerializer cjSer;
                        cjSer = new DataContractJsonSerializer(typeof(Category));
                        cjSer.WriteObject(cjWriter, category);
                        cjWriter.Close();
                        break;
                    case "4": // Write Category to XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();

                        // change category variables
                        category.Name = "Exams";
                        category.Percentage = 50;

                        // serialization code
                        FileStream cxWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractSerializer cxSer;
                        cxSer = new DataContractSerializer(typeof(Category));
                        cxSer.WriteObject(cxWriter, category);
                        cxWriter.Close();
                        break;
                    case "5": // Display Category data on screen
                        Console.WriteLine(category);
                        break;
                    case "6": // Read Assignment from JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractJsonSerializer input;
                            input = new DataContractJsonSerializer(typeof(Assignment));
                            assignment = (Assignment)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                            break;
                        }
                        break;
                    case "7": // Read Assignment from XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractSerializer input;
                            input = new DataContractSerializer(typeof(Assignment));
                            assignment = (Assignment)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                            break;
                        }
                        break;
                    case "8": // Write Assignment to JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();

                        // change assignment variables
                        assignment.Name = "Homework 2";
                        assignment.Description = "Create the submission class. Add serialization to all classes.";
                        assignment.CategoryName = "Homework";

                        // serialization code
                        FileStream ajWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractJsonSerializer ajSer;
                        ajSer = new DataContractJsonSerializer(typeof(Assignment));
                        ajSer.WriteObject(ajWriter, assignment);
                        ajWriter.Close();
                        break;
                    case "9": // Write Assignment to XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();

                        // change assignment variables
                        assignment.Name = "Exam 1";
                        assignment.Description = "Test knowledge of chapters 1-4.";
                        assignment.CategoryName = "Exams";

                        // serialization code
                        FileStream axWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractSerializer axSer;
                        axSer = new DataContractSerializer(typeof(Assignment));
                        axSer.WriteObject(axWriter, assignment);
                        axWriter.Close();
                        break;
                    case "10": // Display Assignment data on screen
                        Console.WriteLine(assignment);
                        break;
                    case "11": // Read Submission from JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractJsonSerializer input;
                            input = new DataContractJsonSerializer(typeof(Submission));
                            submission = (Submission)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                            break;
                        }
                        break;
                    case "12": // Read Submission from XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractSerializer input;
                            input = new DataContractSerializer(typeof(Submission));
                            submission = (Submission)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                            break;
                        }
                        break;
                    case "13": // Write Submission to JSON file
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();

                        // change submission variables
                        submission.CategoryName = "Homework";
                        submission.AssignmentName = "Homework 2";
                        submission.Grade = 100;

                        // serialization code
                        FileStream sjWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractJsonSerializer sjSer;
                        sjSer = new DataContractJsonSerializer(typeof(Submission));
                        sjSer.WriteObject(sjWriter, submission);
                        sjWriter.Close();
                        break;
                    case "14": // Write Submission to XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();

                        // change submission variables
                        submission.CategoryName = "Exams";
                        submission.AssignmentName = "Exam 1";
                        submission.Grade = 95;

                        // serialization code
                        FileStream sxWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractSerializer sxSer;
                        sxSer = new DataContractSerializer(typeof(Submission));
                        sxSer.WriteObject(sxWriter, submission);
                        sxWriter.Close();
                        break;
                    case "15": // Display Submission data on screen
                        Console.WriteLine(submission);
                        break;
                    case "16": // Exit
                        Console.WriteLine("Exiting program.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a choice from the menu.\n");
                        break;
                }

            } while (menuSelection != "16"); // display menu until user enters "16" to exit
        }
    }
}
