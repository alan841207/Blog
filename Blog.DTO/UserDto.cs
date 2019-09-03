using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DTO
{
    public class UserDto
    {
        public string userName { get; set; }

        public string  userPwd { get; set; }

        public string  realName { get; set; }

        public bool sex { get; set; }

        public DateTime bridthday { get; set; }

        public string phone { get; set; }

        public Guid groupid { get; set; }
    }
}
