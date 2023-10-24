﻿using TimeZone.Core.Entities;
using TimeZone.DAL.Contexts;
using TimeZone.DAL.Repositories.Interfaces;

namespace TimeZone.DAL.Repositories.Implements;

public class AboutRepository : Repository<About>, IAboutRepository
{
    public AboutRepository(AppDbContext context) : base(context)
    {
    }
}
