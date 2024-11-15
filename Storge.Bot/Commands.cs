using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace Storge.Bot;

public static class Commands
{
    /// <summary>
    /// Output and entry message with inline buttons when programm is starting (or user give an input message "/start")
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains message/command from user (in this method message should be "/start")</param>
    /// <returns>Return an operation log to console</returns>
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

        return $"Response to command {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output a message with command list
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains message/command from user (in this method message should be "/list")</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> ListAsync(TelegramBotClient bot, Message message)
    {
        await bot.SendMessage(message.Chat, text: "Список команд:\n" + 
            "/start - начинает работу бота\n" +
            "/list - показывает список команд бота\n" +
            "/faq - выводит раздел \"Часто задаваемые вопросы\" ");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output the message with FAQ (frequently asked questions)
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains message/command from user (in this method message should be "/faq")</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> FaqAsync(TelegramBotClient bot, Message message)
    {
        await bot.SendMessage(message.Chat, text: "Часто задаваемые вопросы:\n\n" +
            "Q: Как узнать **статус заказа?** \n" +
            "A: **Статус заказа** можно узнать через наш удобный бот-сервис \n\n" +
            "Q: Как оформить заказ? " +
            "A: Заказ оформляете через сайт компании с помощью встроенного поиска и интуитивно понятного графического интерфейса \n\n " +
            "Q: Как отменить заказ?" +
            "A: Заказ можно отменить в течение 24 часов после оформления заказа. Для этого напишите в чат поддержки с помощью нашего умного бота",
            ParseMode.Markdown);

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output the message with request to try again because user input an unknown message/command for programm
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains message/command from user which program cannot to define</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> UnknownAsync(TelegramBotClient bot, Message message)
    {
        await bot.SendMessage(message.Chat.Id, "Упс! Кажется, что-то пошло не так.\n" +
                                            "Проверь введённые данные и попробуй ещё раз.");
        
        return $"Response to command {message.Text} from {message.Chat.Id}";
    }
}