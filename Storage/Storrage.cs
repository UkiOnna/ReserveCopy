using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public abstract class Storrage
    {
        protected string _name;
        protected string _model;
        protected int memory;
        


        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetModel()
        {
            return _model;
        }

        public void SetModel(string model)
        {
            _model = model;
        }

        public abstract int GetMemory();

        public abstract void CopyData(ref int data);

        public abstract int FreeMemoryInfo();

        public abstract string GetInfo();
    }
}
