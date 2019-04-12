using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSQS.Core;

namespace MSQS.Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSender_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                for(int i=0; i<10;i++)
                {
                    var message = new Core.LogItem();
                    message.Info = txtMessage.Text.Trim() + " " + i;
                    message.AddTime = DateTime.Now;

                    MessageHelper.GetInstance.Write(message);
                    Thread.Sleep(100);
                }                
            });
        }
    }
}
