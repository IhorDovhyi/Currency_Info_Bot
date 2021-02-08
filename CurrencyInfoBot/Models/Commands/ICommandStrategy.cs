using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace CurrencyInfoBot.Models.Commands
{
    public interface ICommandStrategy
    {
        public Task Execute(Message message, TelegramBotClient botClient);
        public void SetMessage(string message);

    }
}
