namespace APPPInCSharp_CoffeeMaker.Console
{
    public class M4ContainmentVessel : ContainmentVessel
    {
        private CoffeeMakerAPI api;

        public M4ContainmentVessel(CoffeeMakerAPI api)
        {
            this.api = api;
        }

        public override bool IsReady()
        {
            WarmerPlateStatus status = api.GetWarmerPlateStatus();
            return status == WarmerPlateStatus.POT_EMPTY;
        }
    }
}