﻿using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class UniversityRepository : GenericRepository<University>, IUniversityRepository
{
    public UniversityRepository(BookingDbContext context) : base(context) { }

    public Guid GetLastUniversityGuid()
    {
        return _context.Set<University>().ToList().LastOrDefault().Guid;
    }
}