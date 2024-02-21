namespace Pinocchio.Infrastructure;

using System.Xml.Linq;
using Pinocchio.Domain;
public interface IParentRepository
{
    Parent Get(string ChatId);
    void Save(Parent parent);
    void Delete(Parent parent);
    IQueryable<Parent> GetQuery();
}
