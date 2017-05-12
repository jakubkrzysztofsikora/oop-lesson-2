using System;
using System.Collections.Generic;
using System.Linq;
using MadScientistLab.Cli;
using MadScientistLab.Commands;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;
using MadScientistLab.LabInventory.Machines;

namespace MadScientistLab.LabInventory
{
    public class Laboratory
    {
        private readonly List<Animal> _animals;
        private readonly ICommandInterface _cli;
        private readonly BigMachine _bigMachine;
        private readonly Purrer _purrer;
        private readonly Squeaker _squeaker;

        public Laboratory(ICommandInterface cli)
        {
            _cli = cli;
            _animals = new List<Animal>();
            _bigMachine = new BigMachine(cli);
            _purrer = new Purrer(_cli);
            _squeaker = new Squeaker(_cli);
        }

        public void Create(AnimalTypeEnum animalType, string name)
        {
            new CreateAnimalCommand(_animals, animalType, name).Execute();
            
            _cli.DisplayInfo($"Created {animalType} with name {name}.");
        }

        public void GoToSleep(string name)
        {
            if (!ValidateExistenceOfAnimal(name))
            {
                _cli.DisplayError($"{name} doesn't exist.");
                return;
            }

            new GoSleepCommand(_animals, name).Execute();
            _cli.DisplayInfo($"{name} is well rested.");
        }

        public void GoEat(string name)
        {
            if (!ValidateExistenceOfAnimal(name))
            {
                _cli.DisplayError($"{name} doesn't exist.");
                return;
            }

            new EatCommand(_animals, name).Execute();
            _cli.DisplayInfo($"{name} is well fed.");
        }

        public void MakeSound(string name)
        {
            var animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            new MakeSoundCommand(_bigMachine, _animals, name).Execute();
        }

        public void ListAnimals()
        {
            foreach (var animal in _animals)
            {
                _cli.DisplayInfo($"{animal.Type} - {animal.Name}");
            }
        }

        public void Delete(string name)
        {
            new DeleteCommand(_animals, name).Execute();   
            _cli.DisplayInfo($"Removed {name} from the lab");
        }

        private bool ValidateExistenceOfAnimal(string name)
        {
            return _animals.Any(GetAnimalByNamePredicate(name));
        }

        private Animal GetAnimalByName(string name)
        {
            return _animals.SingleOrDefault(GetAnimalByNamePredicate(name));
        }

        private bool IsAnimalReadyForMachine(Animal animal)
        {
            return animal.Fed && animal.Rested;
        }

        private Func<Animal, bool> GetAnimalByNamePredicate(string nameOfAnimal)
        {
            return animal => animal.Name.Equals(nameOfAnimal);
        }
    }
}
