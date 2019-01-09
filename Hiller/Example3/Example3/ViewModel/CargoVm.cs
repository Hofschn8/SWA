using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Example3.ViewModel
{
    public class CargoVm
    {
        DispatcherTimer timer = new DispatcherTimer();
        public string Description { get; set; }
        public int DeliveryTime { get; set; }
        public List<CargoItemVm> Cargos { get; set; }
        Action<CargoVm> InformGui;
        TimeSpan span;
        private CargoVm cargoVm;

        public CargoVm(string desc, int time)
        {
            
            Description = desc;
            DeliveryTime = time;
            Cargos = new List<CargoItemVm>();

        }

        public CargoVm(CargoVm c, Action<CargoVm> Informer)
        {
            InformGui = Informer;
            Description = c.Description;
            DeliveryTime = c.DeliveryTime;
            Cargos = c.Cargos;

            span = new TimeSpan(0, 0, DeliveryTime);
            CheckDeliveryTime();
        }

        private void CheckDeliveryTime()
        {
            timer.Interval = span;
            timer.Tick += TickEvent;
            timer.Start();
        }

        private void TickEvent(object sender, EventArgs e)
        {
            InformGui(this);
            timer.Stop();
        }
    }
}
