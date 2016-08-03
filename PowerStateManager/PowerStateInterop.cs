using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerStateManager
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_BATTERY_STATE
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VarEnum.VT_BOOL)]
        public bool[] Spare1;
        
        public byte Tag;

        public uint MaxCapacity;
        public uint RemainingCapacity;
        public uint Rate;
        public uint EstimatedTime;

        public uint DefaultAlert1;
        public uint DefaultAlert2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_POWER_INFORMATION
    {
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public Char CoolingMode;
    }

    internal class PowerStateInterop
    {
        [DllImport("PowerManagement.dll", EntryPoint = "?GetLastSleepTime@@YA_KXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetLastSleepTime();

        [DllImport("PowerManagement.dll", EntryPoint = "?GetLastWakeTime@@YA_KXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern long GetLastWakeTime();

        [DllImport("PowerManagement.dll", EntryPoint = "?GetBatteryState@@YAXUSYSTEM_BATTERY_STATE@@@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetBatteryState(out SYSTEM_BATTERY_STATE result);

        [DllImport("PowerManagement.dll", EntryPoint = "?GetPowerInformation@@YAXU_SYSTEM_POWER_INFORMATION@@@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPowerInformation(out SYSTEM_POWER_INFORMATION result);

        [DllImport("PowerManagement.dll", EntryPoint = "?ReserveHiberFile@@YAX_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReserveHiberFile(bool reserve);

        [DllImport("PowerManagement.dll", EntryPoint = "?SuspendSystem@@YAHXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SuspendSystem();

        [DllImport("PowerManagement.dll", EntryPoint = "?HibernateSystem@@YAHXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HibernateSystem();
    }
}
