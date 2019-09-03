using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Common;
using Blog.DTO;
using Blog.IDAL;
using Blog.Model;
using Blog.WebAPI.Token;
using Blog.WebAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    public class TokenController : Controller
    {
        private IUserRepository _userRepository;

        public TokenController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录获取Token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Token")]
        public async Task<object> GetToke([FromBody]LoginViewModel model)
        {
            string JwtStr = string.Empty;
            bool success = false;


            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.UserPwd))
            {
                return "userName or password invalid";
            }
            else
            {
               User user= await _userRepository.IsExitsAccount(new User
                {
                     UserName=model.UserName,
                     Pwd=MD5Tool.Encrypt(model.UserPwd)
                });
                
                if (user.UserName!=model.UserName)
                {
                    return Ok(new
                    {
                        jwt = "",
                        userName = model.UserName,
                        msg = "userName or password Error!!!",
                        success = success
                    }); ;
                }else{

                    TokenModelJwt tokenModelJwt = new TokenModelJwt { Uid = 1, Role = user.RealName };
                    //得到Token
                    JwtStr = TokenManager.IssueJwt(tokenModelJwt);
                    success = true;

                    return Ok(new
                    {
                        jwt = JwtStr,
                        userName = user.RealName,
                        msg="pass",
                        success = success
                    });
                }

            }
            ////角色需从DB中查询得到
            //var userRole = "Admin";

            //if (userRole != null)
            //{
            //    TokenModelJwt tokenModelJwt = new TokenModelJwt { Uid = 1, Role = userRole };
            //    //得到Token
            //    JwtStr = TokenManager.IssueJwt(tokenModelJwt);
            //    success = true;
            //}

            //return Ok(new
            //{
            //    jwt = JwtStr,
            //    userName="Admin",
            //    success = success
            //}) ;

        }
    }
}