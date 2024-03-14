using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class ParentRepository : IParentRepository
{

    private readonly PinocchioDataContext context;

    public ParentRepository(PinocchioDataContext context)
    {
        this.context = context;
    }
    public void Delete(Parent parent)
    {
        context.Set<Parent>().Remove(parent);
    }

    public Parent? Get(long ChatId)
    {
        if (context.Set<Parent>().Local.Any(e => e.ChatId == ChatId))
        {
            return context.Set<Parent>().Find(ChatId);
        }
        else
        {
            return (from e in GetQuery()
                    where e.ChatId == ChatId
                    select e).FirstOrDefault();
        }
    }

    public IQueryable<Parent> GetQuery()
    {
        return context.Set<Parent>();
    }

    public void Save(Parent parent)
    {
        if (context.Set<Parent>().Any(e => e.ChatId == parent.ChatId))
        {
            context.Set<Parent>().Attach(parent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        else
        {
            context.Set<Parent>().Add(parent);
        }
    }
}
