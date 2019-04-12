using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MSQS.Core;
using Microsoft.Owin.Hosting;
using MSQS.Service.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MSQS.Service
{
    public partial class Service1 : ServiceBase
    {
        private static string SERVICE_NAME = "MSQS Service";
        public Service1()
        {
            InitializeComponent();
            eventLog1.Source = SERVICE_NAME;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; ;
        }        

        protected override void OnStart(string[] args)
        {
            DoWork();
        }

        protected override void OnStop()
        {
        }

        public void DoWork()
        {
            var queue = MessageHelper.GetInstance.GetQueue();
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(LogItem) });
            queue.ReceiveCompleted += Queue_ReceiveCompleted;
            queue.BeginReceive();

            string url = "http://localhost:8086";
            WebApp.Start<Startup>(url);
        }

        private void Queue_ReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;            
            Message m = mq.EndReceive(asyncResult.AsyncResult);

            var message = (LogItem)m.Body;
            Console.WriteLine(message);

            BroadcastContext.Instance.Send(message);

            mq.BeginReceive(); 
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            eventLog1.WriteEntry(e.ExceptionObject.ToString(), EventLogEntryType.Error);
        }
    }
}
