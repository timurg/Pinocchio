namespace Pinocchio.Infrastructure.EntityFramework;

using System;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction? transaction;
    private bool savedAutoDetectChangesEnabled;
    private readonly PinocchioDataContext context;
    private readonly ChildRepository childRepository;
    private readonly ParentRepository parentRepository;
    private readonly DateChildStateRepository dateChildStateRepository;

    public UnitOfWork(PinocchioDataContext context)
    {
        this.context = context;

        transaction = context.Database.BeginTransaction();
        savedAutoDetectChangesEnabled = this.context.ChangeTracker.AutoDetectChangesEnabled;
        this.context.ChangeTracker.AutoDetectChangesEnabled = false;

        childRepository = new ChildRepository(context);
        parentRepository = new ParentRepository(context);
        dateChildStateRepository = new DateChildStateRepository(context);
    }

    public IChildRepository ChildRepository => childRepository;

    public IParentRepository ParentRepository => parentRepository;

    public IDateChildStateRepository DateChildStateRepository => dateChildStateRepository;

    public void Commit()
    {
        if (transaction != null)
        {
            transaction.Commit();
            transaction.Dispose();
            transaction = null;
        }
        context.ChangeTracker.DetectChanges();


        var saved = false;
        while (!saved)
        {
            try
            {
                context.SaveChanges();
                saved = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    var proposedValues = entry.CurrentValues;
                    var databaseValues = entry.GetDatabaseValues();

                    foreach (var property in proposedValues.Properties)
                    {
                        var proposedValue = proposedValues[property];
                        //var databaseValue = databaseValues[property];

                        // TODO: decide which value should be written to database
                        proposedValues[property] = proposedValue;
                        //proposedValue = proposedValues[property];
                    }

                    // Refresh original values to bypass next concurrency check
                    entry.OriginalValues.SetValues(databaseValues);

                }
            }
        }

        //Context.SaveChanges();
        context.ChangeTracker.AutoDetectChangesEnabled = savedAutoDetectChangesEnabled;
    }

    public void Dispose()
    {
        if (transaction != null)
        {
            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
            throw new UnitOfWorkNotCommitedException();
        }
    }
}

[Serializable]
internal class UnitOfWorkNotCommitedException : Exception
{
    public UnitOfWorkNotCommitedException()
    {
    }

    public UnitOfWorkNotCommitedException(string? message) : base(message)
    {
    }

    public UnitOfWorkNotCommitedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnitOfWorkNotCommitedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}