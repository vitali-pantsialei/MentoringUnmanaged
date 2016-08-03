using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerStateManager
{
    [ComVisible(true)]
    [Guid("F4E0B4EE-F660-4ED9-A290-CDB0254E3E7B")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IPowerState
    {
        long GetLastSleepTime();
        long GetLastWakeTime();
        void GetBatteryState(out SYSTEM_BATTERY_STATE result);
        void GetPowerInformation(out SYSTEM_POWER_INFORMATION result);
        void ReserveHiberFile(bool reserve);
        void SuspendSystem();
        void HibernateSystem();
    }
}
