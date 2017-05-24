using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    class GoToSleepCommand : ILaboratoryCommand
    {
        private Animal _animalToSleep;
        private readonly ICommandInterface _cli;

        public GoToSleepCommand(Animal animal, ICommandInterface cli)
        {
            _animalToSleep = animal;
            _cli = cli;
        }

        public void Execute()
        {
            _animalToSleep.GoSleep();
            _cli.DisplayInfo($"{_animalToSleep.Name} is well rested.");
        }
    }
}
