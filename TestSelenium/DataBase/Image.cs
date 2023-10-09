namespace ImgesTelegramBot.DataBase
{
    public class Image
    {
        public int Id{ get; set; }
        public string Link { get; set; }
        public int MainRequestId { get; set; }
        public MainRequest MainRequest { get; set; }
    }
}
