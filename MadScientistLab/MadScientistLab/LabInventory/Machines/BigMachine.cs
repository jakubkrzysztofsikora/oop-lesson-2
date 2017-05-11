using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Machines.Strategies;

namespace MadScientistLab.LabInventory.Machines
{
    public class BigMachine
    {
        private readonly ICommandInterface _cli;
        private ISoundStrategy _soundStrategy;
        private readonly StrategyMaker _strategyMaker;

        public BigMachine(ICommandInterface cli)
        {
            _cli = cli;
            _strategyMaker = new StrategyMaker(_cli);
        }

        public void MakeNoise(Animal animal)
        {
            ChangeStrategy(animal);
            _soundStrategy.MakeNoise(animal);
            animal.Fed = false;
            animal.Rested = false;
        }

        private void ChangeStrategy(Animal animal)
        {
            _soundStrategy = _strategyMaker.CreateStrategyFor(animal);
        }
    }
}
