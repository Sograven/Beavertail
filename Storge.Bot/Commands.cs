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
    /// <param name="message">Variable contains a message/command/action from user (in this method message should be "/start")</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> StartAsync(TelegramBotClient bot, Message message)
    {
        var buttons = new InlineKeyboardMarkup(
            new InlineKeyboardButton { Text = "Список команд", CallbackData = "command_list" },
            new InlineKeyboardButton { Text = "Часто задаваемые вопросы", CallbackData = "command_faq" },
            new InlineKeyboardButton { Text = "Оформить заказ", CallbackData = "command_order" });

        string text = "Привет! На связи магазин Storge.\n" +
                                      "С помощью этого бота ты можешь оформить заказ и узнать его статус.\n" +
                                      "Список команд и их описание можешь узнать с помощью команды /list,\n" +
                                      "либо воспользоваться кнопками под этим сообщением.";

        await bot.SendMessage(message.Chat, replyMarkup: buttons, text: text);

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output a message with command list
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains a message/command/action from user (in this method message should be "/list")</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> ListAsync(TelegramBotClient bot, Message message)
        {
            var button = new InlineKeyboardMarkup(new InlineKeyboardButton { Text = "Назад", CallbackData = "command_start" });

            await bot.SendMessage(message.Chat, replyMarkup: button, text: "Список команд:\n" +
                "/start - начинает работу бота\n" +
                "/list - показывает список команд бота\n" +
                "/faq - выводит раздел c категориями часто задаваемых вопросов ");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    
        }

    /// <summary>
    /// Output the message with FAQ (frequently asked questions)
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains a message/command/action from user (in this method message should be "/faq")</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> FaqAsync(TelegramBotClient bot, Message message)
        {
            var faq_buttons = new InlineKeyboardMarkup()
                .AddButton("Оплата заказа", "command_payment")
                .AddNewRow()
                .AddButton("Доставка", "command_delivery")
                .AddNewRow()
                .AddButton("Контакты и график работы", "command_contacts")
                .AddNewRow()
                .AddButton("Назад", "command_start");            

            await bot.SendMessage(message.Chat, replyMarkup: faq_buttons, text: "Часто задаваемые вопросы\n\n" +
                    "Выберите категорию:");

        return $"Response to message {message.Text} from {message.Chat.Id}";

    }

    /// <summary>
    /// Output the message with FAQ category: questions about payment methods
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains a message/command/action from user (in this method message is an inline button update)</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> PaymentFaqAsync(TelegramBotClient bot, Message message)
    {
        var button = new InlineKeyboardMarkup(new InlineKeyboardButton { Text = "Назад", CallbackData = "command_faq" });
       
        await bot.SendMessage(message.Chat, replyMarkup: button, text: "Q: Как оплатить заказ? \n" +
            "A: Заказ можно оплатить через банковские карты Visa, Mastercard и МИР, а также с помощью СБП. \n\n" +
            "Q: Как оформить заказ? \n" +
            "A: Заказ оформляется через сайт компании с помощью встроенного поиска и интуитивно понятного графического интерфейса. \n\n" +
            "Q: Как отменить заказ? \n" +
            "A: Заказ можно отменить в течение 24 часов после оформления заказа. Для этого напишите в чат поддержки с помощью нашего умного бота.");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output the message with FAQ category: questions about goods delivery
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains a message/command/action from user (in this method message is an inline button update)</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> DeliveryFaqAsync(TelegramBotClient bot, Message message)
    {
        var button = new InlineKeyboardMarkup(new InlineKeyboardButton { Text = "Назад", CallbackData = "command_faq" });

        await bot.SendMessage(message.Chat, replyMarkup: button, text: "Q: Какие пункты выдачи доступны для получения заказа? \n" +
            "A: Мы отправляем покупателям товары с помощью сервисов: СДЭК, Boxberry и почта России. \n\n" +
            "Q: Сколько по времени осуществляется доставка? \n" +
            "A: Средняя время доставки по России: 7-21 день в зависимости от указанного адреса доставки и выбранного сервиса. \n\n" +
            "Q: Как узнать статус заказа? \n" +
            "A: Статус заказа можно узнать через наш удобный бот-сервис. \n\n");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output the message with FAQ category: questions about contact and adress of a Storge company
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains a message/command/action from user (in this method message is an inline button update)</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> ContactsFaqAsync(TelegramBotClient bot, Message message)
    {
        var button = new InlineKeyboardMarkup(new InlineKeyboardButton { Text = "Назад", CallbackData = "command_faq" });

        await bot.SendMessage(message.Chat, replyMarkup: button, text: "Q: Каков ваш примерный график работы? \n" +
            "A: Мы работаем все дни недели круглосуточно. \n\n" +
            "Q: Адрес вашей компании? \n" +
            "A: Адрес: хуево-кукуево, дом 15, квартира \"Вас ебать не должно\" \n\n");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }

    /// <summary>
    /// Output the message with request to try again because user input an unknown message/command for programm or didn't initialize a programm correctly
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="message">Variable contains message/command from user which program cannot to define</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> UnknownAsync(TelegramBotClient bot, Message message, int message_id, bool first_init)
    {
        await bot.SendMessage(message.Chat.Id, text: "Упс! Кажется, что-то пошло не так.\n" + 
                "Проверь введённые данные и попробуй ещё раз.");

        return $"Response to message {message.Text} from {message.Chat.Id}";
    }
}