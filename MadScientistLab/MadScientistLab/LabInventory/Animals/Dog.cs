using MadScientistLab.Cli;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Animals
{
    public class Dog : Animal, IBarkable
    {
        public Dog(string name) : base(name, AnimalTypeEnum.Dog)
        {
        }

        public void Bark(ICommandInterface cli)
        {
            cli.DisplayBark(Name);
        }
    }
}
