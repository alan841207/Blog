using Blog.IDAL;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public class UserRespository:BaseRepository<User>,IUserRepository
    {

        //public UserRespository():base(new BlogContext())
        //{

        //}
        public UserRespository(BlogContext context):base(context)
        {

        }

        /// <summary>
        /// 返回帐号对象
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public async Task<User> IsExitsAccount(User u)
        {
            //User user = await GetAllAsync().FirstAsync<User>(d => d.UserName == u.UserName && d.Pwd == u.Pwd && d.IsRemove == false);

            User user=await Db.Set<User>().FirstOrDefaultAsync(d=>d.UserName==u.UserName && d.Pwd==u.Pwd && d.IsRemove == false);


            return user==null? new User() : user ;

        }
    }
}
