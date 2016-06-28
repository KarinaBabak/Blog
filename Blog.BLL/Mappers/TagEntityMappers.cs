using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Mappers
{
    public static class TagEntityMappers
    {
        public static DalTag ToDalTag(this TagEntity tagEntity)
        {
            if (tagEntity != null)
            {
                return new DalTag()
                {
                    Id = tagEntity.Id,
                    Name = tagEntity.Name
                };
            }
            return null;
        }

        public static TagEntity ToBllTag(this DalTag dalTag)
        {
            if (dalTag != null)
            {
                return new TagEntity()
                {
                    Id = dalTag.Id,
                    Name = dalTag.Name
                };
            }
            return null;
        }
    }
}
