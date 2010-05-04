namespace ExportFromSQLToMongo.Infrastructure
{
    #region Using Directives

    using System;
    using System.Linq;

    using ExportFromSQLToMongo.Contracts;

    using Norm.Linq;

    #endregion

    internal class Session<TEntity> : IDisposable
    {
        private readonly MongoQueryProvider provider;

        public Session(string dbName)
        {
            this.provider = new MongoQueryProvider(dbName);
        }

        public IQueryable<TEntity> Queryable 
        {
            get { return new MongoQuery<TEntity>(this.provider); }
        }

        public MongoQueryProvider Provider
        {
            get { return this.provider; }
        }

        public void Add<T>(T item) where T : class, new()
        {
            this.provider.DB.GetCollection<T>().Insert(item);
        }

        public void Dispose()
        {
            this.provider.Server.Dispose();
        }

        public void Drop<T>()
        {
            this.provider.DB.DropCollection(typeof(T).Name);
        }

        public void Update<T>(T item) where T :  class, IUniqueIdentifier, new()
        {
            this.provider.DB.GetCollection<T>().UpdateOne(new { _id = item.Id }, item);
        }
    }
}