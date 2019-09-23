//*****************************************************************************
// File: CourseWorkUnitTesting.cs
//
// Purpose: Contains the class definition for CourseWorkUnitTesting. This class 
// is built to be part of the ClassLibrary DLL.
//
// Written by: Serena Gibbons
//
// Compiler: Visual Studio 2017 
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CourseWorkUnitTesting
    {
        #region methods
        //*****************************************************************************
        // Method: CourseWorkUnitTesting
        //
        // Purpose: Declare an instance of Category and perform unit testing on all 
        // of the properties of that instance. This should cause pass/fail messages to 
        // appear on screen for each unit test.
        //*****************************************************************************
        public void UnitTestCategory()
        {
            Category category = new Category();

            string testName = "Computer Science";
            double testPercentage = 100;
            
            // assign test values to member variables
            category.Name = testName;
            category.Percentage = testPercentage;

            // testing header
            Console.WriteLine("\n*************************");
            Console.WriteLine("Unit Testing: Category");
            Console.WriteLine("*************************");

            // check if value assigned correctly to name
            if (category.Name == testName)
            {
                Console.WriteLine("Category Name Property: Pass");
            }
            else
            {
                Console.WriteLine("Category Name Property: Fail");
            }
            // check if value assigned correctly to percentage
            if (category.Percentage == testPercentage)
            {
                Console.WriteLine("Category Percentage Property: Pass\n");
            }
            else
            {
                Console.WriteLine("Category Percentage Property: Fail\n");
            }

        }

        //*****************************************************************************
        // Method: UnitTestAssignment
        //
        // Purpose: Declare an instance of Assignment and perform unit testing on all 
        // of the properties of that instance. This should cause pass/fail messages to 
        // appear on screen for each unit test.
        //*****************************************************************************
        public void UnitTestAssignment()
        {
            Assignment assignment = new Assignment();

            string testName = "Homework 1";
            string testDescription = "Create a DLL solution";
            string testCategoryName = "Computer Science";

            // assign test values to member variables
            assignment.Name = testName;
            assignment.Description = testDescription;
            assignment.CategoryName = testCategoryName;

            // testing header
            Console.WriteLine("\n*************************");
            Console.WriteLine("Unit Testing: Assignment");
            Console.WriteLine("*************************");

            // check if value assigned correctly to name
            if (assignment.Name == testName)
            {
                Console.WriteLine("Assignment Name Property: Pass");
            }
            else
            {
                Console.WriteLine("Assignment Name Property: Fail");
            }
            // check if value assigned correctly to description
            if (assignment.Description == testDescription)
            {
                Console.WriteLine("Assignment Description Property: Pass");
            }
            else
            {
                Console.WriteLine("Assignment Description Property: Fail");
            }
            // check if value assigned correctly to categoryName
            if (assignment.CategoryName == testCategoryName)
            {
                Console.WriteLine("Assignment Category Name Property: Pass\n");
            }
            else
            {
                Console.WriteLine("Assignment Category Name Property: Fail\n");
            }
        }
        #endregion
    }
}
