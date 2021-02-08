using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using CurrencyInfoBot.Models.Commands;
using CurrencyInfoBot.Controllers;

namespace CurrencyInfoBot.Models
{
    public class Bot
    {
        public static TelegramBotClient botClient;
        public static MessageController messageController = new MessageController();

        public async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }
            else
            {
                return CreateBot();
            }
        }

        public TelegramBotClient CreateBot()
        {
            botClient = new TelegramBotClient(new BotSettings().Token);
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            return botClient;
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                await messageController.Messege(e.Message, botClient);
            }
        }
    }
}