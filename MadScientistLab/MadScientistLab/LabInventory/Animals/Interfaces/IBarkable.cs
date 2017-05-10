using MadScientistLab.Cli;

namespace MadScientistLab.LabInventory.Animals.Interfaces
{
    public interface IBarkable
    {
        void Bark(ICommandInterface cli);
    }
}
