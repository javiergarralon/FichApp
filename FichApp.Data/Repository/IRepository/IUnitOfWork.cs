using FichApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITimesheetRepository TimesheetRepository { get; }
        void Save();
    }
}
