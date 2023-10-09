using ImgesTelegramBot.Pinterest;

PinterestTest test = new PinterestTest();

test.Open();
test.SignIn("vladkniga36@gmail.com", "4UL-g4D-zJ9-5iX");
test.Search("Доброе утро");
var html = test.GetHtmlPage();
test.Close();

Console.Clear();

ParsePinterest parsePinterest = new ParsePinterest(html);

Console.WriteLine(string.Join("\n", parsePinterest.LinksToImages));

parsePinterest.DownloadImage(parsePinterest.LinksToImages[^2]);

Console.ReadLine();