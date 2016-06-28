using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Interface.DTO;

namespace Blog.DAL.Interface.Interface
{
    public interface IArticleRepository: IRepository<DalArticle>
    {
        IEnumerable<DalArticle> GetByTag(int tagId);
        IEnumerable<DalArticle> GetBySection(int sectionId);
        IEnumerable<DalArticle> GetByDatePublication(DateTime datePublicatipn);
        IEnumerable<DalArticle> GetByBlogger(int bloggerId);
        IEnumerable<DalArticle> Search(string searchString);

    }
}
