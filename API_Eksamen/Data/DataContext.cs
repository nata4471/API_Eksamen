using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Eksamen.Models;

namespace API_Eksamen.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TestObject> TestObjects { get; set; }

        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

    }
}
