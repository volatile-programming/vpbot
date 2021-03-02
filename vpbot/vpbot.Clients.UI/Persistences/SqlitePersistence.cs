using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using SQLite;

using VPBot.DataObjects.Contracts.Core;

namespace VPBot.Clients.UI.Persistences
{
    public class SqlitePersistence<TEntity> : IPersistence<TEntity>
        where TEntity : class, IEntity<Guid>, new()
    {
        private SQLiteConnection _connection;
        private SQLiteAsyncConnection _connectionAsync;

        public SqlitePersistence(SQLiteConnection connection, SQLiteAsyncConnection connectionAsync)
        {
            _connection = connection;
            _connectionAsync = connectionAsync;

            if (!_connection.TableMappings.Any(m => m.MappedType.Name == typeof(TEntity).Name))
                _connection.CreateTable<TEntity>();
        }

        public IUnitOfWork UnitOfWork { get; set; }

        #region Create

        public void Add(TEntity entity)
        {
            _ = _connection.Insert(entity);
        }

        #endregion

        #region Read

        public bool Any(Func<TEntity, bool> query)
        {
            var result = _connection.Table<TEntity>().Any(query);

            return result;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> query)
        {
            var result = _connection.Get(query);

            return result;
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> query)
        {
            var result = _connectionAsync.GetAsync(query);

            return result;
        }

        public List<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            var table = _connection.Table<TEntity>()
                    .OrderBy(x => x.Id);

            if (query != null)
                table = table.Where(query);

            var result = table.ToList();

            return result;
        }
        public Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> query)
        {
            var table = _connectionAsync.Table<TEntity>()
                    .OrderBy(x => x.Id);

            if (query != null)
                table = table.Where(query);

            var result = table.ToListAsync();

            return result;
        }

        #endregion

        #region Update

        public void Update(TEntity entity)
        {
            _ = _connection.Update(entity);
        }

        #endregion

        #region Delete

        public void Remove(TEntity entity)
        {
            _ = _connection.Delete<TEntity>(entity);
        }

        #endregion
    }
}
