using System;
using System.Collections.Generic;

namespace GradeBook
{
    internal class Program
    {
        static public void MainMenu()
        {
            
            int studentCount = 1;

            //Initial test student for testing features
            Dictionary<int, Student> studentDict = new Dictionary<int, Student>();
            Student[] students = {
                new Student("Test", new List<int> { 50, 75 }, studentCount) };
            studentCount++;

            foreach (Student s in students)
            {
                studentDict.Add(s.studentID, s);

            }

            //Main menu for app
        BREAK1:
            Console.Clear();
            Console.WriteLine("Welcome to the Grade Manager 2099: More Edgy than Morbius\n\n ");
            Console.WriteLine("1. Show Grades");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. Show Class Average");
            Console.WriteLine("4. Show Best Grade");
            Console.WriteLine("5. Show Worst Grade");
            Console.WriteLine("6. Remove Grade");
            Console.WriteLine("7. Edit Grade");
            Console.WriteLine("8. Exit Application\n\n");
            Console.Write("Please select an Option between 1-8: ");
            char selection;
            //Here to catch format exception when someone just hits enter or types a non-number character in 
            try
            {
                selection = char.Parse(Console.ReadLine().Trim(' '));
            }
            catch (FormatException)
            {
                goto BREAK1;
            }
            if (selection > '8' || selection < '1')
            {
                Console.WriteLine("That is not a valid selection, please choose a valid option. Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                goto BREAK1;
            }
            
            switch (selection)
            {
                
                case '1':
                    Console.Clear();
                    Console.WriteLine("Here are all the grades for each student: ");
                    Student temp;
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        temp = studentDict[i];
                        Console.Write("Student: " + temp.name + " | Grade: ");
                        foreach (int grade in temp.grades)
                        {
                            Console.Write(grade + ", ");

                        }
                        Console.WriteLine("");
                    };
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    goto BREAK1;
                
                case '2':
                BREAK2:
                    Console.Clear();
                    Console.WriteLine("You can add a grade here! Please enter the ID of the students listed: ");
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        temp = studentDict[i];
                        Console.WriteLine("Student ID: " + temp.studentID + " | Name: " + temp.name);
                    }
                    Console.Write("\nEnter number or enter 0 to add a student: ");
                    int addSel;
                    try
                    {
                        addSel = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid selection. Press enter to retry.");
                        Console.ReadLine();
                        goto BREAK2;
                    }
                    Console.WriteLine("");

                    if (studentDict.ContainsKey(addSel))
                    {
                        Console.Write("Please enter the grade for student " + studentDict[addSel].name + ": ");
                        int addGrade;
                        try
                        {
                            addGrade = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number.");
                            goto BREAK2;
                        }
                        studentDict[addSel].grades.Add(addGrade);
                        Console.WriteLine("Grade added to " + studentDict[addSel].name);
                        goto BREAK1;

                    }
                    else
                    {
                    BREAK3:
                        Console.WriteLine("Student does not exist. Please enter the name of the student to add them to the Grade Book: ");
                        string newStudent = Console.ReadLine();
                        if (string.IsNullOrEmpty(newStudent))
                        {
                            Console.WriteLine("Please enter a name. Press enter to retry.");
                            Console.ReadLine();
                            goto BREAK3;
                        }
                        
                        Console.WriteLine("Student added! Please enter the grade for the student: ");
                        int newGrade;
                        try
                        {
                            newGrade = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number.");
                            goto BREAK2;
                        }
                        Array.Resize(ref students, students.Length + 1);
                        students[students.Length - 1] = new Student(newStudent, new List<int> { newGrade }, studentCount);
                        Student addTemp = students[students.Length - 1];
                        studentCount++;
                        studentDict.Add(addTemp.studentID, addTemp);
                        goto BREAK1;
                    };

                case '3':
                    Console.Clear();
                    int conglom = 0;
                    int numOfGrades = 0;
                    //iterates through each student's grades, adds them, and progresses the counter. Counter is used at end so we know what to divide by
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        temp = studentDict[i];
                        foreach (int grade in temp.grades)
                        {
                            conglom += grade;
                            numOfGrades++;

                        }
                    };
                    Console.WriteLine("\n\nThe class average class score is:" + (conglom / numOfGrades) + "\n\n");
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    goto BREAK1;
                
