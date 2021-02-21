using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDevelopmentAssessment.Models;

namespace WebDevelopmentAssessment.Data
{
    public class WebContentContext : DbContext
    {
        public WebContentContext (DbContextOptions<WebContentContext> options)
            : base(options)
        {
        }

        public DbSet<WebDevelopmentAssessment.Models.Picture> Picture { get; set; }
    }
}
