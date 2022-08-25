using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatalayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int entityID);
        void Update(TEntity entity);
        void Delete(int entityID);
    }
}
