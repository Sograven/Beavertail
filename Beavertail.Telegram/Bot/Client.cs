using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Beavertail.Telegram.Bot;

public static class Client
{
    private static readonly CancellationTokenSource Cts = new();
    private static readonly TelegramBotClient Bot = new(Config.Token, cancellationToken: Cts.Token);
    
    public static async Task StartHandlingAsync()
    {
        var me = await Bot.GetMe();
        Console.WriteLine($"Start listening for {me.FirstName}.");
        
        Bot.OnMessage += OnMessage;
        Bot.OnError += OnError;

        Console.ReadLine();
        await Cts.CancelAsync();
    }

    private static Task OnMessage(Message message, UpdateType updateType)
    {
        Console.WriteLine($"Received a message {message.Text} from {message.Chat.Id}");
        return Task.CompletedTask;
    }

    private static Task OnError(Exception exception, HandleErrorSource source)
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }
}