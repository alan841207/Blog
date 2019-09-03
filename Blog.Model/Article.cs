using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article:BaseEntity
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        //[Required]
        public string ArticleTitle { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        //[Required]
        [Column(TypeName ="ntext")]
        public string ArticleContent { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public int Good { get; set; }

        /// <summary>
        /// 是否公开
        /// </summary>
        public bool IsShare { get; set; }
    }
}
