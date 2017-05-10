using MadScientistLab.Enums;

namespace MadScientistLab.LabInventory.Animals
{
    public class Animal
    {
        public string Name { get; set; }
        public AnimalTypeEnum Type { get; set; }
        public bool Rested { get; set; }
        public bool Fed { get; set; }

        public Animal(string name, AnimalTypeEnum type)
        {
            Name = name;
            Type = type;
            Rested = false;
            Fed = false;
        }

        public void Eat()
        {
            Fed = true;
        }

        public void GoSleep()
        {
            Rested = true;
        }
    }
}
