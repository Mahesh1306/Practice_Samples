using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample.Models
{
    public class ContextModel : DbContext
    {
        public ContextModel(DbContextOptions<ContextModel> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
    }
}
