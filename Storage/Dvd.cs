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

        public override int GetMemory()
        {
            return memory;
        }
    
        public void SetMemory(int memory)
        {
            this.memory = memory;
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
            string info = String.Format("Имя - {0}\n Модель - {1}\n Скорость Записи - {2}\n Скорость чтения - {3}\n Общая память - {4} \nСвободная память - {5}", _name, _model,SpeedWrite,SpeedRead, memory, haveMemory);
            return info;
        }
    }
}
