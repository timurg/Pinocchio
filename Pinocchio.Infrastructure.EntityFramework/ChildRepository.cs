using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class ChildRepository : IChildRepository
{
    private readonly PinocchioDataContext context;

    public ChildRepository(PinocchioDataContext context){
        this.context = context;
    }
    public void Delete(Child child)
    {
        context.Set<Child>().Remove(child);
    }

    public Child Get(Guid id)
    {
        if (context.Set<Child>().Local.Any(e => e.Id == id))
            {
                return context.Set<Child>().Find(id);
            }
            else
            {
                return (from e in GetQuery()
                        where e.Id == id
                        select e).FirstOrDefault();
            }
    }

    public IQueryable<Child> GetQuery()
    {
        return context.Set<Child>();
    }

    public void Save(Child child)
    {
        if (context.Set<Child>().Any(e => e.Id == child.Id))
            {
                context.Set<Child>().Attach(child).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                context.Set<Child>().Add(child);
            }
    }
}
