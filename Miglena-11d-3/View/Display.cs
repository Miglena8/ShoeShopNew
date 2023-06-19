using Miglena_11d_3.Controller;
using Miglena_11d_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miglena_11d_3.View
{
    public class Display
    {
        private int closeOperationId = 6;
        private ShoeLogic shoeBusiness = new ShoeLogic();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            shoeBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Shoe shoe = shoeBusiness.Get(id);
            if (shoe!= null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + shoe.Opisanie);
                Console.WriteLine("Name: " + shoe.Marka);
                Console.WriteLine("Price: " + shoe.Price);
                Console.WriteLine("Stock: " + shoe.Nomer);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Shoe shoe = shoeBusiness.Get(id);
            if (shoe != null)
            {
                Console.WriteLine("Enter name: ");
                shoe.Nomer= double.Parse(Console.ReadLine());
                Console.WriteLine("Enter price: ");
                shoe.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter availability: ");
                shoe.Marka = (Console.ReadLine());
                shoeBusiness.Update(id,shoe);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Shoe shoe = new Shoe();
            Console.WriteLine("Enter Marka: ");
            shoe.Marka = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            shoe.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter nomer: ");
            shoe.Nomer = int.Parse(Console.ReadLine());
            shoeBusiness.Create(shoe);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Shoe" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var Shoe =shoeBusiness.GetAll();
            foreach (var item in Shoe)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Opisanie, item.Nomer, item.Price, item.Marka);
            }
        }

    }
}
