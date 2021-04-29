using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UniversalSpammer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lblMadeBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.laugny.com/");
        }

        private void txtThreads_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblMadeBy.Enabled = false;
            lblidle.Visible = false;
            lblSpamming.Visible = true;
            txtThreads.Enabled = false;
            btnStart.Enabled = false;
            txtMsg.Enabled = false;
            btnClear.Enabled = false;
            if (txtThreads.TextLength == 0)
            {
                MessageBox.Show("Please specify a number of Threads!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtThreads.Enabled = true;
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtMsg.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                tmrSpammer.Start();
                Thread.Sleep(500);
                btnStop.Enabled = true;
            }
        }

        private void tmrSpammer_Tick(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(Convert.ToInt32(txtThreads.Text));
                SendKeys.Send(txtMsg.Text);
                SendKeys.Send("{Enter}");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrSpammer.Stop();
            lblSpamming.Visible = false;
            lblidle.Visible = true;
            txtThreads.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            txtMsg.Enabled = true;
            lblMadeBy.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMsg.Text = "";
        }
    }
}
