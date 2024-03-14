using Telegram.BotAPI;

namespace Pinocchio.Bot;

public abstract class NamedCommand : BaseCommand
{
    public string CommandName { get; }

    public NamedCommand(TelegramBotClient botClient, string commandName) : base(botClient)
    {
        CommandName = commandName;
    }

    public abstract void ExecutionContext(CommandContext context);

}
