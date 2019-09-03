using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IBLL
{
    /// <summary>
    /// 仓储接口类
    /// </summary>
    public interface IBaseService<T> where T : BaseEntity
    {
        /// <summary>
        /// 异步添加单个实体
        /// </summary>
        /// <param name="model">实体数据</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task CreateAsync(T model, bool saved = true);

        /// <summary>
        ///  异步修改单个实体
        /// </summary>
        /// <param name="model">实体数据</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task EditAsync(T model, bool saved = true);

        /// <summary>
        /// 异步移除单个实体
        /// </summary>
        /// <param name="id">id键</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task RemoveAsync(Guid id, bool saved = true);

        /// <summary>
        /// 异步移除单个实体
        /// </summary>
        /// <param name="model">实体数据</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task RemoveAsync(T model, bool saved = true);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        Task Save();

        /// <summary>
        /// 异步获取一个实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<T> GetOneByIdAsync(Guid id);

        /// <summary>
        /// 获取所有的实体
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAllAsync();

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageSize">页总数</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0);

        /// <summary>
        /// 所有页排序
        /// </summary>
        /// <param name="asc"></param>
        /// <returns></returns>
        IQueryable<T> GetAllOrderAsync(bool asc = true);

        /// <summary>
        /// 分页排序
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true);



    }
}
