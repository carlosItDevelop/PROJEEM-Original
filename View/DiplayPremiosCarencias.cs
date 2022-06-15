using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class frmDiplayPremiosCarencias : Form
    {
        public frmDiplayPremiosCarencias()
        {
            InitializeComponent();
        }

        public frmDiplayPremiosCarencias(ref decimal aCtrlPremios, ref decimal aCtrlCarencias, ref decimal aCtrlProcMor15, ref decimal aCtrlWaitMpr15)
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
