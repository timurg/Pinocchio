using Pinocchio.Domain;
using Pinocchio.Infrastructure;

namespace Pinocchio.BussinesLogic;

public class ChildStateBussinesObject
{

    private readonly IUnitOfWork unitOfWork;

    public ChildStateBussinesObject(IUnitOfWork unitOfWork){
        this.unitOfWork = unitOfWork;
    }
    public void ChangeState(Child child, DateOnly date, ChildState childState){
        var lastState = unitOfWork.
    }
}
