using System;
using SQL_Library;
    
namespace SQL_Lesson {
    class Program {
        static void Main(string[] args) {
            
            var sqlLib = new BcConnection();
            sqlLib.Connect(@"localhost\sqlexpress", "EdDb", "trusted_connection=true");
            var student = new Student(sqlLib);
            var students = student.GetAllStudents();
            sqlLib.Disconnect();
        }
    }
}
