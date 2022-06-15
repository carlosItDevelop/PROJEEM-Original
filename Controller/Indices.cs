using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Projeem.Controller
{
    public class Indices
    {
        SqlConnection cn;
 
        public Indices(SqlConnection cn) {
            this.cn = cn;
        }


        public static void ZeraContadores(SqlConnection con)
        {
            string InstrucaoSql = "update indice set sb_atual = 1";
            SqlCommand cmd = new SqlCommand(InstrucaoSql, con);
            cmd.ExecuteNonQuery();
            CSharpUtil.Util.MsgInfo("Tabela [ Indice ] Atualizada com Sucesso!");
            cmd = null;
        }

        public static int GetSubperiodo(SqlConnection cn) {
            int retVal = 0;
            string InstrucaoSql = "Select sb_atual from Indice";
            SqlDataAdapter da = new SqlDataAdapter(InstrucaoSql, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "indice3");
            DataTable dt = ds.Tables["indice3"];
            retVal = int.Parse(dt.Rows[0]["sb_atual"].ToString());
            return retVal;
        }

        public static void AddSubperiodo(SqlConnection con, SqlTransaction tr){
            string InstrucaoSql = "update indice set sb_atual = sb_atual + 1";
            SqlCommand cmd = new SqlCommand(InstrucaoSql, con);
            cmd.Transaction = tr;
            cmd.ExecuteNonQuery();
            cmd = null;
        }

        public static void UpdateStatusProcessamento(string status, SqlConnection cn) {
            string vSql = "UPDATE indice SET status_processamento = '" + status + "'";
            SqlCommand cmd = new SqlCommand(vSql, cn);
            cmd.ExecuteNonQuery();
            cmd = null;
        }

        public static string GetStatusProcessamento(SqlConnection cn)
        {
            string vSql = "select status_processamento from indice";
            SqlDataAdapter da = new SqlDataAdapter(vSql, cn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "status");
            dt = ds.Tables["status"];
            return dt.Rows[0]["status_processamento"].ToString();
        }


    // ------------ //

    }// Fim da Classe;
}// Fim do NameSpace;
