using Blog.IBLL;
using Blog.IDAL;
using Blog.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.BLL
{
    /// <summary>
    /// 业务实现基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity,new()
    {

        //public IBaseRepository<TEntity> baseDal = new BaseRepository<TEntity>();
        //通过在子类的构造函数中注入，这里是基类，不用构造函数
        public IBaseRepository<TEntity> baseRespository; 


        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task CreateAsync(TEntity model, bool saved = true)
        {
            await baseRespository.CreateAsync(model,saved);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task EditAsync(TEntity model, bool saved = true)
        {
            await baseRespository.EditAsync(model, saved);
        }

        /// <summary>
        /// 查询所有集合
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllAsync()
        {
            return baseRespository.GetAllAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            return baseRespository.GetAllByPageAsync(pageSize, pageIndex);
        }

        /// <summary>
        /// 分页排序
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return baseRespository.GetAllByPageOrderAsync(pageSize, pageIndex, asc);
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllOrderAsync(bool asc = true)
        {
            return baseRespository.GetAllOrderAsync(asc);
        }

        /// <summary>
        ///  获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetOneByIdAsync(Guid id)
        {
            return await baseRespository.GetOneByIdAsync(id);
        }

        /// <summary>
        /// 删除实体 （伪删除）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id, bool saved = true)
        {
            await baseRespository.RemoveAsync(id, saved);
        }

        /// <summary>
        /// 删除实体(伪删除)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TEntity model, bool saved = true)
        {
            await baseRespository.RemoveAsync(model, saved);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            await baseRespository.Save();
        }
    }
}
