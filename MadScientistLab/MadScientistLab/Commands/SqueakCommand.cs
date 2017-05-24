using MadScientistLab.Cli;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;
using MadScientistLab.LabInventory.Machines;

namespace MadScientistLab.Commands
{
    class SqueakCommand : ILaboratoryCommand
    {
        private Animal _animalToSqueak;
        private readonly ICommandInterface _cli;
        BigMachine _bigMachine;

        public SqueakCommand(Animal ani, ICommandInterface cli, BigMachine bigM)
        {
            _animalToSqueak = ani;
            _cli = cli;
            _bigMachine = bigM;
        }
        public void Execute()
        {
            if (_animalToSqueak is ISqueakable)
            {
                _bigMachine.MakeNoise(_animalToSqueak);
            }
            else
            {
                _cli.DisplayError($"{_animalToSqueak.Name} can't squeak.");
            }
        }
    }
    
}
