using Pinocchio.Domain;
using Pinocchio.Infrastructure;

namespace Pinocchio.BussinesLogic;

public class ChildStateBussinesObject
{

    private readonly IUnitOfWork unitOfWork;

    public ChildStateBussinesObject(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public void ChangeState(Child child, DateOnly date, ChildState childState)
    {
        var lastState = unitOfWork.DateChildStateRepository.GetQuery().
        Where(s => s.Child == child && s.StateDate == date).OrderByDescending(s => s.Id).Take(1).FirstOrDefault();

        if (lastState == null || (lastState != null && lastState.ChildState != childState))
        {
            unitOfWork.DateChildStateRepository.Save(new DateChildState() { Child = child, StateDate = date, ChildState = childState });
        }
    }

    public ISet<DateChildState> GetChildStates(DateOnly date)
    {
        var result = new HashSet<DateChildState>();
        /* var groupQuerry = 
         var s = from b in unitOfWork.ChildRepository.GetQuery()
              from p in unitOfWork.DateChildStateRepository.GetQuery().Select(p => b.Url + "=>" + p.Title).DefaultIfEmpty()
              select new { b, p };*/
        return result;
    }
}
