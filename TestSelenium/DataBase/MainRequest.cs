namespace ImgesTelegramBot.DataBase
{
    public class MainRequest
    {
        public int Id {  get; set; }
        public string Request { get; set; }
        public DateTime Time { get; set; }
        public List<Image> Images { get; set; }
    }
}
