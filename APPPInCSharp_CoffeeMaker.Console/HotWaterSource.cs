using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPPInCSharp_CoffeeMaker.Console
{
    public abstract class HotWaterSource
    {
        public void Start() { }

        public abstract bool IsReady();
    }
}
