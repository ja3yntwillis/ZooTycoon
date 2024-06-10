using solution_repo.Ibase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_repo.Animals.Lion
{
    public class LionCage : IZoo
    {
        public string getAnimal(string animal)
        {
            return animal + " and it's Cub";
        }

        public string getCage(string cage)
        {
            return cage;
        }

        public List<string> getFood()
        {
            List<string> values = new List<string>();
            values.Add("Deer Meat");
            values.Add("Goat Meat");
            return values;
        }
    }
}
