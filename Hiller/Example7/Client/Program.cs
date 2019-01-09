using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string motorcycle = "Motorcycle{Engine;Tires;Center;Gear}5;15:20";
            string car = "Car{Engine;Tires;Center;Gear}5;20:20";
            string bicycle = "Bicycle{rack;Pedals}4;13:20";
            string[] test = new string[3];
            test[0] = motorcycle;
            test[1] = car;
            test[2] = bicycle;

            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10100));
            Socket socket = client.Client;
            socket.Send(Encoding.UTF8.GetBytes(test[rand.Next(0, 2)]));


            Task.Factory.StartNew(StartSending);
            while (true)
            {
                Console.Read();
            }
            

        }

        public static void StartSending()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            string motorcycle = "Motorcycle{Engine;Tires;Center;Gear}5;15:20";
            string car = "Car{Engine;Tires;Center;Gear}5;20:20";
            string bicycle = "Bicycle{rack;Pedals}4;13:20";
            string[] test = new string[3];
            test[0] = motorcycle;
            test[1] = car;
            test[2] = bicycle;

            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10100));
            Socket socket = client.Client;
            socket.Send(Encoding.UTF8.GetBytes(test[rand.Next(0, 2)]));
        }

    }
}
