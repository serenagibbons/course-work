//*****************************************************************************
// File: Submission.cs
//
// Purpose: Contains the class definition for Submission. This class is built to
// be part of the ClassLibrary DLL.
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
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [DataContract]
    public class Submission
    {
        #region member variables
        private string categoryName;
        private string assignmentName;
        private double grade;
        #endregion

        #region properties
        [DataMember(Name = "categoryName")]
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
        [DataMember(Name = "assignmentName")]
        public string AssignmentName
        {
            get { return assignmentName; }
            set { assignmentName = value; }
        }
        [DataMember(Name = "grade")]
        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        #endregion

        #region methods
        //*****************************************************************************
        // Submission constructor
        //
        // Purpose: Default constructor used to instantiate the class Submission.
        //*****************************************************************************
        public Submission()
        {
            categoryName = null;
            assignmentName = null;
            grade = 0;
        }
        //*****************************************************************************
        // Method: ToString
        //
        // Purpose: To override object's ToString method for the class Submission.
        //*****************************************************************************
        public override string ToString()
        {
            return "category name: " + categoryName
                + "\nassignment name: " + assignmentName
                + "\ngrade: " + grade;
        }
        #endregion
    }
}