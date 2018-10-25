using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IPC247
{
    public class SQLHelper
    {
        public static string str_connect = StringCipher.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["IPC247ConnectionString"].ConnectionString, "IPC247@2018");

        public static string getQueryFromCommand(SqlCommand cmd)
        {
            string CommandTxt = cmd.CommandText;
            string str_Return = "";
            try
            {
                switch (cmd.CommandType)
                {
                    case CommandType.Text:
                        str_Return = cmd.CommandText;
                        break;
                    case CommandType.StoredProcedure:
                        str_Return = "exec " + cmd.CommandText + " ";
                        foreach (SqlParameter prm in cmd.Parameters)
                        {
                            str_Return += string.Format("{0}=N'{1}',", prm.ParameterName, prm.Value);
                        }
                        if (str_Return.Length > 1)
                        {
                            str_Return = str_Return.Substring(0, str_Return.Length - 1);
                        }
                        break;
                    case CommandType.TableDirect:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            return str_Return;
        }

        private static DataTable ExecuteNonQuery(SqlCommand cmd)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    dt.SelectCommand = cmd;
                    cmd.CommandTimeout = 100000;

                    dt.Fill(dtTemp);
                    return dtTemp;
                }
            }
            catch (Exception ex)
            {
                SendMailERROR(string.Format("Lỗi rồi ExecuteNonQuery: {0} \r\n {1} \r\n {2}", ex.ToString(), getQueryFromCommand(cmd), Form_Main.IPAddress));
                return dtTemp;
            }
        }
        private static DataSet ExecuteNonQuery_DataSet(SqlCommand cmd)
        {
            DataSet dtTemp = new DataSet();
            try
            {
                using (SqlDataAdapter dt = new SqlDataAdapter(cmd))
                {
                    dt.SelectCommand = cmd;
                    cmd.CommandTimeout = 100000;

                    dt.Fill(dtTemp);
                    return dtTemp;
                }
            }
            catch (Exception ex)
            {
                SendMailERROR(string.Format("Lỗi rồi ExecuteNonQuery_DataSet: {0} \r\n {1} \r\n {2}", ex.ToString(), getQueryFromCommand(cmd), Form_Main.IPAddress));
              //  SendMailERROR(string.Format("Lỗi rồi ExecuteNonQuery_DataSet: {0}", ex.ToString()));
                return dtTemp;
            }
        }
        public static DataTable ExecuteDataTable(string sql_exec)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_exec, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        dt = ExecuteNonQuery(cmd);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
               // SendMailERROR(string.Format("Lỗi rồi ExecuteDataTable: {0} \r\n {1} \r\n {2}", ex.ToString(), sql_exec, Form_Main.IPAddress));
                SendMailERROR(string.Format("Lỗi rồi ExecuteDataTable: {0}", ex.ToString()));
                return dt;
            }
        }

        public static DataTable ExecuteDataTableByQuery(string sql_exec)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_exec, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        dt = ExecuteNonQuery(cmd);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                //SendMailERROR(string.Format("Lỗi rồi ExecuteDataTableByQuery: {0} \r\n {1} \r\n {2}", ex.ToString(), sql_exec, Form_Main.IPAddress));
                SendMailERROR(string.Format("Lỗi rồi ExecuteDataTableByQuery: {0}", ex.ToString()));
                return dt;
            }
           
        }
        public static DataSet ExecuteDataSetByStore(string sql_exec)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_exec, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        dt = ExecuteNonQuery_DataSet(cmd);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                SendMailERROR(string.Format("Lỗi rồi ExecuteDataSetByStore: {0}", ex.ToString()));
               // SendMailERROR(string.Format("Lỗi rồi ExecuteDataSetByStore: {0} \r\n {1} \r\n {2}", ex.ToString(), sql_exec, Form_Main.IPAddress));
                return dt;
            }

        }
        public static DataSet ExecuteDataSetByQuery(string sql_exec)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_exec, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        dt = ExecuteNonQuery_DataSet(cmd);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
              //  SendMailERROR(string.Format("Lỗi rồi ExecuteDataTableByQuery: {0} \r\n {1} \r\n {2}", ex.ToString(), sql_exec, Form_Main.IPAddress));
                SendMailERROR(string.Format("Lỗi rồi ExecuteDataSetByQuery: {0}", ex.ToString()));
                return dt;
            }

        }
        public static DataTable ExecuteDataTableUndefine(string sql_exec, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_exec, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                        }
                        conn.Open();
                        dt = ExecuteNonQuery(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                SendMailERROR(string.Format("Lỗi rồi ExecuteDataTableUndefine: {0}", ex.ToString()));
                return dt;
            }
            return dt;
        }
        public static DataSet ExecuteDataSetUndefine(string sql_exec, Dictionary<string, object> parameters)
        {
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand(sql_exec, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                        }
                        conn.Open();
                        dt = ExecuteNonQuery_DataSet(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                SendMailERROR(string.Format("Lỗi rồi ExecuteDataSetUndefine: {0}", ex.ToString()));
                return dt;
            }
            return dt;
        }
        private static void SendMailERROR(string Error)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("IPC247Mail@gmail.com", "Th@ison@123456");
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage mail = new MailMessage("dtson.vt@gmail.com", "sondt13@fpt.com.vn");
                    mail.Subject = "Admin - ERROR LOG";
                    mail.Body = Error;
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
      
        }
        public static string sp_extension_ImportProduct(DataTable dtInput, string UserID )
        {
            // DataTable dt = new DataTable();
            string Error = "";
            try
            {
              //  var UserID = json.GetValue("UserName") != null ? (json.GetValue("UserName").Value<String>().Trim() ?? "") : "";
              //  var jsondata = json.GetValue("Data");
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    conn.Open();

                    // List<Product> ProductList = JsonConvert.DeserializeObject<List<Product>>(jsondata.ToString());
                    using (SqlCommand sqlcm = new SqlCommand(String.Format("Delete [T_Product_temp] where CreateBy='{0}'", UserID), conn))
                    {
                        sqlcm.CommandType = CommandType.Text;
                        sqlcm.ExecuteNonQuery();
                    }

                    SqlBulkCopy bulkInsert = new SqlBulkCopy(conn);
                    bulkInsert.DestinationTableName = "T_Product_temp";
                  //  dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                   // dtInput.Columns.Remove("Id");
                    bulkInsert.WriteToServer(dtInput);

                }
                using (SqlConnection conn = new SqlConnection(str_connect))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_extension_ImportProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserID;
                        conn.Open();
                        ExecuteNonQuery(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteLog("sp_extension_ImportProduct", "ERROR : " + ex.ToString());
                //return Request.CreateResponse(HttpStatusCode.OK, new { Success = false, Data = ex.ToString() });
                Error = ex.ToString();
            }
            return Error;
        }
    }
}
