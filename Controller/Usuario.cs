using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Projeem.Controller
{
    #region Classe Usuario:
    public class Usuario
    {
        // Variáveis para 
        // as propriedades.
        private String codigo = "";
        private String nome;
        private String login;
        private String senha;
        private String nivelacesso;
        private DateTime dt_inclusao;
        private DateTime dt_ultimo_acesso;
        // Variáveis de classes:
        private SqlConnection cn;
        private String userlogin;
        // -----------------------------------------------
        private bool onoff = false;
        //---------------------------------
        //Construtor comum, padrão.
        public Usuario() { 
        }
        // Construtor com parâmetro [Sobrecarga]
        public Usuario(SqlConnection cn, String userlogin, String pwd)
        {
            this.cn = cn;
            Senha = pwd;
            this.userlogin = userlogin;
            Conectar();
        }

        /* Método que retornará o estado do User         
         * Logado or Desconectado.
         */
        public bool IsLogado()
        {
            return this.onoff;
        }
        /* Gravará os logs em arquivo texto: logon em, acesso ok,   
         * acesso negado, logoff em, etc.
         */
        private void GravaLog(String logtxt)
        {
        }
        private void Conectar()
        {
            try
            {             
                Senha senha = new Senha();       
                senha.Encripty(this.senha);       
                this.senha = senha.PwdCripty;    

                String strconn = "select * from usuarios where login = '" + 
                                               this.userlogin + "' and senha = '" + this.senha + "'";

                SqlDataAdapter da = new SqlDataAdapter(strconn, cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "usuarios");
                DataTable dt = new DataTable();
                dt = ds.Tables["usuarios"];

                this.onoff = true;

                Login = dt.Rows[0]["login"].ToString();
                Nome = dt.Rows[0]["nome"].ToString();
                Codigo = dt.Rows[0]["codigo"].ToString();
                Nivelacesso = dt.Rows[0]["acesso"].ToString();

                CSharpUtil.Util.User = this.userlogin;

            }
            catch (Exception ex) {
                this.onoff = false;
                CSharpUtil.Util.MsgErro(ex.Message);
            }
        }
        public void Desconectar()
        {
        }

        public void SetLog()
        {
            throw new System.NotImplementedException();
        }               

        #region Properties da Classe Usuario:
        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public String Login
        {
            get { return login; }
            set { login = value; }
        }
        public String Senha
        {
            set { senha = value; }
        }
        public String Nivelacesso
        {
            get { return nivelacesso; }
            set { nivelacesso = value; }
        }
        public DateTime Dt_inclusao
        {
            get { return dt_inclusao; }
            set { dt_inclusao = value; }
        }
        public DateTime Dt_ultimo_acesso
        {
            get { return dt_ultimo_acesso; }
            set { dt_ultimo_acesso = value; }
        }
        #endregion

    }
    #endregion

}