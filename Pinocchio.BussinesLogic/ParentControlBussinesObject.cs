using System.Text;
using Pinocchio.Domain;
using Pinocchio.Infrastructure;

namespace Pinocchio.BussinesLogic;

public class ParentControlBussinesObject
{
    private readonly IUnitOfWork unitOfWork;

    public ParentControlBussinesObject(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public void AddChild(Parent parent, Child child){
        if ((child.Parent == null) && !parent.Children.Any(p => p.Id == child.Id)){
            
            parent.Children.Add(child);
        }
    }

    public void RemoveChild(Parent parent, Child child){
        if ((child.Parent != null) && parent.Children.Any(p => p.Id == child.Id)){
            
            child.Parent = null;
        }
    }

    public Dictionary<DateOnly, DateChildState?> GetChildStates(Parent parent){
        Dictionary<DateOnly, DateChildState?> result = [];
        DateOnly baseDate = DateOnly.FromDateTime(DateTime.Now);
        DateOnly[] dateOnlies = [baseDate, baseDate.AddDays(1), baseDate.AddDays(2), baseDate.AddDays(3), baseDate.AddDays(4), baseDate.AddDays(5), baseDate.AddDays(6)];
        var selection = unitOfWork.DateChildStateRepository.GetQuery().Where(s => dateOnlies.Contains(s.StateDate) && parent.Children.Contains(s.Child)).ToList();
        foreach (var processedDate in dateOnlies){
            result.Add(processedDate, selection.FirstOrDefault(s => s.StateDate == processedDate));
        }
        return result;
    }

    public void ImportChildren(StreamReader streamReader){
        var data = streamReader.ReadToEnd().Split('\n');
        foreach (var ch in data){
            var childName = ch.ToUpper().Trim();
            if (!string.IsNullOrEmpty(ch)){
                var child = unitOfWork.ChildRepository.GetQuery().FirstOrDefault(c => c.ChildName == childName);
                if (child == null){
                    child = new Child() {ChildName = childName, Active = true, Id = Guid.NewGuid(), Parent = null};
                }
                if (!child.Active){
                    child.Active = true;
                }
                unitOfWork.ChildRepository.Save(child);
            }
        }
    }
}
