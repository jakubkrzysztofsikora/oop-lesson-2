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

        public Laboratory(ICommandInterface cli)
        {
            _cli = cli;
            _animals = new List<Animal>();
            _bigMachine = new BigMachine(cli);
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
            var animal = GetAnimalByName(name);
            new GoToSleepCommand(animal,_cli).Execute();
        }

        public void GoEat(string name)
        {
            if (!ValidateExistenceOfAnimal(name))
            {
                _cli.DisplayError($"{name} doesn't exist.");
                return;
            }
            var animal = GetAnimalByName(name);
            new GoToEatCommand(animal, _cli).Execute();
        }

        public void Barker(string name)
        {
            var animal = GetAnimalByName(name);
            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }
            new BarkCommand(animal, _cli, _bigMachine).Execute();
        }

        public void Purrer(string name)
        {
            var animal = GetAnimalByName(name);
            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }
            new PurrCommand(animal, _cli, _bigMachine).Execute();
        }

        public void Squeaker(string name)
        {
            var animal = GetAnimalByName(name);
            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }
           new SqueakCommand(animal, _cli, _bigMachine).Execute();
        }

        public void ListAnimals()
        {
            new ListCommand(_animals, _cli).Execute();
        }

        public void Delete(string nameOfAnimal)
        {
            if (!ValidateExistenceOfAnimal(nameOfAnimal))
            {
                _cli.DisplayError($"{nameOfAnimal} doesn't exist.");
                return;
            }
            Animal aniToRemove = GetAnimalByName(nameOfAnimal);
            new DeleteCommand(aniToRemove, _animals, _cli).Execute();
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
