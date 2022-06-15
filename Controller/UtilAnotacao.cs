
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace Projeem.Controller
{
    
    public class UtilAnotacao
    {

        public UtilAnotacao()
        { 
        }



        public static string GerarIDAnotacao(SqlConnection cn, string banco, string tabela)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            string Resultado;
            SqlDataReader Leitor;
            if (banco == "Oracle")
            {
                cmd.CommandText = "SELECT " + tabela + ".NEXTVAL FROM DUAL";
                Leitor = cmd.ExecuteReader();
                Leitor.Read();
                Resultado = Leitor[0].ToString();
                Leitor.Close();
                // No Oracle, não precisa haver exclusão
            } else {
                // No Sql Server
                cmd.CommandText = "INSERT INTO " + tabela + " ( Inutil ) VALUES( 'X' )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@identity";
                Leitor = cmd.ExecuteReader();
                // É comum usar um while mas, no nosso caso,
                // temos certeza absoluta de que só há um
                // único registro a ser lido
                Leitor.Read();
                Resultado = Leitor[0].ToString();
                Leitor.Close();
                cmd.CommandText = "DELETE FROM " + tabela + " WHERE ID = " + Resultado;
                cmd.ExecuteNonQuery();
            }
            return Resultado;
        }


        public static void PreencheComboAnotacao(SqlConnection cn, ComboBox cbo, String tabela, String campo, string Todos)
        {
            String cmdString = "select distinct " + campo + " from " + tabela + " order by " + campo;
            SqlCommand cmd = new SqlCommand(cmdString, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            cbo.Items.Clear();
            if (dr.Read()) { cbo.Items.Add("Todos"); cbo.Items.Add(dr[campo]); }
            while (dr.Read())
            {
                cbo.Items.Add(dr[campo]);
            }
            dr.Close();
        }

        public static void PreencheComboComum(SqlConnection cn, ComboBox cbo, String tabela, String campo)
        {
            String cmdString = "select distinct " + campo + " from " + tabela + " order by " + campo;
            SqlCommand cmd = new SqlCommand(cmdString, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            cbo.Items.Clear();
            if (dr.Read()) { cbo.Items.Add(dr[campo]); }
            while (dr.Read())
            {
                cbo.Items.Add(dr[campo]);
            }
            dr.Close();
        }





    } // Fim da Classe;
} // Fim do Namespace;

