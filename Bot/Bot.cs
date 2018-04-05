using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace Bot
{
    internal class Bot
    {
        private readonly ITelegramBotClient _client;

        public Bot(ITelegramBotClient client)
        {
            _client = client;
            client.OnMessage += OnMessage;
        }

        private async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message?.Type == MessageType.TextMessage)
            {
                await _client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }

        public void Start()
        {
            _client.StartReceiving();
        }

        public void Stop()
        {
            _client.StopReceiving();
        }
    }
}