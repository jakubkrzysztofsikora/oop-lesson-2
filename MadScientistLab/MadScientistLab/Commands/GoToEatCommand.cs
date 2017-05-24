using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    class GoToEatCommand : ILaboratoryCommand
    {
        private Animal _animalToEat;
        private readonly ICommandInterface _cli;

        public GoToEatCommand(Animal animal, ICommandInterface cli)
        {
            _animalToEat = animal;
            _cli = cli;
        }
        public void Execute()
        {
            _animalToEat.Eat();
            _cli.DisplayInfo($"{_animalToEat.Name} is well fed.");
        }
    }
    
}
