using FiapSmartCityWebAPI.Models;
using FiapSmartCityWebAPI.Repository.Context;



namespace FiapSmartCityWebAPI.Repository
{
    public class AnimalRepository
    {
        public readonly DataBaseContext context;
        public AnimalRepository()
        {
            context = new DataBaseContext();
        }
        public IList<Animal> Listar()
        {
            return context.Animal.ToList();
        }
        public void Create(Animal animal)
        {
            context.Animal.Add(animal);
            context.SaveChanges();
        }
        public void Edit(Animal animal)
        {
            context.Animal.Update(animal);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var animal = new Animal()
            {
                IdAnimal = id
            };
            context.Animal.Remove(animal);
            context.SaveChanges();
        }
    }
}
