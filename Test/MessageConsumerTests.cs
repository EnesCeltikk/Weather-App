using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfService;
using Base;
using System.Messaging;
using System.Data.SqlClient;
using ServiceConsoleApp;
using System.ServiceModel;

namespace Test
{
    [TestClass]
    public class MessageConsumerTests
    {
        private MessageFixture m_Fixture;
        private MessageConsumer m_Consumer;
        private Guid m_Guid;
        private Response m_Response;
        private Request m_Request;
        private MessageQueue m_MessageQueue;
        private Message m_Message;
        private SqlConnection m_SqlConnection;
        private ServiceHost m_Host;
        public void Initialize()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("En"); //Hata raporlarını Ing yapmak için
            m_Fixture = new MessageFixture();
            m_Consumer = m_Fixture.MessageConsumer;
            m_Host = m_Fixture.Host;
            m_Guid = new Guid();

            m_SqlConnection = m_Fixture.SqlConnection;
            m_MessageQueue = m_Fixture.MessageQueue;

            m_Message = new Message();
            m_Response = new Response();
            m_Response.CityName = "test";
            m_Response.Status = Status.Waiting;
            m_Response.Request.CityName = "test";
            m_Response.Request.Status = Status.Waiting;

            m_Request = new Request();
            m_Request.CityName = "test";
            m_Request.Status = Status.Waiting;

        }

        public MessageConsumerTests(MessageFixture messageFixture)
        {
            m_Fixture = messageFixture;
            //m_Consumer = m_Fixture.MessageConsumer;
            m_Guid = Guid.NewGuid();
        }
        public MessageConsumerTests()
        {
            Initialize();
        }
        [TestMethod]
        public void ConsumeMessage_ValidateParameters_GuidCityname()
        {
            m_Guid = Guid.NewGuid();
            Service.MessageQueue.Enqueue("rize$" + m_Guid);
            TestFlags.MessageConsume_QueueTestFlag = true;
            Thread.Sleep(1000);
            m_Consumer.Consume();

            Assert.AreEqual("rize", m_Consumer.CityName);
            Assert.AreEqual(m_Guid, m_Consumer.RequestGuid);

            m_Fixture.ClearData();
            m_Fixture.SetFlagsToDefaultValue();
        }



        [TestMethod]
        public void MsmqReceive_ValidateResponseDtoInMsmq_Success()
        {

            m_Consumer.SendMessage(m_Response);
            m_Message = m_MessageQueue.Receive();
            m_Message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(Response) });

            Assert.ReferenceEquals(m_Message.Body, m_Response);

            //Assert.AreEqual(m_ResponseExpected.CityName, m_ResponseActual.CityName);
            //Assert.AreEqual(m_ResponseExpected.Request.CityName, m_ResponseActual.Request.CityName);
            m_Fixture.ClearData();
            m_Fixture.SetFlagsToDefaultValue();
        }

        [TestMethod]
        public void SendMessagesToMsmq_HundredMessageSent_Success()
        {
            for (int i = 0; i < 100; i++)
            {
                m_Consumer.SendMessage(m_Response);
            }
            Assert.AreEqual(m_MessageQueue.GetAllMessages().Length, 100);
            m_Fixture.ClearData();
        }


        [TestMethod]
        public void CheckService_ValidateHostStates_Success()
        {
            m_Host.Open();
            Assert.AreEqual(m_Host.State.ToString(), "Opened");
            m_Host.Close();
            Assert.AreEqual(m_Host.State.ToString(), "Closed");
        }



    }
}
