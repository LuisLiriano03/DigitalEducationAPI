using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VirtualLearningAcademic.DAL.Context.DBContext;
using VirtualLearningAcademic.DAL.Repository.Contracts;

namespace VirtualLearningAcademic.DAL.Repository.Repositorys
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbdigitalEducationContext _dbContext;

        public GenericRepository(DbdigitalEducationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModel> GetDataDetails(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _dbContext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw;
            }

        }

        public async Task<TModel> CreateData(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateData(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> RemoveData(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }

        public async Task<IQueryable<TModel>> ValidateDataExistence(Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> ModelQuery = filter == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
                return ModelQuery;
            }
            catch
            {
                throw;
            }

        }

    }

}
