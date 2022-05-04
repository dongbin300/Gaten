using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Gaten.Study.DLLInjection
{
    // 공튀기기
    // 다운로드 링크
    // https://eyapp.tistory.com/103

    // 리에로
    // 다운로드 링크
    // https://rhyshan.com/421

    // 시발마린
    // 다운로드 링크
    // https://blog.naver.com/kmi931125/130014779420
    //

    class Program
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            uint dwCreationFlags,
            IntPtr lpThreadId);

        // privileges
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;

        // used for memory allocation
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        public static bool isInjected = false;
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        static void Main(string[] args)
        {
            Execute();
        }

        public static int Inject(string dllPath, Process tProcess)
        {
            Process targetProcess = tProcess;
            string dllName = dllPath;

            // the target process
            // geting the handle of the process - with required privileges
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

            // name of the dll we want to inject
            // alocating some memory on the target process - enough to store the name of the dll
            // and storing its address in a pointer
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

            // writing the name of the dll there
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);

            // searching for the address of LoadLibraryA and storing it in a pointer
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            // creating a thread that will call LoadLibraryA with allocMemAddress as argument
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

            return 0;
        }

        public static void Execute()
        {
            string rawDLL = String.Empty;
            if (is64BitOperatingSystem)
            {
                rawDLL = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "myhack.dll");
            }
            else
            {
                rawDLL = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "h32.dll");
            }
            // Execution of injection
            Process proc = Process.GetProcessesByName("chrome")[0];
            Inject(rawDLL, proc);
            isInjected = true;
        }

        public static Boolean IsInjectedAlready()
        {
            if (isInjected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }
    }

    ///* 프로세스 핸들링 */
    //public enum ThreadAccess : int
    //{
    //    TERMINATE = 0x0001,
    //    SUSPEND_RESUME = 0x0002,
    //    GET_CONTEXT = 0x0008,
    //    SET_CONTEXT = 0x0010,
    //    SET_INFORMATION = 0x0020,
    //    QUERY_INFORMATION = 0x0040,
    //    SET_THREAD_TOKEN = 0x0080,
    //    IMPERSONATE = 0x0010,
    //    DIRECT_IMPERSONATION = 0x0020
    //}

    //[DllImport("Kernel32.dll", SetLastError = true)]
    //public static extern IntPtr OpenThread(ThreadAccess desiredAccess, bool inheritHandle, uint threadID);

    //[DllImport("Kernel32.dll", SetLastError = true)]
    //public static extern IntPtr SuspendThread(IntPtr hThread);

    //[DllImport("Kernel32.dll", SetLastError = true)]
    //public static extern int ResumeThread(IntPtr hThread);

    ///// <summary>
    ///// 실행 중인 프로세스를 일시정지합니다.
    ///// </summary>
    ///// <param name="process">프로세스</param>
    //public static void SuspendProcess(Process process)
    //{
    //    foreach (ProcessThread thread in process.Threads)
    //    {
    //        IntPtr hThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
    //        if (hThread == IntPtr.Zero)
    //            break;
    //        SuspendThread(hThread);
    //    }
    //}

    ///// <summary>
    ///// 정지 상태의 프로세스를 재개합니다.
    ///// </summary>
    ///// <param name="process">프로세스</param>
    //public static void ResumeProcess(Process process)
    //{
    //    foreach (ProcessThread thread in process.Threads)
    //    {
    //        IntPtr hThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
    //        if (hThread == IntPtr.Zero)
    //            break;
    //        ResumeThread(hThread);
    //    }
    //}

    ///* 메모리 탐색 */
    //[DllImport("Kernel32.dll", SetLastError = true)]
    //public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size, out int numberOfBytesRead);

    //[DllImport("Kernel32.dll", SetLastError = true)]
    //public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr baseAddress, byte[] buffer, int size, out int numberOfBytesWritten);


    ///// <summary>
    ///// 게임을 시작하면
    ///// 보통 초기화 작업을 게임 시작 시에 하는 경우가 많아서
    ///// 그걸 강제로 덮어쓰려고 할 때 프로세스를 시작하자마자 일단 멈추고 다른 짓을 하는 거임
    ///// 그 때 사용되는 WinAPI가 OpenThread, SuspendThread, ResumeThread임
    ///// </summary>
    ///// <param name="path">게임 EXE 파일 경로</param>
    ///// <param name="arguments">Command-Line Arguments</param>
    ///// <returns>실행 중인 프로세스</returns>
    //static Process RunApplication(string path, string arguments)
    //{
    //    var startInfo = new ProcessStartInfo(path, arguments);
    //    startInfo.WorkingDirectory = path.Substring(0, path.LastIndexOf("\\") + 1);
    //    startInfo.UseShellExecute = false;

    //    var gameProcess = new Process();
    //    gameProcess.StartInfo = startInfo;
    //    gameProcess.Start();


    //    // 이 아래에 게임 시작 시 추가적인 행동이 필요한 경우 지정
    //    if (true) // 추가적인 행동이 필요할 경우
    //    {
    //        SuspendProcess(gameProcess);

    //        // 하고 싶은 거 하삼. 예를 들면 메모리 변조
    //        int address = 0; // ㅇㅇㅇㅇ
    //        byte[] resultBuffer = new byte[4];
    //        int numberOfBytesWritten;

    //        address = 23423532;
    //        resultBuffer[0] = 12;
    //        resultBuffer[1] = 72;
    //        resultBuffer[2] = 122;
    //        resultBuffer[3] = 121;

    //        WriteProcessMemory(gameProcess.Handle, new IntPtr(address), resultBuffer, resultBuffer.Length, out numberOfBytesWritten);

    //        Console.WriteLine(numberOfBytesWritten);

    //        // 다 했으면
    //        ResumeProcess(gameProcess);

    //        gameProcess.WaitForInputIdle();
    //        // ↑ 프로세스가 유휴 상태가 될 때까지 대기.
    //        // 즉 초반 초기화 작업이 전부 진행될 때까지 대기함을 의미함.
    //        // 단순히 Thread.Sleep에 적당한 시간을 부여하는 것보다 이 메서드를 사용하는 것을 대부분 권장함.

    //        // 더 추가적인 거 할 거 있으면 하삼
    //    }
    //    // 이 위에 게임 시작 시 추가적인 행동이 필요한 경우 지정

    //    return gameProcess;
    //}
    //// 끗 ㅇㅇㅇㅇㅇㅇㅇ 굳
    //// 저런 식으로 하면 되고
    //// 실제 게임 해킹할 때는
    //// 이게 패킷 전송 (서버)이 포함되는 기능인가, 그렇지 않은가에 따라서
    //// 그리고, 단순 메모리 값 변경 (WriteProcessMemory 등) 만으로 원하는 기능이 되는가 여부에 따라
    //// DLL Injection을 사용할지 말지를 결정하게 됨.


    //// 다음은 프로세스 분석 부분임


    //static void Main(string[] args)
    //{
    //    string path = @"C:\notepad.exe";
    //    string arguments = "-w";
    //    var process = RunApplication(path, arguments);

    //    // 보통 게임핵 같은 거 만들 때
    //    // 메모리 변조랑
    //    // 함수 실행이랑
    //    // 유저 입력 대신하는 기능
    //    // 3가지 정도를 구현하는데

    //    // 그 중에서 유저 입력을 어떻게 대신하냐 하면
    //    // Spy++ 켜서 메시지 로그 띄워놓고
    //    // 내가 실제 입력할 때 무슨 일 발생하는지 확인한 다음 그대로 메시지를 날림

    //    // 2번째로 메모리 변조는
    //    // 전에 제가 맛보기로 보여준 치트엔진 이용하는 방법
    //    // + 짧은 시간 안에 마구 변하거나,,, 복잡한 게산이 필요한 경우는 직접 프로그램 만든 후 ReadProcessMemory를 이용해서 어드레스 확인 후 구현

    //    // 3번째 함수 실행은 DLL Injection을 통해서 구현함.
    //    // https://reversecore.com/38

    //    // 매우 중요한 게 한 가지 있음
    //    // 프로젝트 설정에서
    //    // 만약 대상 어플리케이션이 Win32일 경우
    //    // x86으로 맞춰주고 시작해야 함
    //    // 그렇지 않으면 WinAPI 호출 시에 예기치 않은 상황이 발생함
    //    // GetLastError 호출해도 정확한 에러 코드가 안 나와서 헤매게 됨
    //    // (레스맨의 경험담이라 함)
    //    // (;;;;;;)
    //}
}
