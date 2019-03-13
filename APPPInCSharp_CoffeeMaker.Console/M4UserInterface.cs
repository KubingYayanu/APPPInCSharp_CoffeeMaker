using System;

namespace APPPInCSharp_CoffeeMaker.Console
{
    public class M4UserInterface : UserInterface, Pollable
    {
        private CoffeeMakerAPI api;

        public M4UserInterface(CoffeeMakerAPI api)
        {
            this.api = api;
        }

        public void Poll()
        {
            BrewButtonStatus status = api.GetBrewButtonStatus();
            if (status == BrewButtonStatus.PUSHED)
            {
                StartBrewing();
            }
        }

        public override void CompleteCycle()
        {
            api.SetIndicatorState(IndicatorState.OFF);
        }

        public override void Done()
        {
            api.SetIndicatorState(IndicatorState.ON);
        }
    }
}