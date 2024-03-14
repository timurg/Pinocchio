using Telegram.BotAPI;

namespace Pinocchio.Bot;

public class StartCommand: NamedCommand
{
    public StartCommand(TelegramBotClient botClient) : base(botClient, "start")
    {
    }

    public override void ExecutionContext(CommandContext context)
    {
        SendTextMessage(context,
            $"Привет {context.User.UserName}, набери команду /info", disableNotification: true);
    }
}