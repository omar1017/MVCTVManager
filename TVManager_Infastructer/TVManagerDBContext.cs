using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_Domain ;

namespace TVManager_Infrastructure
{
    public class TVManagerDBContext:DbContext
    {
        public DbSet<Language> Languages {  get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
        public TVManagerDBContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = TVManager");

            base.OnConfiguring(optionsBuilder);
        }
        public TVManagerDBContext() { }
    }
}
