namespace ImgesTelegramBot.DataBase
{
    public class UserRequest
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public string Request { get; set; }
        public DateTime Date { get; set; }
    }
}
