namespace EmployeesManagementBE.Repositories.Base
{
    public interface IBaseRepositoy<T> where T : class
    {
        T GetById(int Id);
        Task<T>  GetByIdAsync(int Id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>>  GetAllAsync();
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T>  FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take ,int skip);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip, string[] includes);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderby=null,string orderByDirection=OrderBy.Ascending);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes, int? take, int? skip, Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);  
        int Count();
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);
        Task<T> OrderAsync(Expression<Func<T, object>> orderby = null, string orderByDirection = OrderBy.Ascending);

    }

}
