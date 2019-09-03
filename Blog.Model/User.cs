using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User:BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string  Pwd { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 性别 0：男 1：女
        /// </summary>
        public bool UserSex { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户群组外键
        /// </summary>
        [ForeignKey(nameof(UserGroup))]
        public Guid UserGroupId { get; set; }

        /// <summary>
        /// 用户群组
        /// </summary>
        public UserGroup UserGroup { get; set; }

    }
}
