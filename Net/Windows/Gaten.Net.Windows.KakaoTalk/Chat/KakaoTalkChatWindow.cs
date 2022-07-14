namespace Gaten.Net.Windows.KakaoTalk.Chat
{
    public class KakaoTalkChatWindow
    {
        public IntPtr Handle { get; set; }
        public string ChatRoomName { get; set; }
        public string MyNickname { get; set; }
        public List<string> AdminNicknames { get; set; }
        public BotMode BotMode { get; set; }

        public KakaoTalkChatWindow()
        {

        }
    }

    public enum BotMode
    {
        None,
        Parrot,
        Blind,
        Export,
        Encrypt,
        KoreanName
    }
}