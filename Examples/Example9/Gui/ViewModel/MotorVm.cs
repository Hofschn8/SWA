﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
   public class MotorVm : ItemVm
    {
        public MotorVm()
        {
        }

        public MotorVm(string category, string desc, int prio, int amount, string status)
        {
            Category = category;
            Desc = desc;
            Prio = prio;
            Amount = amount;
            Status = status;
        }

    }
}
