using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines
{
    public class Squeaker
    {
        private readonly ICommandInterface _cli;

        public Squeaker(ICommandInterface cli)
        {
            _cli = cli;
        }

        public void Execute(ISqueakable animal)
        {
            animal.Squeak(_cli);
        }
    }
}
