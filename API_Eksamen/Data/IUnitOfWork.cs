using API_Eksamen.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Eksamen.Data
{
   public interface IUnitOfWork : IDisposable
    {

     
        ITestObjectRepository TestObjects { get; }
        int Complete();


    }
}
