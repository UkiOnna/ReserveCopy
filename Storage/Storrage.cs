using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public abstract class Storrage
    {
        private string _name;
        private string _model;


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

        public abstract void CopyData(string data);

        public abstract void FreeMemoryInfo();

        public abstract void GetInfo();
    }
}
