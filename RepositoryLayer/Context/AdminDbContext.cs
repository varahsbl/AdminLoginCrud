using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class AdminDbContext : DbContext
    {
        public DbSet<Admin> users { get; set; }
        public AdminDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
