using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CurrencyInfoBot.Models.Client;
using CurrencyInfoBot.Models.Currency;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyInfoBot.Models.Commands
{
    public class CurrencyStrategy : ICommandStrategy
    {
        string response;
        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, this.response, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }

        public void SetMessage(string message)
        {
            this.response = message;
        }
    }
}
