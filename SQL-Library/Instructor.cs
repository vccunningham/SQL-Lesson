using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_Library {
    public class Instructor {

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int YearsExperienced { get; set; }
        public int? IsTenured { get; set; }

        public override string ToString() {
            return $" {Id} | {Firstname} | {Lastname} | {YearsExperienced} | {IsTenured} ";
        }

        public Instructor() { }
    }
}
