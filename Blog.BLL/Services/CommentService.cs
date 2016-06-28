using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;
using Blog.DAL.Interface.Interface;
using Blog.BLL.Interface.Services;
using Blog.BLL.Interface.Entities;
using Blog.BLL.Services;
using Blog.BLL.Mappers;

namespace Blog.BLL.Services
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork uow;
        private readonly ICommentRepository commentRepository;

        public CommentService(IUnitOfWork uow, ICommentRepository repository)
        {
            this.uow = uow;
            this.commentRepository = repository;
        }

        public void CreateComment(CommentEntity comment)
        {
            commentRepository.Create(comment.ToDalComment());
            uow.Commit();
        }
        public void DeleteComment(CommentEntity comment)
        {
            commentRepository.Delete(comment.ToDalComment());
            uow.Commit();
        }
        public void UpdateComment(CommentEntity comment)
        {
            commentRepository.Update(comment.ToDalComment());
            uow.Commit();
        }

        public IEnumerable<CommentEntity> GetByArticle(int articleId)
        {
            return commentRepository.GetByArticle(articleId).Select(comment => comment.ToBllComment());
        }
        public CommentEntity GetCommentEntityById(int id)
        {
            return commentRepository.GetById(id).ToBllComment();
        }
        public IEnumerable<CommentEntity> GetAllCommentEntities()
        {
            return commentRepository.GetAll().Select(comment => comment.ToBllComment());
        }
        
    }
}
