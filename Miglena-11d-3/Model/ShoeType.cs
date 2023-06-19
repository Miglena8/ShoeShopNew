using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miglena_11d_3.Model
{
    public class ShoeType
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public ICollection<Shoe> Shoes { get; set; }
    }
}
