using CommonModels;
using System.Data.SqlClient;
using System.Data;
using ClientDataLibrary;

namespace ClientDataConsole
{
    public class LocalMethods
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

        //Write data to proc
        public static string Save(ClientDataModel model)
        {
            using (SqlConnection sqlcon = new SqlConnection(Common.connetionString))
            {

                sqlcon.Open();
                DataSet set = GetDataSetFromProc(sqlcon, model, "spSaveClientData");
                if (set.Tables[0].Rows.Count > 0)
                {
                    string validations = "Failed validations due to the following reasons:\n";
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        validations += set.Tables[0].Rows[i]["Message"].ToString() + "\n";
                    }
                }
            }

            return "Successfully saved";
        }

        public static void ExitApp()
        {
            Console.WriteLine("Press any key to close Client Data Capture: ");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void Warning()
        {
            Console.WriteLine("*****Please Note application will take you exit if nothing or empty space is entered**** \n");
        }

        private static List<string> ListClients()
        {
            var list = new List<string>();


            return list;
        }

        private static DataSet GetDataSetFromProc(SqlConnection connect, ClientDataModel model, string proc)
        {
            DataSet set = new DataSet();
            SqlDataAdapter dpt = new SqlDataAdapter();

            using (SqlCommand cmd = connect.CreateCommand())
            {
                cmd.CommandText = $"EXEC {proc} @ClientName = '{model.ClientName}'" +
                                            $", @Location = '{model.Location}'" +
                                            $", @NumberOfUsers = {model.NumberOfUsers}" +
                                            $", @DateRegistered = '{model.DateRegistered}'";
                dpt.SelectCommand = cmd;
                dpt.Fill(set);
            }
            return set;
        }
    }
}
