using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Eindopdracht2.Models;

namespace Eindopdracht2.Data
{
    public class Eindopdracht2Context : DbContext
    {
        public Eindopdracht2Context (DbContextOptions<Eindopdracht2Context> options)
            : base(options)
        {
        }

        public DbSet<Eindopdracht2.Models.Song> Songs { get; set; } = default!;

        public DbSet<Eindopdracht2.Models.Album> Albums { get; set; } = default!;
    }
}
