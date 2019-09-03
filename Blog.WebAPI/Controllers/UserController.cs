using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Blog.Common;
using Blog.IBLL;
using Blog.Model;
using Blog.WebAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public async Task<MessageModel<string>> CreateUser([FromBody]UserViewModel model)
        {

            var data = new MessageModel<string>();
            if (!ModelState.IsValid)
            {
                
            }
            try
            {
              await  userService.CreateAsync(new User
                {
                    UserName = model.UserName,
                    Pwd = MD5Tool.Encrypt(model.UserPwd),
                    UserSex = model.Sex,
                    RealName = model.RealName,
                    Birthday = model.Bridthday,
                    Phone = model.Phone,
                    UserGroupId = model.GroupId
                });

                data.success = true;
                data.msg = "ok";
                data.response = "add User Success!!!";

            }
            catch (Exception ex)
            {

                data.msg = "Error!!!";
                data.response = "add User Error!!!";
            }
            return data;
        }
    }
}