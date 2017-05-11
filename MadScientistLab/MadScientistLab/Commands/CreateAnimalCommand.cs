using System;
using System.Collections.Generic;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;

namespace MadScientistLab.Commands
{
    public class CreateAnimalCommand : ILaboratoryCommand
    {
        private readonly List<Animal> _animals;
        private readonly AnimalTypeEnum _animalType;
        private readonly string _name;

        public CreateAnimalCommand(List<Animal> animals, AnimalTypeEnum animalType, string name)
        {
            _animals = animals;
            _animalType = animalType;
            _name = name;
        }

        public void Execute()
        {
            switch (_animalType)
            {
                case AnimalTypeEnum.Cat:
                    _animals.Add(new Cat(_name));
                    break;
                case AnimalTypeEnum.Lion:
                    _animals.Add(new Lion(_name));
                    break;
                case AnimalTypeEnum.Dog:
                    _animals.Add(new Dog(_name));
                    break;
                case AnimalTypeEnum.Wolf:
                    _animals.Add(new Wolf(_name));
                    break;
                case AnimalTypeEnum.Mouse:
                    _animals.Add(new Mouse(_name));
                    break;
                case AnimalTypeEnum.Rat:
                    _animals.Add(new Rat(_name));
                    break;
                case AnimalTypeEnum.Tiger:
                    _animals.Add(new Tiger(_name));
                    break;
                case AnimalTypeEnum.Coyote:
                    _animals.Add(new Coyote(_name));
                    break;
                case AnimalTypeEnum.Hamster:
                    _animals.Add(new Hamster(_name));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
