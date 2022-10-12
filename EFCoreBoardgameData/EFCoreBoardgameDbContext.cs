using EFCoreBoardgameData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreBoardgameData
{
    public class EFCoreBoardgameDbContext :DbContext
    {
        public EFCoreBoardgameDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Boardgame> Boardgames { get; set; }
    }
}
