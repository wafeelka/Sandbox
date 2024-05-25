namespace AsyncDapper
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        public abstract Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        public abstract Task<IEnumerable<TEntity>> GetCollectionAsync(CancellationToken cancellationToken = default);

        public abstract Task DeleteAsync(int id, CancellationToken cancellationToken = default);

        public abstract Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        public abstract Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        public abstract Task SaveAsync(CancellationToken token = default);
    }
}
