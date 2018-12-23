using _GUI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using TcpCom;

namespace ClientConsole
{
    class Program
    {
        private static Random rand = new Random();
        private static string[] types = Enum.GetNames(typeof(Types));
        private static ClientServer myClient = new ClientServer(false, 10100, "127.0.0.1", null);

        static void Main(string[] args)
        {


            //while (true)
            //{
            //    GenerateNewBluePrintVm();
            //    Thread.Sleep(3000);
            //}

            DispatcherTimer disp = new DispatcherTimer();
            disp.Interval = new TimeSpan(0, 0, 0, 2);
            disp.Tick += Disp_Tick;
            disp.Start();
            Console.ReadLine();




        }

        private static void Disp_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Generating ....");
            int numberOfEntriesInTypes = types.Length;
            string typ = types[rand.Next(0, numberOfEntriesInTypes - 1)];
            string comp = "";
            if (typ.Equals("Car"))
            {
                comp = "Engine;Tires;Center;Gear";
            }
            else if (typ.Equals("Motorcycle"))
            {
                comp = "Engine;Tires;Chasis;Tank";
            }
            else
            {
                comp = "rack;Tires;Pedals";
            }
            string compTime = "10:20";
            string amount = "5";

            myClient.sendToServer(typ + "{" + comp + "}" + amount + ";" + compTime);
        }

        private static void GenerateNewBluePrintVm()
        {
            Console.WriteLine("Generating ....");
            int numberOfEntriesInTypes = types.Length;
            string typ = types[rand.Next(0, numberOfEntriesInTypes - 1)];
            string comp = "";
            if (typ.Equals("Car"))
            {
                comp = "Engine;Tires;Center;Gear";
            }
            else if (typ.Equals("Motorcycle"))
            {
                comp = "Engine;Tires;Chasis;Tank";
            }
            else
            {
                comp = "rack;Tires;Pedals";
            }
            string compTime = "10:20";
            string amount = "5";

            myClient.sendToServer(typ + "{" + comp + "}" + amount + ";" + compTime);
        }

    }
}
