using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class DeleteFileCommand : ICommand
    {
        private readonly FileReceiver _receiver;
        private readonly string _filePath;
        private string _backupContent;

        public DeleteFileCommand(FileReceiver receiver, string filePath)
        {
            _receiver = receiver;
            _filePath = filePath;
        }

        public void Execute()
        {
            if (File.Exists(_filePath))
            {
                _backupContent = File.ReadAllText(_filePath);
                _receiver.DeleteFile(_filePath);
            }
        }

        public void Undo()
        {
            if (_backupContent != null)
                _receiver.RecoverFile(_filePath, _backupContent);
        }
    }
}
