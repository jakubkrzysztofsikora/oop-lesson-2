using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using System.Collections.Generic;

namespace MadScientistLab.Commands
{
    class ListCommand : ILaboratoryCommand
    {
        List<Animal> _aniList;
        private readonly ICommandInterface _cli;

        public ListCommand(List<Animal> animalList, ICommandInterface cli)
        {
            _aniList = animalList;
            _cli = cli;
        }
        public void Execute()
        {
            foreach (var animal in _aniList)
            {
                _cli.DisplayInfo($"{animal.Type} - {animal.Name}");
            }
        }
    }
}
