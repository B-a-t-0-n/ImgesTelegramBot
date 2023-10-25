namespace ImgesTelegramBot.DataBase
{
    public class UserRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Request { get; set; }
        public DateTime Date { get; set; }
    }
}
