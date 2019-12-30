using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CommonFramework.ado.net
{
   public class BaseDao
    {
        private string connectString = ConfigurationManager.ConnectionStrings["sanguo"].ConnectionString;
        protected string ConnectString {
            set {
                connectString = value;
            }
        } 
        protected int ExcauteNoneQuery(string sql)
        {
            return SqlHelper.ExecuteNonQuery(connectString,CommandType.Text, sql);
        }

        protected int ExcauteNoneQuery(string sql, Dictionary<string, string> dicPara)
        {
            SqlParameter[] parameter = new SqlParameter[dicPara.Count];
            int i = 0;
            foreach (var name in dicPara.Keys)
            {
                parameter[i] = new SqlParameter(name, dicPara[name]);
                i++;
            }
           return SqlHelper.ExecuteNonQuery(connectString, CommandType.Text,sql,parameter);
        }

        protected int ExcauteNoneQuery(string spname, Dictionary<string, string> dicPara, bool isSP)
        {
            SqlParameter[] parameter=null;
            if (dicPara != null)
            {
               parameter = new SqlParameter[dicPara.Count];
                int i = 0;
                foreach (var name in dicPara.Keys)
                {
                    parameter[i] = new SqlParameter(name, dicPara[name]);
                    i++;
                }
            }
           return SqlHelper.ExecuteNonQuery(connectString, spname, parameter);
        }
    }
}
