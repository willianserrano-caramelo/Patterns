using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class EditFileCommand : ICommand
    {
        private readonly FileReceiver _receiver;
        private readonly string _filePath;
        private readonly string _newContent;
        private string _previousContent;

        public EditFileCommand(FileReceiver receiver, string filePath, string newContent)
        {
            _receiver = receiver;
            _filePath = filePath;
            _newContent = newContent;
        }

        public void Execute()
        {
            _previousContent = File.Exists(_filePath) ? File.ReadAllText(_filePath) : string.Empty;
            _receiver.EditFile(_filePath, _newContent);
        }

        public void Undo()
        {
            if (_previousContent != null)
                _receiver.EditFile(_filePath, _previousContent);
        }
    }
}
