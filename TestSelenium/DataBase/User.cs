namespace ImgesTelegramBot.DataBase
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long ChatId { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserRequest> Requests { get; set; } = new List<UserRequest>();
    }
}
