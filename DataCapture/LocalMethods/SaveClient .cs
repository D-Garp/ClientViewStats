using ClientDataLibrary;
using CommonModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCapture.LocalMethods
{
    public class SaveClient
    {
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
