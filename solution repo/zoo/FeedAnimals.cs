using solution_repo.Animals.Elephant;
using solution_repo.Animals.Lion;
using solution_repo.Animals.Tiger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_repo.zoo
{
    public class FeedAnimals
    {
        TigerCage tiger;
        LionCage lion;
        ElephantCage elephant;
        //Tiger and Lion both can eat each other's food but none can eat elaphants food 
        public FeedAnimals(TigerCage tiger, LionCage lion, ElephantCage elephant)
        {
            this.lion = lion;
            this.tiger = tiger;
            this.elephant = elephant;
        }
        public List<string> FeedAllAnimals()
        {
            List <string> foodlist = new List<string>();
            foodlist.AddRange(tiger.getFood());
            foodlist.AddRange(lion.getFood());
            foodlist.AddRange(elephant.getFood());
            return foodlist;

        }
        public List<string> cageAllAnimals(string animal1, string animal2, string animal3)
        {
            List<string> cagelist = new List<string>();
            cagelist.Add(tiger.getCage(animal1));
            cagelist.Add(lion.getCage(animal2));
            cagelist.Add(elephant.getCage(animal3));
            return cagelist;

        }

    }
}
