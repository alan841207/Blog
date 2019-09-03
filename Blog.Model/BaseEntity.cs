using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    public class BaseEntity
    {
        private DateTime createTime = DateTime.Now;

        /// <summary>
        /// 主键 自动生成Guid
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 创建时间  默认时间
        /// </summary>
        public DateTime CreateTime { get => createTime; set => createTime = value; }
        /// <summary>
        /// 是否删除(伪删除) 0:未删除  1:已删除
        /// </summary>
        public bool IsRemove { get; set; }
    }
}
