using System.Diagnostics.Metrics;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Storge.Bot;

public static class Client
{
    /// <summary>
    /// Variable contains a token of program cancellation
    /// </summary>
    private static readonly CancellationTokenSource Cts = new CancellationTokenSource();

    /// <summary>
    /// Variable contains a client for using the Telegram Bot API with parameters: token, cancellationToken
    /// </summary>
    private static readonly TelegramBotClient Bot = new TelegramBotClient(Config.Token, cancellationToken: Cts.Token);

    /// <summary>
    /// Variable contains a boolean value (true/false): Was programm initializated first time or it's continue to work
    /// </summary>
    private static bool FirstInitialization = true;

    /// <summary>
    /// Variable contains a message.Id of first bot's message in chat
    /// </summary>
    private static int Message_Id = 0;

    
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
            "command_start" => await Queries.CommandStartAsync(Bot, callbackQuery),
            "command_list" => await Queries.CommandListAsync(Bot, callbackQuery),
            "command_faq" => await Queries.CommandFaqAsync(Bot, callbackQuery),
            "command_payment" => await Queries.CommandPaymentFaqAsync(Bot, callbackQuery),
            "command_delivery" => await Queries.CommandDeliveryFaqAsync(Bot, callbackQuery),
            "command_contacts" => await Queries.CommandContactsFaqAsync(Bot, callbackQuery),
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
        if (FirstInitialization == true && message.Text == "/start")
        {
            Message_Id = await Commands.FirstStartAsync(Bot, message);
            FirstInitialization = false;
            Console.WriteLine("Initialization message_id - " + Message_Id);
        }
        else if (FirstInitialization == true && message.Text != "/start")
        {
            await Commands.UnknownAsync(Bot, message, Message_Id,FirstInitialization);
        }
        else
        {

            var response = message.Text switch
            {
                "/start" => await Commands.StartAsync(Bot, message, Message_Id),
                "/list" => await Commands.ListAsync(Bot, message, Message_Id),
                "/faq" => await Commands.FaqAsync(Bot, message, Message_Id),
                _ => await Commands.UnknownAsync(Bot, message, Message_Id,FirstInitialization)

            };

            Console.WriteLine(response);

        }           

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