using System;
using System.Runtime.InteropServices;

// Token: 0x02000005 RID: 5
internal static class Win32
{
	// Token: 0x0600000C RID: 12
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool AllocConsole();

	// Token: 0x0600000D RID: 13
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool SetConsoleCtrlHandler(Win32.HandlerRoutine HandlerRoutine, bool Add);

	// Token: 0x0600000E RID: 14
	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

	// Token: 0x0600000F RID: 15
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetModuleHandle(string lpModuleName);

	// Token: 0x06000010 RID: 16
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

	// Token: 0x06000011 RID: 17
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	// Token: 0x06000012 RID: 18
	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

	// Token: 0x06000013 RID: 19
	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

	// Token: 0x06000014 RID: 20
	[DllImport("wininet.dll")]
	public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

	// Token: 0x06000015 RID: 21
	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	// Token: 0x06000016 RID: 22
	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	// Token: 0x06000017 RID: 23
	[DllImport("user32.dll", SetLastError = true)]
	private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

	// Token: 0x06000018 RID: 24 RVA: 0x0000229C File Offset: 0x0000049C
	internal static IntPtr OpenProcess(int v1, bool v2, object id)
	{
		throw new NotImplementedException();
	}

	// Token: 0x04000007 RID: 7
	public const int PROCESS_CREATE_THREAD = 2;

	// Token: 0x04000008 RID: 8
	public const int PROCESS_VM_OPERATION = 8;

	// Token: 0x04000009 RID: 9
	public const int PROCESS_VM_WRITE = 32;

	// Token: 0x0400000A RID: 10
	public const int PROCESS_VM_READ = 16;

	// Token: 0x0400000B RID: 11
	public const int PROCESS_QUERY_INFORMATION = 1024;

	// Token: 0x0400000C RID: 12
	public const uint PAGE_READWRITE = 4U;

	// Token: 0x0400000D RID: 13
	public const uint MEM_COMMIT = 4096U;

	// Token: 0x0400000E RID: 14
	public const uint MEM_RESERVE = 8192U;

	// Token: 0x02000015 RID: 21
	// (Invoke) Token: 0x06000088 RID: 136
	public delegate bool HandlerRoutine(int dwCtrlType);
}
