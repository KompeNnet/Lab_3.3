using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Helpers
{
    public class Finalization
    {
        public Action DataUpdate;
        public Action DataLoad;
        public bool isFinal;

        public Finalization(Action DataUpdate, Action DataLoad, bool isFinal)
        {
            this.DataUpdate = DataUpdate;
            this.DataLoad = DataLoad;
            this.isFinal = isFinal;
        }
    }
}
