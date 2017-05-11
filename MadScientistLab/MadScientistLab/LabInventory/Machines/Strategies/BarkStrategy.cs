using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines.Strategies
{
    public class BarkStrategy : ISoundStrategy
    {
        private readonly ICommandInterface _cli;

        public BarkStrategy(ICommandInterface cli)
        {
            _cli = cli;
        }

        public void MakeNoise(Animal animal)
        {
            (animal as IBarkable)?.Bark(_cli);
        }
    }
}
