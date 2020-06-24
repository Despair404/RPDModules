using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPDModule
{
    class DBWorker
    {

        string connection;
        public DBWorker (string connection)
        {
            this.connection = connection;
        }

        public DataSet getDataSet (string query)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
        }
        public void performQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(this.connection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                var result = command.ExecuteNonQuery();
            }
        }
    }
}
