using System;
using System.Messaging;

namespace Base
{
    public class MSMQueue 
    {
        private MessageQueue m_MessageQueue;
        private Message m_Message;

        public MSMQueue (string address)
        {
            try
            {
                if (MessageQueue.Exists(@address))
                {
                    m_MessageQueue = new MessageQueue(@address);
                }
                else
                {
                    m_MessageQueue = MessageQueue.Create(@address);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("MSMQ kuyruğu oluşturulurken hata", ex);
                throw ex.InnerException;
            }
        }


        public Message Receive(TimeSpan timeSpan, Type type)
        {
            try
            {
                m_Message = m_MessageQueue.Receive(timeSpan);
                m_Message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { type });
            }
            catch
            {
                m_Message = new Message();
            }
            return m_Message;
        }


        public void Send(object obj)
        {
            m_MessageQueue.Send(obj);
        }
    }
}
