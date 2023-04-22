using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentProject.Abstraction.IRepositories
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
