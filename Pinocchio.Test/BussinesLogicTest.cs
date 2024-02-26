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
        TestContext.Out.WriteLine("setup");
        var contextFactory = new SqlitePinocchioContextFactory();
        this.context = contextFactory.CreateDbContext([], TestContext.Out.WriteLine);
        unitOfWork = new UnitOfWork(this.context);
    }

    [TearDown]
    public void Cleanup()
    {
        TestContext.Out.WriteLine("Cleanup");
        unitOfWork.Commit();
        unitOfWork.Dispose();

        context?.Dispose();
        context = null;
    }
    [Test]
    public void TestGetChildStates()
    {
        var bo = new ChildStateBussinesObject(unitOfWork);
        Assert.DoesNotThrow(delegate {
            var result = bo.GetChildStates(DateOnly.FromDateTime(DateTime.Now));
            throw new ApplicationException("Ny Zina, ny ep twoyou mat'");
        } );
    }
}