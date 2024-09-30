using FichApp.DataAccess.Repository.IRepository;
using FichApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.DataAccess.Repository.IRepository
{
    public interface ITimesheetRepository : IRepository<Timesheet>
    {
        void Update(Timesheet timesheet);
    }
}
