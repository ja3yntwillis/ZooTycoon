using solution_repo.Animals.Elephant;
using solution_repo.Animals.Lion;
using solution_repo.Animals.Tiger;
using solution_repo.zoo;

MyZoo myZoo = new MyZoo(new ElephantCage(),new LionCage(),new TigerCage());
myZoo.MyZooTycoon();
var a= new FeedAnimals(new TigerCage(), new LionCage(), new ElephantCage()).FeedAllAnimals();