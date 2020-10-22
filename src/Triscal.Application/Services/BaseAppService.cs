using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Triscal.Application.Interfaces;
using Triscal.Domain.Interfaces.Services;

namespace Triscal.Application.Services
{
    public class BaseAppService<T> : IBaseAppService<T> where T : class
    {
        private readonly IBaseService<T> _service;

        public BaseAppService(IBaseService<T> service)
        {
            _service = service;
        }        

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _service.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _service.GetByIdAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            return await _service.InsertAsync(entity);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _service.UpdateAsync(entity);
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await _service.DeleteAsync(entity);
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
