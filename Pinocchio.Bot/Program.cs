
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using Pinocchio.Bot;
using Pinocchio.Infrastructure.EntityFramework;
using Pinocchio.Infrastructure.EntityFramework.Sqlite;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.GettingUpdates;

NLog.ILogger _logger = NLog.LogManager.GetCurrentClassLogger();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets<Program>()
    .Build();
    
var botClient = new TelegramBotClient(botToken: configuration["bot:id"] ?? throw new ApplicationException("Requared parametr bot:id"));

var me = botClient.GetMe();

var namedCommands = new BlockingCollection<NamedCommand>
{
    new StartCommand(botClient)
};

var contextFactory = new SqlitePinocchioContextFactory();
var context = contextFactory.CreateDbContext([]);

_logger.Debug($"Start listening for @{me.Username}");
var updates = await botClient.GetUpdatesAsync();
while (true)
{
    _logger.Trace("tic");
    if (updates.Any())
    {
        _logger.Debug("Detect updates");
        foreach (var update in updates)
        {
            using var unitOfWork = new UnitOfWork(context);
            try
            {
                var commandContext = update.GetCommandContext(unitOfWork);
                namedCommands.ExecuteCommand(commandContext);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.ToString());
            }
                
            unitOfWork.Commit();
        }

        var offset = updates.Last().UpdateId + 1;
        updates = botClient.GetUpdates(offset);
    }
    else
    {
        updates = botClient.GetUpdates();
    }
}
