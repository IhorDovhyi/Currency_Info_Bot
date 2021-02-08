using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyInfoBot.View
{
    public class Answer
    {
        DateTime dateTime;
        public int answerID { get; set; } = 0;
        public string answer { get; set; } = "I do not understand\nEnter currency type and date\nExample(currency dd.mm.yyyy)";
        BankRequest bankRequest;
        List<string> messageContains;
        List<string> currensyType = new List<string>();
        List<string> names = new List<string>() { @"HELLO", @"HI" };

        public Answer(string question)
        {
            messageContains = question.Split(' ').ToList<string>();
        }
        public Answer GiveAnswer()
        {
            dateTime = new DateTime();
            DateTime tmp = new DateTime();
            foreach (var mes in messageContains)
            {
                if (names.Any(x => x == mes.ToUpper()))
                {
                    HelloAnswer(mes);
                    break;
                }
                else if (DateTime.TryParse(mes, out tmp))
                {
                    dateTime = tmp;
                }
                else
                {
                    currensyType.Add(mes);
                }
            }
            if (dateTime > DateTime.MinValue && currensyType.Count > 0)
            {
                CurrencyAnswer();
            }
            return this;
        }

        private void CurrencyAnswer()
        {
            this.answerID = 2;
            if (dateTime > DateTime.Today)
            {
                this.answer = $"Sorry. I'm just a bot. Not an oracle :(. Today is {DateTime.Today.ToString("d")}";
            }
            else if(dateTime < new DateTime(2014, 01, 01))
            {
                this.answer = $"Sorry. it was a long time ago... I only know what was after 01.01.2014";
            }
            else
            {
                bankRequest = new BankRequest(dateTime);
                foreach (var currencyName in currensyType)
                {
                    string response = bankRequest.GetBanksResponse().GetResponse(currencyName.ToUpper());

                    if (response != String.Empty)
                    {
                        this.answer = bankRequest.GetBanksResponse().GetResponse(currencyName.ToUpper());
                        break;
                    }
                    else
                    {
                        this.answer = $"I did not find the exchange rate for the currency: ({currencyName}  {dateTime.ToString("d")})";
                    }
                }
            }
        }

        private void HelloAnswer(string _message)
        {
            this.answerID = 1;
            this.answer = $"{_message.ToUpper()}! I'm Currency.Info.Bot\nEnter currency type and date\nExample(currency dd.mm.yyyy)";
        }

    }
}
