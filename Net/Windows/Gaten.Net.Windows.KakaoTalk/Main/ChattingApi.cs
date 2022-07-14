using Gaten.Net.Windows.KakaoTalk.Chat;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaten.Net.Windows.KakaoTalk.Main
{
    /// <summary>
    /// 메인 창의 채팅 탭을 제어할 수 있도록 만들어진 클래스입니다.
    /// </summary>
    public class ChattingTab
    {
        // 변경해선 안 되는 상수값 목록
        const short FirstSearchItemX = 86;
        const short FirstSearchItemY = 36;

        // 핸들 목록
        IntPtr RootHandle { get; }
        IntPtr SearchHandle { get; }
        IntPtr ChatRoomListHandle { get; }
        IntPtr SearchResultListHandle { get; }

        internal ChattingTab(IntPtr hChattingTab, IntPtr rootHandle)
        {
            RootHandle = rootHandle;
            SearchHandle = WinApi.GetWindow(hChattingTab, WinApi.GW_CHILD);
            ChatRoomListHandle = WinApi.GetWindow(SearchHandle, WinApi.GW_HWNDNEXT);
            SearchResultListHandle = WinApi.GetWindow(ChatRoomListHandle, WinApi.GW_HWNDNEXT);
        }

        /// <summary>
        /// 기존 채팅방 중에서 해당 이름을 가진 채팅방을 검색합니다.
        /// </summary>
        /// <param name="roomName">검색할 채팅방 이름</param>
        public void SearchByRoomName(string roomName)
        {
            WinApi.SetEditText(SearchHandle, roomName, WinApi.Encoding.Unicode);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// 채팅방 탭의 검색 결과를 초기화합니다.
        /// </summary>
        public void ClearSearchResult()
        {
            WinApi.SetEditText(SearchHandle, "", WinApi.Encoding.Unicode);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// 해당 이름을 가진 채팅방에서 대화를 시작합니다. (채팅방 이름은 정확히 일치해야 합니다)<para/>
        /// 만약 내가 만든 오픈채팅방일 경우에는, 해당 방의 메뉴 아이콘 클릭 -> 채팅방 설정 클릭 후 채팅방 이름을 변경해주어야 정상 작동합니다.
        /// </summary>
        /// <param name="roomName">검색할 채팅방 이름</param>
        /// <param name="minimizeWindow">채팅 시작 후, 바로 채팅창을 최소화할지 여부</param>
        //public KakaoTalkChatWindow StartChattingAt(string roomName, bool minimizeWindow = false)
        //{
        //    return _StartChattingAt(roomName, minimizeWindow, null);
        //}

        //internal KakaoTalkChatWindow _StartChattingAt(KakaoTalkChatWindow window, bool minimizeWindow, KakaoTalkChatWindow previousWindow)
        //{
        //    ClearSearchResult();
        //    SearchByRoomName(window.ChatRoomName);
        //    WinAPI.ClickInBackground(SearchResultListHandle, WinAPI.MouseButton.Left, FirstSearchItemX, FirstSearchItemY);
        //    Thread.Sleep(200);
        //    KakaoTalkChatWindow chatRoom = null;
        //    lock (window)
        //    {
        //        WinAPI.PressKeyInBackground(SearchResultListHandle, WinAPI.KeyCode.VK_ENTER);
        //        while (!KakaoTalkChatApi.isch IsChatRoomOpen(window.ChatRoomName)) Thread.Sleep(20);
        //        if (previousWindow == null)
        //        {
        //            chatRoom = new KakaoTalkChatWindow(window.ChatRoomName);
        //            if (minimizeWindow) chatRoom.Minimize();
        //            ChatWindows.Add(chatRoom);
        //        }
        //        else chatRoom = new KakaoTalkChatWindow(window.ChatRoomName, false);
        //    }
        //    ClearSearchResult();

        //    return chatRoom;
        //}
    }
}
