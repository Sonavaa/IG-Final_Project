namespace Instagram.Models
{
    public class MyDirect
    {
        public int Id { get; set; }

        public string TheOtherWriterId { get; set; }

        public AppUser? TheOtherWriter { get; set; }

        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public List<Message>? AllMessages { get; set; }
    }
}
