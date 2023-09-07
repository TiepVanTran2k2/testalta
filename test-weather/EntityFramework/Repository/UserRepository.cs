using Domain.Entities;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repository;
public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DbContextApp1 db) : base(db)
    {
    }
}
