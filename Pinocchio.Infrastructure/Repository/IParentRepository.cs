namespace Pinocchio.Infrastructure;

using System.Xml.Linq;
using Pinocchio.Domain;
public interface IParentRepository
{
    Parent? Get(long ChatId);
    void Save(Parent parent);
    void Delete(Parent parent);
    IQueryable<Parent> GetQuery();
}
