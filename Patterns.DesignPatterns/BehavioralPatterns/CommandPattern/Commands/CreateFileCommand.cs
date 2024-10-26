using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class CreateFileCommand : ICommand
    {
        private readonly FileReceiver _receiver;
        private readonly string _filePath;

        public CreateFileCommand(FileReceiver receiver, string filePath)
        {
            _receiver = receiver;
            _filePath = filePath;
        }

        public void Execute() => _receiver.CreateFile(_filePath);

        public void Undo() => _receiver.DeleteFile(_filePath);
    }
}
