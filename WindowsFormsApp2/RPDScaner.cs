using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPDModule
{
     static class RPDScaner
    {
        public static List<IntPtr> titleChildren;
        static DBWorker DB;


        public static int getDisciplineID (string discipline, int planID)
        {
            string conRPD = ConfigurationManager.ConnectionStrings["RPDConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conRPD))
            {
                connection.Open();
                string sql = "SELECT * FROM ПланыСтроки WHERE Дисциплина='" + discipline + "' AND КодПлана=" + planID;
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                object idD = 0;
                while (reader.Read())
                {
                    idD = reader.GetValue(0);
                }
                connection.Close();
                return Convert.ToInt32(idD);
            }
        }

    }
}
