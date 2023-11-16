using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IContract
    {


        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataTable RefreshView(string textfilter);


        [OperationContract]
        [FaultContract(typeof(FaultException))]
        DataTable GetmyData();


        [OperationContract]
        Car InitF2(int id);


        [OperationContract]
        string Proc(int id);

  
        [OperationContract]
        void InsertCommand(Car c);


        [OperationContract]
        void Delete(int id);


        [OperationContract]
        void Update(Car c, int id);


        [OperationContract]
        Car Load(int id);
       
    }



    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        int Log_in(string username, string password);
        [OperationContract]
        int Registration(string username, string password);
    }


    //класс общий для клиента и сервера
    [DataContract]
    public class Car
    {

        [DataMember]
        private int id;
        [DataMember]
        private string car_brand;
        [DataMember]
        private int probeg;
        [DataMember]
        private int car_price;
        [DataMember]
        private int data_proizvodstva;
        [DataMember]
        private string seller;


        public Car(int id, string car_brand, int probeg, int car_price, int data_proizvodstva, string seller)
        {
            this.id = id;
            this.car_brand =car_brand;
            this.probeg = probeg;
            this.car_price = car_price;
            this.data_proizvodstva = data_proizvodstva;
            this.seller = seller;
        }


      
        public Car()
        {
        }


        [DataMember]
        public int ID
        {
            get => id;
            set
            {
                id = value;
            }
        }


        [DataMember]
        public string CARBRAND
        {
            get => car_brand;
            set
            {
                car_brand = value;
            }
        }


        [DataMember]
        public int PROBEG
        {
            get => probeg;
            set
            {
                probeg = value;
            }

        }



        [DataMember]
        public int CARPRICE
        {
            get => car_price;
            set
            {
                car_price = value;
            }
        }



        [DataMember]
        public int DATAPROIZVODSTVA
        {
            get => data_proizvodstva;
            set
            {
                data_proizvodstva = value;
            }
        }


        [DataMember]
        public string SELLER
        {
            get => seller;
            set
            {
                seller = value;
            }
        }

    }

}
