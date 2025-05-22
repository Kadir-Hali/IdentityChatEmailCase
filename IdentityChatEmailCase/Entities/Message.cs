namespace IdentityChatEmailCase.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
