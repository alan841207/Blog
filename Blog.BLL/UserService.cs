using Blog.DTO;
using Blog.IBLL;
using Blog.IDAL;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL
{
    public class UserService:BaseService<User>,IUserService
    {
        private IUserRepository dal;
        public UserService(IUserRepository dal)
        {
            this.dal = dal;
            base.baseRespository = dal;
        }

        /// <summary>
        /// 是否存在此帐户
        /// </summary>
        /// <param name="u">帐户对象</param>
        /// <returns></returns>
        public async Task<User> CheckAccount(User u)
        {
           
           return await dal.IsExitsAccount(u);
        }
    }
}
