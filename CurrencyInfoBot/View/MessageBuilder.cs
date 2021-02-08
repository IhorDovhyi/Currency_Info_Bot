using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyInfoBot.View
{
    public class MessageBuilder
    {
        string message;
        public Answer botAnswer;

        public MessageBuilder(string clientMessage)
        {
            message = clientMessage;
        }

        public Answer BotAnswer()
        {
            return botAnswer = new Answer(message).GiveAnswer();
        }        
    }
}
