using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrincePurse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrincePurse.Data
{
    public class PrincePurseContext : IdentityDbContext
    {
        public PrincePurseContext(DbContextOptions<PrincePurseContext> options)
            : base(options)
        {
        }
        public DbSet<Purse> Purse { get; set; }
    }
}
