using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Projeem.Controller
{
    public class ControleAplicacao
    {
        SqlConnection cn;
        DataTable dt;
        public ControleAplicacao(SqlConnection cn) {
            this.cn = cn;
        }

        #region:: Método Add para Gravar os Dados de Controle da Aplicação
        public void Add_Contabilidade(SqlConnection cnn, SqlTransaction tr, int id, int gp, int sb, string dbt_ctbil, 
                        string dbt_real, string cto_ctbil, 
                        string cto_real, string sdo_sb_ctbil, 
                        string sdo_sb_real, string cg_subsidiario, 
                        string mvct, string premio_real, 
                        string sdo_ctbl_acum, string sdo_real_acum ) 
            { 
            try
            {
                #region:: Conversões de , por .
                dbt_ctbil = dbt_ctbil.Replace(".", "");
                dbt_ctbil = dbt_ctbil.Replace(",", ".");
                //----------------------
                dbt_real = dbt_real.Replace(".", "");
                dbt_real = dbt_real.Replace(",", ".");
                //----------------------
                cto_ctbil = cto_ctbil.Replace(".", "");
                cto_ctbil = cto_ctbil.Replace(",", ".");
                //----------------------
                cto_real = cto_real.Replace(".", "");
                cto_real = cto_real.Replace(",", ".");
                //----------------------
                sdo_sb_ctbil = sdo_sb_ctbil.Replace(".", "");
                sdo_sb_ctbil = sdo_sb_ctbil.Replace(",", ".");
                //----------------------
                sdo_sb_real = sdo_sb_real.Replace(".", "");
                sdo_sb_real = sdo_sb_real.Replace(",", ".");
                //----------------------
                cg_subsidiario = cg_subsidiario.Replace(".", "");
                cg_subsidiario = cg_subsidiario.Replace(",", ".");
                //----------------------
                mvct = mvct.Replace(".", "");
                mvct = mvct.Replace(",", ".");
                //----------------------
                sdo_ctbl_acum = sdo_ctbl_acum.Replace(".", "");
                sdo_ctbl_acum = sdo_ctbl_acum.Replace(",", ".");
                //----------------------
                sdo_real_acum = sdo_real_acum.Replace(".", "");
                sdo_real_acum = sdo_real_acum.Replace(",", ".");
                //----------------------
                #endregion

                SqlCommand cmd = new SqlCommand("Add_Contabilidade", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tr;

                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@gp", gp));
                cmd.Parameters.Add(new SqlParameter("@sb", sb));
                cmd.Parameters.Add(new SqlParameter("@dbt_ctbil", dbt_ctbil));
                cmd.Parameters.Add(new SqlParameter("@dbt_real", dbt_real));
                cmd.Parameters.Add(new SqlParameter("@cto_ctbil", cto_ctbil));
                cmd.Parameters.Add(new SqlParameter("@cto_real", cto_real));
                cmd.Parameters.Add(new SqlParameter("@sdo_sb_ctbil", sdo_sb_ctbil));
                cmd.Parameters.Add(new SqlParameter("@sdo_sb_real", sdo_sb_real));
                cmd.Parameters.Add(new SqlParameter("@cg_subsidiario", cg_subsidiario));
                cmd.Parameters.Add(new SqlParameter("@mvct", mvct));
                cmd.Parameters.Add(new SqlParameter("@premio_real", premio_real));
                cmd.Parameters.Add(new SqlParameter("@sdo_ctbl_acum", sdo_ctbl_acum));
                cmd.Parameters.Add(new SqlParameter("@sdo_real_acum", sdo_real_acum));

                cmd.ExecuteNonQuery();
                
            } catch (Exception ex) {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
         
        }
        #endregion

        #region:: Metodo AddEstatistica_Carencia
        public void AddEstatistica_Carencia(SqlConnection cnn, SqlTransaction tr, int id, int car1, int car2, int car3, int car4, 
            int car5, int car6, int car7, int car8, int car9, int car10, int car11, int car12, 
                                                    int car13, int car14, int car15) 
            { 
            try {

                SqlCommand cmd = new SqlCommand("Add_Estatistica_Carencia", cnn);                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tr;

                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@car1", car1));
                cmd.Parameters.Add(new SqlParameter("@car2", car2));
                cmd.Parameters.Add(new SqlParameter("@car3", car3));
                cmd.Parameters.Add(new SqlParameter("@car4", car4));
                cmd.Parameters.Add(new SqlParameter("@car5", car5));
                cmd.Parameters.Add(new SqlParameter("@car6", car6));
                cmd.Parameters.Add(new SqlParameter("@car7", car7));
                cmd.Parameters.Add(new SqlParameter("@car8", car8));
                cmd.Parameters.Add(new SqlParameter("@car9", car9));
                cmd.Parameters.Add(new SqlParameter("@car10", car10));
                cmd.Parameters.Add(new SqlParameter("@car11", car11));
                cmd.Parameters.Add(new SqlParameter("@car12", car12));

                cmd.Parameters.Add(new SqlParameter("@car13", car13));
                cmd.Parameters.Add(new SqlParameter("@car14", car14));
                cmd.Parameters.Add(new SqlParameter("@car15", car15));                
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                CSharpUtil.Util.MsgErro(ex.Message);
            }

                // ---------------  //
        }//Fim do Método AddEstatistica_Carencia;
        #endregion

        #region:: Método AddEstatistica_Premio
        public void AddEstatistica_Premio(SqlConnection cnn, SqlTransaction tr, int id, int pre1, int pre2, int pre3, int pre4, 
                                          int pre5, int pre6, int pre7, int pre8, int pre9, 
                                          int pre10, int pre11, int pre12, 
                                          int pre13, int pre14, int pre15)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Add_Estatistica_Premio", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = tr;

                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@pre1", pre1));
                cmd.Parameters.Add(new SqlParameter("@pre2", pre2));
                cmd.Parameters.Add(new SqlParameter("@pre3", pre3));
                cmd.Parameters.Add(new SqlParameter("@pre4", pre4));
                cmd.Parameters.Add(new SqlParameter("@pre5", pre5));
                cmd.Parameters.Add(new SqlParameter("@pre6", pre6));
                cmd.Parameters.Add(new SqlParameter("@pre7", pre7));
                cmd.Parameters.Add(new SqlParameter("@pre8", pre8));
                cmd.Parameters.Add(new SqlParameter("@pre9", pre9));
                cmd.Parameters.Add(new SqlParameter("@pre10", pre10));
                cmd.Parameters.Add(new SqlParameter("@pre11", pre11));
                cmd.Parameters.Add(new SqlParameter("@pre12", pre12));

                cmd.Parameters.Add(new SqlParameter("@pre13", pre12));
                cmd.Parameters.Add(new SqlParameter("@pre14", pre12));
                cmd.Parameters.Add(new SqlParameter("@pre15", pre12));

                cmd.ExecuteNonQuery();
                //CSharpUtil.Util.MsgInfo("Registro Adicionado com Sucesso!");
            } catch (Exception ex) {
                CSharpUtil.Util.MsgErro(ex.Message);
            }


        // --------------------------------  //
        }//Fim do Método AddEstatistica_Premio;


        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        public static void DeleteAll_WithSProc(SqlConnection cn)
        {
            try
            {
                SqlCommand cmd;

                cmd = new SqlCommand("Deleta_Estatistica_Carencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Deleta_Estatistica_Premio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Deleta_Contabilidade", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                CSharpUtil.Util.MsgInfo("Registros [contabilidade] Excluídos com Sucesso!");
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }


        public void ExibeDadosContabilidade() {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Exibe_Contabilidade", this.cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "Exibe_Contabilidade");
                dt = new DataTable();
                dt = ds.Tables["Exibe_Contabilidade"];
                curReg = 0;
                registro_atual = curReg + 1;
                num_registro = dt.Rows.Count;

                ds.Dispose();

                if (num_registro > 0) SetRst();

            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }


        void SetRst()
        {

            id_aplicacao = Convert.ToInt32(dt.Rows[curReg]["id_aplicacao"].ToString());
            grupo = Convert.ToInt32(dt.Rows[curReg]["num_gp"].ToString());
            subperiodo = Convert.ToInt32(dt.Rows[curReg]["subperiodo"].ToString());
            debito_contabil = Convert.ToDecimal(dt.Rows[curReg]["debito_contabil"].ToString());
            debito_real = Convert.ToDecimal(dt.Rows[curReg]["debito_real"].ToString());
            credito_contabil = Convert.ToDecimal(dt.Rows[curReg]["credito_contabil"].ToString());
            credito_real = Convert.ToDecimal(dt.Rows[curReg]["credito_real"].ToString());
            saldo_sb_contabil = Convert.ToDecimal(dt.Rows[curReg]["saldo_sb_contabil"].ToString());
            saldo_sb_real = Convert.ToDecimal(dt.Rows[curReg]["saldo_sb_real"].ToString());
            capital_subsidiario = Convert.ToDecimal(dt.Rows[curReg]["capital_subsidiario"].ToString());
            mvtc = Convert.ToDecimal(dt.Rows[curReg]["mvtc"].ToString());
            premio_real = dt.Rows[curReg]["premio_real"].ToString();

            saldo_contabil_acumulado = Convert.ToDecimal(dt.Rows[curReg]["saldo_contabil_acumulado"].ToString());
            saldo_real_acumulado = Convert.ToDecimal(dt.Rows[curReg]["saldo_real_acumulado"].ToString());

            vcar1 = Convert.ToInt32(dt.Rows[curReg]["c1"].ToString());
            vcar2 = Convert.ToInt32(dt.Rows[curReg]["c2"].ToString());
            vcar3 = Convert.ToInt32(dt.Rows[curReg]["c3"].ToString());
            vcar4 = Convert.ToInt32(dt.Rows[curReg]["c4"].ToString());
            vcar5 = Convert.ToInt32(dt.Rows[curReg]["c5"].ToString());
            vcar6 = Convert.ToInt32(dt.Rows[curReg]["c6"].ToString());
            vcar7 = Convert.ToInt32(dt.Rows[curReg]["c7"].ToString());
            vcar8 = Convert.ToInt32(dt.Rows[curReg]["c8"].ToString());
            vcar9 = Convert.ToInt32(dt.Rows[curReg]["c9"].ToString());
            vcar10 = Convert.ToInt32(dt.Rows[curReg]["c10"].ToString());
            vcar11 = Convert.ToInt32(dt.Rows[curReg]["c11"].ToString());
            vcar12 = Convert.ToInt32(dt.Rows[curReg]["c12"].ToString());

            vcar13 = Convert.ToInt32(dt.Rows[curReg]["c13"].ToString());
            vcar14 = Convert.ToInt32(dt.Rows[curReg]["c14"].ToString());
            vcar15 = Convert.ToInt32(dt.Rows[curReg]["c15"].ToString());
                        
            vpre1 = Convert.ToInt32(dt.Rows[curReg]["p1"].ToString());
            vpre2 = Convert.ToInt32(dt.Rows[curReg]["p2"].ToString());
            vpre3 = Convert.ToInt32(dt.Rows[curReg]["p3"].ToString());
            vpre4 = Convert.ToInt32(dt.Rows[curReg]["p4"].ToString());
            vpre5 = Convert.ToInt32(dt.Rows[curReg]["p5"].ToString());
            vpre6 = Convert.ToInt32(dt.Rows[curReg]["p6"].ToString());
            vpre7 = Convert.ToInt32(dt.Rows[curReg]["p7"].ToString());
            vpre8 = Convert.ToInt32(dt.Rows[curReg]["p8"].ToString());
            vpre9 = Convert.ToInt32(dt.Rows[curReg]["p9"].ToString());
            vpre10 = Convert.ToInt32(dt.Rows[curReg]["p10"].ToString());
            vpre11 = Convert.ToInt32(dt.Rows[curReg]["p11"].ToString());
            vpre12 = Convert.ToInt32(dt.Rows[curReg]["p12"].ToString());
            
            vpre13 = Convert.ToInt32(dt.Rows[curReg]["p13"].ToString());
            vpre14 = Convert.ToInt32(dt.Rows[curReg]["p14"].ToString());
            vpre15 = Convert.ToInt32(dt.Rows[curReg]["p15"].ToString());
            

        }

        #region:: Métodos de Navegação
        public void Proximo()
        {
            curReg++;
            if (curReg > num_registro - 1)
            {
                curReg = num_registro - 1;
                finalDeArquivo = true;
                CSharpUtil.Util.MsgInfo("Final de Arquivo!");
            }
            else
            {
                registro_atual = curReg + 1;
                SetRst();
            }
        } // Fim de ProximoRegistro;

        public void Anterior()
        {
            finalDeArquivo = false;
            curReg--;
            if (curReg < 0)
            {
                curReg = 0;
                CSharpUtil.Util.MsgInfo("Início de Arquivo!");
            }
            else
            {
                registro_atual = curReg + 1;
                SetRst();
            }
        } // Fim de Anterior;

        public void Primeiro()
        {
            curReg = 0;
            registro_atual = curReg + 1;
            finalDeArquivo = false;
            SetRst();
        } // Fim de Primeiro;

        public void Ultimo()
        {
            curReg = num_registro - 1;
            registro_atual = curReg + 1;
            finalDeArquivo = false;
            SetRst();
        } // Fim de Primeiro;

        #endregion

        #region:: Variáveis da Classe
        int id_aplicacao;
        int grupo;
        int subperiodo;
        decimal debito_contabil;
        decimal debito_real;
        decimal credito_contabil;
        decimal credito_real;
        decimal saldo_sb_contabil;
        decimal saldo_sb_real;
        decimal capital_subsidiario;
        decimal mvtc;
        string premio_real;

        int curReg; // ÚNICA SEM PROPRIEDADE!!!
        int registro_atual;
        int num_registro;
        bool finalDeArquivo = false;

        decimal saldo_contabil_acumulado;
        decimal saldo_real_acumulado;

        int vcar1;
        int vcar2;
        int vcar3;
        int vcar4;
        int vcar5;
        int vcar6;
        int vcar7;
        int vcar8;
        int vcar9;
        int vcar10;
        int vcar11;
        int vcar12;

        int vcar13;
        int vcar14;
        int vcar15;
        
        

        int vpre1;
        int vpre2;
        int vpre3;
        int vpre4;
        int vpre5;
        int vpre6;
        int vpre7;
        int vpre8;
        int vpre9;
        int vpre10;
        int vpre11;
        int vpre12;

        int vpre13;
        int vpre14;
        int vpre15;


        #endregion

        #region:: Propriedades da Classe

        public int Vpre1 { get { return vpre1;} set { vpre1 = value;} }
        public int Vpre2 { get { return vpre2; } set { vpre2 = value;}}
        public int Vpre3 { get { return vpre3; } set { vpre3 = value; } }
        public int Vpre4 { get { return vpre4; } set { vpre4 = value; } }
        public int Vpre5 { get { return vpre5; } set { vpre5 = value; } }
        public int Vpre6 { get { return vpre6; } set { vpre6 = value; } }
        public int Vpre7 { get { return vpre7; } set { vpre7 = value; } }
        public int Vpre8 { get { return vpre8; } set { vpre8 = value; } }
        public int Vpre9 { get { return vpre9; } set { vpre9 = value; } }
        public int Vpre10 { get { return vpre10; } set { vpre10 = value; } }
        public int Vpre11 { get { return vpre11; } set { vpre11 = value; } }
        public int Vpre12 { get { return vpre12; } set { vpre12 = value; } }

        public int Vpre13 { get { return vpre13; } set { vpre13 = value; } }
        public int Vpre14 { get { return vpre14; } set { vpre14 = value; } }
        public int Vpre15 { get { return vpre15; } set { vpre15 = value; } }
        

        public int Vcar1 { get { return vcar1; } set { vcar1 = value; } }
        public int Vcar2 { get { return vcar2; } set { vcar2 = value; } }
        public int Vcar3 { get { return vcar3; } set { vcar3 = value; } }
        public int Vcar4 { get { return vcar4; } set { vcar4 = value; } }
        public int Vcar5 { get { return vcar5; } set { vcar5 = value; } }
        public int Vcar6 { get { return vcar6; } set { vcar6 = value; } }
        public int Vcar7 { get { return vcar7; } set { vcar7 = value; } }
        public int Vcar8 { get { return vcar8; } set { vcar8 = value; } }
        public int Vcar9 { get { return vcar9; } set { vcar9 = value; } }
        public int Vcar10 { get { return vcar10; } set { vcar10 = value; } }
        public int Vcar11 { get { return vcar11; } set { vcar11 = value; } }
        public int Vcar12 { get { return vcar12; } set { vcar12 = value; } }

        public int Vcar13 { get { return vcar13; } set { vcar13 = value; } }
        public int Vcar14 { get { return vcar14; } set { vcar14 = value; } }
        public int Vcar15 { get { return vcar15; } set { vcar15 = value; } }
        

        public int Registro_atual
        {
            get { return registro_atual; }
            set { registro_atual = value; }
        }
        public int Num_registro
        {
            get { return num_registro; }
            set { num_registro = value; }
        }

        public int Id_aplicacao {
            get { return id_aplicacao; }
            set { id_aplicacao = value; }
        }
        public int Grupo {
            get { return grupo; }
            set { grupo = value; }
        }
        public int Subperiodo {
            get { return subperiodo; }
            set { subperiodo = value; }
        }
        public decimal Debito_contabil {
            get { return debito_contabil; }
            set { debito_contabil = value; }
        }
        public decimal Debito_real {
            get { return debito_real; }
            set { debito_real = value; }
        }
        public decimal Credito_contabil {
            get { return credito_contabil; }
            set { credito_contabil = value; }
        }
        public decimal Credito_real {
            get { return credito_real; }
            set { credito_real = value; }
        }
        public decimal Saldo_sb_contabil {
            get { return saldo_sb_contabil; }
            set { saldo_sb_contabil = value; }
        }
        public decimal Saldo_sb_real {
            get { return saldo_sb_real; }
            set { saldo_sb_real = value; }
        }
        public decimal Capital_subsidiario {
            get { return capital_subsidiario; }
            set { capital_subsidiario = value; }
        }
        public decimal Mvtc {
            get { return mvtc; }
            set { mvtc = value; }
        }
        public string Premio_real {
            get { return premio_real; }
            set { premio_real = value; }
        }

        public decimal Saldo_contabil_acumulado {
            get { return saldo_contabil_acumulado; }
            set { saldo_contabil_acumulado = value; }
        }
        public decimal Saldo_real_acumulado
        {
            get { return saldo_real_acumulado; }
            set { saldo_real_acumulado = value; }
        }

        public bool FinalDeArquivo
        {
            get { return finalDeArquivo; }
            set { finalDeArquivo = true; }
        }


        #endregion


        
    }
}
