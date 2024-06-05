using solution_repo.Ibase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_repo.Animals.Elephant
{
    internal class ElephantCage : IZoo
    {
        public string getAnimal(string animal)
        {
           return animal+" and it's Cub";
        }

        public string getCage(string cage)
        {
            return cage;
        }

        public List<string> getFood()
        {
            List<string> values = new List<string>();
            values.Add("Vegetables");
            values.Add("Leaves");
            return values;
        }
    }
}
