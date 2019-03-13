using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPPInCSharp_CoffeeMaker.Console
{
    public class M4UserInterface : UserInterface
    {
        private CoffeeMakerAPI api;

        public M4UserInterface(CoffeeMakerAPI api)
        {
            this.api = api;
        }

        private void CheckButton()
        {
            BrewButtonStatus status = api.GetBrewButtonStatus();
            if (status == BrewButtonStatus.PUSHED)
            {
                StartBrewing();
            }
        }
    }
}
