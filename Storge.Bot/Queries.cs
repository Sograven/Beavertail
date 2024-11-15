using Telegram.Bot;
using Telegram.Bot.Types;

namespace Storge.Bot;

public static class Queries
{
    /// <summary>
    /// Output a command list on user's request
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="callbackQuery">Variable contains an query of requests</param>
    /// <returns>Return a operation log to console</returns>
    public static async Task<string> CommandListAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.ListAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);
        
        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }
  
    /// <summary>
    /// Output a message on user's request about not working function and refer to admin
    /// </summary>
    /// <param name="bot">Variable contains a client for using the Telegram Bot API</param>
    /// <param name="callbackQuery">Variable contains an query of requests</param>
    /// <returns>Return a operation log to console</returns>
    public static async Task<string> UnknownQueryAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await bot.AnswerCallbackQuery(callbackQuery.Id, "Кажется, это ещё не работает. Напиши админу");
        
        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }
}