using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 群组
    /// </summary>
    public class UserGroup:BaseEntity
    {
        /// <summary>
        /// 组名
        /// </summary>
        [Required]
        public string GroupName { get; set; }
    }
}
