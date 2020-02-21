using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SQL_Library {
    public class InstructorController {
        public static BcConnection bcConnection { get; set; }
        private static Instructor LoadInstructorInstance(SqlDataReader reader) {
            var instructor = new Instructor();
            instructor.Id = Convert.ToInt32(reader["Id"]);
            instructor.Firstname = reader["Firstname"].ToString();
            instructor.Lastname = reader["Lastname"].ToString();
            instructor.YearsExperienced = Convert.ToInt32(reader["YearsExperienced"]);
            instructor.IsTenured = Convert.IsDBNull(reader["IsTenured"]) ? (int?)null : Convert.ToInt32(reader["IsTenured"]);
            return instructor;
        }

        public static List<Instructor> GetAllInstructors() {
            var sql = "SELECT * From Instructor";
            var command = new SqlCommand(sql, bcConnection.Connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                Console.WriteLine("No rows from GetAllInstructor()");
                return new List<Instructor>();
            }
            var instuctors = new List<Instructor>();
            while (reader.Read()) {

            }
            reader.Close();
            reader = null;
            return instuctors;
        }
        public static Instructor GetInstructorByPk(int ID) {

            var sql = $"SELECT * from Instructor Where Id = {ID}";
            var command = new SqlCommand(sql, bcConnection.Connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            var instructor = LoadInstructorInstance(reader);
            reader.Close();
            reader = null;
            return instructor;

        }

    }
}
