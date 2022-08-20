// See https://aka.ms/new-console-template for more information
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;
using HomeWork9_TelegramBot;

BotSettings botSettings = new BotSettings();
HandlerUpdates handlerUpdates = new HandlerUpdates();
HandleErrors handleErrors = new HandleErrors();
TelegramBotClient bot = new TelegramBotClient(botSettings.Token);
using var cts = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { }
};
//var r = receiverOptions.Offset.Value;
bot.StartReceiving(handlerUpdates.HandleUpdatesAsync, handleErrors.HandleError,receiverOptions,cts.Token);


var me = await bot.GetMeAsync();
//var f = bot.GetUpdatesAsync(0).Result.ToArray();
//bot.mess
Console.WriteLine($"Привет я Бот id={me.Id}, мое имя - {me.FirstName}. Я работаю!");
Console.ReadLine();
cts.Cancel();



