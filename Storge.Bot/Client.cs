using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Storge.Bot;

public static class Client
{
    private static readonly CancellationTokenSource Cts;
    private static readonly TelegramBotClient Bot;
    
    public static async Task Main()
    {
        await StartHandling();
    }

    private static async Task StartHandling()
    {
        var me = await Bot.GetMe();
        Console.WriteLine(me.FirstName);
        
        Bot.OnUpdate += OnUpdate;
        Bot.OnMessage += OnMessage;
        Bot.OnError += OnError;

        Console.ReadLine();
        await Cts.CancelAsync();
    }
    
    private static async Task OnUpdate(Update update)
    {
        
    }
    
    private static async Task OnMessage(Message message, UpdateType updateType)
    {
        if (message.Text == "/start")
            await Bot.SendMessage(message.Chat, $"Hi, {message.From!.FirstName}!");
    }

    private static async Task OnError(Exception exception, HandleErrorSource source)
    {
        Console.WriteLine(exception);
    }

    static Client()
    {
        Cts = new CancellationTokenSource();
        Bot = new TelegramBotClient("<Token>", cancellationToken: Cts.Token);
    }
}