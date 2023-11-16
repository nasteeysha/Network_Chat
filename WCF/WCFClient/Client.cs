using Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    public class Client
    {
        private IContract contract;
        private ILogin login;



        public Client()
        {
            ChannelFactory<IContract> factory = new ChannelFactory<IContract>("ClientPoint1");
            ChannelFactory<ILogin> factory2 = new ChannelFactory<ILogin>("ClientPoint2");
            contract = factory.CreateChannel();
            login = factory2.CreateChannel();
        }

        
        public void InsertClient(Car car)
        {
            contract.InsertCommand(car);
        }


        public void UpdateClient(Car car, int id)
        {
            contract.Update(car, id);
        }

        public string ProcClient(int id)
        {
            return contract.Proc(id);
        }

        public void DeleteClient(int id)
        {
            contract.Delete(id);
        }




        public DataTable GetmyDataClient()
        {
            //return contract.GetmyData();
            
            try
            {
                return contract.GetmyData();
            }
            catch (FaultException ex)
            {
                return null;
            }
        }

        public DataTable RefreshViewClient(string textfilter)
        {
            try
            {
                return contract.RefreshView(textfilter);
            }
            catch (FaultException ex)
            {
                return null;
            }
        }

        public Car LoadClient(int id)
        {
            return contract.Load(id);
        }


        public int LoginClient(string username, string password)
        {
            return login.Log_in(username, password);
        }


        public int RegistrationClient(string username, string password)
        {
            return login.Registration(username, password);
        }







        public void Send(Car c)
        {
            //contract.Insert(new Car {Id = id, CARBRAND = value });
            contract.InsertCommand(new Car ());
        }



        public Car InitF2Client(int id)
        {
            return contract.InitF2(id);
        }

        public void Upp(Car c)
        {
            //contract.Insert(new Car {Id = id, CARBRAND = value });
            contract.InsertCommand(new Car());
        }

        public Car Receive(int id)
        {
            return contract.Load(id);
        }

        public Car[] ReceiveAll()
        {
            List<Car> cd = new List<Car>();
            for (int i=1; i <=10; i++)
            {
                cd.Add(contract.Load(i));
            }
            return cd.ToArray();
        }
    }
}
