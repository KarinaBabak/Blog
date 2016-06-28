using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.BLL.Interface.Entities;

namespace Blog.BLL.Interface.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentEntity> GetByArticle(int articleId);
        CommentEntity GetCommentEntityById(int id);
        IEnumerable<CommentEntity> GetAllCommentEntities();
        void CreateComment(CommentEntity comment);
        void DeleteComment(CommentEntity comment);
        void UpdateComment(CommentEntity comment);
    }
}
