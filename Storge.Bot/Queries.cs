using Telegram.Bot;
using Telegram.Bot.Types;

namespace Storge.Bot;

public static class Queries
{
    public static async Task<string> CommandStartAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.StartAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);

        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }

    /// <summary>
    /// Output a command list on user's request
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="callbackQuery">Variable contains an query of requests</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> CommandListAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.ListAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);
        
        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }

    /// <summary>
    /// Output a module "frequently asked questions" on user's request
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="callbackQuery">Variable contains an query of requests</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> CommandFaqAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.FaqAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);

        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }

    public static async Task<string> CommandPaymentFaqAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.PaymentFaqAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);

        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }

    public static async Task<string> CommandDeliveryFaqAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.DeliveryFaqAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);

        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }

    public static async Task<string> CommandContactsFaqAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.ContactsFaqAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);

        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }

    /// <summary>
    /// Output a message on user's request about not working function and refer to admin
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="callbackQuery">Variable contains an query of requests</param>
    /// <returns>Return an operation log to console</returns>
    public static async Task<string> UnknownQueryAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await bot.AnswerCallbackQuery(callbackQuery.Id, "Кажется, это ещё не работает. Напиши админу");
        
        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }
}