using Miglena_11d_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Miglena_11d_3.Controller
{
    public class ShoeLogic
    {
        private ShoesContext _ShoeContext = new ShoesContext();
        public Shoe Get(int Id)
        {
            Shoe findedShoe = _ShoeContext.Shoes.Find(Id);
            if (findedShoe != null)
            {
                _ShoeContext.Entry(findedShoe).Reference(X => X.ShoeTypes).Load();
            }
            return findedShoe;
        }
        public List<Shoe> GetAll()
        {
            return _ShoeContext.Shoes.Include("ShoeTypes" ).ToList();
        }
        public void Create(Shoe shoe)
        {
            _ShoeContext.Shoes.Add(shoe);
            _ShoeContext.SaveChanges();


        }
        public void Update(int Id, Shoe shoe)
        {
            Shoe findedShoe = _ShoeContext.Shoes.Find(Id); if (findedShoe == null)
            {
                return;
            }
            findedShoe.Marka = shoe.Marka;
            findedShoe.Price = shoe.Price;
            findedShoe.Nomer= shoe.Nomer;
            findedShoe.Opisanie = shoe.Opisanie;
            _ShoeContext.SaveChanges();




        }
        public void Delete(int id)
        {
            Shoe findedShoe = _ShoeContext.Shoes.Find(id);
            _ShoeContext.Shoes.Remove(findedShoe);
            _ShoeContext.SaveChanges();
        }
            
           
        
    }
}
