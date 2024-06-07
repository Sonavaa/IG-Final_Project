namespace Instagram.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string MessageContent { get; set; }

        public int DirectId { get; set; }

        public MyDirect? Direct { get; set; }

        public string Writer { get; set; }

    }
}
