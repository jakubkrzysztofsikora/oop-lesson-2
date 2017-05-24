using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;
using MadScientistLab.LabInventory.Machines;

namespace MadScientistLab.Commands
{
    class BarkCommand : ILaboratoryCommand
    {
        private Animal _animalToBark;
        private readonly ICommandInterface _cli;
        BigMachine _bigMachine;

        public BarkCommand(Animal ani, ICommandInterface cli, BigMachine bigM)
        {
            _animalToBark = ani;
            _cli = cli;
            _bigMachine = bigM;
        }

        public void Execute()
        {
            if (_animalToBark is IBarkable)
            {
                _bigMachine.MakeNoise(_animalToBark);
            }
            else
            {
                _cli.DisplayError($"{_animalToBark.Name} can't bark.");
            }
        }
    }
}
