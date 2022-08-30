using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;

namespace HomeWork9_TelegramBot
{
    public class HandlerUpdates
    {
        private  HandleMessages hMessages = new HandleMessages();
        private HandleCallbackQuerys handleCallbackQuerys = new HandleCallbackQuerys();
        public HandlerUpdates()
        { 
        }
        public async Task HandleUpdatesAsync(ITelegramBotClient bot, Update update, CancellationToken cansellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await hMessages.HandleMessage(bot, update.Message);
                return;
            }
            if (update.Type == UpdateType.CallbackQuery)
            {
                await handleCallbackQuerys.HandleCallbackQuery(bot, update.CallbackQuery);
                return;
            }
            if (update.Type == UpdateType.Message && update?.Message?.Document != null)
            {
                var document = update?.Message?.Document;
                using (StreamWriter sw = new StreamWriter("files.txt", true))
                {
                    sw.WriteLineAsync($"{document.FileId};{document.FileName}");
                }
                await bot.SendTextMessageAsync(update.Message.Chat.Id, text: $"Документ - {document.FileName} добавлен");
            }
            if (update.Type == UpdateType.Message &&  update?.Message?.Audio != null)
            {
                var audio = update?.Message?.Audio;
                using (StreamWriter sw = new StreamWriter("files.txt", true))
                {
                    sw.WriteLineAsync($"{audio.FileId};{audio.FileName}");
                }
                await bot.SendTextMessageAsync(update.Message.Chat.Id, text: $"Аудио-файл - {audio.FileName} добавлен");
            }
            if (update.Type == UpdateType.Message && update?.Message?.Photo != null)
            {
                //var vv = (int)update?.Message?.Photo.Length;
                var photo = update?.Message?.Photo[(int)update?.Message?.Photo.Length-1];
                using (StreamWriter sw = new StreamWriter("files.txt", true))
                {
                    sw.WriteLineAsync($"{photo.FileId};Фото.jpg");
                }
                await bot.SendTextMessageAsync(update.Message.Chat.Id, text: $"Фото добавлено");
            }
        }
    }
}
