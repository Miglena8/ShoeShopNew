using Miglena_11d_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miglena_11d_3.Controller
{
    public class ShoeTypeLogic
    {
        private ShoesContext _ShoesContext = new ShoesContext();

        public List<ShoeType> GetShoeTypes()
        {
            return _ShoesContext.ShoeTypes.ToList();
        }
        public string GetShoesTypeById(int id)
        {
            return _ShoesContext.ShoeTypes.Find(id).Marka;
        }
    }
}
