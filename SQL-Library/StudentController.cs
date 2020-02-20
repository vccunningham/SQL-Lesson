using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Library {
    public class StudentController{

        public static BcConnection bcConnection { get; set; }

        public static List<Student> GetAllStudents() {
            var sql = "SELECT * From Student";
            var command = new SqlCommand(sql, bcConnection.Connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) {
                Console.WriteLine("No rows from GetAllStudents()");
                return new List<Student>();
            }
            var students = new List<Student>();
            while (reader.Read()) {
                var student = new Student();
                student.ID = Convert.ToInt32(reader["Id"]);
                student.Firstname = reader["Firstname"].ToString();
                student.Lastname = reader["Lastname"].ToString();
                student.SAT = Convert.ToInt32(reader["SAT"]);
                student.GPA = Convert.ToDouble(reader["GPA"]);
                students.Add(student);
                
                //student.MajorID = Convert.ToInt32(reader["MajorID"]);
            }
            return students;
        }


    }
}
