using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Interface.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        //RollBack();
    }
}
