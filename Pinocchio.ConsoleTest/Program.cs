using Pinocchio.BussinesLogic;
using Pinocchio.Infrastructure.EntityFramework;
using Pinocchio.Infrastructure.EntityFramework.Sqlite;

var contextFactory = new SqlitePinocchioContextFactory();
var context = contextFactory.CreateDbContext([], System.Console.WriteLine);
var unitOfWork = new UnitOfWork(context);

var bo = new ChildStateBussinesObject(unitOfWork);
var pob = new ParentControlBussinesObject (unitOfWork);
var result = bo.GetChildStates(DateOnly.FromDateTime(DateTime.Now));

/*
// Start import child list

var fileStream = File.OpenRead("/home/timur/Документы/GitHub/Pinocchio/data/test.txt");

pob.ImportChildren(new StreamReader(fileStream));

//end
*/

unitOfWork.Commit();
Console.WriteLine("Done");