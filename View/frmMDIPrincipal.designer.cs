namespace Projeem.View
{
    partial class frmMDIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDIForm));
            this.mNuPrincipal = new System.Windows.Forms.MenuStrip();
            this.arquivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuAplicacao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sStrip = new System.Windows.Forms.StatusStrip();
            this.sbLblTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLblVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooBtn = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tooBtnImagemDeFundo = new System.Windows.Forms.ToolStripDropDownButton();
            this.fundoFixoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagemDeFundoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.congelarImagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semBackGroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNameImg = new System.Windows.Forms.ToolStripLabel();
            this.btnAplicaDebitoECredito = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSair = new System.Windows.Forms.ToolStripButton();
            this.tmTrocaImg = new System.Windows.Forms.Timer(this.components);
            this.mNuPrincipal.SuspendLayout();
            this.sStrip.SuspendLayout();
            this.tooBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // mNuPrincipal
            // 
            this.mNuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivosToolStripMenuItem,
            this.toolStripMenuItem2});
            this.mNuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mNuPrincipal.Name = "mNuPrincipal";
            this.mNuPrincipal.Size = new System.Drawing.Size(643, 24);
            this.mNuPrincipal.TabIndex = 1;
            this.mNuPrincipal.Text = "menuStrip1";
            // 
            // arquivosToolStripMenuItem
            // 
            this.arquivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuAplicacao,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.arquivosToolStripMenuItem.Name = "arquivosToolStripMenuItem";
            this.arquivosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.arquivosToolStripMenuItem.Text = "Arquivos";
            // 
            // toolMenuAplicacao
            // 
            this.toolMenuAplicacao.Name = "toolMenuAplicacao";
            this.toolMenuAplicacao.Size = new System.Drawing.Size(126, 22);
            this.toolMenuAplicacao.Text = "Aplicação";
            this.toolMenuAplicacao.Click += new System.EventHandler(this.toolMenuAplicacao_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem2.Text = "?";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // sStrip
            // 
            this.sStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLblTitle,
            this.sbLblVersao});
            this.sStrip.Location = new System.Drawing.Point(0, 318);
            this.sStrip.Name = "sStrip";
            this.sStrip.Size = new System.Drawing.Size(643, 22);
            this.sStrip.TabIndex = 4;
            this.sStrip.Text = "Versão";
            // 
            // sbLblTitle
            // 
            this.sbLblTitle.Name = "sbLblTitle";
            this.sbLblTitle.Size = new System.Drawing.Size(58, 17);
            this.sbLblTitle.Text = "sbLblTitle";
            // 
            // sbLblVersao
            // 
            this.sbLblVersao.Name = "sbLblVersao";
            this.sbLblVersao.Size = new System.Drawing.Size(70, 17);
            this.sbLblVersao.Text = "sbLblVersao";
            // 
            // tooBtn
            // 
            this.tooBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tooBtnImagemDeFundo,
            this.lblNameImg,
            this.btnAplicaDebitoECredito,
            this.toolBtnSair});
            this.tooBtn.Location = new System.Drawing.Point(0, 24);
            this.tooBtn.Name = "tooBtn";
            this.tooBtn.Size = new System.Drawing.Size(643, 25);
            this.tooBtn.TabIndex = 8;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tooBtnImagemDeFundo
            // 
            this.tooBtnImagemDeFundo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fundoFixoToolStripMenuItem,
            this.imagemDeFundoToolStripMenuItem,
            this.congelarImagensToolStripMenuItem,
            this.semBackGroundToolStripMenuItem});
            this.tooBtnImagemDeFundo.Image = ((System.Drawing.Image)(resources.GetObject("tooBtnImagemDeFundo.Image")));
            this.tooBtnImagemDeFundo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooBtnImagemDeFundo.Name = "tooBtnImagemDeFundo";
            this.tooBtnImagemDeFundo.Size = new System.Drawing.Size(101, 22);
            this.tooBtnImagemDeFundo.Text = "BackGround";
            this.tooBtnImagemDeFundo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tooBtnImagemDeFundo.ToolTipText = "BackGround - Controle de Imagem";
            // 
            // fundoFixoToolStripMenuItem
            // 
            this.fundoFixoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fundoFixoToolStripMenuItem.Image")));
            this.fundoFixoToolStripMenuItem.Name = "fundoFixoToolStripMenuItem";
            this.fundoFixoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.fundoFixoToolStripMenuItem.Text = "Mostrar Logotipo";
            this.fundoFixoToolStripMenuItem.Click += new System.EventHandler(this.fundoFixoToolStripMenuItem_Click);
            // 
            // imagemDeFundoToolStripMenuItem
            // 
            this.imagemDeFundoToolStripMenuItem.Enabled = false;
            this.imagemDeFundoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imagemDeFundoToolStripMenuItem.Image")));
            this.imagemDeFundoToolStripMenuItem.Name = "imagemDeFundoToolStripMenuItem";
            this.imagemDeFundoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.imagemDeFundoToolStripMenuItem.Text = "Imagem em Rotação";
            this.imagemDeFundoToolStripMenuItem.Click += new System.EventHandler(this.imagemDeFundoToolStripMenuItem_Click);
            // 
            // congelarImagensToolStripMenuItem
            // 
            this.congelarImagensToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("congelarImagensToolStripMenuItem.Image")));
            this.congelarImagensToolStripMenuItem.Name = "congelarImagensToolStripMenuItem";
            this.congelarImagensToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.congelarImagensToolStripMenuItem.Text = "Congelar Imagens";
            this.congelarImagensToolStripMenuItem.Click += new System.EventHandler(this.congelarImagensToolStripMenuItem_Click);
            // 
            // semBackGroundToolStripMenuItem
            // 
            this.semBackGroundToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("semBackGroundToolStripMenuItem.Image")));
            this.semBackGroundToolStripMenuItem.Name = "semBackGroundToolStripMenuItem";
            this.semBackGroundToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.semBackGroundToolStripMenuItem.Text = "Sem BackGround";
            this.semBackGroundToolStripMenuItem.Click += new System.EventHandler(this.semBackGroundToolStripMenuItem_Click);
            // 
            // lblNameImg
            // 
            this.lblNameImg.AutoSize = false;
            this.lblNameImg.Name = "lblNameImg";
            this.lblNameImg.Size = new System.Drawing.Size(150, 22);
            this.lblNameImg.ToolTipText = "Nome da Imagem Atual na Tela";
            // 
            // btnAplicaDebitoECredito
            // 
            this.btnAplicaDebitoECredito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAplicaDebitoECredito.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicaDebitoECredito.Image")));
            this.btnAplicaDebitoECredito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAplicaDebitoECredito.Name = "btnAplicaDebitoECredito";
            this.btnAplicaDebitoECredito.Size = new System.Drawing.Size(23, 22);
            this.btnAplicaDebitoECredito.Text = "PROJEEM - Aplica Débito e Crédito";
            this.btnAplicaDebitoECredito.Click += new System.EventHandler(this.btnAplicaDebitoECredito_Click);
            // 
            // toolBtnSair
            // 
            this.toolBtnSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnSair.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnSair.Image")));
            this.toolBtnSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnSair.Name = "toolBtnSair";
            this.toolBtnSair.Size = new System.Drawing.Size(23, 22);
            this.toolBtnSair.ToolTipText = "Fechar o Aplicativo";
            this.toolBtnSair.Click += new System.EventHandler(this.toolBtnSair_Click);
            // 
            // tmTrocaImg
            // 
            this.tmTrocaImg.Interval = 3000;
            this.tmTrocaImg.Tick += new System.EventHandler(this.tmTrocaImg_Tick);
            // 
            // frmMDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(643, 340);
            this.Controls.Add(this.tooBtn);
            this.Controls.Add(this.sStrip);
            this.Controls.Add(this.mNuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mNuPrincipal;
            this.Name = "frmMDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PROJEEM - Projeto de Engenharia e Estatística Matemática";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDIForm_Load);
            this.mNuPrincipal.ResumeLayout(false);
            this.mNuPrincipal.PerformLayout();
            this.sStrip.ResumeLayout(false);
            this.sStrip.PerformLayout();
            this.tooBtn.ResumeLayout(false);
            this.tooBtn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mNuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem arquivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.StatusStrip sStrip;
        private System.Windows.Forms.ToolStripStatusLabel sbLblTitle;
        private System.Windows.Forms.ToolStripStatusLabel sbLblVersao;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tooBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tooBtnImagemDeFundo;
        private System.Windows.Forms.ToolStripMenuItem fundoFixoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagemDeFundoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem congelarImagensToolStripMenuItem;
        private System.Windows.Forms.Timer tmTrocaImg;
        private System.Windows.Forms.ToolStripLabel lblNameImg;
        private System.Windows.Forms.ToolStripMenuItem semBackGroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolBtnSair;
        private System.Windows.Forms.ToolStripButton btnAplicaDebitoECredito;
        private System.Windows.Forms.ToolStripMenuItem toolMenuAplicacao;
    }
}

