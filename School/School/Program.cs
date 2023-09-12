using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    class Program
    {
        static List<Classroom> classrooms = new List<Classroom>();
        
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("1. Create room");
                Console.WriteLine("2. Select room");
                Console.WriteLine("3. Exit");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        Classroom newclassroom = new Classroom();
                        classrooms.Add(newclassroom);
                        Console.WriteLine("Created room.");
                        break;

                    case 2:
                        Console.WriteLine("Choose the room number (1, 2, etc.):");
                        int numberClassroom = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (numberClassroom >= 0 && numberClassroom < classrooms.Count)
                        {
                            Classroom classroomSelected = classrooms[numberClassroom];
                            InteractWithClassroom(classroomSelected);
                        }
                        else
                        {
                            Console.WriteLine("Invalid room number.");
                        }
                        break;

                    case 3:
                        return;
                }
            }
        }

        static void InteractWithClassroom(Classroom classroom)
        {
            while(true)
            {
                Console.WriteLine("\n1. Register student");
                Console.WriteLine("2. Remove student");
                Console.WriteLine("3. Number of approved");
                Console.WriteLine("4. Number of disapproved");
                Console.WriteLine("5. Approved List");
                Console.WriteLine("6. Deprecated List");
                Console.WriteLine("7. Overall Average");
                Console.WriteLine("8. Return to previous menu");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                        Student newStudent = new Student();
                        Console.WriteLine("Student's name: ");
                        newStudent.Name = Console.ReadLine();
                        Console.WriteLine("Note 1: ");
                        newStudent.Note1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Note 2: ");
                        newStudent.Note2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Note 3: ");
                        newStudent.Note3 = Convert.ToDouble(Console.ReadLine());
                        classroom.RegisterStudent(newStudent);
                        Console.WriteLine("Registered student.");
                        break;

                    case 2:
                        Console.WriteLine("Name of student to be removed: ");
                        string nameStudent = Console.ReadLine();
                        Student studentToRemove = classroom.Students.FirstOrDefault(a => a.Name == nameStudent);
                        if(studentToRemove != null)
                        {
                            classroom.RemoveStudent(studentToRemove);
                            Console.WriteLine("Student removed.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Number of approved: " + classroom.CountApproved());
                        break;


                    case 4:
                        Console.WriteLine("Number of disapproved: " + classroom.CountDisapproved());
                        break;

                    case 5:
                        ListStudents(classroom.GetApproved());
                        break;

                    case 6:
                        ListStudents(classroom.GetDisapproved());
                        break;

                    case 7:
                        Console.WriteLine("General average: " + classroom.CalculateGeneralAverage());
                        break;

                    case 8:
                        return;
                }
            }
        }

        static void ListStudents(List<Student> students)
        {
            Console.WriteLine("Student List: ");
            foreach (var student in students)
            {
                Console.WriteLine("$Name: {student.Name}, Average: {student.CalculateAverageTLS()}");
            }
        }
    }
}
