using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 文章列表
    /// </summary>
    public class ArticleToCategory:BaseEntity
    {
        /// <summary>
        /// 类别外键
        /// </summary>
        [ForeignKey(nameof(BlogCategory))]
        public Guid BlogCategoryId { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public BlogCategory BlogCategory { get; set; }

        /// <summary>
        /// 文章外键
        /// </summary>
        [ForeignKey(nameof(Article))]
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