                case '4':
                    Console.Clear();
                    int highest = 0;
                    Student winner = studentDict[1];
                    //iterates through each student in the dict and sorts their grades. Then takes the last (whihc is the highest) value and compares it to the stored value. Highest value stays and it puts that object in winner variable
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        Student tempHigh = studentDict[i];
                        tempHigh.grades.Sort();
                        if (tempHigh.grades[tempHigh.grades.Count - 1] > highest)
                        {
                            highest = tempHigh.grades[tempHigh.grades.Count - 1];
                            winner = tempHigh;
                        }
                        

                    }
                    Console.WriteLine("\n\n\nThe highest grade in the class was: " + highest + ". This grade is held by " + winner.name);
                    Console.WriteLine("\n\n\nPlease press enter to return to the Main Menu");
                    Console.ReadLine();
                    goto BREAK1;
                
                case '5':
                    Console.Clear();
                    int lowest = 100;
                    Student loser = studentDict[1];
                    //Almost exactly the same as the highest function but the other way. Takes first value in sorted List and compares.
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        Student tempLow = studentDict[i];
                        tempLow.grades.Sort();
                        if (tempLow.grades[0] < lowest)
                        {
                            lowest = tempLow.grades[0];
                            loser = tempLow;
                        }
                    }
                    Console.WriteLine("\n\n\nThe highest grade in the class was: " + lowest + ". This grade is held by " + loser.name);
                    Console.WriteLine("\n\n\nPlease press enter to return to the Main Menu");
                    Console.ReadLine();
                    goto BREAK1;
                   
                case '6':
                    BREAK4:
                    Console.Clear();
                    Console.WriteLine("Grade Eraser MK16: Point it out and we'll erase it!\n\n\n");
                    Console.WriteLine("Current recorded students:");
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        temp = studentDict[i];
                        Console.WriteLine("Student ID: " + temp.studentID + " | Name: " + temp.name);
                    }
                    Console.Write("\n\n Which student's grade would you like to remove?: ");
                    int removeSel;
                    try
                    {
                        removeSel = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter the correct input type. Press enter to retry");
                        Console.ReadLine();
                        goto BREAK4;
                    }
                    if (studentDict.ContainsKey(removeSel)) 
                    {
                        int counter = 1;
                        int remGrade;
                        Student tempRem = studentDict[removeSel];
                        foreach (int grade in tempRem.grades)
                        {
                            Console.WriteLine(counter + ": " + grade);
                            counter++;
                        }
                        Console.Write("Enter the ID number of the grade you would like removed: ");
                        remGrade = int.Parse(Console.ReadLine());
                        studentDict[removeSel].grades.RemoveAt(remGrade -1);
                        Console.WriteLine("Grade Removed! Press enter to go to main menu");
                        Console.ReadLine();
                        goto BREAK1;
                     
                    }else
                    {
                        Console.WriteLine("That student does not exist. Press enter to return to main menu.");
                        goto BREAK1;
                    }

                   
                case '7':
                    BREAK5:
                    Console.Clear();
                    Console.WriteLine("Grade Changer Proteus Edition: If you dont't like it, change it!\n\n\n");
                    Console.WriteLine("Current recorded students:");
                    for (int i = 1; i <= studentDict.Count; i++)
                    {
                        temp = studentDict[i];
                        Console.WriteLine("Student ID: " + temp.studentID + " | Name: " + temp.name);
                    }
                    Console.Write("\n\n Which student's grade would you like to change?: ");
                    int editSel;
                    try
                    {
                        editSel = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter the correct input type. Press enter to retry");
                        Console.ReadLine();
                        goto BREAK5;
                    }
                    if (studentDict.ContainsKey(editSel))
                    {
                        int counter = 1;
                        int editGrade;
                        int newGrade;
                        Student tempRem = studentDict[editSel];
                        foreach (int grade in tempRem.grades)
                        {
                            Console.WriteLine(counter + ": " + grade);
                            counter++;
                        }
                        Console.Write("Enter the ID number of the grade you would like changed: ");
                        editGrade = int.Parse(Console.ReadLine());
                        Console.Write("What would you like it changed to?: ");
                        newGrade = int.Parse(Console.ReadLine());
                        studentDict[editSel].grades.RemoveAt(editGrade - 1);
                        studentDict[editSel].grades.Insert(editGrade -1 , newGrade);
                        Console.WriteLine("Grade changed! Press enter to go to main menu");
                        Console.ReadLine();
                        goto BREAK1;
                    }
                    else
                    {
                        Console.WriteLine("That student does not exist. Press enter to return to main menu.");
                        goto BREAK1;
                    }
                
                case '8':
                    Console.WriteLine("Ending application. Please press enter to continue.");
                    break;

            }

        }
        
            public class Student
            {
                public string name;
                public List<int> grades;
                public int studentID;


                public Student(string name, List<int> grades, int studentID)
                {
                    this.name = name;

                    this.grades = grades;
                    this.studentID = studentID;
                }

            

            static public void Main(string[] args)
            {

                MainMenu();
            }

        }
    }
}
