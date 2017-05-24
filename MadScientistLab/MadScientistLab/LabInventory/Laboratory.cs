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
        //private readonly Purrer _purrer;
        //private readonly Squeaker _squeaker;

        public Laboratory(ICommandInterface cli)
        {
            _cli = cli;
            _animals = new List<Animal>();
            _bigMachine = new BigMachine(cli);
            //_purrer = new Purrer(_cli);
            //_squeaker = new Squeaker(_cli);
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
            animal.GoSleep();
            _cli.DisplayInfo($"{animal.Name} is well rested.");
        }

        public void GoEat(string name)
        {
            if (!ValidateExistenceOfAnimal(name))
            {
                _cli.DisplayError($"{name} doesn't exist.");
                return;
            }

            var animal = GetAnimalByName(name);
            animal.Eat();
            _cli.DisplayInfo($"{animal.Name} is well fed.");
        }

        public void Barker(string name)
        {
            var animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            if (animal is IBarkable)
            {
                _bigMachine.MakeNoise(animal);
            }
            else
            {
                _cli.DisplayError($"{name} can't bark.");
            }
        }

        public void Purrer(string name)
        {
            var animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            if (animal is IPurrable)
            {
                //_purrer.Execute(animal as IPurrable);
                _bigMachine.MakeNoise(animal);
                //animal.Fed = false;
                //animal.Rested = false;
            }
            else
            {
                _cli.DisplayError($"{name} can't purr.");
            }
        }

        public void Squeaker(string name)
        {
            var animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            if (animal is ISqueakable)
            {
                //_squeaker.Execute(animal as ISqueakable);
                _bigMachine.MakeNoise(animal);
                //animal.Fed = false;
                //animal.Rested = false;
            }
            else
            {
                _cli.DisplayError($"{name} can't squeak.");
            }
        }

        public void ListAnimals()
        {
            foreach (var animal in _animals)
            {
                _cli.DisplayInfo($"{animal.Type} - {animal.Name}");
            }
        }

        public void Delete(string nameOfAnimal)
        {
            _animals.Remove(GetAnimalByName(nameOfAnimal));
            _cli.DisplayInfo($"Removed {nameOfAnimal} from the lab");
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
