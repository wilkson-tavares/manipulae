using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Interface
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
