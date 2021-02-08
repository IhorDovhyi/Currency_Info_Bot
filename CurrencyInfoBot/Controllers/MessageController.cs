using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyInfoBot.Models;
using CurrencyInfoBot.Models.Commands;
using CurrencyInfoBot.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace CurrencyInfoBot.Controllers
{
    [Route("Bot/message")]
    public class MessageController : Controller
    {
        StrategyFactory strategyFactory;

        [HttpGet]
        public string Get()
        {
            return $"Ready to work"; 
        }

        public async Task Messege(Message message, TelegramBotClient botClient)
        {
            if (message.Text != null)
            {
                strategyFactory = new StrategyFactory(message.Text);
                await strategyFactory.Strategy().Execute(message,botClient);
            }
        }
    }
}
