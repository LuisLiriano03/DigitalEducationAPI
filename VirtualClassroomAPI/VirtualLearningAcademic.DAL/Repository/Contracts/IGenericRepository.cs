using System.Linq.Expressions;

namespace VirtualLearningAcademic.DAL.Repository.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> GetDataDetails(Expression<Func<TModel, bool>> filter);
        Task<TModel> CreateData(TModel model);
        Task<bool> UpdateData(TModel model);
        Task<bool> RemoveData(TModel model);
        Task<IQueryable<TModel>> ValidateDataExistence(Expression<Func<TModel, bool>> filter = null);

    }

}
