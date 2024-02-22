using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinocchio.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ///<summary>
        /// Необходимо вызывать для фиксации
        ///</summary>
        void Commit();
        IChildRepository ChildRepository { get; }
        IParentRepository ParentRepository { get; }
        IDateChildStateRepository DateChildStateRepository {get;}
    }
}