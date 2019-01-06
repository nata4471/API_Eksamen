using API_Eksamen.Data.IRepository;
using API_Eksamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API_Eksamen.Data.Repository
{
    public class TestObjectRepository : Repository<TestObject>, ITestObjectRepository
    {
        public TestObjectRepository(DataContext _context) : base(_context)

        {

        }



        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }

      
    }
}
