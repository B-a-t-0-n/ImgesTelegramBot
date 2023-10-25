using ImgesTelegramBot.DataBase;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = ImgesTelegramBot.DataBase.User;

namespace ImagesTelegramBot.TelegramgBot
{
    internal class TgBot
    {
        public ITelegramBotClient bot;
        private string infoComand = "Команды ::\n" +
                                    "/картинки - позволятет прислать картинку по запосу\n" +
                                    "/инструкция - показывает все доступные команды";

        public TgBot(string token) 
        {
            bot = new TelegramBotClient(token);
        }

        public void Start()
        {
            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);

            //while (true)
            //{
            //    bot.SendTextMessageAsync(1785002367, "как дела у Артёмки");
            //    Thread.Sleep(4000);
            //}
        }

        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            if(!string.IsNullOrEmpty(message.Text)) 
            {
                await MessageTextAsync(message);
                await Console.Out.WriteLineAsync($"name :: {message.Chat.FirstName}\n" +
                                                 $"id :: {message.Chat.Id}\n" +
                                                 $"message :: {message.Text}\n" +
                                                 $"------------------------------------------");
            }
        }

        private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private async Task MessageTextAsync(Message message)
        {
            switch (message.Text)
            {
                case "/start":
                    AddNewUser(message);
                    await bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "данный бот присылает картинки в течении дня, а так же может присылать картинки по запросу\n" + infoComand
                        );
                    break;
                case "/картинки":
                    await bot.SendTextMessageAsync(message.Chat.Id, "введите название картинки");
                    break;
                case "/info":
                    await bot.SendTextMessageAsync(message.Chat.Id, infoComand);
                    break;
            }
        }

        private void AddNewUser(Message message)
        {
            using(ImagesBotContext context = new ImagesBotContext())
            {
                User user = new User() 
                {
                    Name = message.Chat.FirstName,
                    ChatId = message.Chat.Id,
                    IsAdmin = false,
                };

                if (!context.Users.All(i => i.ChatId == user.ChatId))
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("пользователь успешно добавлен");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
       
    }
}
