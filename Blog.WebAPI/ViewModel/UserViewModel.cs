using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebAPI.ViewModel
{
    public class UserViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(50,MinimumLength = 6)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string  UserPwd { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Bridthday { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户群组
        /// </summary>
        public Guid GroupId { get; set; }

    }
}
