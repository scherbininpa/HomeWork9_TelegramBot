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
    public class HandleMessages
    {

        public HandleMessages()
        { }
        public async Task HandleMessage(ITelegramBotClient bot, Message message)
        {
            if (message.Text == "/start")
            {
                ReplyKeyboardMarkup keyboard = new(new[]
                {
                    new KeyboardButton[] { "Файлы"},
                })
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard=true
                };
                await bot.SendTextMessageAsync(message.Chat.Id, text: "Добро пожаловать, пользуйтесь меню!", replyMarkup: keyboard);
            }
 /*           if (message.Text == "/keyboard")
            {
                ReplyKeyboardMarkup keyboard = new(new[]
                {
                    new KeyboardButton[] { "Hello","Goodbye"},
                    new KeyboardButton[]{ "Привет", "Пока"}
                })
                {
                    ResizeKeyboard = true
                };
                await bot.SendTextMessageAsync(message.Chat.Id, text: "Choose:", replyMarkup: keyboard);
                return;
            }
            if (message.Text == "/inline")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Buy 50$","buy_50$"),
                        InlineKeyboardButton.WithCallbackData("Buy 100$","buy_100$")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Sell 50$","sell_50$"),
                        InlineKeyboardButton.WithCallbackData("Sell 100$","sell_100$")
                    }
                });
                await bot.SendTextMessageAsync(message.Chat.Id, text: "Choose inline:", replyMarkup: keyboard);
                return;
            }*/
            if (message.Text == "Файлы")///files
            {
                HandleChatFiles chatFiles = new HandleChatFiles();
                foreach (ChatFiles file in chatFiles.Files.Values)
                {
                    await bot.SendTextMessageAsync(message.Chat.Id, text: $"{file.Name}", replyMarkup: new InlineKeyboardMarkup(new[]
                        {
                            new [] {
                                InlineKeyboardButton.WithCallbackData( "\U0001F4BE Скачать",$"download_{file.Number}")
                            }
                     }));
                }

                return;
            }
            await bot.SendTextMessageAsync(message.Chat.Id, text: $"Вы сказали: {message.Text}");
        }
    }
}
