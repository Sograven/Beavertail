using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Storge.Bot;

public static class Commands
{
    public static async Task<string> StartAsync(TelegramBotClient bot, Message message)
    {
        var buttons = new InlineKeyboardMarkup(
            new InlineKeyboardButton { Text = "Список команд", CallbackData = "command_list" },
            new InlineKeyboardButton { Text = "Часто задаваемые вопросы", CallbackData = "command_faq" },
            new InlineKeyboardButton { Text = "Оформить заказ", CallbackData = "command_order" });
        
        await bot.SendMessage(message.Chat, replyMarkup: buttons, text: "Привет! На связи магазин Storge.\n" +
                                                                          "С помощью этого бота ты можешь оформить заказ и узнать его статус.\n" +
                                                                          "Список команд и их описание можешь узнать с помощью команды /list,\n" +
                                                                          "либо воспользоваться кнопками под этим сообщением.");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    public static async Task<string> ListAsync(TelegramBotClient bot, Message message)
    {
        await bot.SendMessage(message.Chat, text: "Список команд: \n/start - начинает работу бота \n/list - показывает список команд бота.");
        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    public static async Task<string> UnknownAsync(TelegramBotClient bot, Message message)
    {
        await bot.SendMessage(message.Chat.Id, "Упс! Кажется, что-то пошло не так.\n" +
                                            "Проверь введённые данные и попробуй ещё раз.");
        
        return $"Response to message {message.Text} from {message.Chat.Id}";
    }
}