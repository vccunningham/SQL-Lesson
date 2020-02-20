using System;
using SQL_Library;
    
namespace SQL_Lesson {
    class Program {
        static void Main(string[] args) {
            
            var sqlLib = new BcConnection();
            sqlLib.Connect(@"localhost\sqlexpress", "EdDb", "trusted_connection=true");
            StudentController.bcConnection = sqlLib;
            //var student = new Student(sqlLib);
            var students = StudentController.GetAllStudents();
            foreach(var student in students) {
                Console.WriteLine(student);
            }
            sqlLib.Disconnect();
        }
    }
}
