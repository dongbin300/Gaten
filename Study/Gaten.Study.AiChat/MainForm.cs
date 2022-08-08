using Gaten.Net.IO;

namespace Gaten.Study.AiChat
{
    public partial class MainForm : Form
    {
        List<Message> messages = new List<Message>();
        KakaoTalkChatLog log;

        public MainForm()
        {
            InitializeComponent();
            log = new KakaoTalkChatLog(GResource.GetTextLines("aic-test.txt"));
        }

        /// <summary>
        /// 메시지 보내기
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sender"></param>
        void SendMessage(string message, Message.Sender sender)
        {
            messages.Add(new Message(message, sender));
            ChatPanel.Refresh();
            AiReact(message);
        }

        /// <summary>
        /// AI의 반응
        /// </summary>
        /// <param name="message"></param>
        void AiReact(string message)
        {
            List<int> messageIndexes = new List<int>();
            for (int i = 0; i < log.messages.Count; i++)
            {
                if (log.messages[i].data.Contains(message))
                {
                    messageIndexes.Add(i);
                }
            }

            var aiMessage = messageIndexes.Count == 0 ?
                new Message(log.messages[new Random().Next(log.messages.Count - 1)].data, Message.Sender.Ai) :
                new Message(log.messages[messageIndexes[new Random().Next(messageIndexes.Count)] + 1].data, Message.Sender.Ai);

            messages.Add(aiMessage);
            ChatPanel.Refresh();
        }

        /// <summary>
        /// 메시지 텍스트박스 키 입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    if (messageTextBox.Text.Length > 0)
                        SendMessage(messageTextBox.Text, Message.Sender.Human);
                    messageTextBox.Clear();
                    break;
            }
        }

        /// <summary>
        /// 화면 새로고침
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatPanel_Paint(object sender, PaintEventArgs e)
        {
            int p = 0;
            foreach (Message msg in messages)
            {
                if (msg.sender == Message.Sender.Ai)
                {
                    Vision.DrawMessage(e, 20, 10 + p * 25, msg.data, false);
                }
                else
                {
                    Vision.DrawMessage(e, 320 - Vision.GetPixelSize(msg.data), 10 + p * 25, msg.data, true);
                }
                p++;
            }
        }

        /// <summary>
        /// 채팅창 지우기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            messages.Clear();
            ChatPanel.Refresh();
        }
    }
}