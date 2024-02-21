using Pinocchio.Domain;

namespace Pinocchio.Infrastructure.EntityFramework;

public class ParentRepository : IParentRepository
{

private readonly PinocchioDataContext context;

    public ParentRepository(PinocchioDataContext context){
        this.context = context;
    }    
    public void Delete(Parent parent)
    {
        throw new NotImplementedException();
    }

    public Parent Get(string ChatId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Parent> GetQuery()
    {
        throw new NotImplementedException();
    }

    public void Save(Parent parent)
    {
        throw new NotImplementedException();
    }
}
