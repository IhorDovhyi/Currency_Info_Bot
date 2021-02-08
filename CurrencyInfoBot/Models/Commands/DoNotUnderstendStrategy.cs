using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyInfoBot.Models.Commands
{
    public class DoNotUnderstendStrategy : ICommandStrategy
    {
        string message = "I do not understand\nEnter currency type and date\nExample(currency dd.mm.yyyy)";

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, this.message, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }

        public void SetMessage(string message)
        {
            this.message = "I do not understand\nEnter currency type and date\nExample(currency dd.mm.yyyy)";
        }
    }
}
