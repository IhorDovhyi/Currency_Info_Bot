using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyInfoBot.Models;
using CurrencyInfoBot.Models.Commands;
using CurrencyInfoBot.Models.Currency;
using CurrencyInfoBot.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telegram.Bot;
using Exchangerate = CurrencyInfoBot.Models.Currency.Exchangerate;

namespace CurrencyInfoBot.Tests
{
    [TestClass]
    public class CurrencyInfoBotTests
    {
        [TestMethod]
        public void TestBotSettings_CorrectBotSettingsExpected()
        {
            // Arrange
            BotSettings testBot = new BotSettings();
            string expectedName = "Currency.Info.Bot";
            string expectedUrl = "Some URL";
            string expectedToken = "1234567:4TT8bAc8GHUspu3ERYn - KGcvsvGB9u_n4ddy";
            // Act
            testBot.Deserialize();
            // Assert
            Assert.AreEqual(expectedName, testBot.Name);
            Assert.AreEqual(expectedUrl, testBot.Url);
            Assert.AreEqual(expectedToken, testBot.Token);
        }
        [TestMethod]
        public void TestBot_MethodCreateBot_CorrectTelegramBotClientExpected()
        {
            // Arrange
            Bot testBot = new Bot();
            // Act
            var actualBot = testBot.CreateBot();
            // Assert
            Assert.IsTrue(actualBot is TelegramBotClient);
            Assert.IsInstanceOfType(actualBot, typeof(TelegramBotClient));
        }
        [TestMethod]
        public void TestClassBanksResponse_GetResponseMethod_CorrectStringExpected()
        {
            // Arrange
            BanksResponse banksResponse = new BanksResponse() { date = new DateTime(2021, 1, 1),
                                                                bank = "PB",
                                                                baseCurrency = 980,
                                                                baseCurrencyLit = "UAH",
                                                                exchangeRate = new List<Exchangerate>()
                                                                                    { new Exchangerate() {baseCurrency = "UAH",
                                                                                                          currency = "USD",
                                                                                                          saleRateNB = 28,
                                                                                                          purchaseRateNB = 28.1F }}};
            var expected = banksResponse.date.ToString("d") + "\n" +
                        "1 " + banksResponse.exchangeRate[0].currency + $" = {Math.Round(banksResponse.exchangeRate[0].saleRateNB, 2)} " + banksResponse.exchangeRate[0].baseCurrency;
            // Act
            var actual = banksResponse.GetResponse("USD");
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestStrategyFactory_CorrectStrategyExpected()
        {
            // Arrange
            StrategyFactory strategyHello = new StrategyFactory("Hello");
            StrategyFactory strategyCurrency = new StrategyFactory("usd 05/02/2021");
            StrategyFactory strategyNotUnderstend = new StrategyFactory("Abracadabra");
            // Act
            var actualHello = strategyHello.Strategy();
            var actualCurrency = strategyCurrency.Strategy();
            var actualNotUnderstend = strategyNotUnderstend.Strategy();
            // Assert
            Assert.IsInstanceOfType(actualHello, new HelloCommandStrategy().GetType());
            Assert.IsInstanceOfType(actualCurrency, new CurrencyStrategy().GetType());
            Assert.IsInstanceOfType(actualNotUnderstend, new DoNotUnderstendStrategy().GetType());
        }
        [TestMethod]
        public void MessageBuilderTest_BotAnswerMethod_CorrectAnswerExpected()
        {
            // Arrange
            MessageBuilder messageHello = new MessageBuilder("Hello");
            MessageBuilder messageCurrency = new MessageBuilder("usd 05/02/2022");
            MessageBuilder messageNotUnderstend = new MessageBuilder("Abracadabra");
            string expectedAnswerHello = "HELLO! I'm Currency.Info.Bot\nEnter currency type and date\nExample(currency dd.mm.yyyy)";
            string expectedAnswerCurrency = $"Sorry. I'm just a bot. Not an oracle :(. Today is {DateTime.Today.ToString("d")}";
            string expectedAnswerNotUnderstend = "I do not understand\nEnter currency type and date\nExample(currency dd.mm.yyyy)";
            // Act
            var actualHelloAncver = messageHello.BotAnswer().answer;
            var actualCurrencyAncver = messageCurrency.BotAnswer().answer;
            var actualNotUnderstendAncver = messageNotUnderstend.BotAnswer().answer;
            // Assert
            Assert.AreEqual(expectedAnswerHello, actualHelloAncver);
            Assert.AreEqual(expectedAnswerCurrency, actualCurrencyAncver);
            Assert.AreEqual(expectedAnswerNotUnderstend, actualNotUnderstendAncver);
        }
        [TestMethod]
        public void AnswerClassTest_GiveAnswerMethod_CorrectAnswerExpected()
        {
            // Arrange
            Answer longTimeAgoAnswer = new Answer("usd 01/01/2013");
            Answer notFindAnswer = new Answer("Pln 01/01/2021");
            string expectedLongTimeAgoAnswer = $"Sorry. it was a long time ago... I only know what was after 01.01.2014";
            string expectedNotFindAnswer = $"I did not find the exchange rate for the currency: (Pln  01.01.2021)";
            // Act
            var actualLongTimeAgoAnswer = longTimeAgoAnswer.GiveAnswer().answer;
            var actualnotFindAnswer = notFindAnswer.GiveAnswer().answer;
            // Assert
            Assert.AreEqual(expectedLongTimeAgoAnswer, actualLongTimeAgoAnswer);
            Assert.AreEqual(expectedNotFindAnswer, actualnotFindAnswer);

        }
    }
}
