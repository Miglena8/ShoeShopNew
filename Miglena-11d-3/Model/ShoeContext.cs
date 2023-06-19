using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Miglena_11d_3.Model
{


    public class ShoesContext : DbContext
    {
        public ShoesContext() : base("ShoesContext")
        {

        }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeType> ShoeTypes { get; set; }
    }

}
