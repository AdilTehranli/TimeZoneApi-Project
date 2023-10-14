using TimeZone.Core.Entities;
using TimeZone.DAL.Contexts;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.DAL.Repositories.Implements;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }
}
