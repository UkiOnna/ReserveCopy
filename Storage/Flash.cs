using System;
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
        private bool first = false;


        public override int GetMemory()
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            return memory;
        }

        public void  SetMemory(int memory)
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            this.memory = memory;
        }

        public int GetUsbSpeed()
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            return speedUsb;
        }

        public void SetSpeedUsb(int speedUsb)
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            this.speedUsb = speedUsb;
        }

        public override bool CopyData(ref int data)
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            // haveMemory += (memory - haveMemory);
            if (memory - haveMemory >= data)
            {
                haveMemory += data;
                data = 0;
                return true;
            }

            else
            {
                return false;
            }


        }

        public override int FreeMemoryInfo()
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            return memory - haveMemory;
        }

        public override string GetInfo()
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            string info = String.Format("Имя - {0}\n Модель - {1}\n Скорость usb - {2}\n Общая память - {3} \nСвободная память - {4}", _name, _model, speedUsb, memory,memory-haveMemory);
            return info;
        }
    }
}
