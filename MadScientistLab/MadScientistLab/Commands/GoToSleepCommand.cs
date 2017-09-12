using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    public class GoToSleepCommand : ILaboratoryCommand
    {
        private readonly string _animalName;
        private readonly Func<string, bool> _validateExistenceOfAnimal;
        private readonly Func<string, Animal> _getAnimalByName;
        private readonly ICommandInterface _cli;

        public GoToSleepCommand(string animalName, Func<string, bool> validateExistenceOfAnimal, Func<string, Animal> getAnimalByName, ICommandInterface cli)
        {
            _animalName = animalName;
            _validateExistenceOfAnimal = validateExistenceOfAnimal;
            _getAnimalByName = getAnimalByName;
            _cli = cli;
        }

        public void Execute()
        {
            if (!_validateExistenceOfAnimal(_animalName))
            {
                _cli.DisplayError($"{_animalName} doesn't exist.");
            }

            var animal = _getAnimalByName(_animalName);
        }
    }
}
