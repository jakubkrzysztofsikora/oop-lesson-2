using System.Collections.Generic;
using MadScientistLab.Cli;

namespace MadScientistLab.Tests.TestStubs
{
    public class StubCommandInterface : ICommandInterface
    {
        public List<string> InfoMessages { get; set; }
        public List<string> ErrorsMessages { get; set; }
        public List<string> BarksMessages { get; set; }
        public List<string> PurrsMessages { get; set; }
        public List<string> SqueaksMessages { get; set; }
   
        public StubCommandInterface()
        {
            InfoMessages = new List<string>();
            ErrorsMessages = new List<string>();
            BarksMessages = new List<string>();
            PurrsMessages = new List<string>();
            SqueaksMessages = new List<string>();
        }

        public void DisplayError(string message)
        {
            ErrorsMessages.Add(message);
        }

        public void DisplayInfo(string message)
        {
            InfoMessages.Add(message);
        }

        public void DisplayBark(string name)
        {
            BarksMessages.Add(name);
        }

        public void DisplayPurr(string name)
        {
            PurrsMessages.Add(name);
        }

        public void DisplaySqueak(string name)
        {
            SqueaksMessages.Add(name);
        }
    }
}
