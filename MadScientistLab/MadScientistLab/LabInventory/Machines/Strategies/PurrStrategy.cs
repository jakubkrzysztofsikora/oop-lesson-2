using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines.Strategies
{
    public class PurrStrategy : ISoundStrategy
    {
        private readonly ICommandInterface _cli;

        public PurrStrategy(ICommandInterface cli)
        {
            _cli = cli;
        }

        public void MakeNoise(Animal animal)
        {
            (animal as IPurrable)?.Purr(_cli);
        }
    }
}