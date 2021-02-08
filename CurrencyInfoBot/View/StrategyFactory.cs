using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyInfoBot.Models.Commands;

namespace CurrencyInfoBot.View
{
    public class StrategyFactory
    {
        ICommandStrategy strategy;
        MessageBuilder messageBuilder;
        public StrategyFactory(string clientMessage)
        {
            messageBuilder = new MessageBuilder(clientMessage);
        }
        public ICommandStrategy Strategy()
        {
            switch (messageBuilder.BotAnswer().answerID)
            {
                case 1:
                    {
                        strategy = new HelloCommandStrategy();
                        strategy.SetMessage(messageBuilder.botAnswer.answer);
                        return strategy;
                    }
                case 2:
                    {
                        strategy = new CurrencyStrategy();
                        strategy.SetMessage(messageBuilder.botAnswer.answer);
                        return strategy;
                    }
                default:
                    {
                        strategy = new DoNotUnderstendStrategy();
                        strategy.SetMessage(messageBuilder.botAnswer.answer);
                        return strategy;
                    }
            }
        }
    }
}
