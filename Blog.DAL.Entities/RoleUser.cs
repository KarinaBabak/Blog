﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Entities
{
    public class RoleUser : IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

    }
}
