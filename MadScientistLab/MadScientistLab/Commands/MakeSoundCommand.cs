using System;
using System.Collections.Generic;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Machines;

namespace MadScientistLab.Commands
{
    public class MakeSoundCommand : ILaboratoryCommand
    {
        private readonly List<Animal> _animals;
        private readonly string _name;
        private readonly BigMachine _bigMachine;

        public MakeSoundCommand(BigMachine bigMachine, List<Animal> animals, string name)
        {
            _bigMachine = bigMachine;
            _animals = animals;
            _name = name;
        }

        public void Execute()
        {
            _bigMachine.MakeNoise(_animals.Find(Animal => Animal.Name == _name));
        }
    }
}