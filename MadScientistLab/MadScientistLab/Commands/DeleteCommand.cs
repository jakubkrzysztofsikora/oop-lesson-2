using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using System.Collections.Generic;
using System;

namespace MadScientistLab.Commands
{
    class DeleteCommand : ILaboratoryCommand
    {
        Animal _animalToBeRemoved;
        List<Animal> _aniList;
        private readonly ICommandInterface _cli;
        public DeleteCommand(Animal ani, List<Animal> animalList, ICommandInterface cli)
        {
            _animalToBeRemoved = ani;
            _aniList = animalList;
            _cli = cli;
        }
        public void Execute()
        {
            _aniList.Remove(_animalToBeRemoved);
            _cli.DisplayInfo($"Removed {_animalToBeRemoved.Name} from the lab");
        }
    }
}
