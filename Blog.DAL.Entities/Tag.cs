﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DAL.Entities
{
    public class Tag: IEntity
    {
        public Tag()
        {
            TagsArticle = new HashSet<TagArticle>();
        }

        public int Id { get; set; }       
        public string Name { get; set; }
        public virtual ICollection<TagArticle> TagsArticle { get; set; }
    }
}
