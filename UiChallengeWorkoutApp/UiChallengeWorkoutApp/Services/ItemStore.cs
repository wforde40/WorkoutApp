using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UiChallengeWorkoutApp.Services
{
    class ItemStore<T> : IDataStore<T>
    {
        public Task<bool> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public T Get()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
