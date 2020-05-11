using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongDaSo
{
    public class CheckingClass
    {
        public bool conditionA { get; set; }
        public bool conditionB { get; set; }
        public bool conditionC { get; set; }
        public bool conditionD { get; set; }

        public CheckingClass()
        {
            this.conditionA = false;
            this.conditionB = false;
            this.conditionC = false;
            this.conditionD = false;
        }
    }
}
