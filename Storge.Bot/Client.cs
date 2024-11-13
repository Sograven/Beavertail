using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Storge.Bot;

public static class Client
{
    private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
    private static readonly TelegramBotClient Bot = new TelegramBotClient(Config.Token, cancellationToken: Cts.Token);
    
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
    
    private static async Task OnUpdate(Update update)
    {
        var type = update.Type;
        if (type is UpdateType.CallbackQuery)
            await OnCallbackQuery(update.CallbackQuery!);
    }

    private static async Task OnCallbackQuery(CallbackQuery callbackQuery)
    {
        var response = callbackQuery.Data switch
        {
            "command_list" => await Commands.StartAsync(Bot, callbackQuery.Message!),
            _ => await Commands.UnknownAsync(Bot, callbackQuery.Message!)
        };
        
        Console.WriteLine(response);
    }
    
    private static async Task OnMessage(Message message, UpdateType updateType)
    {
        var response = message.Text switch
        {
            "/start" => await Commands.StartAsync(Bot, message),
            _ => await Commands.UnknownAsync(Bot, message)
        };
        
        Console.WriteLine(response);
    }

    private static async Task OnError(Exception exception, HandleErrorSource source)
    {
        Console.WriteLine(exception);
    }
}