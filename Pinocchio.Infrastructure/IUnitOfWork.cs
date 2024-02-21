using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinocchio.Infrastructure
{
    public interface IUnitOfWork
    {
        IChildRepository ChildRepository { get; }
        IParentRepository ParentRepository { get; }
    }
}