using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQL_Library {

    public class Student {
        public static BcConnection bcConnection;

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int SAT { get; set; }
        public double GPA { get; set; }
        public int? MajorID { get; set; }

        public override string ToString() {
            return $"{ID} | {Firstname} {Lastname} | {SAT} | {GPA}";
        }



        public Student() { }
        
    }
}
