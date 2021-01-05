using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using WcfService;
using Base;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Test
{
    [TestClass]
    public class MessageFixture
    {
        public MessageConsumer MessageConsumer;
        public MessageQueue MessageQueue;
        public string ConnectionString;
        public SqlConnection SqlConnection;
        public ServiceHost Host;
        public Uri BaseAddress;

        public MessageFixture()
        {
            Initialize();

        }
        [TestInitialize]
        public void Initialize()
        {
            TestFlags.DbInitializeTestFlag = true;
            MessageConsumer = new MessageConsumer();
            MessageQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\StajQueue"))
            {
                MessageQueue = new MessageQueue(@".\Private$\StajQueue");
            }
            else
            {
                MessageQueue = MessageQueue.Create(@".\\Private$\\StajQueue");
            }

            BaseAddress = new Uri("http://localhost:4501");
            Host = new ServiceHost(typeof(Service), BaseAddress);
            Host.AddServiceEndpoint(typeof(IService), new BasicHttpBinding(), BaseAddress.ToString());
            ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
            metadataBehavior.HttpGetEnabled = true;
            Host.Description.Behaviors.Add(metadataBehavior);

            ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Staj_DB;User ID=sa;Password=123";
            SqlConnection = new SqlConnection(ConnectionString);
        }

        public void ClearData()
        {
            Service.MessageQueue.Clear();
            MessageQueue.Purge();
            MessageQueue.Close();
            SqlConnection.Close();

        }
        public void SetFlagsToDefaultValue()
        {
            TestFlags.MessageConsume_QueueTestFlag = false;
            TestFlags.DbInitializeTestFlag = false;
        }
    }
}
