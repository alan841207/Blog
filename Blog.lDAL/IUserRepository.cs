using Blog.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IDAL
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> IsExitsAccount(User u);
    }
}
