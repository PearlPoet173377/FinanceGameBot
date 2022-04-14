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
            var botClient = new TelegramBotClient("5354352885:AAFYfdZllmxxngUEDzRN65IZsGjV4BvNUSU");
            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };
            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync(cancellationToken: cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");

            Timer tim = null;
            tim = new Timer(TimerCallback, null, 0, 180000);

            Console.ReadLine();

        }

        private static void TimerCallback(Object o)
        {
            var a = new FinGameDB();
            a.NewRound();
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
            int count = a.GetLastId();

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
                        text: $"Правила игры: Вам нужна покупать и продавать акции, тем самым зарабатывая деньги.\nПример запроса: 1 3 10.\nПервая цифра имеет варианты: 1 (покупка акций), 2 (продажа акций) или 3 (получение информации о компании).\nВторая цифра - номер компании, как в списке.\nТретья цифра - количество акций (при получении информации компании эта цифра не нужна).",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);
                    a.AddPerson(chatId);
                    break;
                default:
                    switch (words[0])
                    {
                        case "1":
                            if (a.CheckMoney(chatId, words[2], words[1]))
                            {
                                a.BuyStocks(words[1], chatId, words[2]);
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Вы купили {words[2]} акций компании {a.GetCompName(words[1])}.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Ой, проблемы с запросом.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                            }
                            break;
                        case "2":
                            if (a.CheckStocks(Convert.ToInt32(words[1]), chatId, Convert.ToInt32(words[2])))
                            {
                                a.SellStocks(words[1], chatId, words[2]);
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Вы продали {words[2]} акций компании {a.GetCompName(words[1])}.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Ой, проблемы с запросом.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                            }
                            break;
                        case "3":
                            if (Convert.ToInt32(words[1])>3)
                            {
                                await botClient.SendTextMessageAsync(
                                    chatId: chatId,
                                    text: $"Ой, проблемы с запросом.",
                                    parseMode: ParseMode.Markdown,
                                    cancellationToken: cancellationToken);
                                break;
                            }
                            await botClient.SendTextMessageAsync(
                                chatId: chatId,
                                text: $"История цен компании {a.GetCompName(words[1])}:\nТекущая цена: {a.GetCurrentPrice(words[1])}.\nЦена 1 раунд назад: {a.GetOneRoundLaterPrice(words[1])}.\nЦена 2 раунда назад: {a.GetTwoRoundLaterPrice(words[1])}.\nЦена 3 раунда назад: {a.GetThreeRoundLaterPrice(words[1])}.\nЦена 4 раунда назад: {a.GetFourRoundLaterPrice(words[1])}.",
                                parseMode: ParseMode.Markdown,
                                cancellationToken: cancellationToken);
                            break;
                        default:
                            await botClient.SendTextMessageAsync(
                                chatId: chatId,
                                text: $"Ой, проблемы с запросом.",
                                parseMode: ParseMode.Markdown,
                                cancellationToken: cancellationToken);
                            break;
                    }
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Ваш баланс: {a.GetPersonMoney(Convert.ToString(chatId))}.\nВаши купленные акции компаний:\n{a.GetCompName("1")}: {countStocks[0]}.\n{a.GetCompName("2")}: {countStocks[1]}.\n{a.GetCompName("3")}: {countStocks[2]}.\n{a.GetCompName("4")}: {countStocks[3]}.\nСписок компаний:\n1) {a.GetCompName("1")}. Текущая цена: {a.GetCurrentPrice("1")}.\n2) {a.GetCompName("2")}. Текущая цена: {a.GetCurrentPrice("2")}.\n3) {a.GetCompName("3")}. Текущая цена: {a.GetCurrentPrice("3")}.\n4) {a.GetCompName("4")}. Текущая цена: {a.GetCurrentPrice("4")}.",
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cancellationToken);
                    break;
            }

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}. {chatId.GetType()}");
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
