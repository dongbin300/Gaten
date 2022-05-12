using System.Text;

namespace Gaten.Study.AiChat
{
    public class KakaoTalkChatLog
    {
        public string with;
        public DateTime saveTime;
        public List<KakaoTalkMessage> messages = new List<KakaoTalkMessage>();

        public KakaoTalkChatLog(string[] chatData)
        {
            try
            {
                with = chatData[0].Replace("님과 카카오톡 대화", "").Trim();
                saveTime = DateTime.Parse(chatData[1].Replace("저장한 날짜 : ", "").Trim());

                string today = string.Empty;

                for (int i = 3; i < chatData.Length; i++)
                {
                    if (chatData[i].Contains("["))
                    {
                        string[] contents = chatData[i].Split(']').Select(x => x.Trim()).ToArray();
                        if (contents[2].Equals("사진") || contents[2].Equals("이모티콘"))
                            continue;

                        messages.Add(new KakaoTalkMessage()
                        {
                            sender = contents[0].Replace("[", ""),
                            sendTime = DateTime.Parse(today + " " + contents[1].Replace("[", "")),
                            data = contents[2]
                        });
                    }
                    else
                    {
                        if (chatData[i].Split(new string[] { "초대", "들", "나" }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
                            continue;
                        today = chatData[i].Replace("-", "").Trim();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
