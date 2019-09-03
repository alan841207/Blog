using Blog.IDAL;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private  BlogContext _db;

        public BaseRepository(BlogContext db)
        {
            this._db = db;
        }


        internal BlogContext Db
        {
            get { return _db; }
            private set { _db = value; }
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task CreateAsync(TEntity model, bool saved = true)
        {
            this._db.Set<TEntity>().Add(model);
             if (saved) await this._db.SaveChangesAsync();
        }

        /// <summary>
        /// 资源回收
        /// </summary>
        public void Dispose()
        {
            this._db.Dispose();
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        public async Task EditAsync(TEntity model, bool saved = true)
        {
            ////修改状态
            this._db.Entry(model).State = EntityState.Modified;

            //this._db.Set<TEntity>().Update(model);
            if (saved)
            {
                await this._db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllAsync()
        {
            return this._db.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 排序并分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllOrderAsync(bool asc = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetOneByIdAsync(Guid id)
        {
           return await GetAllAsync().FirstAsync(p=>p.Id==id);
        }

        /// <summary>
        /// 伪删除 实际为更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id, bool saved = true)
        {
            TEntity t = new TEntity
            {
                Id = id
            };
            this._db.Entry(t).State = EntityState.Unchanged;
            t.IsRemove = true;
            if (saved)
            {
                await this._db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 删除实体 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TEntity model, bool saved = true)
        {
            await RemoveAsync(model.Id,saved);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            await this._db.SaveChangesAsync();
        }
    }
}
