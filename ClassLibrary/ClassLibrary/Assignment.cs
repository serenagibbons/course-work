//*****************************************************************************
// File: Assignment.cs
//
// Purpose: Contains the class definition for Assignment. This class is built to
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
    public class Assignment
    {
        #region member variables
        private string name;
        private string description;
        private string categoryName;
        #endregion

        #region properties
        [DataMember(Name = "name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember(Name = "description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember(Name = "categoryname")]
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
        #endregion

        #region methods
        //*****************************************************************************
        // Assignment constructor
        //
        // Purpose: Default constructor used to instantiate the class Assignment.
        //*****************************************************************************
        public Assignment()
        {
            name = null;
            description = null;
            categoryName = null;
        }

        //*****************************************************************************
        // Method: ToString
        //
        // Purpose: To override object's ToString method for the class Assignment.
        //*****************************************************************************
        public override string ToString()
        {
            return "name: " + name
                + "\ndescription: " + description
                + "\ncategory name: " + categoryName;
        }
        #endregion
    }
}
