using DL.IRepository;
using DL.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class BaseServices<T, TKey> : IBaseServices<T, TKey> where T : class, new()
    {
		//通过在子类的构造函数中注入，这里是基类，不用构造函数
		public IBaseRepository<T, TKey> baseDal;

        public int Delete(TKey id)
        {
            return baseDal.Delete(id);
        }

        public int Delete(T entity)
        {
            return baseDal.Delete(entity);
        }

        public Task<int> DeleteAsync(TKey id)
        {
            return baseDal.DeleteAsync(id);
        }

        public Task<int> DeleteAsync(T entity)
        {
            return baseDal.DeleteAsync(entity);
        }

        public int DeleteList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return baseDal.DeleteList(whereConditions, transaction, commandTimeout);
        }

        public int DeleteList(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return baseDal.DeleteList(conditions, parameters, transaction, commandTimeout);
        }

        public Task<int> DeleteListAsync(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return baseDal.DeleteListAsync(whereConditions, transaction, commandTimeout);
        }

        public Task<int> DeleteListAsync(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return baseDal.DeleteListAsync(conditions, parameters, transaction, commandTimeout);
        }

        public void Dispose()
        {
            baseDal.Dispose();
        }

        public T Get(TKey id)
        {
            return baseDal.Get(id);
        }

        public Task<T> GetAsync(TKey id)
        {
            return baseDal.GetAsync(id);
        }

        public IEnumerable<T> GetList()
        {
            return baseDal.GetList();
        }

        public IEnumerable<T> GetList(object whereConditions)
        {
            return baseDal.GetList(whereConditions);
        }

        public IEnumerable<T> GetList(string conditions, object parameters = null)
        {
            return baseDal.GetList(conditions, parameters);
        }

        public Task<IEnumerable<T>> GetListAsync()
        {
            return baseDal.GetListAsync();
        }

        public Task<IEnumerable<T>> GetListAsync(object whereConditions)
        {
            return baseDal.GetListAsync(whereConditions);
        }

        public Task<IEnumerable<T>> GetListAsync(string conditions, object parameters = null)
        {
            return baseDal.GetListAsync(conditions, parameters);
        }

        public IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            return baseDal.GetListPaged(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }

        public Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            return baseDal.GetListPagedAsync(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }

        public int? Insert(T entity)
        {
            return baseDal.Insert(entity);
        }

        public Task<int?> InsertAsync(T entity)
        {
            return baseDal.InsertAsync(entity);
        }

        public int RecordCount(string conditions = "", object parameters = null)
        {
            return baseDal.RecordCount(conditions, parameters);
        }

        public Task<int> RecordCountAsync(string conditions = "", object parameters = null)
        {
            return baseDal.RecordCountAsync(conditions, parameters);
        }

        public int Update(T entity)
        {
            return baseDal.Update(entity);
        }

        public Task<int> UpdateAsync(T entity)
        {
            return baseDal.UpdateAsync(entity);
        }
    }
}
