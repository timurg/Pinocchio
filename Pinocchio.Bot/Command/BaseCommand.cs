using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.UpdatingMessages;

namespace Pinocchio.Bot;

public abstract class BaseCommand
{
    protected readonly TelegramBotClient BotClient;

    protected BaseCommand(TelegramBotClient botClient)
    {
        BotClient = botClient ?? throw new ArgumentNullException(nameof(botClient));
    }
    
    protected void DeleteUserCommand(CommandContext commandContext)
    {
        if (commandContext.ChatId.HasValue && commandContext.MessageId.HasValue)
            BotClient.DeleteMessage(commandContext.ChatId.Value, commandContext.MessageId.Value);
    }

    public void SendTextMessage(CommandContext commandContext, string message, bool disableNotification = false)
    {
        if (commandContext.ChatId.HasValue) 
            BotClient.SendMessage(commandContext.ChatId.Value, message, disableNotification: true);
    }

    public void ShowMainMenu(CommandContext commandContext)
    {
        if (commandContext.ChatId.HasValue){
            var btn = new InlineKeyboardButton[1];
                btn[0] = new InlineKeyboardButton(text: "Импортировать ") {CallbackData="" };
                var rm = new InlineKeyboardMarkup(
                    inlineKeyboard:
                    [
                        btn
                    ]
                );
        }
            
    }
}