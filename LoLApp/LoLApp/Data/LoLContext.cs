using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoLApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoLApp.Data
{
    public class LoLContext : DbContext
    {
        public LoLContext(DbContextOptions<LoLContext> options) : base(options)
        {
        }

        public DbSet<Champion> Champions { get; set; }
    }
}
