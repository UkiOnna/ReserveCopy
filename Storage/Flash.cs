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
        private int memory;
        string[] data;

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

        public override void CopyData(string data)
        {
            throw new NotImplementedException();
        }
    }
}
