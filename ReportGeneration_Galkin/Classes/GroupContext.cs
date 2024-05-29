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
    public class GroupContext : Group
    {
        public GroupContext(int Id, string Name) : base(Id, Name) { }

        public static List<GroupContext> AllGroups()
        {
            List<GroupContext> allGroups = new List<GroupContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Group = Connection.Query("Select * From `group` Order By `Name`;", connection);
            while (Group.Read())
            {
                allGroups.Add(new GroupContext(
                    Group.GetInt32(0),
                    Group.GetString(1)));
            }
            Connection.CloseConnection(connection);
            return allGroups;
        }
    }
}
