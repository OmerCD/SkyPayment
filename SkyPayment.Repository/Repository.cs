using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SkyPayment.Core.Entities;
using SkyPayment.Core.Mongo;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Repository
{
    public class Repository<T>: IRepository<T> where T :BaseEntity
    {
        private SkyPaymentContext _context;
        private IMongoCollection<T> Collection => _context.Get<T>();
        public Repository(SkyPaymentContext context)
        {
            _context = context;
            // _collection = _context;
        }

        public IQueryable<T> AsQueryable()
        {
            return Collection.AsQueryable();
        }

        public IEnumerable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return Collection.AsQueryable().Where(filterExpression);
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TProjected>> projectionExpression)
        {
            throw new NotImplementedException();
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            return Collection.AsQueryable().FirstOrDefault(filterExpression);
        }

        public Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return Task.Run(() => Collection.AsQueryable().FirstOrDefault(filterExpression));
        }

        public T FindById(string id)
        {
            return Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public Task<T> FindByIdAsync(string id)
        {
            return Task.Run(() => Collection.AsQueryable().FirstOrDefault(x => x.Id == id));
        }

        public T InsertOne(T document)
        { 
            Collection.InsertOne(document);
            return document;
        }

        public Task InsertOneAsync(T document)
        {
            return Collection.InsertOneAsync(document);
        }

        public void InsertMany(ICollection<T> documents)
        {
            Collection.InsertMany(documents);
        }

        public Task InsertManyAsync(ICollection<T> documents)
        {
            return Collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(T document)
        {
            var filter = Builders<T>.Filter.Eq(nameof(document.Id), document.Id);
            var update = new BsonDocumentUpdateDefinition<BsonDocument>(document.ToBsonDocument());
            
            Collection.ReplaceOne(filter, document);
        }
        
        public Task ReplaceOneAsync(T document)
        {
            var filter = Builders<T>.Filter.Eq(nameof(document.Id), document.Id);
            return Collection.ReplaceOneAsync(filter, document);
        }
        public void UpdateOne(T document, UpdateDefinition<T> updateDefinition)
        {
            var filter = Builders<T>.Filter.Eq(nameof(document.Id), document.Id);
            Collection.UpdateOne(filter, updateDefinition);
        }
        public Task UpdateOneAsync(T document, UpdateDefinition<T> updateDefinition)
        {
            var filter = Builders<T>.Filter.Eq(nameof(document.Id), document.Id);
            return Collection.UpdateOneAsync(filter, updateDefinition);
        }

        public void DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            var found = Collection.AsQueryable().FirstOrDefault(filterExpression);
            if (found == null) return;
            var filter = Builders<T>.Filter.Eq(nameof(found.Id), found.Id);
            Collection.DeleteOne(filter);
        }

        public Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            var found = Collection.AsQueryable().FirstOrDefault(filterExpression);
            if (found == null) return Task.CompletedTask;
            var filter = Builders<T>.Filter.Eq(nameof(found.Id), found.Id);
            return Collection.DeleteOneAsync(filter);
        }

        public void DeleteById(string id)
        {
            var filter = Builders<T>.Filter.Eq(nameof(BaseEntity.Id), id);
            Collection.DeleteOne(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq(nameof(BaseEntity.Id), id);
            return Collection.DeleteOneAsync(filter);
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