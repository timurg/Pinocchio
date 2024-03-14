using Pinocchio.Domain;
using Pinocchio.Infrastructure;

namespace Pinocchio.Bot;

public record class CommandContext
{
    public string CommandName = null!;
    public long? ChatId;
    public int? MessageId;
    public long? FromId;
    public string Message = null!;
    public Parent User = null!;
    public IUnitOfWork UnitOfWork = null!;
    public string[] Parameters = null!;
}
