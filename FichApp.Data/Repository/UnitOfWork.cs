using FichApp.DataAccess.Data;
using FichApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ITimesheetRepository TimesheetRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TimesheetRepository = new TimesheetRepository(_db);
        }       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
