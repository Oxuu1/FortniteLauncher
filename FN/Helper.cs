using System;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x02000003 RID: 3
internal static class Helper
{
	// Token: 0x0600000A RID: 10 RVA: 0x0000220C File Offset: 0x0000040C
	public static void InjectDll(int processId, string path)
	{
		IntPtr hProcess = Win32.OpenProcess(1082, false, processId);
		IntPtr procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
		uint num = (uint)((path.Length + 1) * Marshal.SizeOf(typeof(char)));
		IntPtr intPtr = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, num, 12288U, 4U);
		UIntPtr uintPtr;
		Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(path), num, out uintPtr);
		Win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
	}
}
