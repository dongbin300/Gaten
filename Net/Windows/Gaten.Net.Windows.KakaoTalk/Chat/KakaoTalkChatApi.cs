using System.Diagnostics;
using System.Text;

using static Gaten.Net.Windows.WinApi;

namespace Gaten.Net.Windows.KakaoTalk.Chat
{
    public class KakaoTalkChatApi
    {
        static readonly object Clipboard = new object();

        public static string GetRoomName(KakaoTalkChatWindow window)
        {
            var chatListHandle = FindChatListHandle(window);
            int capacity = SendMessage(chatListHandle, WM_GETTEXTLENGTH, 0, 0);
            var buffer = new StringBuilder(capacity);
            SendMessageGetTextW(chatListHandle, WM_GETTEXT, capacity + 1, buffer);

            return buffer.ToString();
        }

        public static List<KakaoTalkChatMessage>? GetChatMessage(KakaoTalkChatWindow window, bool backupClipboardData = false)
        {
            var chatListHandle = FindChatListHandle(window);

            string? messageString = null;
            bool isClipboardAvailable = true;
            List<KakaoTalkChatMessage>? messages = null;
            SendMessage(chatListHandle, 0x7E9, 0x65, 0); // 메시지 전체 선택
            Thread.Sleep(20);

            lock (Clipboard)
            {
                try
                {
                    if (backupClipboardData) ClipboardManager.BackupData(window.Handle);
                    SendMessage(chatListHandle, 0x7E9, 0x64, 0); // 메시지 복사
                    Thread.Sleep(20);
                    messageString = ClipboardManager.GetText(window.Handle);
                    if (backupClipboardData) ClipboardManager.RestoreData(window.Handle);
                }
                catch (ClipboardManager.CannotOpenException) { isClipboardAvailable = false; }
            }

            if (isClipboardAvailable)
            {
                string[] messageStrings = messageString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                messages = new List<KakaoTalkChatMessage>();
                for (int i = 0; i < messageStrings.Length; i++)
                {
                    var message = new KakaoTalkChatMessage(messageStrings[i]);
                    if (message.Type == MessageType.Unknown) break;
                    messages.Add(message);
                }
            }

            return messages;

            //SendMessage(chatListHandle, 0x7E9, 0x65, 0); // 메시지 전체 선택
            //Thread.Sleep(20);

            //SendMessage(chatListHandle, 0x7E9, 0x64, 0); // 메시지 복사
            //Thread.Sleep(20);
            //var messageString = ClipboardManager.GetText(window.Handle);

            //string[] messageStrings = messageString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //var messages = new List<KakaoTalkChatMessage>();
            //for (int i = 0; i < messageStrings.Length; i++)
            //{
            //    var message = new KakaoTalkChatMessage(messageStrings[i]);
            //    if (message.Type == MessageType.Unknown) break;
            //    messages.Add(message);
            //}

            //return messages;
        }

        public static void SendChatMessage(KakaoTalkChatWindow window, string text)
        {
            var editMessageHandle = GetWindow(window.Handle, GW_CHILD);
            SendMessageW(editMessageHandle, WM_SETTEXT, 0, text);
            Thread.Sleep(100);
            PressKeyInBackground(editMessageHandle, KeyCode.VK_ENTER);
            Thread.Sleep(100);
        }

        private static IntPtr FindChatListHandle(KakaoTalkChatWindow window)
        {
            return FindWindowEx(window.Handle, IntPtr.Zero, "EVA_VH_ListControl_Dblclk", "");
        }

        public static RECT GetChatListRect(KakaoTalkChatWindow window)
        {
            var chatListHandle = FindChatListHandle(window);
            var rect = GetWindowRect(chatListHandle);
            return rect;
        }

        public static void SetWindowSize(KakaoTalkChatWindow window)
        {
            //MoveWindow(window.Handle, )
        }


