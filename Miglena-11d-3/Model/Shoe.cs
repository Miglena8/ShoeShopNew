using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miglena_11d_3.Model
{
    public class Shoe
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Opisanie { get; set; }
        public double Price { get; set; }
        public double Nomer { get; set; }
        public int ShoeTypeId { get; set; }
        public ShoeType ShoeTypes { get; set; } 
    }
}
