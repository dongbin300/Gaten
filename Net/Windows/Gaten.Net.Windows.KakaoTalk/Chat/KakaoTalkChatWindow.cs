namespace Gaten.Net.Windows.KakaoTalk.Chat
{
    public class KakaoTalkChatWindow
    {
        public IntPtr Handle { get; set; }
        public string ChatRoomName { get; set; } = string.Empty;
        public string MyNickname { get; set; } = string.Empty;
        public List<string> AdminNicknames { get; set; } = new();
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
        KoreanName,
        Test
    }
}