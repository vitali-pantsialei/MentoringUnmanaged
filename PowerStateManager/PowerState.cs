using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerStateManager
{
    [ComVisible(true)]
    [Guid("02D394FE-DF2F-463A-9445-FD41AEDFF6E1")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerState : IPowerState
    {
        public int GetLastSleepTime()
        {
            return PowerStateInterop.GetLastSleepTime();
        }

        public int GetLastWakeTime()
        {
            return PowerStateInterop.GetLastWakeTime();
        }

        public void GetBatteryState(out SYSTEM_BATTERY_STATE result)
        {
            PowerStateInterop.GetBatteryState(out result);
        }

        public void GetPowerInformation(out SYSTEM_POWER_INFORMATION result)
        {
            PowerStateInterop.GetPowerInformation(out result);
        }

        public void ReserveHiberFile(bool reserve)
        {
            PowerStateInterop.ReserveHiberFile(reserve);
        }

        public void SuspendSystem()
        {
            PowerStateInterop.SuspendSystem();
        }

        public void HibernateSystem()
        {
            PowerStateInterop.HibernateSystem();
        }
    }
}
