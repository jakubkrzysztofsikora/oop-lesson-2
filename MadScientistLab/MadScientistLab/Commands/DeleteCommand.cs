using System;
using System.Collections.Generic;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    public class DeleteCommand : ILaboratoryCommand
    {
        private readonly List<Animal> _animals;
        private readonly string _name;

        public DeleteCommand(List<Animal> animals, string name)
        {
            _animals = animals;
            _name = name;
        }

        public void Execute()
        {
            _animals.RemoveAll(Animal => Animal.Name == _name);
        }
    }
}