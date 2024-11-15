using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Storge.Bot;

public static class Client
{
    private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
    private static readonly TelegramBotClient Bot = new TelegramBotClient(Config.Token, cancellationToken: Cts.Token);
    /// <summary>
    /// Entry point for the program
    /// </summary>
    /// <returns></returns>
    public static async Task StartHandlingAsync()
    {
        var me = await Bot.GetMe();
        Console.WriteLine($"Start listening for {me.FirstName}.");
        
        Bot.OnUpdate += OnUpdate;
        Bot.OnMessage += OnMessage;
        Bot.OnError += OnError;

        Console.ReadLine();
        await Cts.CancelAsync();
    }
    
    /// <summary>
    /// This method define a type of user's action and then respond
    /// </summary>
    /// <param name="update">Variable contains an incoming update from user's action</param>
    /// <returns></returns>
    private static async Task OnUpdate(Update update)
    {
        if (update.Type is UpdateType.CallbackQuery)
            await OnQuery(update.CallbackQuery!);
        else
            Console.WriteLine($"Unknown update type {update.Type}");
    }

    /// <summary>
    /// This method check an callbackQuery,compare data and output a corresponding result
    /// </summary>
    /// <param name="callbackQuery">Variable contains an query of requests</param>
    /// <returns></returns>
    private static async Task OnQuery(CallbackQuery callbackQuery)
    {
        var response = callbackQuery.Data switch
        {
            "command_list" => await Queries.CommandListAsync(Bot, callbackQuery),
            _ => await Queries.UnknownQueryAsync(Bot, callbackQuery)
        };
        
        Console.WriteLine(response);
    }
    
    /// <summary>
    /// This method compare incoming user's text message with command list and output a corresponding command
    /// </summary>
    /// <param name="message">Variable contain a user's message</param>
    /// <param name="updateType">Variable contain a type of user's action (text, press a button, send photo or other actions) </param>
    /// <returns></returns>
    private static async Task OnMessage(Message message, UpdateType updateType)
    {
        var response = message.Text switch
        {
            "/start" => await Commands.StartAsync(Bot, message),
            "/list" => await Commands.ListAsync(Bot, message),
            _ => await Commands.UnknownAsync(Bot, message)
        };
        
        Console.WriteLine(response);
    }

    /// <summary>
    /// This method give a message about exception in the console
    /// </summary>
    /// <param name="exception">Contains an definitive error </param>
    /// <param name="source">Contains a source of error</param>
    /// <returns></returns>
    private static async Task OnError(Exception exception, HandleErrorSource source)
    {
        Console.WriteLine(exception);
    }
}