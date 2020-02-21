using System;
using SQL_Library;
    
namespace SQL_Lesson {
    class Program {
        static void Main(string[] args) {

            var sqlLib = new BcConnection();
            sqlLib.Connect(@"localhost\sqlexpress", "EdDb", "trusted_connection=true");
            StudentController.bcConnection = sqlLib;

            InstructorController.bcConnection = sqlLib;
            var instructors = InstructorController.GetAllInstructors();
            foreach(var i in instructors) {
                Console.WriteLine(i);
            }

            MajorController.bcConnection = sqlLib;
            var major = MajorController.GetMajorByPk(1);
            Console.WriteLine(major);
            var majors = MajorController.GetAllMajors();
            foreach(var m in majors) {
                Console.WriteLine(m);
            }
            //var student = new Student(sqlLib);
            //var newStudent = new Student {
            //    ID = 555,
            //    Firstname = "Fred",
            //    Lastname = "Fives",
            //    SAT = 601,
            //    GPA = 5.00,
            //    MajorID = 1
            //};
            //var success = StudentController.InsertStudent(newStudent);
            
            var student = StudentController.GetStudentByPk(888);
            if (student == null) {
                Console.WriteLine("Student not found");
            } else {
                Console.WriteLine(student);
            }

            student.Firstname = "Charlie";
            student.Lastname = "Chan";
            var success = StudentController.UpdateStudent(student);

            var studentToDelete = new Student {
                ID = 999
            };
               // success = StudentController.DeleteStudent(999);

            var students = StudentController.GetAllStudents();
            foreach(var student0 in students) {
                Console.WriteLine(student0);
            }
            sqlLib.Disconnect();
        }
    }
}
