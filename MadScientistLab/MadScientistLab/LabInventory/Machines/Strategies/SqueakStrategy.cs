using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines.Strategies
{
    public class SqueakStrategy : ISoundStrategy
    {
        private readonly ICommandInterface _cli;

        public SqueakStrategy(ICommandInterface cli)
        {
            _cli = cli;
        }

        public void MakeNoise(Animal animal)
        {
            (animal as ISqueakable)?.Squeak(_cli);
        }
    }
}