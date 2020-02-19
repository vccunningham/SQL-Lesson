using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Library {

    public class Student {

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int SAT { get; set; }
        public double GPA { get; set; }
        public int MajorID { get; set; }


        private BcConnection bcConnection;

        public List<Student> GetAllStudents() {
            var sql = "SELECT * From Student";
            var command = new SqlCommand(sql, bcConnection.Connection);
            var reader = command.ExecuteReader();
            if(!reader.HasRows) {
                Console.WriteLine("No rows from GetAllStudents()");
                return new List<Student>();
            }
            var students = new List<Student>();
            while(reader.Read()) {
                var student = new Student();
                student.ID = Convert.ToInt32(reader["Id"]);
                student.Firstname = reader["Firstname"].ToString();
                student.Lastname = reader["Lastname"].ToString();
                student.SAT = Convert.ToInt32(reader["SAT"]);
                student.GPA = Convert.ToDouble(reader["GPA"]);
                student.MajorID = Convert.ToInt32(reader["MajorID"]);
            }
            return students;
        }
        public Student() { }
        public Student(BcConnection connection) {
            bcConnection = connection;
        }
    }
}
