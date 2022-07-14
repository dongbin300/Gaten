namespace Gaten.Net.Windows.KakaoTalk.Chat
{
    public enum MessageType 
    { 
        Unknown, 
        DateChange, 
        UserJoin, 
        UserLeave, 
        Talk,
        Blind
    }

    public class KakaoTalkChatMessage
    {
        /// <summary>
        /// 해당 메시지의 타입. 타입은 KakaoTalk.MessageType 을 참고하세요.
        /// </summary>
        public MessageType Type { get; }
        /// <summary>
        /// 해당 메시지를 보낸 유저의 이름
        /// </summary>
        public string UserName { get; }
        /// <summary>
        /// 해당 메시지의 내용
        /// </summary>
        public string Content { get; }

        public KakaoTalkChatMessage(string fullContent)
        {
            Type = GetMessageType(fullContent);
            UserName = GetUserName(fullContent, Type);
            Content = GetContent(fullContent, Type, UserName);
        }

        public override string ToString()
        {
            string type = "";
            switch (Type)
            {
                case MessageType.DateChange:
                    type = "DateChange";
                    break;
                case MessageType.UserJoin:
                    type = "UserJoin";
                    break;
                case MessageType.UserLeave:
                    type = "UserLeave";
                    break;
                case MessageType.Talk:
                    type = "Talk";
                    break;
                case MessageType.Blind:
                    type = "Blind";
                    break;
            }

            return $"Type : {type}, Username : {UserName}, Content : {Content}";
        }

        private static MessageType GetMessageType(string fullContent)
        {
            // ????년 ?월 ?일 ?요일 => MessageType.DateTime
            // 홍길동님이 들어왔습니다. => MessageType.UserJoin
            // 홍길동나갔습니다. => MessageType.UserLeave
            // [홍길동] [오? ?(?):??] 입력문장 => MessageType.Talk

            if (fullContent.IndexOf("20") == 0)
            {
                if (fullContent.IndexOf("년 ") == 4)
                {
                    if (fullContent.IndexOf("월 ") == 7 || fullContent.IndexOf("월 ") == 8)
                    {
                        if (fullContent.IndexOf("일 ") == 10 ||
                            fullContent.IndexOf("일 ") == 11 ||
                            fullContent.IndexOf("일 ") == 12)
                        {
                            if ((fullContent.IndexOf("요일") == 13 && fullContent.Length == 15) ||
                                (fullContent.IndexOf("요일") == 14 && fullContent.Length == 16) ||
                                (fullContent.IndexOf("요일") == 15 && fullContent.Length == 17))
                            {
                                return MessageType.DateChange;
                            }
                        }
                    }
                }
            }

            if (fullContent.Contains("님이 들어왔습니다.") && fullContent.IndexOf("님이 들어왔습니다.") == fullContent.Length - 10)
            {
                if (!(fullContent.IndexOf("[") == 0 && fullContent.Contains("] [오") && fullContent.Contains("] ")))
                {
                    return MessageType.UserJoin;
                }
            }

            if (fullContent.Contains("나갔습니다.") && fullContent.IndexOf("나갔습니다.") == fullContent.Length - 6)
            {
                if (!(fullContent.IndexOf("[") == 0 && fullContent.Contains("] [오") && fullContent.Contains("] ")))
                {
                    return MessageType.UserLeave;
                }
            }

            if (fullContent.IndexOf("[") == 0)
            {
                if (fullContent.Contains("] [오"))
                {
                    if (fullContent.Contains("] "))
                    {
                        return MessageType.Talk;
                    }
                }
            }

            if(fullContent.Contains("메시지를 가렸습니다."))
            {
                if (!(fullContent.IndexOf("[") == 0 && fullContent.Contains("] [오") && fullContent.Contains("] ")))
                {
                    return MessageType.Blind;
                }
            }

            return MessageType.Unknown;
        }

        private static string GetUserName(string fullContent, MessageType type)
        {
            switch (type)
            {
                case MessageType.UserJoin:
                    return fullContent.Substring(0, fullContent.LastIndexOf("님이 들어왔습니다."));
                case MessageType.UserLeave:
                    return fullContent.Substring(0, fullContent.LastIndexOf("나갔습니다."));
                case MessageType.Talk:
                    return fullContent.Substring(1, fullContent.IndexOf("] [오") - 1);
                default:
                    return null;
            }
        }

        private static string GetContent(string fullContent, MessageType type, string Username)
        {
            switch (type)
            {
                case MessageType.DateChange:
                    return string.Format("오늘은 {0}입니다.", fullContent);
                case MessageType.UserJoin:
                    return Username + "님이 들어왔습니다.";
                case MessageType.UserLeave:
                    return Username + "님이 나갔습니다.";
                case MessageType.Talk:
                    string temp = fullContent.Substring(Username.Length + 2);
                    return temp.Substring(temp.IndexOf("] ") + 2);
                case MessageType.Blind:
                    return fullContent;
                default:
                    return null;
            }
        }
    }
}
