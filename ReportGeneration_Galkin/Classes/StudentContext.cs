using MySql.Data.MySqlClient;
using ReportGeneration_Galkin.Classes.Common;
using ReportGeneration_Galkin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration_Galkin.Classes
{
    public class StudentContext : Student
    {
        public StudentContext(int id, string firstname, string lastname, int idGroup, bool expelled, DateTime? dateExpelled)
            : base(id, firstname, lastname, idGroup, expelled, dateExpelled) { }

        public static List<StudentContext> AllStudents()
        {
            List<StudentContext> allStudents = new List<StudentContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader reader = Connection.Query("Select * From `student` Order By `LastName`;", connection);

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string firstname = reader.IsDBNull(1) ? null : reader.GetString(1);
                string lastname = reader.IsDBNull(2) ? null : reader.GetString(2);
                int idGroup = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                bool expelled = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                DateTime? dateExpelled = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5);

                allStudents.Add(new StudentContext(id, firstname, lastname, idGroup, expelled, dateExpelled));
            }

            Connection.CloseConnection(connection);
            return allStudents;
        }
    }
}