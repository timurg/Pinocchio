using Pinocchio.Domain;

namespace Pinocchio.Infrastructure;

public interface IChildRepository
{
    Child Get(Guid id);
    void Save(Child child);
    void Delete(Child child);
    IQueryable<Child> GetQuery();
}
