using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    ///  评论
    /// </summary>
    public class Comment: BaseEntity
    {
        /// <summary>
        /// 自增键 -> 几楼
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int CommentId { get; set; }
        /// <summary>
        /// 文章外键
        /// </summary>
        [ForeignKey(nameof(Article))]
        public Guid ArticleId { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public Article Article { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        [Required]
        [Column(TypeName ="ntext")]
        public string CommentContent { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }
    }
}
