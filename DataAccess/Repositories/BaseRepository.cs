using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly DbContext DbContext;
        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
