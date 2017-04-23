using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._3.Classes
{
    public class Finalization
    {
        public Action DataUpdate;
        public bool isFinal;

        public Finalization(Action DataUpdate, bool isFinal)
        {
            this.DataUpdate = DataUpdate;
            this.isFinal = isFinal;
        }
    }
}
