using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeem.Controller
{
    public class Serie
    {
        #region::: Variáveis de Classe
        SqlConnection cn;
        int curReg = 0;
        int totalReg = 0;
        int registro_atual;
        int num_registro;
        
        int id_serie;
        int gr_01;
        int gr_02;
        int carencia;
        int qtde_premio;
        int mor_carencia;
        int pr_aplicacao;
        int num_aplicacao;
        int carencia_recap;
        string status;
        DataTable dt;

        bool finalDeArquivo = false;

        #endregion


        /// <summary>
        /// Construtor do Objeto
        /// </summary>
        /// <param name="cn">Objeto Conexão passada como referência (como todo objeto)</param>
        public Serie(SqlConnection cn) {
            this.cn = cn;
        }

        public void AumentaCarencia(int id_serie) {
            try
            {
                SqlCommand cmd = new SqlCommand("Aumenta_Carencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id_serie));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }

        public void AumentaCarenciaRecap(int id_serie)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Aumenta_Carencia_Recap", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id_serie));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }
        
        public void ZeraCarencia(int id_serie) {
            try
            {
                SqlCommand cmd = new SqlCommand("Zera_Carencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id_serie));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }

        public void ZeraCarenciaRecap(int id_serie)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Zera_Carencia_Recap", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id_serie));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }

        public void AumentaQtdePremio(int id_serie) {
            try
            {
                SqlCommand cmd = new SqlCommand("Aumenta_QtdePremio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id_serie));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        } // Fim de AumentaQtdePremio;

        public void ComparaCarencia(int id_serie) {
            if (carencia > mor_carencia)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Compara_Carencia", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id_serie));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    CSharpUtil.Util.MsgErro(ex.Message);
                }
            }
        } // Fim de ComparaCarencia

        public void ContaStatusEAgrupa(ref Label w01, ref Label w02, ref Label w03, ref Label w04, ref Label w05, 
                                       ref Label p01, ref Label p02, ref Label p03, ref Label p04, ref Label p05, 
                                       ref Label p115, ref Label SubWait, ref Label SubReady)
        {
            try
            {
                int curReg = 0;
                int numReg = 0;
                string vStatus = "";
                int vCount = 0;
                int vQtdeRecapWait = 0;
                int vQtdeRecapProc = 0;
                int vQtdeSubWait = 0;
                int vQtdeSubReady = 0;

                SqlDataAdapter da = new SqlDataAdapter("ContaStatusEAgrupa", this.cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "ContaStatusEAgrupa");
                dt = ds.Tables["ContaStatusEAgrupa"];
                curReg = 0;
                numReg = dt.Rows.Count;

                if (numReg > 0) {
                    while (curReg < numReg) {
                        vStatus = dt.Rows[curReg]["status"].ToString();
                        vCount = (int)dt.Rows[curReg]["qtde_status"];
                        switch (vStatus.Trim()) { 
                            case "Processing_115":
                                p115.Text = vCount.ToString();
                                break;
                            case "Recap_wait_01":
                                vQtdeRecapWait += vCount;
                                w01.Text = vCount.ToString();
                                break;
                            case "Recap_wait_02":
                                vQtdeRecapWait += vCount;
                                w02.Text = vCount.ToString();
                                break;
                            case "Recap_wait_03":
                                vQtdeRecapWait += vCount;
                                w03.Text = vCount.ToString();
                                break;
                            case "Recap_wait_04":
                                vQtdeRecapWait += vCount;
                                w04.Text = vCount.ToString();
                                break;
                            case "Recap_wait_05":
                                vQtdeRecapWait += vCount;
                                w05.Text = vCount.ToString();
                                break;
                            case "Recap_Proc_01":
                                vQtdeRecapProc += vCount;
                                p01.Text = vCount.ToString();
                                break;
                            case "Recap_Proc_02":
                                vQtdeRecapProc += vCount;
                                p02.Text = vCount.ToString();
                                break;
                            case "Recap_Proc_03":
                                vQtdeRecapProc += vCount;
                                p03.Text = vCount.ToString();
                                break;
                            case "Recap_Proc_04":
                                vQtdeRecapProc += vCount;
                                p04.Text = vCount.ToString();
                                break;
                            case "Recap_Proc_05":
                                vQtdeRecapProc += vCount;
                                p05.Text = vCount.ToString();
                                break;
                            case "Subsidio_wait":
                                vQtdeSubWait += vCount;
                                SubWait.Text = vCount.ToString();
                                break;
                            case "Subsidio_Ready":
                                vQtdeSubReady += vCount;
                                SubReady.Text = vCount.ToString();
                                break;
                        }
                        curReg++;
                    }
                }

                ds.Dispose();

            } catch (Exception ex) {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        } // Fim de AumentaQtdePremio;

        public void SomaValorRecapProc(ref int[] vCountCarAtual, ref string[,] aMapaCapi, ref decimal[] CtrlGpDebito, 
                                       ref Label p01, ref Label p02, ref Label p03, ref Label p04, ref Label p05, ref Label p115)
        {
            decimal vTotValor1, vTotValor2, vTotValor3, vTotValor4, vTotValor5, vTotValor115;
            vTotValor1 = vTotValor2 = vTotValor3 = vTotValor4 = vTotValor5 = vTotValor115 = 0.00M;

            #region:: Zera o Array vCountCarAtual que controla a Carência
            for (int i = 0; i < 15; i++)
            {
                vCountCarAtual[i] = 0;
            }
            #endregion


            int vCar = int.MinValue;
            string vStatus = "";
            decimal vValor = 0.00M;

            int curReg = 0;
            int numReg = 0;

            SqlDataAdapter da = new SqlDataAdapter("SomaDebito_Proc", this.cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            da.Fill(ds, "SomaDebito_Proc");
            DataTable dt = new DataTable();
            dt = ds.Tables["SomaDebito_Proc"];
            numReg = dt.Rows.Count;
            

            if (numReg > 0) {
                while (curReg < numReg) {
                    vStatus = dt.Rows[curReg]["status"].ToString();
                    vCar = (int)dt.Rows[curReg]["carencia"];
                    vValor = Convert.ToDecimal(aMapaCapi[vCar, 3]);

                    CtrlGpDebito[(int)dt.Rows[curReg]["gr_01"] - 1] += Convert.ToDecimal(aMapaCapi[vCar, 2]);
                    CtrlGpDebito[(int)dt.Rows[curReg]["gr_02"] - 1] += Convert.ToDecimal(aMapaCapi[vCar, 2]);

                    switch (vStatus.Trim())
                    {
                        case "Processing_115":
                            vTotValor115 += vValor;
                            p115.Text = vTotValor115.ToString("0.00");
                            break;
                        case "Recap_Proc_01":
                            vTotValor1 += vValor;
                            p01.Text = vTotValor1.ToString("0.00");
                            break;
                        case "Recap_Proc_02":
                            vTotValor2 += vValor;
                            p02.Text = vTotValor2.ToString("0.00");
                            break;
                        case "Recap_Proc_03":
                            vTotValor3 += vValor;
                            p03.Text = vTotValor3.ToString("0.00");
                            break;
                        case "Recap_Proc_04":
                            vTotValor4 += vValor;
                            p04.Text = vTotValor4.ToString("0.00");
                            break;
                        case "Recap_Proc_05":
                            vTotValor5 += vValor;
                            p05.Text = vTotValor5.ToString("0.00");
                            break;
                    }

                    if (vCar < 15) {
                        vCountCarAtual[vCar]++;
                    }

                    curReg++;
                }
            }// Fim do if
            ds.Dispose();
        /* ----------- */
        }// Fim do Método

        public void SomaValorRecapWait(ref string[,] aMapaCapi, ref Label w01, ref Label w02, ref Label w03, 
                                       ref Label w04, ref Label w05) {

               decimal vTotValor1, vTotValor2, vTotValor3, vTotValor4, vTotValor5;
               vTotValor1 = vTotValor2 = vTotValor3 = vTotValor4 = vTotValor5 = 0.00M;

               int vCar = int.MinValue;
               string vStatus = "";
               decimal vValor = 0.00M;

               int curReg = 0;
               int numReg = 0;

               SqlDataAdapter da = new SqlDataAdapter("SomaDebito_Wait", this.cn);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               DataSet ds = new DataSet();
               DataTable dt = new DataTable();
               da.Fill(ds, "SomaDebito_Wait");
               dt = ds.Tables["SomaDebito_Wait"];
               numReg = dt.Rows.Count;


               if (numReg > 0)
               {
                   while (curReg < numReg)
                   {
                       vStatus = dt.Rows[curReg]["status"].ToString();
                       vCar = (int)dt.Rows[curReg]["carencia"];
                       vValor = Convert.ToDecimal(aMapaCapi[vCar, 3]);

                       switch (vStatus.Trim())
                       {
                           case "Recap_wait_01":
                               vTotValor1 += vValor;
                               w01.Text = vTotValor1.ToString("0.00");
                               break;
                           case "Recap_wait_02":
                               vTotValor2 += vValor;
                               w02.Text = vTotValor2.ToString("0.00");
                               break;
                           case "Recap_wait_03":
                               vTotValor3 += vValor;
                               w03.Text = vTotValor3.ToString("0.00");
                               break;
                           case "Recap_wait_04":
                               vTotValor4 += vValor;
                               w04.Text = vTotValor4.ToString("0.00");
                               break;
                           case "Recap_wait_05":
                               vTotValor5 += vValor;
                               w05.Text = vTotValor5.ToString("0.00");
                               break;
                       }

                       curReg++;
                   }
               }// Fim do if
               ds.Dispose();
        /* ----------- */
        }// Fim do Método



        public void PreencheLabelsCountCar(ref int[] vCountCarAtual, ref Label lblCar1, ref Label lblCar2, ref Label lblCar3,
                                                                   ref Label lblCar4, ref Label lblCar5, ref Label lblCar6, 
                                                                   ref Label lblCar7, ref Label lblCar8, ref Label lblCar9, 
                                                                   ref Label lblCar10, ref Label lblCar11, ref Label lblCar12, 
                                                                   ref Label lblCar13, ref Label lblCar14, ref Label lblCar15) {

            #region:  Labels que Setam os SubPeríodos das Carências

            lblCar1.Text = vCountCarAtual[0].ToString();
            lblCar2.Text = vCountCarAtual[1].ToString();
            lblCar3.Text = vCountCarAtual[2].ToString();
            lblCar4.Text = vCountCarAtual[3].ToString();
            lblCar5.Text = vCountCarAtual[4].ToString();
            lblCar6.Text = vCountCarAtual[5].ToString();
            lblCar7.Text = vCountCarAtual[6].ToString();
            lblCar8.Text = vCountCarAtual[7].ToString();
            lblCar9.Text = vCountCarAtual[8].ToString();
            lblCar10.Text = vCountCarAtual[9].ToString();
            lblCar11.Text = vCountCarAtual[10].ToString();
            lblCar12.Text = vCountCarAtual[11].ToString();
            lblCar13.Text = vCountCarAtual[12].ToString();
            lblCar14.Text = vCountCarAtual[13].ToString();
            lblCar15.Text = vCountCarAtual[14].ToString();

            #endregion
        }


        /* ---------------------------------------------- */
        #region:: 2 Métodos Sobrecarregados ProcessaCredito.


        /// <summary>
        ///  Método Sobrecarregado ProcessaCredito,
        ///  em caso de prêmio!
        /// </summary>
        /// <param name="gp_premiado"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="qtdePremio"></param>
        /// <param name="lblQtdeSeriesPremiadas"></param>
        /// <param name="vCountCarDoPremio"></param>
        /// <param name="CtrlGpCredito"></param>
        /// <param name="aMapaCapi"></param>
        /// <param name="car"></param>
        /// <param name="vLucroIndividual"></param>
        public void ProcessaCredito(int gp_premiado, int id, string status, ref int qtdePremio, 
                                    ref Label lblQtdeSeriesPremiadas, ref int[] vCountCarDoPremio, ref decimal[] CtrlGpCredito,
                                    ref string[,] aMapaCapi, int car, ref decimal vLucroIndividual)
        {
            if (car <= 15)
            {
                ZeraCarencia(id_serie);
                AumentaQtdePremio(id_serie);
                CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                qtdePremio++;
                lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();


                // Novo - Observar comportamento
                vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                if (car < 15)
                {
                    vCountCarDoPremio[car]++;
                }
                #endregion

            } else {

                switch (status)
                {
                    case "Processing_115":
                        ZeraCarencia(id_serie);
                        ZeraCarenciaRecap(id_serie);
                        AumentaQtdePremio(id_serie);
                        CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                        qtdePremio++;
                        lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();

                        // Novo - Observar comportamento
                        vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                        #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                        if (car < 15)
                        {
                            vCountCarDoPremio[car]++;
                        }
                        #endregion
                        break;
                    case "Recap_wait_01":
                        IniciaNewStatus("Recap_Proc_01", id_serie, this.cn);
                        break;
                    case "Recap_wait_02":
                        IniciaNewStatus("Recap_Proc_02", id_serie, this.cn);
                        break;
                    case "Recap_wait_03":
                        IniciaNewStatus("Recap_Proc_03", id_serie, this.cn);
                        break;
                    case "Recap_wait_04":
                        IniciaNewStatus("Recap_Proc_04", id_serie, this.cn);
                        break;
                    case "Recap_wait_05":
                        IniciaNewStatus("Recap_Proc_05", id_serie, this.cn);
                        break;
                    case "Recap_Proc_01":
                        MudaStatus("Processing_115", id_serie, this.cn);
                        ZeraCarencia(id_serie);
                        ZeraCarenciaRecap(id_serie);
                        AumentaQtdePremio(id_serie);
                        CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                        qtdePremio++;
                        lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();

                        // Novo - Observar comportamento
                        vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                        #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                        if (car < 15)
                        {
                            vCountCarDoPremio[car]++;
                        }
                        #endregion

                        break;
                    case "Recap_Proc_02":
                        MudaStatus("Processing_115", id_serie, this.cn);
                        ZeraCarencia(id_serie);
                        ZeraCarenciaRecap(id_serie);
                        AumentaQtdePremio(id_serie);
                        CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                        qtdePremio++;
                        lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();

                        // Novo - Observar comportamento
                        vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                        #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                        if (car < 15)
                        {
                            vCountCarDoPremio[car]++;
                        }
                        #endregion
                        break;
                    case "Recap_Proc_03":
                        MudaStatus("Processing_115", id_serie, this.cn);
                        ZeraCarencia(id_serie);
                        ZeraCarenciaRecap(id_serie);
                        AumentaQtdePremio(id_serie);
                        CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                        qtdePremio++;
                        lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();

                        // Novo - Observar comportamento
                        vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                        #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                        if (car < 15)
                        {
                            vCountCarDoPremio[car]++;
                        }
                        #endregion
                        break;
                    case "Recap_Proc_04":
                        MudaStatus("Processing_115", id_serie, this.cn);
                        ZeraCarencia(id_serie);
                        ZeraCarenciaRecap(id_serie);
                        AumentaQtdePremio(id_serie);
                        CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                        qtdePremio++;
                        lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();

                        // Novo - Observar comportamento
                        vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                        #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                        if (car < 15)
                        {
                            vCountCarDoPremio[car]++;
                        }
                        #endregion
                        break;
                    case "Recap_Proc_05":
                        MudaStatus("Processing_115", id_serie, this.cn);
                        ZeraCarencia(id_serie);
                        ZeraCarenciaRecap(id_serie);
                        AumentaQtdePremio(id_serie);
                        CtrlGpCredito[gp_premiado - 1] += Convert.ToDecimal(aMapaCapi[car, 5]);
                        qtdePremio++;
                        lblQtdeSeriesPremiadas.Text = qtdePremio.ToString();

                        // Novo - Observar comportamento
                        vLucroIndividual += Convert.ToDecimal(aMapaCapi[car, 6]);


                        #region:: Seta o Array vCountCarAtual de acordo com a carência por Sb
                        if (car < 15)
                        {
                            vCountCarDoPremio[car]++;
                        }
                        #endregion
                        break;
                    //case "Subsidio_wait":
                    //    break;
                    //case "Subsidio_Ready":
                    //    break;
                    //default:
                    //    break;
                }// Fim do Switch / Case
                // ------------------ //
            }// Fim do If            
            // ------- //
        }// Fim do Método

        /// <summary>
        ///  Método Sobrecarregado ProcessaCredito,
        ///  em caso de NEGATIVA de prêmio!
        /// </summary>
        /// <param name="seriePremiada"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="aMapaCapi"></param>
        /// <param name="car"></param>
        public void ProcessaCredito(int id, string status, int car)
        {
            if (car < 15) {

                AumentaCarencia(id_serie);
                ComparaCarencia(id_serie);

            } else if (car == 15) {

                IniciaNewStatus("Recap_wait_01", id_serie, this.cn);
                AumentaCarencia(id_serie);
                ComparaCarencia(id_serie);

            } else if (car > 15) {

                switch (status)
                {
                    case "Processing_115":
                        // OBS.: O Status Processing_115 
                        // para Carecia = 16 não existe,
                        // pois, já no SB anterior este status
                        // foi alterado para Recap_wait_01
                        // AVALIAR COM MAIS DETALHES
                        if (car == 16) { CSharpUtil.Util.Msg("Este Status está errado, \n\rpois deveria ser Recap_wait_01"); }
                        break;
                        // De Recap_wait_01 até Recap_wait_05
                        // o procedimento é o mesmo e comum à
                        // qualquer opção para NÃO credito, e
                        // já está no final do Switch / Case!
                        /* ------------------------------- */
                    //case "Recap_wait_01":
                    //    break;
                    //case "Recap_wait_02":
                    //    break;
                    //case "Recap_wait_03":
                    //    break;
                    //case "Recap_wait_04":
                    //    break;
                    //case "Recap_wait_05":
                    //    break;
                        /* ------------------------------- */
                    case "Recap_Proc_01":
                        if (carencia_recap > 5)
                        {
                            IniciaNewStatus("Recap_wait_02", id_serie, this.cn);
                        } else {
                            AumentaCarenciaRecap(id_serie);
                            AumentaCarencia(id_serie);
                            ComparaCarencia(id_serie);
                        }
                        break;
                    case "Recap_Proc_02":
                        if (carencia_recap > 5)
                        {
                            IniciaNewStatus("Recap_wait_03", id_serie, this.cn);
                        } else {
                            AumentaCarenciaRecap(id_serie);
                            AumentaCarencia(id_serie);
                            ComparaCarencia(id_serie);
                        }
                        break;
                    case "Recap_Proc_03":
                        if (carencia_recap > 5) {
                            IniciaNewStatus("Recap_wait_04", id_serie, this.cn);
                        } else {
                            AumentaCarenciaRecap(id_serie);
                            AumentaCarencia(id_serie);
                            ComparaCarencia(id_serie);
                        }
                        break;
                    case "Recap_Proc_04":
                        if (carencia_recap > 5) {
                            IniciaNewStatus("Recap_wait_05", id_serie, this.cn);
                        } else {
                            AumentaCarenciaRecap(id_serie);
                            AumentaCarencia(id_serie);
                            ComparaCarencia(id_serie);
                        }
                        break;
                    case "Recap_Proc_05":
                        if (carencia_recap > 5) {
                            MudaStatus("Subsidio_wait", id_serie, this.cn);
                        } else {
                            AumentaCarenciaRecap(id_serie);
                            AumentaCarencia(id_serie);
                            ComparaCarencia(id_serie);
                        }
                        break;
                    //case "Subsidio_wait":
                    //    break;
                    //case "Subsidio_Ready":
                    //    break;
                    //default:
                    //    break;
                }// Fim do Switch

            }// Fim do else if (car == 15)

        }// Fim do Método ProcessaCredito (false)

        #endregion:: FIM: 2 Métodos Sobrecarregados ProcessaCredito.
        /* ------------------------------------------------------ */


        public void IniciaNewStatus(string new_status, int id, SqlConnection cn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Inicia_Status_Recap", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@new_status", new_status));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }

        public void MudaStatus(string new_status, int id_ser, SqlConnection conn) {
            try
            {
                SqlCommand cmd = new SqlCommand("Muda_Status", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id_ser));
                cmd.Parameters.Add(new SqlParameter("@new_status", new_status));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }

        public static void ZeraContadores(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Zera_Contadores", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@new_status", "Processing_115"));
            cmd.ExecuteNonQuery();
            CSharpUtil.Util.MsgInfo("Tabela [ Series ] Atualizada com Sucesso!");
        }

        public void CarregaSeries(SqlConnection cn)
        {
            SqlDataAdapter da = new SqlDataAdapter("Carrega_Series", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "Carrega_Series");
            dt = ds.Tables["Carrega_Series"];
            curReg = 0;
            registro_atual = curReg+1;
            totalReg = dt.Rows.Count;
            num_registro = totalReg;

            ds.Dispose();

            if (num_registro > 0) SetRst();

        } // Fim de CarregaSeries;

        public int ContaStatus(string status)
        {
            int vRetVal = 0;
            SqlDataAdapter da = new SqlDataAdapter("Conta_Status", this.cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add(new SqlParameter("@status", status));
            DataSet ds = new DataSet();
            da.Fill(ds, "Conta_Status");
            dt = ds.Tables["Conta_Status"];
            vRetVal = Convert.ToInt32(dt.Rows[0]["total"].ToString());

            ds.Dispose();

            return vRetVal;

        }
        
        public void Proximo()
        {
            curReg++;
            registro_atual = curReg+1;
            if (curReg > totalReg - 1)
            {
                curReg = totalReg - 1;
                finalDeArquivo = true;
                //CSharpUtil.Util.MsgInfo("Final de Arquivo!");
            }
            else
            {
                SetRst();
            }
        } // Fim de ProximoRegistro;

        public void Anterior()
        {
            finalDeArquivo = false;
            curReg--;
            registro_atual = curReg+1;
            if (curReg < 0)
            {
                curReg = 0;
                CSharpUtil.Util.MsgInfo("Início de Arquivo!");
            }
            else
            {
                SetRst();
            }
        } // Fim de Anterior;

        public void Primeiro()
        {
            curReg = 0;
            registro_atual = curReg+1;
            finalDeArquivo = false;
            SetRst();
        } // Fim de Primeiro;

        void SetRst()
        {
            id_serie = Convert.ToInt32(dt.Rows[curReg]["id_serie"].ToString());
            gr_01 = Convert.ToInt32(dt.Rows[curReg]["gr_01"].ToString());
            gr_02 = Convert.ToInt32(dt.Rows[curReg]["gr_02"].ToString());
            carencia = Convert.ToInt32(dt.Rows[curReg]["carencia"].ToString());
            carencia_recap = Convert.ToInt32(dt.Rows[curReg]["carencia_recap"].ToString());
            qtde_premio = Convert.ToInt32(dt.Rows[curReg]["qtde_premio"].ToString());
            mor_carencia = Convert.ToInt32(dt.Rows[curReg]["mor_carencia"].ToString());
            pr_aplicacao = Convert.ToInt32(dt.Rows[curReg]["pr_aplicacao"].ToString());
            status = dt.Rows[curReg]["status"].ToString();
        }


        #region::: Propriedades do Objeto

        public bool FinalDeArquivo {
            get { return finalDeArquivo; }
            set { finalDeArquivo = value; }
        }

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

        public int Id_serie
        {
            get { return id_serie; }
            set { id_serie = value; }
        }

        public int Gr_01
        {
            get { return gr_01; }
            set { gr_01 = value; }
        }
        public int Gr_02 {
            get { return gr_02; }
            set { gr_02 = value; }
        }

        public int Carencia {
            get { return carencia; }
            set { carencia = value; }
        }
        public int Qtde_premio {
            get { return qtde_premio; }
            set { qtde_premio = value; }
        }
        public int Mor_carencia {
            get { return mor_carencia; }
            set { mor_carencia = value; }
        }
        public int Pr_aplicacao {
            get { return pr_aplicacao; }
            set { pr_aplicacao = value; }
        }
        public int Num_aplicacao {
            get { return num_aplicacao; }
            set { num_aplicacao = value; }
        }
        public string Status {
            get { return status; }
            set { status = value; }
        }

        public int Carencia_recap
        {
            get { return carencia_recap; }
            set { carencia_recap = value; }
        }


        #endregion

    }} // Fim do namespace
