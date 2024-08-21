using CommonModels;
using System.Data.SqlClient;
using System.Data;
using ClientDataLibrary;

namespace ClientDataConsole
{
    public class Validations
    {
        public static bool NameIsUnique(string name)
        {
            string sqlcom = $"SELECT * FROM tblClientData WHERE ClientName = '{name}'";

            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString))
            {
                sqlcon.Open();
                DataTable dt = new DataTable();
                dt = Common.GetDataTable(sqlcon, sqlcom);

                if (dt != null && dt.Rows.Count > 0) return false;
            }

            return true;
        }

    }
}
