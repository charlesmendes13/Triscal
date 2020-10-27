using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Entities;
using Triscal.Infrastructure.Data.Context;

namespace Triscal.Unit.Tests.Infrastructure.DbContext
{
    public class InMemoryDbContext : IDisposable
    {
        private readonly TriscalContext dbContext;

        public InMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TriscalContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            dbContext = new TriscalContext(options);
        }

        public TriscalContext DbContext()
        {
            return dbContext;
        }

        public void Seeds(object entity)
        {
            dbContext.Database.EnsureCreated();

            if (entity is ICollection)
            {
                dbContext.AddRange(((IEnumerable)entity).Cast<object>());
                dbContext.SaveChanges();
            }
            else 
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();
            }            
        }

        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();

            dbContext.Dispose();
        }
    }
}
