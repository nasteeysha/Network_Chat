using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WCFServer
{
    

    public class Server
    {
        private ServiceHost host1;
        private ServiceHost host2;


        public Server()
        {
            host1 = new ServiceHost(typeof(Contract));
            host2 = new ServiceHost(typeof(Login));
        }
        public void Start()
        {
            host1.Open();
            host2.Open();
        }

    }
}
