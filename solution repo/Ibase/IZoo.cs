using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_repo.Ibase
{
    internal interface IZoo
    {
        public string getCage(string cage);
        public string getAnimal(string animal);
        public List<String> getFood();
    }
}
