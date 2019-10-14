//*****************************************************************************
// File: CourseWork.cs
//
// Purpose: Contains the class definition for CourseWork. This class is built to
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
    public class CourseWork
    {
        #region member variables
        private string courseName;
        private List<Category> categories;
        private List<Assignment> assignments;
        private List<Submission> submissions;
        #endregion

        #region properties
        [DataMember(Name = "coursename")]
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        [DataMember(Name = "categories")]
        public List<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }
        [DataMember(Name = "assignments")]
        public List<Assignment> Assignments
        {
            get { return assignments; }
            set { assignments = value; }
        }
        [DataMember(Name = "submissions")]
        public List<Submission> Submissions
        {
            get { return submissions; }
            set { submissions = value; }
        }
        #endregion

        #region methods
        //*****************************************************************************
        // CourseWork constructor
        //
        // Purpose: Default constructor used to instantiate the class CourseWork.
        //*****************************************************************************
        public CourseWork()
        {
            courseName = null;
            categories = new List<Category>();
            assignments = new List<Assignment>();
            submissions = new List<Submission>();
        }

        //*****************************************************************************
        // Method: FindSubmission
        //
        // Purpose: Takes an assignment name as a parameter and returns the Submission
        // with the given assignment name. If it is not found then null is returned.
        //*****************************************************************************
        public Submission FindSubmission(String an)
        {
            for (int i = 0; i < assignments.Count; ++i)
            {
                if (submissions[i].AssignmentName == an)
                {
                    return submissions[i];
                }
            }

            // if method has not returned after for loop, assignment has not been found
            return null;
        }

        //*****************************************************************************
        // Method: CalculateGrade
        //
        // Purpose: Calculates the overall grade given the submissions. The overall 
        // grade is a weighted average. The weights are the category percentages.
        //*****************************************************************************

            // Category FindCategory(string cName); -- look through Category list checking name for "Homework", "Exams", ...
            // 
            // double SubmissionAverage(string cName); -- look through Submission list checking for category name, 
            // if yes add grade to the total and incremement count
        public double CalculateGrade()                 // FIX ALL OF THIS
        {
            // cateogry weights
            double examWeight = categories[0].Percentage;
            double homeworkWeight = categories[1].Percentage;
            double quizWeight = categories[2].Percentage;
            double labWeight = categories[3].Percentage;

            // category averages
            double examAvg = submissions[0].Grade;
            double homeworkAvg = submissions[1].Grade;
            double quizAvg = submissions[2].Grade;
            double labAvg = submissions[3].Grade;

            // return weighted average
            double average = examWeight * examAvg + homeworkWeight * homeworkAvg + quizWeight * quizAvg + labWeight * labAvg;
            return average;
        }

        //*****************************************************************************
        // Method: ToString
        //
        // Purpose: To override object's ToString method for the class CourseWork.
        //*****************************************************************************
        public override string ToString()
        {
            string categoryStrings = "";
            string assignmentStrings = "";
            string submissionStrings = "";

            // create string of all category information
            for (int i = 0; i < categories.Count; ++i)
            {
                categoryStrings += categories[i].Name + ", ";
                categoryStrings += categories[i].Percentage + "\n";
            }

            // create string of all assignment information
            for (int i = 0; i < assignments.Count; ++i)
            {
                assignmentStrings += assignments[i].Name + ", ";
                assignmentStrings += assignments[i].CategoryName + ", ";
                assignmentStrings += assignments[i].Description + "\n";
            }

            // create string of all submission information
            for (int i = 0; i < submissions.Count; ++i)
            {
                submissionStrings += submissions[i].CategoryName + ", ";
                submissionStrings += submissions[i].AssignmentName  + ", ";
                submissionStrings += submissions[i].Grade + "\n";
            }

            return "course name: " + courseName
                + "\ncategories:\n" + categoryStrings
                + "\nassignments:\n" + assignmentStrings   
                + "\nsubmissions:\n" + submissionStrings; 
        }
        #endregion
    }
}
