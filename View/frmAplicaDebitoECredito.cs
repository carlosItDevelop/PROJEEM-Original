#region:: Diretivas Using's

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using Projeem.Controller;
using View;

#endregion: Diretivas Using's

namespace Projeem.View
{
    public partial class frmAplicaDebitoECredito : Form
    {

        #region:: Variáveis da Classe
        string[,] aMapaCapi = new string[41, 8];


        #region:: Arrays que controlam os debitos e créditos dos Gps até 15º SB

        static decimal[] CtrlGpID = new decimal[25];
        static decimal[] CtrlGpDebito = new decimal[25];
        static decimal[] CtrlGpDebitoDeduzido = new decimal[25];
        static decimal[] CtrlGpCredito = new decimal[25];

        static decimal vLucroIndividual = 0.00M;//  Novo - Estudar comportamento!!! 

        #endregion:: Arrays que controlam os debitos e créditos dos Gps até 15º SB


        static int[] vCountCarAtual = new int[15]; // Valores iniciados no Evento Click StartProcess;
        static int[] vCountCarDoPremio = new int[15]; // Valores iniciados no Load do Form;

        DateTime dt_ini;
        DateTime dt_aux;
        TimeSpan dt_duracao;

        int gr1, gr2, car;
        int qtdePremio = 0;
        int id_ser;
        int totalDeSerie;
        int regAtualSerie;
        string status = string.Empty;
        string vTipoDeProcessamento;

        ControleAplicacao ctrl = null;
        SqlConnection cn;
        Hashtable hashContabilidade = new Hashtable();
        Indices ind = null;

        string fileSoundDemora = "Demora.wav";
        string fileSoundGuardaCarta = "GuardaCarta.wav";
        string fileSoundRenuncia = "Renuncia.wav";
        //string fileSoundInicioJogo = "Inicio.wav"; // Mudar o arquivo!!!
        string appSoundPath = Application.StartupPath + @"\sounds\"; 

        #endregion:: Variáveis da Classe

        #region:: Contrutor do Form
        /// <summary>
        /// Construtor da Classe;
        /// </summary>
        /// <param name="cn"></param>
        public frmAplicaDebitoECredito(SqlConnection cn)
        {

            this.cn = cn;
            ind = new Indices(cn);
            ctrl = new ControleAplicacao(cn);

            hashContabilidade["DebitoContabil"] = 0.00M;
            hashContabilidade["DebitoReal"] = 0.00M;
            hashContabilidade["CreditoContabil"] = 0.00M;
            hashContabilidade["CreditoReal"] = 0.00M;
            hashContabilidade["SaldoSbContabil"] = 0.00M;
            hashContabilidade["SaldoSbReal"] = 0.00M;
            hashContabilidade["SaldoAcumuladoContabil"] = 0.00M;
            hashContabilidade["SaldoAcumuladoReal"] = 0.00M;

            InitializeComponent();

        }// Fim do Construtor da Classe;
        #endregion: Contrutor do Form

        /// <summary>
        /// Load do Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAplicaDebitoECredito_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Funcoes.MontaMapaCapi(txtNumSB, txtValorMedia, cboNumGP, ref aMapaCapi, lvMapaCapi);
            
            UtilAnotacao.PreencheComboComum(this.cn, cboGrupoAtual, "grupos", "grupo");
            barProgresso.Minimum = 0;
            barProgresso.Maximum = 100;
            barProgresso.Value = 0;

            lblUser.Text = CSharpUtil.Util.User;
            lblData.Text = CSharpUtil.Util.Date;
            lblReferencia.Text = CSharpUtil.Util.Referencia;

            btnStartProcess.Enabled = true;

            #region:: Zera Labels de Recap
            lblRecap01_wait.Text = "0";
            lblRecap02_wait.Text = "0";
            lblRecap03_wait.Text = "0";
            lblRecap04_wait.Text = "0";
            lblRecap05_wait.Text = "0";
            lblRecap01_Proc.Text = "0";
            lblRecap02_Proc.Text = "0";
            lblRecap03_Proc.Text = "0";
            lblRecap04_Proc.Text = "0";
            lblRecap05_Proc.Text = "0";

            lblSerieProc_115_Qtde.Text = "0";

            lblSubsidioWaitCount.Text = "0";
            lblSubsidioReadyCount.Text = "0";

            lblRecap01_PValor.Text = "0.00";
            lblRecap02_PValor.Text = "0.00";
            lblRecap03_PValor.Text = "0.00";
            lblRecap04_PValor.Text = "0.00";
            lblRecap05_PValor.Text = "0.00";

            lblSerieProc_115_Valor.Text = "0.00";

            lblRecap01_WValor.Text = "0.00";
            lblRecap02_WValor.Text = "0.00";
            lblRecap03_WValor.Text = "0.00";
            lblRecap04_WValor.Text = "0.00";
            lblRecap05_WValor.Text = "0.00";
            #endregion

