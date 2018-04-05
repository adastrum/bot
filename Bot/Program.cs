using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace Bot
{
    internal class Program
    {
        private static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var token = configuration["token"];
            var client = new TelegramBotClient(token);
            var bot = new Bot(client);
            bot.Start();
            Console.ReadLine();
            bot.Stop();
        }
    }
}
