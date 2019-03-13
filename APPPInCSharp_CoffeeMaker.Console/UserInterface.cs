namespace APPPInCSharp_CoffeeMaker.Console
{
    public class UserInterface
    {
        private HotWaterSource hws;
        private ContainmentVessel cv;

        public void Done()
        {
        }

        public void Complete()
        {
        }

        protected void StartBrewing()
        {
            if (hws.IsReady() && cv.IsReady())
            {
                hws.Start();
                cv.Start();
            }
        }
    }
}