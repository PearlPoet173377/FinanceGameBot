# FinanceGameBot
Telegram-бот "Финансовая игра".

Работу выполнил Сафаров Александр Алексеевич.

Используемая IDE Visual Studio 2019.

Framework: .NET 5.0.

Файлы проекта: Program.cs, FinGameDB.cs.

СУБД: SQLite.

Цель работы: Создать финансовую игру на основе Telegram-бота, главной механикой которой является продажа и покупка акций нескольких компаний.
Принцип работы: Пользователь запускает бота в приложении Telegram. Telegram ID пользователя записывается в БД, создавая денежный счёт игрока в 5000. Пользователь может покупать и продавать акции компаний из списка, если у игрока есть необходимая сумма денег или нужное количество акций. Также игрок может получить данные о ценах на акции компании за последние 5 раундов. Все эти действия выполняются за счёт запросов от пользователя. Запрос должен состоять из трёх или двух частей. Первая часть - это определение запроса, то есть покупка (/buy), продажа (/sell) или получение информации (/info). Вторая часть запроса - выбор компании из списка по номеру. Третья часть запроса - количество акций. Эта часть не нужна для запроса на получение информации. Примеры запросов: "/buy 1 10" (покупка 10 акций компании №1 из списка), "/sell 2 5" (продажа 5 акций компании №2 из списка), "/info 3" (получение информации о ценах на акции компании №3 за последние 5 раундов). Также пользователь может получить информацию о правилах игры, отправив "/help". Каждые две минуты начинается новый раунд, то есть меняются цены на акции, рассылаются прогнозы на цены акций на следующий раунд и обновляется таблица лидеров.

Описание Program.cs:
Используемые библиотеки: 
System, System.Threading, System.Threading.Tasks, Telegram.Bot, Telegram.Bot.Exceptions, Telegram.Bot.Extensions.Polling, Telegram.Bot.Types, Telegram.Bot.Types.Enums.
Описание методов:
TimerCallback - выполнение действий по таймеру.
HandleUpdateAsync - метод для обработки запросов пользователя
ErrorMessageSend - отправка ошибки с полученным запросом.
HandleErrorAsync - вывод ошибки во время выполнения прогграммы.

Описание FinGameDB.cs:
Используемы библиотеки:
System, System.Threading, System.Collections.Generic, Microsoft.Data.Sqlite, System.Threading.Tasks.
Описание методов:
GetLastId - получение последнего id из таблицы Persons.
GetPersonId - получение Telegram ID (chatId) по id из таблицы Persons.
GetPersonMoney - получение количества денег (money) по chatId из таблицы Persons.
GetStockCount - полчение количества акций всех компаний по chatId из таблицы Persons.
GetFirstPlace - получени количества самого большего количества денег среди игроков.
GetLeaderName - получение chatId пользователя с самым большим количеством денег.
GetCurrentPrice, GetOneRoundLaterPrice, GetTwoRoundLaterPrice, GetThreeRoundLaterPrice, GetFourRoundLaterPrice - получение цены на акцию определенной компании за определённый раунд из таблицы CompaniesStock.
GetCompName - получение имени компании по id из таблицы CompaniesStock.
UpdateChanger - изменение коэффициента изменения цены на акции в таблице Changers.
GetChanger - получение коэффициента изменения цены на акции из таблицы Changers.
ChangeChangerCompPrice - вызов UPdateChanger для всех компаний.
SendNews - создание текста с прогнозами на именение цен акций на основе коэффициентов из таблицы Changers.
AlgForPrice - алгоритм изменения цен на акции, используя коэффициенты из таблицы Changers.
ChangePrices - измение цен на акции, используя AlgForPrice, в таблице CompaniesStock.
CheckPerson - проверка для добавления пользователя в таблицу Persons
AddPerson - добавление пользователя в таблицу Persons.
CheckMoney - проверка количества денег у пользователя при покупке акций.
BuyStocks - покупка акций.
CheckStocks - проврка количества акций у пользователя при продаже акций.
SellStocks - продажа акций.
NewRound - использование ChangePrices для изменения цен для каждой компании и вызов метода ChangeChangerCompPrice.

Описание Базы данных:
Таблица Changers хранит значения коэффициентов для изменения цен.
Поля таблицы:
id (INTEGER, NOT NULL, PRIMARY KEY, AUTOINCREMENT);
changer (INTEGER, NOT NULL).

Таблица CompaniesStock хранит данные о ценах каждой компании.
Поля таблицы:
id (INTEGER, NOT NULL, UNIQUE, PRIMARY KEY, AUTOINCREMENT);
name (NVARCHAR(50));
currentprice (MONEY, DEFAULT 50);
oneroundlaterprice, tworoundlaterprice, threeroundlaterprice, fourroundlaterprice (MONEY, DEFAULT 0).

Таблица Persons хранит данные о пользователях.
Поля таблицы:
id (INTEGER, NOT NULL, UNIQUE, PRIMARY KEY, AUTOINCREMENT);
chatid (INTEGER, NOT NULL);
money (MONEY, DEFAULT 5000);
MacrosoftStock, LamazonStock, GoogolStock, PersonBookStock (INTEGER, DEFAULT 0);
New (INTEGER DEFAULT 0).

Дальнейшее развитие проекта:
1) Создание полноценной таблицы лидеров.
2) Возможность создания для каждого пользователя никнейма.
3) Изменение алгоритма для изменения цен, не зависищего от случайных чисел.
4) Разработка алгоритма ценооборазования в зависимости от купленных и проданных игроками акций.
5) Создание графиков для визуализации изменений в ценах акций.
6) Более удобный метод отправки запросов для обработки.
