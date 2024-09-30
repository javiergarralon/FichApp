using FichApp.DataAccess.Data;
using FichApp.DataAccess.Repository.IRepository;
using FichApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.DataAccess.Repository
{
    public class TimesheetRepository : Repository<Timesheet>, ITimesheetRepository
    {
        private ApplicationDbContext _db;

        public TimesheetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Timesheet timesheet)
        {
            _db.Timesheets.Update(timesheet);
        }
    }
}
