using Microsoft.EntityFrameworkCore;
using RESTdotnetAPI.Model.Base;
using RESTdotnetAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTdotnetAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public T Create(T item)
        {

            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
           
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

      
        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            return result;
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
            
        }


    }
}