            #region:: Exibe e Seta os Hash de Contabilidades;
            ctrl.ExibeDadosContabilidade();
            if (ctrl.Num_registro > 0) {
                ctrl.Ultimo();
                PreencheCampos();

                hashContabilidade["DebitoContabil"] = Convert.ToDecimal(lblDebitoContabil.Text);
                hashContabilidade["DebitoReal"] = Convert.ToDecimal(lblDebitoReal.Text);
                hashContabilidade["CreditoContabil"] = Convert.ToDecimal(lblCreditoContabil.Text);
                hashContabilidade["CreditoReal"] = Convert.ToDecimal(lblCreditoReal.Text);
                hashContabilidade["SaldoSbContabil"] = Convert.ToDecimal(lblSaldoContabilSb.Text);
                hashContabilidade["SaldoSbReal"] = Convert.ToDecimal(lblSaldoRealSb.Text);
                hashContabilidade["SaldoAcumuladoContabil"] = Convert.ToDecimal(lblSaldoContabilAcumulado.Text);
                hashContabilidade["SaldoAcumuladoReal"] = Convert.ToDecimal(lblSaldoRealAcumulado.Text);

            }
            #endregion:: Exibe e Seta os Hash de Contabilidades;

            #region:: REVISAR ESTES DOIS TRECHOS!

            /* ----------- */
            #region:: BACALHAU
            // Estou Burlando a Regra aqui até resolver o impasse,
            // pois apesar do código acima setarei lblStatusDeProcessamento 
            // como 'DEBITO' até encontrar o problema!
            Indices.UpdateStatusProcessamento("DEBITO", this.cn);
            #endregion:: BACALHAU
            /* ----------- */

            
            vTipoDeProcessamento = Indices.GetStatusProcessamento(this.cn);
            if (vTipoDeProcessamento.Equals("DEBITO")){
                lblStatusDeProcessamento.Text = "--> DÉBITO!";
            } else { lblStatusDeProcessamento.Text = "--> CRÉDITO!"; }

            #endregion:: REVISAR ESTES DOIS TRECHOS!

            /* ------------------ */
        }// FIM DO LOAD DO FORM;

        /// <summary>
        /// Botão de Start dos Processos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            if (vTipoDeProcessamento.Equals("DEBITO"))
            {
                try {
                    cboGrupoAtual.Text = "";
                    lblStatusDeProcessamento.Text = "PROCESSANDO DÉBITO!";
                    btnSair.Enabled = false; // Desabilita Botão sair Até Processar Crédito;
                    btnZeraBaseDeDados.Enabled = false; // Desabilita durante processamente das Séries
                    /**/
                    ProcessaDebito();
                    /**/
                    Indices.UpdateStatusProcessamento("CREDITO", this.cn);
                    btnZeraBaseDeDados.Enabled = true; // Habilita após processamente das Séries
                    vTipoDeProcessamento = "CREDITO";
                    lblStatusDeProcessamento.Text = "--> CRÉDITO!";
                } catch (Exception ex) {
                    CSharpUtil.Util.MsgErro(ex.Message);
                }
            } else {
                if (cboGrupoAtual.Text.Trim().Length <= 0) {
                    CSharpUtil.Util.MsgErro("Você precisa informar o grupo anterior");
                } else {
                    try {                        
                        lblStatusDeProcessamento.Text = "PROCESSANDO CRÉDITO!";
                        btnZeraBaseDeDados.Enabled = false; // Desabilita durante processamente das Séries
                        /**/
                        ProcessaCredito();
                        /**/
                        Indices.UpdateStatusProcessamento("DEBITO", this.cn);
                        btnZeraBaseDeDados.Enabled = true; // Habilita após processamente das Séries
                        btnSair.Enabled = true; // Habilita Botão sair, pois com Débito pendete podemos sair
                        vTipoDeProcessamento = "DEBITO";
                        lblStatusDeProcessamento.Text = "--> DÉBITO!";
                        
                    } catch (Exception ex) {
                        CSharpUtil.Util.MsgErro(ex.Message);
                    }
                }// cboNumGP.Text.Trim().Length > 0; 
            }
        
