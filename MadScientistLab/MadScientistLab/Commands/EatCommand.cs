using System;
using System.Collections.Generic;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    public class EatCommand : ILaboratoryCommand
    {
        private readonly List<Animal> _animals;
        private readonly string _name;

        public EatCommand(List<Animal> animals, string name)
        {
            _animals = animals;
            _name = name;
        }

        public void Execute()
        {
            _animals.Find(Animal => Animal.Name == _name).Fed = true;
        }
    }
}