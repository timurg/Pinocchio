using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class DateChildStateRepository : IDateChildStateRepository
{

    private readonly PinocchioDataContext context;

    public DateChildStateRepository(PinocchioDataContext context)
    {
        this.context = context;
    }

    public DateChildState? Get(uint id)
    {
        if (context.Set<DateChildState>().Local.Any(e => e.Id == id))
        {
            return context.Set<DateChildState>().Find(id);
        }
        else
        {
            return (from e in GetQuery()
                    where e.Id == id
                    select e).FirstOrDefault();
        }
    }

    public IQueryable<DateChildState> GetQuery()
    {
        return context.Set<DateChildState>();
    }

    public void Save(DateChildState child)
    {
        if (context.Set<DateChildState>().Any(e => e.Id == child.Id))
        {
            context.Set<DateChildState>().Attach(child).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        else
        {
            context.Set<DateChildState>().Add(child);
        }
    }
}
