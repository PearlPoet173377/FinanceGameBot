using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FinanceGameBot
{
    internal static class Program
    {
        private static async Task Main()
        {
            var botClient = new TelegramBotClient("5224463084:AAE9d8CEETwuXsEw86swNeFPSGUWrxvBDwA");
            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync(cancellationToken: cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");

            Timer tim = null;
            tim = new Timer(TimerCallback, null, 0, 90000);

            Console.ReadLine();

        }

        private static void TimerCallback(Object o)
        {
            var a = new FinGameDB();
            string txt = a.SendNews();
            a.NewRound();
            var bot = new TelegramBotClient("5224463084:AAE9d8CEETwuXsEw86swNeFPSGUWrxvBDwA");
            int lastId = a.GetLastId();
            for(int i = 1; i<=lastId;i++)
            {

                long cId = a.GetPersonId($"{i}");
                String b = Convert.ToString(a.GetStockCount(Convert.ToString(cId)));
                String[] countStocks = b.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var t = bot.SendTextMessageAsync($"{cId}", $"Начался новый раунд! Цены на акции изменились.\nВаш баланс: {a.GetPersonMoney(Convert.ToString(cId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {countStocks[0]}.\n{a.GetCompName("2")}: {countStocks[1]}.\n{a.GetCompName("3")}: {countStocks[2]}.\n{a.GetCompName("4")}: {countStocks[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}. Если нужна помощь, напишите /help");
                System.Threading.Thread.Sleep(100);
                var x = bot.SendTextMessageAsync($"{cId}", $"{txt}");

            }

        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            var chatId = update.Message!.Chat.Id;
            var messageText = update.Message.Text;

            var a = new FinGameDB();

            String s = Convert.ToString(messageText);
            String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            String b = Convert.ToString(a.GetStockCount(Convert.ToString(chatId)));
            String[] countStocks = b.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (messageText)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Привет! Это Финансовая игра. Здесь Вы можете покупать и продавать акции компаний.\nВаш баланс: {a.GetPersonMoney(Convert.ToString(chatId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {countStocks[0]}.\n{a.GetCompName("2")}: {countStocks[1]}.\n{a.GetCompName("3")}: {countStocks[2]}.\n{a.GetCompName("4")}: {countStocks[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}.",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Правила игры: Вам нужна покупать и продавать акции, тем самым зарабатывая деньги.\nПример запроса: /buy 3 10.\nПервое слово имеет варианты: /buy (покупка акций), /sell (продажа акций) или /info (получение информации о компании).\nВторая цифра - номер компании, как в списке.\nТретья цифра - количество акций (при получении информации компании эта цифра не нужна). Между числами обязательно нужны пробелы.",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);
                    a.AddPerson(chatId);
                    break;
                case "/help":
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Привет! Это Финансовая игра. Здесь Вы можете покупать и продавать акции компаний.\nВаш баланс: {a.GetPersonMoney(Convert.ToString(chatId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {countStocks[0]}.\n{a.GetCompName("2")}: {countStocks[1]}.\n{a.GetCompName("3")}: {countStocks[2]}.\n{a.GetCompName("4")}: {countStocks[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}.",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Правила игры: Вам нужна покупать и продавать акции, тем самым зарабатывая деньги.\nПример запроса: /buy 3 10.\nПервое слово имеет варианты: /buy (покупка акций), /sell (продажа акций) или /info (получение информации о компании).\nВторая цифра - номер компании, как в списке.\nТретья цифра - количество акций (при получении информации компании эта цифра не нужна). Между числами обязательно нужны пробелы.",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);
                    a.AddPerson(chatId);
                    break;
                default:
                    switch (words[0])
                    {
                        case "/buy":
                            if (a.CheckMoney(chatId, words[2], words[1]))
                            {
                                a.BuyStocks(words[1], chatId, words[2]);
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Вы купили {words[2]} акций компании {a.GetCompName(words[1])}.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                                String d = Convert.ToString(a.GetStockCount(Convert.ToString(chatId)));
                                String[] latercS = d.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Ваш баланс: {a.GetPersonMoney(Convert.ToString(chatId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {latercS[0]}.\n{a.GetCompName("2")}: {latercS[1]}.\n{a.GetCompName("3")}: {latercS[2]}.\n{a.GetCompName("4")}: {latercS[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                            }
                            else
                            {
                                await ErrorMessageSend(botClient, update, cancellationToken);
                            }
                            break;
                        case "/sell":
                            if (a.CheckStocks(Convert.ToInt32(words[1]), chatId, Convert.ToInt32(words[2])))
                            {
                                a.SellStocks(words[1], chatId, words[2]);
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Вы продали {words[2]} акций компании {a.GetCompName(words[1])}.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                                String d = Convert.ToString(a.GetStockCount(Convert.ToString(chatId)));
                                String[] latercS = d.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Ваш баланс: {a.GetPersonMoney(Convert.ToString(chatId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {latercS[0]}.\n{a.GetCompName("2")}: {latercS[1]}.\n{a.GetCompName("3")}: {latercS[2]}.\n{a.GetCompName("4")}: {latercS[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                            }
                            else
                            {
                                await ErrorMessageSend(botClient, update, cancellationToken);
                            }
                            break;
                        case "/info":
                            if (words.Length < 2)
                            {
                                if (Convert.ToInt32(words[1]) > 5)
                                {
                                    await ErrorMessageSend(botClient, update, cancellationToken);
                                    break;
                                }
                            }
                            await botClient.SendTextMessageAsync(
                                chatId: chatId,
                                text: $"История цен компании {a.GetCompName(words[1])}:\nТекущая цена: {a.GetCurrentPrice(words[1])}.\nЦена 1 раунд назад: {a.GetOneRoundLaterPrice(words[1])}.\nЦена 2 раунда назад: {a.GetTwoRoundLaterPrice(words[1])}.\nЦена 3 раунда назад: {a.GetThreeRoundLaterPrice(words[1])}.\nЦена 4 раунда назад: {a.GetFourRoundLaterPrice(words[1])}.",
                                parseMode: ParseMode.Markdown,
                                cancellationToken: cancellationToken);
                            break;
                        default:
                            await ErrorMessageSend(botClient, update, cancellationToken);
                            break;
                    }
                    /*String d = Convert.ToString(a.GetStockCount(Convert.ToString(chatId)));
                    String[] latercS = d.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Ваш баланс: {a.GetPersonMoney(Convert.ToString(chatId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {latercS[0]}.\n{a.GetCompName("2")}: {latercS[1]}.\n{a.GetCompName("3")}: {latercS[2]}.\n{a.GetCompName("4")}: {latercS[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}.",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);*/
                    break;
            }

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
        }

        private static async Task ErrorMessageSend(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            var chatId = update.Message!.Chat.Id;
            var messageText = update.Message.Text;

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Ой, проблемы с запросом.",
                parseMode: ParseMode.Markdown,
                cancellationToken: cancellationToken);
        }

        static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);
            return Task.CompletedTask;
        }
        
    }
}
