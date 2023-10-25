using ImagesTelegramBot.TelegramgBot;
using ImgesTelegramBot.DataBase;
using ImgesTelegramBot.Pinterest;



//PinterestTest test = new PinterestTest();

//test.Open();
//test.SignIn("vladkniga36@gmail.com", "4UL-g4D-zJ9-5iX");
//test.Search("программирование");
//var html = test.GetHtmlPage();
//test.Close();

//Console.Clear();

//ParsePinterest parsePinterest = new ParsePinterest(html);

//Console.WriteLine(string.Join("\n", parsePinterest.LinksToImages));

//parsePinterest.DownloadImage(parsePinterest.LinksToImages[^2]);


//using (ImagesBotContext context = new ImagesBotContext())
//{
//    context.Users.RemoveRange(context.Users.Where(i => i.IsAdmin == false).ToArray());
//    context.SaveChanges();
//}


TgBot tgBot = new TgBot("6552947325:AAFzzYMGI6d4sMMhE_GRzjQ8U8sE35OE5Ko");
tgBot.Start();

Console.ReadLine();