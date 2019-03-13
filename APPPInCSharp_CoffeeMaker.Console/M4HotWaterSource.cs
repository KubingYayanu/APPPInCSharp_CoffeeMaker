namespace APPPInCSharp_CoffeeMaker.Console
{
    public class M4HotWaterSource : HotWaterSource
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
    }
}