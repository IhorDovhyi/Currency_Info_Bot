using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Linq;

namespace CurrencyInfoBot.Models.Commands
{
    public class HelloCommandStrategy : ICommandStrategy
    {
        private string _message;

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, _message, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }

        public void SetMessage(string message)
        {
            _message = message;
        }
    }
}
