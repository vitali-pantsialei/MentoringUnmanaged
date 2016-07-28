#include <windows.h>
#include <powrprof.h>

typedef struct _SYSTEM_POWER_INFORMATION {
	ULONG MaxIdlenessAllowed;
	ULONG Idleness;
	ULONG TimeRemaining;
	UCHAR CoolingMode;
} SYSTEM_POWER_INFORMATION, *PSYSTEM_POWER_INFORMATION;

ULONGLONG GetLastSleepTime()
{
	ULONGLONG result;
	CallNtPowerInformation(LastSleepTime, NULL, 0, &result, sizeof(result));
	return result;
}

ULONGLONG GetLastWakeTime()
{
	ULONGLONG result;
	CallNtPowerInformation(LastWakeTime, NULL, 0, &result, sizeof(result));
	return result;
}

SYSTEM_BATTERY_STATE GetBatteryState()
{
	SYSTEM_BATTERY_STATE result;
	CallNtPowerInformation(SystemBatteryState, NULL, 0, &result, sizeof(result));
	return result;
}

SYSTEM_POWER_INFORMATION GetPowerInformation()
{
	SYSTEM_POWER_INFORMATION result;
	CallNtPowerInformation(SystemPowerInformation, NULL, 0, &result, sizeof(result));
	return result;
}

void ReserveHiberFile(bool reserve)
{
	CallNtPowerInformation(SystemReserveHiberFile, &reserve, sizeof(reserve), NULL, 0);
}

int SuspendSystem()
{
	return SetSuspendState(false, false, false);
}

int HibernateSystem()
{
	return SetSuspendState(true, false, false);
}