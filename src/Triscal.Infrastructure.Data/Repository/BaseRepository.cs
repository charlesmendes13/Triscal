using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Infrastructure.Data.Context;

namespace Triscal.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TriscalContext _context;

        public BaseRepository(TriscalContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public virtual async Task<T> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        #endregion
    }    
}
