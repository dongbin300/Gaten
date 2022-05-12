namespace Gaten.Study.AiChat
{
    public class Message
    {
        public enum Sender { Ai, Human }
        public Sender sender;
        public string data;

        public Message(string data, Sender sender)
        {
            this.data = data;
            this.sender = sender;
        }
    }
}