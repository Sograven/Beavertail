using Telegram.Bot;
using Telegram.Bot.Types;

namespace Storge.Bot;

public static class Queries
{
    public static async Task<string> CommandListAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await Commands.ListAsync(bot, callbackQuery.Message!);
        await bot.AnswerCallbackQuery(callbackQuery.Id);
        
        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }
    
    public static async Task<string> UnknownQueryAsync(TelegramBotClient bot, CallbackQuery callbackQuery)
    {
        await bot.AnswerCallbackQuery(callbackQuery.Id, "Кажется, это ещё не работает. Напиши админу");
        
        return $"Response to query {callbackQuery.Data} from {callbackQuery.From.Id}";
    }
}