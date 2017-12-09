using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Dvd:Storrage
    {
        public int SpeedWrite { get; set; }
        public int SpeedRead { get; set; }
        public int haveMemory { get; set; }
        private bool first = false;

        public override int GetMemory()
        {
            if (!first){
                haveMemory = 0;
                first = true;
            }
            return memory;
        }
    
        public void SetMemory(int memory)
        {
            if (!first)
            {
                haveMemory = 0;
                first = true;
            }
            this.memory = memory;
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
            string info = String.Format("Имя - {0}\n Модель - {1}\n Скорость Записи - {2}\n Скорость чтения - {3}\n Общая память - {4} \nСвободная память - {5}", _name, _model,SpeedWrite,SpeedRead, memory, memory-haveMemory);
            return info;
        }
    }
}
