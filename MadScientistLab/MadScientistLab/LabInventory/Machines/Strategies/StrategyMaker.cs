using System;
using System.Collections.Generic;
using System.Linq;
using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines.Strategies
{
    public class StrategyMaker
    {
        private readonly Dictionary<Type, ISoundStrategy> _typeToStrategy;

        public StrategyMaker(ICommandInterface cli)
        {
            var barkStrategy = new BarkStrategy(cli);

            _typeToStrategy = new Dictionary<Type, ISoundStrategy>()
            {
                { typeof(IBarkable), barkStrategy }
            };
        }

        public ISoundStrategy CreateStrategyFor(Animal animal)
        {
            return _typeToStrategy[animal.GetType().GetInterfaces().First()];
        }
    }
}
