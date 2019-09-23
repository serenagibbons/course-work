//*****************************************************************************
// File: Category.cs
//
// Purpose: Contains the class definition for Category. This class is built to
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
    public class Category
    {
        #region member variables
        private string name;
        private double percentage;
        #endregion

        #region properities
        [DataMember(Name = "name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember(Name = "percentage")]
        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }
        #endregion

        #region methods
        //*****************************************************************************
        // Cateogry constructor
        //
        // Purpose: Default constructor used to instantiate the class Category.
        //*****************************************************************************
        public Category()
        {
            name = null;
            percentage = 0;
        }

        //*****************************************************************************
        // Method: ToString
        //
        // Purpose: To override object's ToString method for the class Category.
        //*****************************************************************************
        public override string ToString()
        {
            return "name: " + name 
                + "\npercentage: " + percentage;
        }
        #endregion
    }
}
