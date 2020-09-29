using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using SkyPayment.Core.Entities;
using SkyPayment.Core.Mongo;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Repository
{
    public class Repository<T>: IRepository<T> where T :IEntity
    {
        private SkyPaymentContext _context;
        private readonly IMongoCollection<T> _collection;
        
        public Repository(SkyPaymentContext context, IMongoCollection<T> collection)
        {
            _context = context;
            // _collection = _context;
        }

        public IQueryable<T> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            throw new NotImplementedException();
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public T FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertOne(T document)
        {
            throw new NotImplementedException();
        }

        public Task InsertOneAsync(T document)
        {
            throw new NotImplementedException();
        }

        public void InsertMany(ICollection<T> documents)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(ICollection<T> documents)
        {
            throw new NotImplementedException();
        }

        public void ReplaceOne(T document)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceOneAsync(T document)
        {
            throw new NotImplementedException();
        }

        public void DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}