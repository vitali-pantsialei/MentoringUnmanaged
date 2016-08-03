#include <windows.h>
#include <powrprof.h>

#pragma comment(lib, "PowrProf.lib")

typedef struct _SYSTEM_POWER_INFORMATION {
	ULONG MaxIdlenessAllowed;
	ULONG Idleness;
	ULONG TimeRemaining;
	UCHAR CoolingMode;
} SYSTEM_POWER_INFORMATION, *PSYSTEM_POWER_INFORMATION;

_declspec(dllexport)
ULONGLONG GetLastSleepTime()
{
	ULONGLONG result;
	CallNtPowerInformation(LastSleepTime, NULL, 0, &result, sizeof(result));
	return result;
}

_declspec(dllexport)
ULONGLONG GetLastWakeTime()
{
	ULONGLONG result;
	CallNtPowerInformation(LastWakeTime, NULL, 0, &result, sizeof(result));
	return result;
}

_declspec(dllexport)
void GetBatteryState(SYSTEM_BATTERY_STATE result)
{
	CallNtPowerInformation(SystemBatteryState, NULL, 0, &result, sizeof(result));
}

_declspec(dllexport)
void GetPowerInformation(SYSTEM_POWER_INFORMATION result)
{
	CallNtPowerInformation(SystemPowerInformation, NULL, 0, &result, sizeof(result));
}

_declspec(dllexport)
void ReserveHiberFile(bool reserve)
{
	CallNtPowerInformation(SystemReserveHiberFile, &reserve, sizeof(reserve), NULL, 0);
}

_declspec(dllexport)
int SuspendSystem()
{
	return SetSuspendState(FALSE, FALSE, FALSE);
}

_declspec(dllexport)
int HibernateSystem()
{
	return SetSuspendState(TRUE, FALSE, FALSE);
}