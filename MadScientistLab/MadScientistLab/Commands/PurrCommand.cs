using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;
using MadScientistLab.LabInventory.Machines;

namespace MadScientistLab.Commands
{
    class PurrCommand : ILaboratoryCommand
    {
        private Animal _animalToPurr;
        private readonly ICommandInterface _cli;
        BigMachine _bigMachine;

        public PurrCommand(Animal ani, ICommandInterface cli, BigMachine bigM)
        {
            _animalToPurr = ani;
            _cli = cli;
            _bigMachine = bigM;
        }
    public void Execute()
        {
            if (_animalToPurr is IPurrable)
            {
                _bigMachine.MakeNoise(_animalToPurr);
            }
            else
            {
                _cli.DisplayError($"{_animalToPurr.Name} can't purr.");
            }
        }
    }
}
