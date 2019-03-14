using APPPInCSharp_CoffeeMaker.Console;
using NUnit.Framework;

namespace APPPInCSharp_CoffeeMaker.UnitTests
{
    [TestFixture]
    public class CoffeeMakerTests
    {
        private M4UserInterface ui;
        private M4HotWaterSource hws;
        private M4ContainmentVessel cv;
        private CoffeeMakerStub api;

        [SetUp]
        public void SetUp()
        {
            api = new CoffeeMakerStub();
            ui = new M4UserInterface(api);
            hws = new M4HotWaterSource(api);
            cv = new M4ContainmentVessel(api);
            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);
        }

        private void Poll()
        {
            ui.Poll();
            hws.Poll();
            cv.Poll();
        }

        #region InitialCondition

        [Test]
        public void InitialCondition_BoilerOn_ReturnFalse()
        {
            InitialConditionSetting();
            Assert.That(api.boilerOn, Is.False);
        }

        [Test]
        public void InitialCondition_LightOn_ReturnFalse()
        {
            InitialConditionSetting();
            Assert.That(api.lightOn, Is.False);
        }

        [Test]
        public void InitialCondition_PlateOn_ReturnFalse()
        {
            InitialConditionSetting();
            Assert.That(api.plateOn, Is.False);
        }

