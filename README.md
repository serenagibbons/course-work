# Course Work

## ClassLibrary
A dynamic link library containing the class definitions for Assignment.cs, Category.cs, CourseWork.cs, CourseWorkUnitTesting.cs, and Submission.cs.

## CourseWorkClassMenu
A console application which imports the ClassLibrary DLL and displays a menu to select and perform serialization and deserialization of CourseWork objects to and from JSON and XML files, and display all course work on the screen.

## CourseWorkGUI
A WPF application which imports the ClassLibrary DLL and creates a graphical user interface for displaying course work data. Course work data is serialized from a JSON file and displayed by category, assignment, and submission. The GUI also calculates and dispalys the overall course grade as well as allows for searching through the submissions for an assignment to retrieve the assignment's cateogry and grade.

## CourseWorkGUIv2
A WPF application which imports the ClassLibrary DLL and creates a master-detail interface for displaying course work data. Course work data is serialized from a JSON file and then entered into a SQL Server Express database. The GUI retrieves data from the database to display details of the currently selected record in the master list. 

## CourseWorkMenu
A console application which imports the ClassLibrary DLL and displays a menu to select and perform serialization and deserialization of Category, Assignment, and Submission objects and display data on the screen.

## StudentData
A console application which imports the ClassLibrary DLL and displays a menu to select and perform unit testing on Category and Assignment objects to ensure proper assignment of variables.
