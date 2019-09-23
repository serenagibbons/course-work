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

namespace CourseWorkMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuSelection;

            do
            {
                // display menu
                Console.WriteLine("Course Work Menu");
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

                #region unit testing
                // perform unit testing based on user's input or exit the program
                switch (menuSelection)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "16":
                        Console.WriteLine("Exiting program.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a choice from the menu.\n");
                        break;
                }
                #endregion

            } while (menuSelection != "16"); // display menu until user enters "16" to exit
        }
    }
}
