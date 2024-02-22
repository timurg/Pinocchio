using Pinocchio.Domain;

namespace Pinocchio.Infrastructure;

public interface IDateChildStateRepository
{
    DateChildState? Get(uint id);
    void Save(DateChildState child);
    IQueryable<DateChildState> GetQuery();
}
