﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Flash:Storrage
    {
        private int speedUsb;
        public int haveMemory { get; set; }

        public override int GetMemory()
        {
            return memory;
        }

        public void  SetMemory(int memory)
        {
            this.memory = memory;
        }

        public int GetUsbSpeed()
        {
            return speedUsb;
        }

        public void SetSpeedUsb(int speedUsb)
        {
            this.speedUsb = speedUsb;
        }

        public override void CopyData(ref int data)
        {
           // haveMemory += (memory - haveMemory);
            if (memory - haveMemory >= data)
            {
                haveMemory += data;
                data = 0;
            }

            else
            {
                data -= memory - haveMemory;
                haveMemory = memory;
            }


        }

        public override int FreeMemoryInfo()
        {
            return memory - haveMemory;
        }

        public override string GetInfo()
        {
            string info = String.Format("Имя - {0}\n Модель - {1}\n Скорость usb - {2}\n Общая память - {3} \nСвободная память - {4}", _name, _model, speedUsb, memory,haveMemory);
            return info;
        }
    }
}
