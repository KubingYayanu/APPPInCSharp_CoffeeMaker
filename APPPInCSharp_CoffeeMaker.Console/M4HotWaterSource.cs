namespace APPPInCSharp_CoffeeMaker.Console
{
    public class M4HotWaterSource : HotWaterSource, Pollable
    {
        private CoffeeMakerAPI api;

        public M4HotWaterSource(CoffeeMakerAPI api)
        {
            this.api = api;
        }

        public override bool IsReady()
        {
            BoilerStatus status = api.GetBoilerStatus();
            return status == BoilerStatus.NOT_EMPTY;
        }

        public override void StartBrewing()
        {
            api.SetReliefValveState(ReliefValveState.CLOSED);
            api.SetBoilerState(BoilerState.ON);
        }

        public void Poll()
        {
            BoilerStatus boilerStatus = api.GetBoilerStatus();
            if (isBrewing)
            {
                if (boilerStatus == BoilerStatus.EMPTY)
                {
                    api.SetBoilerState(BoilerState.OFF);
                    api.SetReliefValveState(ReliefValveState.CLOSED);
                    DeclareDone();
                }
            }
        }

        public override void Pause()
        {
            api.SetReliefValveState(ReliefValveState.OPEN);
            api.SetBoilerState(BoilerState.OFF);
        }

        public override void Resume()
        {
            api.SetReliefValveState(ReliefValveState.CLOSED);
            api.SetBoilerState(BoilerState.ON);
        }
    }
}