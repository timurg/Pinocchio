using Pinocchio.BussinesLogic;
using Pinocchio.Infrastructure;
using Pinocchio.Infrastructure.EntityFramework;
using Pinocchio.Infrastructure.EntityFramework.Sqlite;

namespace Pinocchio.Test;

[TestFixture]
public class BussinesLogicTest
{
    private UnitOfWork unitOfWork;
    private PinocchioDataContext? context;
    [SetUp]
    public void Setup()
    {
        var contextFactory = new SqlitePinocchioContextFactory();
        this.context = contextFactory.CreateDbContext([]);
        unitOfWork = new UnitOfWork(this.context);
    }

    [TearDown]
    public void Cleanup()
    {
        unitOfWork.Commit();
        unitOfWork.Dispose();

        context?.Dispose();
        context = null;
    }
    [Test]
    public void Test1()
    {
        var bo = new ChildStateBussinesObject(unitOfWork);
        var result = bo.GetChildStates(DateOnly.FromDateTime(DateTime.Now));

        Assert.Pass();
    }
}