        [Test]
        public void InitialCondition_ValveClosed_ReturnTrue()
        {
            InitialConditionSetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void InitialConditionSetting()
        {
            Poll();
        }

        #endregion InitialCondition

        #region StartNoPot

        [Test]
        public void StartNoPot_BoilerOn_ReturnFalse()
        {
            StartNoPotSetting();
            Assert.That(api.boilerOn, Is.False);
        }

        [Test]
        public void StartNoPot_LightOn_ReturnFalse()
        {
            StartNoPotSetting();
            Assert.That(api.lightOn, Is.False);
        }

        [Test]
        public void StartNoPot_PlateOn_ReturnFalse()
        {
            StartNoPotSetting();
            Assert.That(api.plateOn, Is.False);
        }

        [Test]
        public void StartNoPot_ValveClosed_ReturnTrue()
        {
            StartNoPotSetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void StartNoPotSetting()
        {
            Poll();
            api.buttonPressed = true;
            api.potPresent = false;
            Poll();
        }

        #endregion StartNoPot

        #region StartNoWater

        [Test]
        public void StartNoWater_BoilerOn_ReturnFalse()
        {
            StartNoWatterSetting();
            Assert.That(api.boilerOn, Is.False);
        }

        [Test]
        public void StartNoWater_LightOn_ReturnFalse()
        {
            StartNoWatterSetting();
            Assert.That(api.lightOn, Is.False);
        }

        [Test]
        public void StartNoWater_PlateOn_ReturnFalse()
        {
            StartNoWatterSetting();
            Assert.That(api.plateOn, Is.False);
        }

        [Test]
        public void StartNoWater_ValveClosed_ReturnTrue()
        {
            StartNoWatterSetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void StartNoWatterSetting()
        {
            Poll();
            api.buttonPressed = true;
            api.boilerEmpty = true;
            Poll();
        }

        #endregion StartNoWater

        #region GoodStart

        [Test]
        public void GoodStart_BoilerOn_ReturnTrue()
        {
            NormalStartSetting();
            Assert.That(api.boilerOn, Is.True);
        }

        [Test]
        public void GoodStart_LightOn_ReturnFalse()
        {
            NormalStartSetting();
            Assert.That(api.lightOn, Is.False);
        }

        [Test]
        public void GoodStart_PlateOn_ReturnFalse()
        {
            NormalStartSetting();
            Assert.That(api.plateOn, Is.False);
        }

        [Test]
        public void GoodStart_ValveClosed_ReturnTrue()
        {
            NormalStartSetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void NormalStartSetting()
        {
            Poll();
            api.boilerEmpty = false;
            api.buttonPressed = true;
            Poll();
        }

        #endregion GoodStart

        #region StartedPotNotEmpty

        [Test]
        public void StartedPotNotEmpty_BoilerOn_ReturnTrue()
        {
            StartedPotNotEmptySetting();
            Assert.That(api.boilerOn, Is.True);
        }

        [Test]
        public void StartedPotNotEmpty_LightOn_ReturnFalse()
        {
            StartedPotNotEmptySetting();
            Assert.That(api.lightOn, Is.False);
        }

        [Test]
        public void StartedPotNotEmpty_PlateOn_ReturnTrue()
        {
            StartedPotNotEmptySetting();
            Assert.That(api.plateOn, Is.True);
        }

        [Test]
        public void StartedPotNotEmpty_ValveClosed_ReturnTrue()
        {
            StartedPotNotEmptySetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void StartedPotNotEmptySetting()
        {
            Poll();
            api.boilerEmpty = false;
            api.buttonPressed = true;
            Poll();
            api.potNotEmpty = true;
            Poll();
        }

        #endregion StartedPotNotEmpty

        #region BoilerEmptyPotNotEmpty

        [Test]
        public void BoilerEmptyPotNotEmpty_BoilerOn_ReturnFalse()
        {
            NormalBrewSetting();
            Assert.That(api.boilerOn, Is.False);
        }

        [Test]
        public void BoilerEmptyPotNotEmpty_LightOn_ReturnTrue()
        {
            NormalBrewSetting();
            Assert.That(api.lightOn, Is.True);
        }

        [Test]
        public void BoilerEmptyPotNotEmpty_PlateOn_ReturnTrue()
        {
            NormalBrewSetting();
            Assert.That(api.plateOn, Is.True);
        }

        [Test]
        public void BoilerEmptyPotNotEmpty_ValveClosed_ReturnTrue()
        {
            NormalBrewSetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void NormalBrewSetting()
        {
            NormalFillSetting();
            api.boilerEmpty = true;
            Poll();
        }

        #endregion BoilerEmptyPotNotEmpty

        #region EmptyPotReturnedAfterBoilerEmptied

        [Test]
        public void EmptyPotReturnedAfterBoilerEmptied_BoilerOn_ReturnFalse()
        {
            EmptyPotReturnedAfterBoilerEmptiedSetting();
            Assert.That(api.boilerOn, Is.False);
        }

        [Test]
        public void EmptyPotReturnedAfterBoilerEmptied_LightOn_ReturnFalse()
        {
            EmptyPotReturnedAfterBoilerEmptiedSetting();
            Assert.That(api.lightOn, Is.False);
        }

        [Test]
        public void EmptyPotReturnedAfterBoilerEmptied_PlateOn_ReturnFalse()
        {
            EmptyPotReturnedAfterBoilerEmptiedSetting();
            Assert.That(api.plateOn, Is.False);
        }

        [Test]
        public void EmptyPotReturnedAfterBoilerEmptied_ValveClosed_ReturnTrue()
        {
            EmptyPotReturnedAfterBoilerEmptiedSetting();
            Assert.That(api.valveClosed, Is.True);
        }

        private void EmptyPotReturnedAfterBoilerEmptiedSetting()
        {
            NormalBrewSetting();
            api.potNotEmpty = false;
            Poll();
        }

        #endregion EmptyPotReturnedAfterBoilerEmptied

        [Test]
        public void PotRemovedAndReplacedWhileEmpty()
        {
            NormalStartSetting();
            api.potPresent = false;
            Poll();
            Assert.That(api.boilerOn, Is.False);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.False);

            api.potPresent = true;
            Poll();
            Assert.That(api.boilerOn, Is.True);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.True);
        }

        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedEmpty()
        {
            NormalFillSetting();
            api.potPresent = false;
            Poll();
            Assert.That(api.boilerOn, Is.False);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.False);

            api.potPresent = true;
            api.potNotEmpty = false;
            Poll();
            Assert.That(api.boilerOn, Is.True);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.True);
        }

        private void NormalFillSetting()
        {
            NormalStartSetting();
            api.potNotEmpty = true;
            Poll();
        }

        [Test]
        public void PotRemovedWhileNotEmptyAndReplacedNotEmpty()
        {
            NormalFillSetting();
            api.potPresent = false;
            Poll();
            Assert.That(api.boilerOn, Is.False);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.False);

            api.potPresent = true;
            Poll();
            Assert.That(api.boilerOn, Is.True);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.True);
            Assert.That(api.valveClosed, Is.True);
        }

        [Test]
        public void BoilerEmptiesWhilePotRemoved()
        {
            NormalFillSetting();
            api.potPresent = false;
            Poll();
            Assert.That(api.boilerOn, Is.False);
            Assert.That(api.lightOn, Is.False);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.False);

            api.boilerEmpty = true;
            Poll();
            Assert.That(api.boilerOn, Is.False);
            Assert.That(api.lightOn, Is.True);
            Assert.That(api.plateOn, Is.False);
            Assert.That(api.valveClosed, Is.True);

            api.potPresent = true;
            Poll();
            Assert.That(api.boilerOn, Is.False);
            Assert.That(api.lightOn, Is.True);
            Assert.That(api.plateOn, Is.True);
            Assert.That(api.valveClosed, Is.True);
        }
    }
}