        // ---------------------------- //                                  
        }// Fim do Método btnStartProcess;



        /// <summary>
        ///  ProcessaDebito
        /// </summary>
        private void ProcessaDebito()
        {
            #region:: Área de Inicialização do Método

            #region:: Zera os Arrays para GridView
            for (int i = 0; i < 25; i++)
            {
                CtrlGpID[i] = i + 1;
                CtrlGpDebito[i] = 0;
                CtrlGpDebitoDeduzido[i] = 0;
            }
            #endregion


            Serie serie = new Serie(this.cn);
            serie.CarregaSeries(this.cn);
            serie.Primeiro();
            totalDeSerie = serie.Num_registro;

            serie.ContaStatusEAgrupa(ref lblRecap01_wait, ref lblRecap02_wait, ref lblRecap03_wait,
                                     ref lblRecap04_wait, ref lblRecap05_wait, ref lblRecap01_Proc,
                                     ref lblRecap02_Proc, ref lblRecap03_Proc,
                                     ref lblRecap04_Proc, ref lblRecap05_Proc,
                                     ref lblSerieProc_115_Qtde, ref lblSubsidioWaitCount, ref lblSubsidioReadyCount);

            serie.SomaValorRecapProc(ref vCountCarAtual, ref aMapaCapi, ref CtrlGpDebito, ref lblRecap01_PValor, 
                                     ref lblRecap02_PValor, ref lblRecap03_PValor, ref lblRecap04_PValor,
                                     ref lblRecap05_PValor, ref lblSerieProc_115_Valor);

            serie.SomaValorRecapWait(ref aMapaCapi, ref lblRecap01_WValor, ref lblRecap02_WValor, 
                                     ref lblRecap03_WValor, ref lblRecap04_WValor, ref lblRecap05_WValor);
                
                // FALTAM ESTES!!!!!!
                //lblSubsidioWaitValor.Text = Convert.ToDecimal(hashRecapStatus["Subsidio_WValor"]).ToString("0.000");
                //lblSubsidioReadyValor.Text = Convert.ToDecimal(hashRecapStatus["Subsidio_RValor"]).ToString("0.000");


            btnStartProcess.Enabled = false;
            barProgresso.Value = 0;
            lblQtdeSeriesPremiadas.Text = "0";


            dt_ini = DateTime.Now;
            lblInicio.Text = dt_ini.ToString();

            hashContabilidade["CreditoContabil"] = 0.00M;
            hashContabilidade["CreditoReal"] = 0.00M;
            lblCreditoContabil.Text = 0.00M.ToString("0.000");
            lblCreditoReal.Text = 0.00M.ToString("0.000");
            
            #endregion: Área de inicialização do Método

            #region:: While que processa o débito
            while (!serie.FinalDeArquivo)
            {

                #region:: Seta tempo, id_serie, Barra de Progresso, status e car
                dt_aux = DateTime.Now;
                dt_duracao = dt_aux.Subtract(dt_ini);
                lblTempoDecorrido.Text = dt_duracao.ToString();

                regAtualSerie = serie.Registro_atual;
                barProgresso.Value = regAtualSerie * 100 / totalDeSerie;

                id_ser = serie.Id_serie;
                lblIdSerie.Text = id_ser.ToString();

                status = serie.Status;
                car = serie.Carencia;
                #endregion

                #region:: Seta as Variáveis que representam os Grupos em cada Série
                gr1 = serie.Gr_01;
                gr2 = serie.Gr_02;
                #endregion

                if ((regAtualSerie % 200) == 0) {
                    serie.PreencheLabelsCountCar(ref vCountCarAtual, ref lblCar1, ref lblCar2, ref lblCar3, ref lblCar4, ref lblCar5,
                                                 ref lblCar6, ref lblCar7, ref lblCar8, ref lblCar9, ref lblCar10, ref lblCar11,
                                                 ref lblCar12, ref lblCar13, ref lblCar14, ref lblCar15);
                    Application.DoEvents();
                }

                serie.Proximo(); 

            }// Fim do while (!serie.FinalDeArquivo)
            #endregion: While que processa o débito

            #region:: Controle do Acumulo do Débito Contábil Total do SB;
            decimal vCount = 0.00M;
            for (int i = 0; i < 25; i++) {
                vCount += CtrlGpDebito[i];
            }
            hashContabilidade["DebitoContabil"] = vCount;
            lblDebitoContabil.Text = Convert.ToDecimal(hashContabilidade["DebitoContabil"]).ToString("0.000");
            #endregion

            #region:: Bloco (006)


                // Deduz débito através do Mvtc e retorna Mvtc
                decimal lmvtc = Funcoes.OtimizaDebito(ref CtrlGpDebitoDeduzido, CtrlGpDebito, this.cn);
                lblMvtc.Text = lmvtc.ToString("0.000");

                vCount = 0.00M;
                lvControlGP.Items.Clear();
                for (int j = 0; j < 25; j++)
                {
                    lvControlGP.Items.Add(new ListViewItem(new string[] { 
                                              CtrlGpID[j].ToString(),
                                              CtrlGpDebito[j].ToString("0.000"),
                                              CtrlGpDebitoDeduzido[j].ToString("0.000")}));
                                              vCount += CtrlGpDebitoDeduzido[j];
                }

                hashContabilidade["DebitoReal"] = vCount;
                lblDebitoReal.Text = ((decimal)hashContabilidade["DebitoReal"]).ToString("0.000");



            #endregion:: FIM Bloco (006)

            serie = null;

            #region:: uso das HashTable's para Controlar Contabilidade
            hashContabilidade["SaldoSbContabil"] = Convert.ToDecimal(hashContabilidade["CreditoContabil"]) 
                                                 - Convert.ToDecimal(hashContabilidade["DebitoContabil"]);
            hashContabilidade["SaldoSbReal"] = Convert.ToDecimal(hashContabilidade["CreditoReal"]) 
                                             - Convert.ToDecimal(hashContabilidade["DebitoReal"]);
            
            lblSaldoContabilSb.Text = Convert.ToDecimal(hashContabilidade["SaldoSbContabil"]).ToString("0.000");
            lblSaldoRealSb.Text = Convert.ToDecimal(hashContabilidade["SaldoSbReal"]).ToString("0.000");

            hashContabilidade["SaldoAcumuladoContabil"] = Convert.ToDecimal(hashContabilidade["SaldoAcumuladoContabil"]) 
                                                        - Convert.ToDecimal(hashContabilidade["DebitoContabil"]);
            hashContabilidade["SaldoAcumuladoReal"] = Convert.ToDecimal(hashContabilidade["SaldoAcumuladoReal"]) 
                                                    - Convert.ToDecimal(hashContabilidade["DebitoReal"]);

            lblSaldoContabilAcumulado.Text =  Convert.ToDecimal(hashContabilidade["SaldoAcumuladoContabil"]).ToString("0.000");
            lblSaldoRealAcumulado.Text = Convert.ToDecimal(hashContabilidade["SaldoAcumuladoReal"]).ToString("0.000");
            #endregion: uso das HashTable's para Controlar Contabilidade

            #region:: Pseudo-Capital Subsidiário
            // Pseudo-Capital Subsidiário, após todos os cálculos, 
            // pois está após Débito; SB INCOMPLETO. Nem é gravado na Base de Dados!
            /* -------------------------------------------------------------------------------------------------------------------- */
            lblCapitalSubsidiarioNoDebito.Text = ((Convert.ToDecimal(hashContabilidade["SaldoAcumuladoReal"]) 
                                                 - Convert.ToDecimal(hashContabilidade["SaldoAcumuladoContabil"]))).ToString("0.000");
            /* -------------------------------------------------------------------------------------------------------------------- */
            #endregion: Pseudo-Capital Subsidiário

            btnStartProcess.Enabled = true;
            Funcoes.TocaWav(appSoundPath + fileSoundRenuncia);

        }// FIM DO MÉTODO ProcessandoDebito;



        /// <summary>
        /// ProcessaCredito
        /// </summary>
        private void ProcessaCredito() 
        {
            #region:: Área de Inicialização do Método
            int gp_premiado = Convert.ToInt32(cboGrupoAtual.Text);
            
            btnStartProcess.Enabled = false;

            Serie serie = new Serie(this.cn);
            serie.CarregaSeries(this.cn);
            serie.Primeiro();
            totalDeSerie = serie.Num_registro;
            
            dt_ini = DateTime.Now;
            lblInicio.Text = dt_ini.ToString();

            #endregion: Área de Inicialização do Método

            #region:: Zera o Array (Credito e CarPremio) -> GridView
            for (int i = 0; i < 25; i++)
            {
                CtrlGpCredito[i] = 0;
            }
            qtdePremio = 0;

            for (int i = 0; i < 15; i++)
            {
                vCountCarDoPremio[i] = 0;
            }

            #endregion: Zera o Array (Credito e CarPremio) -> GridView

            #region:: While que Seta tempo, id_serie, Barra de Progresso, status e car
           
            while (!serie.FinalDeArquivo)
            {

                dt_aux = DateTime.Now;
                dt_duracao = dt_aux.Subtract(dt_ini); // TimeSpan Variável
                lblTempoDecorrido.Text = dt_duracao.ToString();

                regAtualSerie = serie.Registro_atual;
                barProgresso.Value = regAtualSerie * 100 / totalDeSerie;

                id_ser = serie.Id_serie;
                lblIdSerie.Text = id_ser.ToString();

                // Seta Status da Serie Atual
                status = serie.Status;
                car = serie.Carencia;


                if ((regAtualSerie % 50) == 0)
                {
                    // Labels que Setam 
                    // os SubPeríodos dos Prêmios
                    DisplayLblsPremios();
                    Application.DoEvents();
                }

                #region:: If que controla o fluxo em caso de Prêmio
               
                if ( (gp_premiado == serie.Gr_01) || (gp_premiado == serie.Gr_02) )
                {
                    // Método que cuidará de tudo sobre o registro quando a serie for premiada; Crédito, Recap, Status, Subsídio, Etc.
                    serie.ProcessaCredito(gp_premiado, id_ser, status, ref qtdePremio, ref lblQtdeSeriesPremiadas,
                                          ref vCountCarDoPremio, ref CtrlGpCredito, ref aMapaCapi, car, ref vLucroIndividual);
                }
                else
                {
                    // Método que cuidará de tudo sobre o registro quando a serie 
                    // for premiada; Crédito, Recap, Status, Subsídio, Etc.
                    serie.ProcessaCredito(id_ser, status, car);
                }

                #endregion: If que controla o fluxo em caso de Prêmio

                serie.Proximo();

            // ----------------------------------- //
            }// Fim do while (!serie.FinalDeArquivo);

            #endregion: While que Seta tempo, id_serie, Barra de Progresso, status e car

            #region:: Exibe label após while
            // Chama Novamente o método, 
            // após o while para certificar-se 
            // de que serão exibidos todos os labels 
            // a despeito de "if ((regAtualSerie % 50) == 0)"
            DisplayLblsPremios();
            #endregion: Exibe label após while

            #region:: Controle do Acumulo do Crédito Contábil Total do SB;
            decimal vCount = 0;
            for (int i = 0; i < 25; i++)
            {
                vCount += CtrlGpCredito[i];
            }
            hashContabilidade["CreditoContabil"] = vCount;            
            lblCreditoContabil.Text = Convert.ToDecimal(hashContabilidade["CreditoContabil"]).ToString("0.000");
            #endregion

            #region:: Recupera da Tabela Grupos se o Premio foi Deduzido ou não e vCreditoReal!
            Grupos grp = new Grupos(this.cn);
            decimal vCreditoReal = decimal.MinValue;
            string DebitoDeduzido = grp.IsDebidoDeduzido(cboGrupoAtual.Text.Trim(), ref vCreditoReal);
            if (DebitoDeduzido.Equals("S")) {
                lblPremioReal.Text = "Não";
            } else {
                lblPremioReal.Text = "Sim";
            }
            hashContabilidade["CreditoReal"] = vCreditoReal;
            lblCreditoReal.Text = vCreditoReal.ToString("0.000");
            grp = null;
            #endregion

            #region:: uso das HashTable's para Controlar Contabilidade
            hashContabilidade["SaldoSbContabil"] = Convert.ToDecimal(hashContabilidade["CreditoContabil"]) 
                                                 - Convert.ToDecimal(hashContabilidade["DebitoContabil"]);
            hashContabilidade["SaldoSbReal"] =  Convert.ToDecimal(hashContabilidade["CreditoReal"]) 
                                                 - Convert.ToDecimal(hashContabilidade["DebitoReal"]);
            
            lblSaldoContabilSb.Text = ((decimal)hashContabilidade["SaldoSbContabil"]).ToString("0.000");
            lblSaldoRealSb.Text = ((decimal)hashContabilidade["SaldoSbReal"]).ToString("0.000");

            hashContabilidade["SaldoAcumuladoContabil"] = Convert.ToDecimal(hashContabilidade["SaldoAcumuladoContabil"]) 
                                                        + Convert.ToDecimal(hashContabilidade["CreditoContabil"]);
            hashContabilidade["SaldoAcumuladoReal"] = Convert.ToDecimal(hashContabilidade["SaldoAcumuladoReal"]) 
                                                        + Convert.ToDecimal(hashContabilidade["CreditoReal"]);

            lblSaldoContabilAcumulado.Text = ((decimal)hashContabilidade["SaldoAcumuladoContabil"]).ToString("0.000");
            lblSaldoRealAcumulado.Text = ((decimal)hashContabilidade["SaldoAcumuladoReal"]).ToString("0.000");
            #endregion

            #region:: Capital Subsidiário e Pseudo[...] DE CICLO COMPLETO; Após Crédito!
            // Transformar em Função (na Classe Funcao) via Método Static.
            /* -------------------------------------------------------- */
            // Capital Subsidiário, após todos os cálculos. Válido, pois está após crédito, que marca um SB completo!
            /* ------------------------------------------------------------------------------------------------------------ */
            lblCapitalSubsidiario.Text = (Convert.ToDecimal(hashContabilidade["SaldoAcumuladoReal"])
                                         - Convert.ToDecimal(hashContabilidade["SaldoAcumuladoContabil"])).ToString("0.000");
            /* ------------------------------------------------------------------------------------------------------------ */
            // Pseudo-Capital Subsidiário, após todos os cálculos, 
            // Aqui em crédito com uma aboradagem diferente,  pois 
            // ao invés de usar duas funções de Indices e grvar tb 
            // em Indices, gravar apenas em Controle de Aplicação!
            /* ---------------------------------------------------------- */
            lblCapitalSubsidiarioNoDebito.Text = lblCapitalSubsidiario.Text;
            /* ---------------------------------------------------------- */
            #endregion

            #region:: Conjugado entre GravaDados, Carrega e PreencheCampo

            // Inserir nestes contextos abaixo;
            lblLucroIndividualContabil.Text = vLucroIndividual.ToString("0.00");

            /**/
            GravaDados();
            /**/

            ctrl.ExibeDadosContabilidade();
            ctrl.Ultimo();
            PreencheCampos();
            #endregion


            serie = null;

            btnStartProcess.Enabled = true;
            Funcoes.TocaWav(appSoundPath + fileSoundDemora);

        // ---------------------------- //
        }// Fim do Método ProcessaCredito;

        /// <summary>
        /// Apenas mostra em tempo quase real as 
        /// atualizações das labels dos prêmios!
        /// </summary>
        void DisplayLblsPremios() {
            lblPremio1periodo.Text = vCountCarDoPremio[0].ToString();
            lblPremio2periodo.Text = vCountCarDoPremio[1].ToString();
            lblPremio3periodo.Text = vCountCarDoPremio[2].ToString();
            lblPremio4periodo.Text = vCountCarDoPremio[3].ToString();
            lblPremio5periodo.Text = vCountCarDoPremio[4].ToString();
            lblPremio6periodo.Text = vCountCarDoPremio[5].ToString();
            lblPremio7periodo.Text = vCountCarDoPremio[6].ToString();
            lblPremio8periodo.Text = vCountCarDoPremio[7].ToString();
            lblPremio9periodo.Text = vCountCarDoPremio[8].ToString();
            lblPremio10periodo.Text = vCountCarDoPremio[9].ToString();
            lblPremio11periodo.Text = vCountCarDoPremio[10].ToString();
            lblPremio12periodo.Text = vCountCarDoPremio[11].ToString();

            lblPremio13periodo.Text = vCountCarDoPremio[12].ToString();
            lblPremio14periodo.Text = vCountCarDoPremio[13].ToString();
            lblPremio15periodo.Text = vCountCarDoPremio[14].ToString();
        }


        #region :: Método VerificaCampos
        bool VerificaCampos()
        {
            string msgInconsistencia = "RELATÓRIO DE INCONSISTÊNCIA:\r\n=======================\r\n\n";
            int k = 0;
            if (cboGrupoAtual.Text.Trim().Equals(""))
            {
                k++;
                msgInconsistencia += (k < 10 ? "0" + k.ToString() + " - Campo Prêmio é Obrigatório!\r\n" : k.ToString() +
                    " - Campo Prêmio é Obrigatório!\r\n");
            }
            if (lblCreditoReal.Text.Trim().Length == 0)
            {
                k++;
                msgInconsistencia += (k < 10 ? "0" + k.ToString() + " - Campo Crédito Real é Obrigatório!\r\n" : k.ToString() +
                    " - Campo Crédito Real é Obrigatório!\r\n");
            }

            if (lblCapitalSubsidiario.Text.Trim().Length == 0)
            {
                k++;
                msgInconsistencia += (k < 10 ? "0" + k.ToString() + " - Campo Capital Subsidiario é Obrigatório!\r\n" : k.ToString() +
                    " - Campo Capital Subsidiario é Obrigatório!\r\n");
            }
            if (lblMvtc.Text.Trim().Length == 0)
            {
                k++;
                msgInconsistencia += (k < 10 ? "0" + k.ToString() + " - Campo LVTC é Obrigatório!\r\n" : k.ToString() +
                    " - Campo LVTC é Obrigatório!\r\n");
            }
            if (lblPremioReal.Text.Trim().Length == 0)
            {
                k++;
                msgInconsistencia += (k < 10 ? "0" + k.ToString() + " - Campo Prêmio Real é Obrigatório!\r\n" : k.ToString() +
                    " - Campo Prêmio Real é Obrigatório!\r\n");
            }

            if (k > 0)
            {
                CSharpUtil.Util.MsgErro(msgInconsistencia);
                return false;
            }
            return true;
        }// Fim do Método VerificaCampos;
        #endregion

        void PreencheCampos()
        {
            lblResult_gp.Text = ctrl.Grupo.ToString();
            lblDebitoContabil.Text = ctrl.Debito_contabil.ToString("0.000");
            lblDebitoReal.Text = ctrl.Debito_real.ToString("0.000");
            lblCreditoContabil.Text = ctrl.Credito_contabil.ToString("0.000");
            lblCreditoReal.Text = ctrl.Credito_real.ToString("0.000");
            lblSaldoContabilSb.Text = ctrl.Saldo_sb_contabil.ToString("0.000");
            lblSaldoRealSb.Text = ctrl.Saldo_sb_real.ToString("0.000");
            lblCapitalSubsidiario.Text = ctrl.Capital_subsidiario.ToString("0.000");
            lblMvtc.Text = ctrl.Mvtc.ToString("0.000");
            lblPremioReal.Text = ctrl.Premio_real;
            lblSaldoContabilAcumulado.Text = ctrl.Saldo_contabil_acumulado.ToString("0.000");
            lblSaldoRealAcumulado.Text = ctrl.Saldo_real_acumulado.ToString("0.000");
            lblCtrlNavegacao.Text = "Reg.: " + ctrl.Registro_atual.ToString() + " de: " + ctrl.Num_registro.ToString();

            vCountCarDoPremio[0] = ctrl.Vpre1;
            vCountCarDoPremio[1] = ctrl.Vpre2;
            vCountCarDoPremio[2] = ctrl.Vpre3;
            vCountCarDoPremio[3] = ctrl.Vpre4;
            vCountCarDoPremio[4] = ctrl.Vpre5;
            vCountCarDoPremio[5] = ctrl.Vpre6;
            vCountCarDoPremio[6] = ctrl.Vpre7;
            vCountCarDoPremio[7] = ctrl.Vpre8;
            vCountCarDoPremio[8] = ctrl.Vpre9;
            vCountCarDoPremio[9] = ctrl.Vpre10;
            vCountCarDoPremio[10] = ctrl.Vpre11;
            vCountCarDoPremio[11] = ctrl.Vpre12;            
            vCountCarDoPremio[12] = ctrl.Vpre13;
            vCountCarDoPremio[13] = ctrl.Vpre14;
            vCountCarDoPremio[14] = ctrl.Vpre15;

            lblPremio1periodo.Text = vCountCarDoPremio[0].ToString();
            lblPremio2periodo.Text = vCountCarDoPremio[1].ToString();
            lblPremio3periodo.Text = vCountCarDoPremio[2].ToString();
            lblPremio4periodo.Text = vCountCarDoPremio[3].ToString();
            lblPremio5periodo.Text = vCountCarDoPremio[4].ToString();
            lblPremio6periodo.Text = vCountCarDoPremio[5].ToString();
            lblPremio7periodo.Text = vCountCarDoPremio[6].ToString();
            lblPremio8periodo.Text = vCountCarDoPremio[7].ToString();
            lblPremio9periodo.Text = vCountCarDoPremio[8].ToString();
            lblPremio10periodo.Text = vCountCarDoPremio[9].ToString();
            lblPremio11periodo.Text = vCountCarDoPremio[10].ToString();
            lblPremio12periodo.Text = vCountCarDoPremio[11].ToString();
            lblPremio13periodo.Text = vCountCarDoPremio[12].ToString();
            lblPremio14periodo.Text = vCountCarDoPremio[13].ToString();
            lblPremio15periodo.Text = vCountCarDoPremio[14].ToString();            

            lblCar1.Text = ctrl.Vcar1.ToString();
            lblCar2.Text = ctrl.Vcar2.ToString();
            lblCar3.Text = ctrl.Vcar3.ToString();
            lblCar4.Text = ctrl.Vcar4.ToString();
            lblCar5.Text = ctrl.Vcar5.ToString();
            lblCar6.Text = ctrl.Vcar6.ToString();
            lblCar7.Text = ctrl.Vcar7.ToString();
            lblCar8.Text = ctrl.Vcar8.ToString();
            lblCar9.Text = ctrl.Vcar9.ToString();
            lblCar10.Text = ctrl.Vcar10.ToString();
            lblCar11.Text = ctrl.Vcar11.ToString();
            lblCar12.Text = ctrl.Vcar12.ToString();
            lblCar13.Text = ctrl.Vcar13.ToString();
            lblCar14.Text = ctrl.Vcar14.ToString();
            lblCar15.Text = ctrl.Vcar15.ToString();

        }// FIM DO MÉTODO PREENCHECAMPOS;

        #region:: Método GravaDados
        /// <summary>
        /// GravaDados
        /// </summary>
        void GravaDados()
        {
            // transação que é levada para 
            // dentro dos métodos de adição 
            // abaixo, juntamente com o objeto Connection;
            SqlTransaction trans = null;
            try
            {
                if (VerificaCampos()) // Mudar para (CamposConfere -> Conferri campo por campo);
                {
                    ControleAplicacao ctrl_app = new ControleAplicacao(this.cn);
                    int id = int.Parse(CSharpUtil.Util.GerarID(this.cn, "id_contabilidade"));
                    int gp = int.Parse(cboGrupoAtual.Text);
                    int sb = Indices.GetSubperiodo(this.cn);

                    trans = this.cn.BeginTransaction("GravaDados");

                    ctrl_app.Add_Contabilidade(this.cn, trans, id, gp, sb,                                 
                                Convert.ToDecimal(hashContabilidade["DebitoContabil"]).ToString(),
                                Convert.ToDecimal(hashContabilidade["DebitoReal"]).ToString(),
                                Convert.ToDecimal(hashContabilidade["CreditoContabil"]).ToString(),
                                Convert.ToDecimal(hashContabilidade["CreditoReal"]).ToString(),
                                Convert.ToDecimal(hashContabilidade["SaldoSbContabil"]).ToString(),                                                                         Convert.ToDecimal(hashContabilidade["SaldoSbReal"]).ToString(),                                                                             lblCapitalSubsidiario.Text,
                                lblMvtc.Text,
                                lblPremioReal.Text,
                                Convert.ToDecimal(hashContabilidade["SaldoAcumuladoContabil"]).ToString(),                                
                                Convert.ToDecimal(hashContabilidade["SaldoAcumuladoReal"]).ToString());



                    ctrl_app.AddEstatistica_Carencia(this.cn, trans, id, 
                                int.Parse(lblCar1.Text),
                                int.Parse(lblCar2.Text),
                                int.Parse(lblCar3.Text),
                                int.Parse(lblCar4.Text),
                                int.Parse(lblCar5.Text),
                                int.Parse(lblCar6.Text),
                                int.Parse(lblCar7.Text),
                                int.Parse(lblCar8.Text),
                                int.Parse(lblCar9.Text),
                                int.Parse(lblCar10.Text),
                                int.Parse(lblCar11.Text),
                                int.Parse(lblCar12.Text),
                                int.Parse(lblCar13.Text),
                                int.Parse(lblCar14.Text),
                                int.Parse(lblCar15.Text));

                    ctrl_app.AddEstatistica_Premio(this.cn, trans, id, 
                                int.Parse(lblPremio1periodo.Text),
                                int.Parse(lblPremio2periodo.Text),
                                int.Parse(lblPremio3periodo.Text),
                                int.Parse(lblPremio4periodo.Text),
                                int.Parse(lblPremio5periodo.Text),
                                int.Parse(lblPremio6periodo.Text),
                                int.Parse(lblPremio7periodo.Text),
                                int.Parse(lblPremio8periodo.Text),
                                int.Parse(lblPremio9periodo.Text),
                                int.Parse(lblPremio10periodo.Text),
                                int.Parse(lblPremio11periodo.Text),
                                int.Parse(lblPremio12periodo.Text),
                                int.Parse(lblPremio13periodo.Text),
                                int.Parse(lblPremio14periodo.Text),
                                int.Parse(lblPremio15periodo.Text));


                    Indices.AddSubperiodo(this.cn, trans);

                   trans.Commit();

                }
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.MsgErro(ex.Message);
                trans.Rollback("GravaDados");
            }

            Funcoes.TocaWav(appSoundPath + fileSoundGuardaCarta);

        /* ----------------------- */
        }// Fim do Método GravaDados;

        #endregion: Método GravaDados


        #region:: Métodos de Navegação - Contabilidade
        private void btnProximo_Click(object sender, EventArgs e)
        {
            ctrl.Proximo();
            PreencheCampos();
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            ctrl.Anterior();
            PreencheCampos();
        }
        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            ctrl.Primeiro();
            PreencheCampos();
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            ctrl.Ultimo();
            PreencheCampos();
        }
        #endregion: Métodos de Navegação - Contabilidade

        private void btnZeraBaseDeDados_Click(object sender, EventArgs e)
        {
            Serie.ZeraContadores(this.cn);                          // OK - STOREPROCEDURE
            Indices.ZeraContadores(this.cn);
            Indices.UpdateStatusProcessamento("DEBITO", this.cn);
            ControleAplicacao.DeleteAll_WithSProc(this.cn);         // OK - STOREPROCEDURE
            Grupos.ZeraDebitosEDeducoes(this.cn);                   // OK - STOREPROCEDURE
            lblSaldoContabilAcumulado.Text = "0.000";
            lblSaldoRealAcumulado.Text = "0.000";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnMontaCapi_Click(object sender, EventArgs e)
        {
            Funcoes.MontaMapaCapi(txtNumSB, txtValorMedia, cboNumGP, ref aMapaCapi, lvMapaCapi);
        }

        private void btnMontaTabela_Click(object sender, EventArgs e)
        {
            int vCount = 0;       
                for (int j = 1; j <= 24; j++)
                {
                    for (int m = 2; m <= 25; m++)
                    {
                        if (m > j) {
                            vCount++;
                            InsereRegistro(j, m, vCount);
                        }
                    }
            }
            CSharpUtil.Util.Msg("Registros Inseridos Com Sucesso!!!");
        /* --------------------------- */
        } // Fim de btnMontaTabela_Click;

        void InsereRegistro(int gr1, int gr2, int id){

            SqlCommand cmd = new SqlCommand("Inserir_Registro_Series", this.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add( new SqlParameter("@id", id));
            cmd.Parameters.Add( new SqlParameter("@gr_01", gr1));
            cmd.Parameters.Add( new SqlParameter("@gr_02", gr2));
            cmd.Parameters.Add( new SqlParameter("@carencia", "0"));
            cmd.Parameters.Add( new SqlParameter("@qtde_premio", "1"));
            cmd.Parameters.Add( new SqlParameter("@mor_carencia", "0"));
            cmd.Parameters.Add( new SqlParameter("@pr_aplicacao", "1"));
            cmd.Parameters.Add( new SqlParameter("@status", "Processing_115"));
            cmd.Parameters.Add( new SqlParameter("@carencia_recap", "0"));
            cmd.Parameters.Add( new SqlParameter("@aux_carencia", "0"));
            cmd.Parameters.Add( new SqlParameter("@max_carencia", "0"));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CSharpUtil.Util.Msg(ex.Message);
            }
        /* ---------------------------- */
        }


        private void tabMapacapi_Click(object sender, EventArgs e)
        {

        }

        private void btnPremiosCarencias_Click(object sender, EventArgs e)
        {
            //frmDiplayPremiosCarencias f = new frmDiplayPremiosCarencias(ref aCtrlPremios, ref aCtrlCarencias, ref aCtrlProcMor15, ref aCtrlWaitMpr15);
            frmDiplayPremiosCarencias f = new frmDiplayPremiosCarencias();
            f.ShowDialog();
        } 


    // -------------------------- //
    }// FIM DA CLASSE GERAL DO FORM;
}// FIM DO NAMESPACE;