        //public static void ReopenChatRoom(KakaoTalkChatWindow window, bool minimizeWindow = false)
        //{
        //    if (IsOpen(window))
        //    {
        //        Close(window);
        //    } 
        //    MainWindow.ChangeTabTo(MainWindowTab.Chatting);
        //    KakaoTalkChatWindow newWindowInfo = _StartChattingAt(window.ChatRoomName, minimizeWindow, this);
        //    RootHandle = newWindowInfo.RootHandle;
        //    EditMessageHandle = newWindowInfo.EditMessageHandle;
        //    SearchWordsHandle = newWindowInfo.SearchWordsHandle;
        //    ChatListHandle = newWindowInfo.ChatListHandle;
        //}

        //internal KakaoTalkChatWindow _StartChattingAt(KakaoTalkChatWindow window, bool minimizeWindow, KakaoTalkChatWindow previousWindow)
        //{
        //    ClearSearchResult();
        //    SearchByRoomName(window.ChatRoomName);
        //    WinAPI.ClickInBackground(SearchResultListHandle, WinAPI.MouseButton.Left, FirstSearchItemX, FirstSearchItemY);
        //    Thread.Sleep(MouseClickInterval);
        //    KakaoTalkChatWindow chatRoom = null;
        //    lock (ChatWindows)
        //    {
        //        WinAPI.PressKeyInBackground(SearchResultListHandle, WinAPI.KeyCode.VK_ENTER);
        //        while (!IsOpen(roomName)) Thread.Sleep(ProgressCheckInterval);
        //        if (previousWindow == null)
        //        {
        //            chatRoom = new KakaoTalkChatWindow(roomName);
        //            if (minimizeWindow) chatRoom.Minimize();
        //            ChatWindows.Add(chatRoom);
        //        }
        //        else chatRoom = new KakaoTalkChatWindow(roomName, false);
        //    }
        //    ClearSearchResult();

        //    return chatRoom;
        //}

        //public void ClearSearchResult()
        //{
        //    WinAPI.SetEditText(SearchHandle, "", WinAPI.Encoding.Unicode);
        //    Thread.Sleep(UIChangeInterval);
        //}

        //public void SearchByRoomName(string roomName)
        //{
        //    WinAPI.SetEditText(SearchHandle, roomName, WinAPI.Encoding.Unicode);
        //    Thread.Sleep(UIChangeInterval);
        //}

        //private static bool IsOpen(KakaoTalkChatWindow window)
        //{
        //    return FindWindow("#32770", window.ChatRoomName) == window.Handle ? true : false;
        //}

        //private void Close(KakaoTalkChatWindow window)
        //{
        //    if (!IsOpen(window)) return;
        //    lock (window)
        //    {
        //        PressKeyInBackground(window.Handle, KeyCode.VK_ESC);
        //        Thread.Sleep(100);
        //    }
        //    int interval = 100;
        //    Thread.Sleep(interval > 0 ? interval : 0);
        //}

        /// <summary>
        /// Get Opened KakaoTalk Chat Windows.
        /// </summary>
        /// <returns></returns>
        public static List<KakaoTalkChatWindow> GetChatWindows(string chatRoomTitle)
        {
            var results = new List<KakaoTalkChatWindow>();

            //var processes = GetWindowProcesses("KakaoTalk");
            //foreach(var process in processes)
            //{
            //    results.Add(new KakaoTalkChatWindow
            //    {
            //        Handle = process.MainWindowHandle
            //    });
            //}

            IntPtr hWnd = IntPtr.Zero;
            while (true)
            {
                hWnd = FindWindowEx(IntPtr.Zero, hWnd, null, chatRoomTitle);
                if (hWnd == IntPtr.Zero)
                {
                    break;
                }
                results.Add(new KakaoTalkChatWindow
                {
                    Handle = hWnd
                });
            }

            return results;
        }

        static List<Process> GetWindowProcesses(string processName = "")
        {
            List<Process> result = new List<Process>();
            var processes = processName == "" ? Process.GetProcesses() : Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                if (process.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(process.MainWindowTitle) && process.Responding)
                {
                    result.Add(process);
                }
            }
            return result;
        }
    }
}
