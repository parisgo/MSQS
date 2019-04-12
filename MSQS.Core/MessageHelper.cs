using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSQS.Core
{
    public class MessageHelper
    {
        private static string QUEUE_PATH = ".\\Private$\\mq01";
        private static MessageQueue messageQueue = null;

        private static readonly MessageHelper instance = new MessageHelper();              

        private MessageHelper()
        {
            if (messageQueue == null)
            {
                IsQueueExists(QUEUE_PATH);

                messageQueue = new MessageQueue(QUEUE_PATH);
            }
        }

        public static MessageHelper GetInstance
        {
            get
            {
                return instance;
            }            
        }

        public void Write(LogItem message)
        {
            messageQueue.Send(message);
        }

        public MessageQueue GetQueue()
        {
            return messageQueue;
        }

        private static void IsQueueExists(string path)
        {
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }
        }
    }
}
