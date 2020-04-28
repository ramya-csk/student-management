using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDetails
{
    class StudentHandler
    {
        int menu;
        List<Student> StudentList = new List<Student>();

        public StudentHandler()
        {
            SeedData();
        }

        protected void SeedData()
        {
            StudentList.Add(new Student
            {
                Id = 1,
                Name = "Ramya",
                Gender = "Female",
                DOB = Convert.ToDateTime("08-09-1998")
            });
            StudentList.Add(new Student
            {
                Id = 2,
                Name = "Chandru",
                Gender = "Male",
                DOB = Convert.ToDateTime("05-05-1997")
            });
            StudentList.Add(new Student
            {
                Id = 3,
                Name = "Riya",
                Gender = "Female",
                DOB = Convert.ToDateTime("08-05-1994")
            });
        }
        private void Exit()
        {
            Boolean checkNum = true;
            do
            {
                try
                {

                    Console.WriteLine("Press 0 to enter into main menu ");
                    int userEntNum = int.Parse(Console.ReadLine());
                    if (userEntNum == 0)
                    {

                        Console.Clear();
                        checkNum = false;
                        start();

                    }
                }


                catch
                {
                    Console.WriteLine("Sorry!Enter in correct format");
                    checkNum = true;
                }
            }
            while (checkNum == true);
        }
        public void start()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("WELCOME TO STUDENT MANAGEMENT SYSTEM");
                Console.WriteLine("1: Add Student Details");
                Console.WriteLine("2: Find Student Details");
                Console.WriteLine("3: List Student Details");
                Console.WriteLine("4: Delete Student Details");
                Console.WriteLine("5: Exit\n");
                Console.WriteLine("Please select the above menu");

                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add Details");
                        AddStudent();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Find Details");
                        FindStudent();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("List Details");
                        ListStudent();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Delete Details");
                        DeleteStudent();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Return");
                        break;
                }
            }
            while (menu != 5);
            if (menu == 5)
            {
                System.Environment.Exit(0);
            }
        }
        private void AddStudent()
        {
            try
            {
                Student student = new Student();
                student.Id = 0;
                do
                {
                    Console.WriteLine("Student Id:");
                    int enteredId = int.Parse(Console.ReadLine());
                    var repeatedId = StudentList.Find(s => s.Id == enteredId);
                    if (repeatedId != null)
                    {
                        Console.WriteLine("Id is already present in the list. Please enter different Id");
                    }
                    else
                    {
                        student.Id = enteredId;
                    }
                }
                while (student.Id == 0);
                Console.WriteLine("Student Name:");
                student.Name = Console.ReadLine();
                do
                {
                    Console.WriteLine("Student Gender:");
                    student.Gender = Console.ReadLine();
                }
                while (!(student.Gender == "male" || student.Gender == "female"));

                Console.WriteLine("Student DOB:");
                student.DOB = DateTime.Parse(Console.ReadLine());
                StudentList.Add(student);
                Console.WriteLine("Student added successfully");
            }
            catch
            {
                Console.WriteLine("Something went wrong! Please enter the values correctly");
            }
            Console.WriteLine();
            Exit();
        }

        private void FindStudent()
        {

            Console.WriteLine("Enter the student id you wish to find");
            int StuId = int.Parse(Console.ReadLine());

            Student editStudent = StudentList.Find(s => s.Id == StuId);
            if (editStudent != null)
            {
                Console.WriteLine("|{0,-5}|{1,-15}|{2,-8}|{3,-20}|", "-----", "---------------", "--------", "--------------------");
                Console.WriteLine("|{0,-5}|{1,-15}|{2,-8}|{3,-20}|", "Id", "Name", "Gender", "DOB");
                Console.WriteLine("|{0,5}|{1,15}|{2,8}|{3,20}|", "-----", "---------------", "--------", "--------------------");
                Console.WriteLine("|{0,-5}|{1,-15}|{2,-8}|{3,-20}|",
                    editStudent.Id,
                    editStudent.Name,
                    editStudent.Gender,
                    editStudent.DOB);
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
            Console.WriteLine();
            Exit();

        }

        private void ListStudent()
        {
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-8}|{3,-20}|", "-----", "---------------", "--------", "--------------------");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-8}|{3,-20}|", "Id", "Name", "Gender", "DOB");
            Console.WriteLine("|{0,5}|{1,15}|{2,8}|{3,20}|", "-----", "---------------", "--------", "--------------------");
            foreach (var student in StudentList)
            {
                Console.WriteLine("|{0,-5}|{1,-15}|{2,-8}|{3,-20}|", student.Id, student.Name, student.Gender, student.DOB);
            }
            Console.WriteLine("|{0,5}|{1,15}|{2,8}|{3,20}|", "-----", "---------------", "--------", "--------------------");
            Console.WriteLine();
            Exit();

        }
        private void DeleteStudent()
        {
            Console.WriteLine("Enter the Student Id which you wish to delete");
            int dltStuId = int.Parse(Console.ReadLine());

            Student foundStudent = StudentList.Find(s => s.Id == dltStuId);
            if (foundStudent != null)
            {
                StudentList.Remove(foundStudent);
                Console.WriteLine("Student With id {0} is deleted successfully", dltStuId);
            }
            else
            {
                Console.WriteLine("Student not found");
            }
            Console.WriteLine();
            Exit();
        }
    }
}
