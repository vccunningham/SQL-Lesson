using System;
using SQL_Library;
    
namespace SQL_Lesson {
    class Program {
        static void Main(string[] args) {
            
            var sqlLib = new BcConnection();
            sqlLib.Connect(@"localhost\sqlexpress", "EdDb", "trusted_connection=true");
            sqlLib.Disconnect();
        }
    }
}
