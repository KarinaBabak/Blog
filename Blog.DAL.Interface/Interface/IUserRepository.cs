using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.DAL.Interface.DTO;

namespace Blog.DAL.Interface.Interface
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetByLogin(string login);        
        IEnumerable<DalUser> GetAllBesidesAdmin();
        IEnumerable<DalUser> GetBlockedUsers();        
        void BlockUser(int id);
        void UnBlockUser(int id);
    }
}
