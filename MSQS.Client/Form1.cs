using System;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using MSQS.Core;

namespace MSQS.Client
{
    public partial class Form1 : Form
    {
        private static string url = "http://localhost:8086";

        public Form1()
        {
            InitializeComponent();            

            var connection = new HubConnection(url);
            var myHub = connection.CreateHubProxy("BroadcastHub");
            myHub.On<LogItem>("ReceiveMsg", ReceiveMsg);

            connection.Start().ContinueWith(task =>
            {
                labStatut.Text = task.IsFaulted ? "Connect server error !" : "Connect server OK";
            }).Wait();
        }

        private void ReceiveMsg(LogItem log)
        {
            this.BeginInvoke((Action)(() => {
                txtMessage.Text += log.ToString() + System.Environment.NewLine;
            }));
        }
    }
}
