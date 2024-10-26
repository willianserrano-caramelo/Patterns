using Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern.Commands
{
    public class DeleteRecordCommand : ICommand
    {
        private readonly DatabaseReceiver _receiver;
        private readonly int _id;
        private string _backupData;

        public DeleteRecordCommand(DatabaseReceiver receiver, int id)
        {
            _receiver = receiver;
            _id = id;
        }

        public void Execute()
        {
            _backupData = _receiver.ReadRecord(_id);
            _receiver.DeleteRecord(_id);
        }

        public void Undo()
        {
            if (_backupData != null)
                _receiver.CreateRecord(_id, _backupData);
        }
    }
}
