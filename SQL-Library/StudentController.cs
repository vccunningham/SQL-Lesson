using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Library {
    public class StudentController {

        public static BcConnection bcConnection { get; set; }

        public static List<Student> GetAllStudents() {
            var sql = "SELECT * From Student s Left Join Major m on m.Id = s.MajorId";
            var command = new SqlCommand(sql, bcConnection.Connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
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

                if (Convert.IsDBNull(reader["Description"])) {
                    student.Major = null;
                } else {
                    var major = new Major {
                        Description = reader["Description"].ToString(),
                        MinSAT = Convert.ToInt32(reader["MinSAT"])
                    };
                }
                students.Add(student);


                //student.MajorID = Convert.ToInt32(reader["MajorID"]);
            }
            reader.Close();
            reader = null;
            return students;

        }

        public static Student GetStudentByPk(int ID) {

            var sql = $"SELECT * from Student Where Id = {ID}";
            var command = new SqlCommand(sql, bcConnection.Connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var student = new Student();
            student.ID = Convert.ToInt32(reader["Id"]);
            student.Firstname = reader["Firstname"].ToString();
            student.Lastname = reader["Lastname"].ToString();
            student.SAT = Convert.ToInt32(reader["SAT"]);
            student.GPA = Convert.ToDouble(reader["GPA"]);
            
            reader.Close();
            reader = null;
            return student;

            //student.MajorID = Convert.ToInt32(reader["MajorID"]);
        }
            
        public static bool InsertStudent(Student student) {
            var MajorID = "";
            if (student.MajorID == null) {
                MajorID = "NULL";
            } else {
                MajorID = student.MajorID.ToString();
            }
            var sql = $"INSERT into Student (Id, Firstname, Lastname, SAT, GPA, MajorId) " +
                        $" VALUES(@ID, @Firstname, @Lastname, @SAT, @GPA, @MajorID); ";
            
            var command = new SqlCommand(sql, bcConnection.Connection);

            command.Parameters.AddWithValue("@Id", student.ID);
            command.Parameters.AddWithValue("@Firstname", student.Firstname);
            command.Parameters.AddWithValue("@Lastname", student.Lastname);
            command.Parameters.AddWithValue("@SAT", student.SAT);
            command.Parameters.AddWithValue("@GPA", student.GPA);
            command.Parameters.AddWithValue("@MajorID", student.MajorID ?? Convert.DBNull);


            var recsAffected = command.ExecuteNonQuery();
            if(recsAffected != 1) {
                throw new Exception("Insert failed");
            }
            return true;

        }
        public static bool UpdateStudent(Student student) {
            var sql = "Update Student Set" +
                " Firstname = @Firstname, " +
                " Lastname = @Lastname, " +
                " SAT = @SAT, " +
                " GPA = @GPA, " +
                " MajorID = @MajorID" +
                " Where Id = @Id; ";

            var command = new SqlCommand(sql, bcConnection.Connection);

            command.Parameters.AddWithValue("@Id", student.ID);
            command.Parameters.AddWithValue("@Firstname", student.Firstname);
            command.Parameters.AddWithValue("@Lastname", student.Lastname);
            command.Parameters.AddWithValue("@SAT", student.SAT);
            command.Parameters.AddWithValue("@GPA", student.GPA);
            command.Parameters.AddWithValue("@MajorID", student.MajorID ?? Convert.DBNull);

            var recsAffected = command.ExecuteNonQuery();
            if (recsAffected != 1) {
                throw new Exception("Update failed");
            }
            return true;
        }
        public static bool DeleteStudent(Student student) {
            var sql = "DELETE from Student" +
                " Where Id = @Id; ";
            var command = new SqlCommand(sql, bcConnection.Connection);
            command.Parameters.AddWithValue("@Id", student.ID);
            var recsAffected = command.ExecuteNonQuery();
            if (recsAffected != 1) {
                throw new Exception("Delete failed");

            }
            return true;
        }
        public static bool DeleteStudent(int id) {
            var student = GetStudentByPk(id);
            if(student == null) {
                return false;
            }
            var success = DeleteStudent(student);
            return true;
            
        }
    }
}       
            
                
            
        
        
        
    
    
        
        
    

