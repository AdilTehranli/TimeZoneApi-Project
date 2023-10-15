using TimeZone.Core.Entities;
using TimeZone.DAL.Contexts;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.DAL.Repositories.Implements;

public class BannerRepository : Repository<Banner>, IBannerRepository
{
    public BannerRepository(AppDbContext context) : base(context)
    {
    }
}
