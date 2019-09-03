using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 博客分类表
    /// </summary>
    public class BlogCategory:BaseEntity
    {
        /// <summary>
        /// 类别名称
        /// </summary>
        [Required]
        public string CategoryName { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        ///  用户
        /// </summary>
        public User User { get; set; }
    }
}
