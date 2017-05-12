using System;
using System.Collections.Generic;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    public class GoSleepCommand : ILaboratoryCommand
    {
        private readonly List<Animal> _animals;
        private readonly string _name;

        public GoSleepCommand(List<Animal> animals, string name)
        {
            _animals = animals;
            _name = name;
        }

        public void Execute()
        {
            _animals.Find(Animal => Animal.Name == _name).Rested = true;
        }
    }
}