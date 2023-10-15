using TimeZone.Core.Entities;
using TimeZone.DAL.Contexts;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.DAL.Repositories.Implements;

public class WrapperRepository : Repository<Wrapper>, IWrapperRepository
{
    public WrapperRepository(AppDbContext context) : base(context)
    {
    }
}
