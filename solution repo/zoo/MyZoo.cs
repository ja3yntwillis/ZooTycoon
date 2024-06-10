using solution_repo.Animals.Elephant;
using solution_repo.Animals.Lion;
using solution_repo.Animals.Tiger;
using solution_repo.Ibase;
using System.Collections.Generic;

namespace solution_repo.zoo
{
    public class MyZoo
    {
        IZoo eleObj;
        IZoo lionCage;
        IZoo tigerCage;

        public MyZoo(IZoo eleObj, IZoo lionCage, IZoo tigerCage)
        {
            this.eleObj = eleObj;
            this.lionCage = lionCage;
            this.tigerCage = tigerCage;   
        }

        public Dictionary<string, string> MyZooTycoon()
        {
            List<string> zooAnimals = new List<string>();
            zooAnimals.Add(eleObj.getAnimal("elephant"));
            zooAnimals.Add(lionCage.getAnimal("lion"));
            zooAnimals.Add(tigerCage.getAnimal("tiger"));

            List<string> zooCages = new List<string>();
            zooCages.Add(eleObj.getCage("elephant"));
            zooCages.Add(lionCage.getCage("lion"));
            zooCages.Add(tigerCage.getCage("tiger"));

            List<List<string>> zooFood = new List<List<string>>();
            zooFood.Add(eleObj.getFood());
            zooFood.Add(lionCage.getFood());
            zooFood.Add(tigerCage.getFood());

            Dictionary<string, string> ZooDict = new Dictionary<string, string>();
            ZooDict.Add("Animal1", zooAnimals[0]);
            ZooDict.Add("Animal2", zooAnimals[1]);
            ZooDict.Add("Animal3", zooAnimals[2]);

            ZooDict.Add("CageForAnimal1", zooCages[0]);
            ZooDict.Add("CageForAnimal2", zooCages[1]);
            ZooDict.Add("CageForAnimal3", zooCages[2]);

            ZooDict.Add("FoodForAnimal1", zooFood[0][0]);
            ZooDict.Add("FoodForAnimal2", zooFood[1][1]);
            ZooDict.Add("FoodForAnimal3", zooFood[2][2]);

            return ZooDict;
        }
    }
}
