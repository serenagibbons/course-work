//*****************************************************************************
// File: Program.cs
//
// Purpose: Contains the class definition for Program. Program imports the
// ClassLibrary DLL containing the classes Category, Assignment, Submission,
// and CourseWork. Program displays a menu to select and perform 
// serializationa and deserialization.
//
// Written By: Serena Gibbons
//
// Compiler: Visual Studio 2017
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

namespace CourseWorkClassMenu
{
    class Program
    {

        static void Main(string[] args)
        {
            string menuSelection;

            // instantiate object to use with serialization/deserialization
            CourseWork courseWork = new CourseWork();

            // file names
            string fileName;

            do
            {
                // display menu
                Console.WriteLine("Course Work Menu");
                Console.WriteLine("-------------------");
                Console.WriteLine("1 - Read course work from JSON file");
                Console.WriteLine("2 - Read course work from XML file");
                Console.WriteLine("3 - Write course work to JSON file");
                Console.WriteLine("4 - Write course work to XML file");
                Console.WriteLine("5 - Display all course work on screen");
                Console.WriteLine("6 - Find submission");
                Console.WriteLine("7 - Exit");
                Console.Write("Enter Choice: ");

                // read and store user's selection
                menuSelection = Console.ReadLine();
                Console.WriteLine();

                // perform unit testing based on user's input or exit the program
                switch (menuSelection)
                {
                    case "1": // Read course work from JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            StreamReader streamReader = new StreamReader(reader, Encoding.UTF8);
                            string jsonString = streamReader.ReadToEnd();
                            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
                            MemoryStream stream = new MemoryStream(byteArray);
                            DataContractJsonSerializer input;
                            input = new DataContractJsonSerializer(typeof(CourseWork));
                            courseWork = (CourseWork)input.ReadObject(stream);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                        }
                        catch (SerializationException e) {
                            Console.WriteLine("Serialization exception.\n");
                            Console.WriteLine(e);
                        }
                        break;
                    case "2": // Read course work from XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to read from: ");
                        fileName = Console.ReadLine();
                        // try reading from file, if exception thrown, break
                        try
                        {
                            FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            DataContractSerializer input;
                            input = new DataContractSerializer(typeof(CourseWork));
                            courseWork = (CourseWork)input.ReadObject(reader);
                            reader.Close();
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Invalid file name.\n");
                        }
                        break;
                    case "3": // Write course work to JSON file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();
                        // serialization code
                        FileStream jsonWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractJsonSerializer jsonSer;
                        jsonSer = new DataContractJsonSerializer(typeof(CourseWork));
                        jsonSer.WriteObject(jsonWriter, courseWork);
                        jsonWriter.Close();
                        break;
                    case "4": // Write course work to XML file
                        // prompt user for file name
                        Console.Write("Enter a file name to write to: ");
                        fileName = Console.ReadLine();
                        // serialization code
                        FileStream xmlWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                        DataContractSerializer xmlSer;
                        xmlSer = new DataContractSerializer(typeof(CourseWork));
                        xmlSer.WriteObject(xmlWriter, courseWork);
                        xmlWriter.Close();
                        break;
                    case "5": // Display course work data on screen
                        Console.WriteLine(courseWork);
                        Console.WriteLine("Overall grade: " + courseWork.CalculateGrade());
                        break;
                    case "6": // Find submission
                        Console.Write("Enter assignment name: ");
                        string assignment = Console.ReadLine();
                        Submission s = courseWork.FindSubmission(assignment);
                        if (s != null)
                        {
                            Console.WriteLine(s);
                        }
                        else
                        {
                            Console.WriteLine("Submission not found");
                        }
                        break;
                    case "7": // Exit
                        Console.WriteLine("Exiting program.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a choice from the menu.\n");
                        break;
                }

                Console.WriteLine();
            } while (menuSelection != "7"); // display menu until user enters "16" to exit
        }
    }
}
