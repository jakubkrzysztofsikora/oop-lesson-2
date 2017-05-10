using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines
{
    public class Purrer
    {
        private readonly ICommandInterface _cli;

        public Purrer(ICommandInterface cli)
        {
            _cli = cli;
        }

        public void Execute(IPurrable animal)
        {
            animal.Purr(_cli);
        }
    }
}
