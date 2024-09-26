using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichApp.Data.Repository.IRepository
{
    internal interface IUnitOfWork
    {
        void Save();
    }
}
