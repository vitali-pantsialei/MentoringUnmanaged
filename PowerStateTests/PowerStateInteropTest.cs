using System;
using PowerStateManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerStateTests
{
    [TestClass]
    public class PowerStateInteropTest
    {
        [TestMethod]
        public void GetLastSleepTimeTest()
        {
            Console.WriteLine(PowerStateInterop.GetLastWakeTime());
        }

        [TestMethod]
        public void GetLastWakeTimeTest()
        {
            Console.WriteLine(PowerStateInterop.GetLastSleepTime());
        }

        [TestMethod]
        public void GetBatteryStateTest()
        {
            SYSTEM_BATTERY_STATE state = new SYSTEM_BATTERY_STATE();
            PowerStateInterop.GetBatteryState(state);
            Console.WriteLine(state);
        }

        [TestMethod]
        public void GetPowerInformationTest()
        {
            SYSTEM_POWER_INFORMATION state = new SYSTEM_POWER_INFORMATION();
            PowerStateInterop.GetPowerInformation(state);
            Console.WriteLine(state);
        }

        [TestMethod]
        public void ReserveHiberFileTest()
        {
            PowerStateInterop.ReserveHiberFile(true);
        }

        [TestMethod]
        public void FreeHiberFileTest()
        {
            PowerStateInterop.ReserveHiberFile(false);
        }

        //[TestMethod]
        //public void HibernateSystemTest()
        //{
        //    PowerStateInterop.HibernateSystem();
        //}
    }
}
