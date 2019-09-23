//*****************************************************************************
// File: Program.cs
//
// Purpose: Contains the class definition for Program. Program imports the
// ClassLibrary DLL containing the classes Category, Assignment, and
// CourseWorkUnitTesting. Program displays a menu to select and perform 
// testing.
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
using ClassLibrary;

namespace StudentData
{
    class Program
    {

        static void Main(string[] args)
        {
            string menuSelection;
            CourseWorkUnitTesting test = new CourseWorkUnitTesting();

            do
            {
                // display menu
                Console.WriteLine("Course Work Testing Menu");
                Console.WriteLine("------------------------");
                Console.WriteLine("1 - Unit Test Category");
                Console.WriteLine("2 - Unit Test Assignment");
                Console.WriteLine("3 - Exit");
                Console.Write("Enter Choice: ");

                // read and store user's selection
                menuSelection = Console.ReadLine();

                #region unit testing
                // perform unit testing based on user's input or exit the program
                switch (menuSelection)
                {
                    case "1":
                        test.UnitTestCategory();
                        break;
                    case "2":
                        test.UnitTestAssignment();
                        break;
                    case "3":
                        Console.WriteLine("Exiting program.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a choice from the menu.\n");
                        break;
                }
                #endregion

            } while (menuSelection != "3"); // display menu until user enters "3" to exit
        }
    }
}
