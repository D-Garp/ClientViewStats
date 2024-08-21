using System;
using System.Data;
using System.Data.SqlClient;
using CommonModels;

namespace ClientDataLibrary
{
    public class Common
    {
        public static string connetionString = @"Data source=DESKTOP-71UTN04;Initial catalog=ClientListDB;trusted_connection=true";

        public static DataTable GetDataTable(SqlConnection connect, string sqlcom)
        {
            DataTable table = new DataTable();
            using (SqlCommand cmd = connect.CreateCommand())
            {
                cmd.CommandText = sqlcom;
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            return table;
        }
    }

}
